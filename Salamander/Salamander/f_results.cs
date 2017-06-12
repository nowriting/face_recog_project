using Salamander.ANN_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;

namespace Salamander
{
    public partial class f_results : Form
    {
        Image Pic;
        string chosenImg;
        string chosenImgResized = @"testImages/ShowFaces/main_resized.bmp";
        string folderProcessedSobel = @"testImages/ProcessedSobel/";
        string folderEasyRecog = @"testImages/ProcessedSmoothEasyRecog/";
        string folderCannyRecog = @"testImages/ProcessedCannyRecog/";
        string folderGenerated = @"testImages/GeneratedFaces/";
        string folderProcessed = @"testImages/ProcessedFaces/";
        string folderResized = @"testImages/ResizedFaces/";
        string folderUseThisFolder = @"testImages/ProcessedSmoothEasyRecog/";

        Bitmap resizeMatchHigh;
        Bitmap resizeMatchLow;
        Bitmap showHighMatch;
        Bitmap showLowMatch;
        double ANNmaxError = 5.3;
        int maxHeight = 120;
        int maxWidth = 120;

        //Neural Network Object With Output Type String
        private NeuralNetwork<string> neuralNetwork = null;

        //Data Members Required For Neural Network
        private Dictionary<string, double[]> TrainingSet = null;
        private int av_ImageHeight = 0;
        private int av_ImageWidth = 0;
        private int NumOfPatterns = 0;

        //For Asynchronized Programming Instead of Handling Threads
        private delegate bool TrainingCallBack();
        private AsyncCallback asyCallBack = null;
        private IAsyncResult res = null;
        private ManualResetEvent ManualReset = null;

        private DateTime DTStart;

        public f_results()
        {
            InitializeComponent();
            InitializeSettings();

            GenerateTrainingSet();
            CreateNeuralNetwork();

            asyCallBack = new AsyncCallback(TrainingCompleted);
            ManualReset = new ManualResetEvent(false);

        }

        private void InitializeSettings()
        {
            txtBox_info.AppendText("Iestatījumi tiek iestatīti..");

            try
            {
                // NameValueCollection AppSettings = ConfigurationManager.AppSettings;

                // comboBoxLayers.SelectedIndex = (Int16.Parse(AppSettings["NumOfLayers"]) - 1);
                // textBoxTrainingBrowse.Text = Path.GetFullPath(AppSettings["PatternsDirectory"]);
                // textBoxMaxError.Text = AppSettings["MaxError"];

                string[] Images = Directory.GetFiles(folderUseThisFolder, "*.bmp");
                NumOfPatterns = Images.Length;

                av_ImageHeight = 0;
                av_ImageWidth = 0;

                foreach (string s in Images)
                {
                    Bitmap Temp = new Bitmap(s);
                    av_ImageHeight += Temp.Height;
                    av_ImageWidth += Temp.Width;
                    Temp.Dispose();
                }
                av_ImageHeight /= NumOfPatterns;
                av_ImageWidth /= NumOfPatterns;

                int networkInput = av_ImageHeight * av_ImageWidth;

                // textBoxInputUnit.Text = ((int)((double)(networkInput + NumOfPatterns) * .33)).ToString();
                // textBoxHiddenUnit.Text = ((int)((double)(networkInput + NumOfPatterns) * .11)).ToString();
                // textBoxOutputUnit.Text = NumOfPatterns.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda iestatījumos: " + ex.Message, "Kļūda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // textBoxState.AppendText("Done!\r\n");
        }

        private void GenerateTrainingSet()
        {
            txtBox_info.AppendText("Apmācības datu ģenerēšana..");

            string[] Patterns = Directory.GetFiles(folderUseThisFolder, "*.bmp");

            TrainingSet = new Dictionary<string, double[]>(Patterns.Length);
            foreach (string s in Patterns)
            {
                Bitmap Temp = new Bitmap(s);
                TrainingSet.Add(Path.GetFileNameWithoutExtension(s),
                    ImageProcessing.ToMatrix(Temp, av_ImageHeight, av_ImageWidth));
                Temp.Dispose();
            }

            txtBox_info.AppendText("Gatavs!\r\n");
        }

        private void CreateNeuralNetwork()
        {
            if (TrainingSet == null)
                throw new Exception("Unable to Create Neural Network As There is No Data to Train..");

            /*
            if (comboBoxLayers.SelectedIndex == 0)
            {

                neuralNetwork = new NeuralNetwork<string>
                    (new BP1Layer<string>(av_ImageHeight * av_ImageWidth, NumOfPatterns), TrainingSet);

            }
            else if (comboBoxLayers.SelectedIndex == 1)
            {
                int InputNum = Int16.Parse(textBoxInputUnit.Text);

                neuralNetwork = new NeuralNetwork<string>
                    (new BP2Layer<string>(av_ImageHeight * av_ImageWidth, InputNum, NumOfPatterns), TrainingSet);

            }
            else if (comboBoxLayers.SelectedIndex == 2)
            {
                int InputNum = Int16.Parse(textBoxInputUnit.Text);
                int HiddenNum = Int16.Parse(textBoxHiddenUnit.Text);

                neuralNetwork = new NeuralNetwork<string>
                    (new BP3Layer<string>(av_ImageHeight * av_ImageWidth, InputNum, HiddenNum, NumOfPatterns), TrainingSet);

            }
            */

            // JUST EXECUTING 3 LAYERS FROM START AND WITH STATIC VALUES
            // int InputNum = Int16.Parse(textBoxInputUnit.Text);
            // int HiddenNum = Int16.Parse(textBoxHiddenUnit.Text);
            int InputNum = 295;
            int HiddenNum = 98;
            
            neuralNetwork = new NeuralNetwork<string>
                (new BP3Layer<string>(av_ImageHeight * av_ImageWidth, InputNum, HiddenNum, NumOfPatterns), TrainingSet);


            neuralNetwork.IterationChanged +=
                new NeuralNetwork<string>.IterationChangedCallBack(neuralNetwork_IterationChanged);
      
            neuralNetwork.MaximumError = ANNmaxError;
        }

        public static void getMaxError(double maxError)
        {
            if ((maxError != 0) && (maxError > 0))
            {
               double ANNmaxError = maxError;
            }
        }

        void neuralNetwork_IterationChanged(object o, NeuralEventArgs args)
        {
            UpdateError(args.CurrentError);
            UpdateIteration(args.CurrentIteration);

            if (ManualReset.WaitOne(0, true))
                args.Stop = true;
        }

        private void TrainingCompleted(IAsyncResult result)
        {
            if (result.AsyncState is TrainingCallBack)
            {
                TrainingCallBack TR = (TrainingCallBack)result.AsyncState;

                bool isSuccess = TR.EndInvoke(res);
                if (isSuccess)
                    UpdateState("Apmācība veiksmīgi pabeigta. \r\n");
                else
                    UpdateState("Training Process is Aborted or Exceed Maximum Iteration\r\n");

                SetButtons(true);
                timer1.Stop();
            }
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            f_main openWin = new f_main();
            openWin.Show();
            this.Close();
        }

        private void cmd_saveNet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveNet = new SaveFileDialog();
            saveNet.Filter = "Network File(*.net)|*.net";

            if (saveNet.ShowDialog() == DialogResult.OK)
            {
                neuralNetwork.SaveNetwork(saveNet.FileName);
            }

            saveNet.Dispose();
        }

        private void cmd_loadNet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openNet = new OpenFileDialog();
            openNet.Filter = "Network File(*.net)|*.net";
            openNet.InitialDirectory = Application.StartupPath;

            if (openNet.ShowDialog() == DialogResult.OK)
            {
                neuralNetwork.LoadNetwork(openNet.FileName);
            }
            
            cmd_recognize.Enabled = true;
            cmd_saveNet.Enabled = true;

            openNet.Dispose();
        }

        private void cmd_trainNet_Click(object sender, EventArgs e)
        {
            UpdateState("Apmācības process sākts..\r\n");
            SetButtons(false);
            ManualReset.Reset();

            TrainingCallBack TR = new TrainingCallBack(neuralNetwork.Train);
            res = TR.BeginInvoke(asyCallBack, TR);
            DTStart = DateTime.Now;
            timer1.Start();
        }

        private void cmd_recognize_Click(object sender, EventArgs e)
        {
            string MatchedHigh = "?", MatchedLow = "?";
            double OutputValueHight = 0, OutputValueLow = 0;

            Bitmap imgToRecog = (Bitmap)picBox_input.Image;

            double[] input = ImageProcessing.ToMatrix(imgToRecog, av_ImageHeight, av_ImageWidth);

            neuralNetwork.Recognize(input, ref MatchedHigh, ref OutputValueHight, ref MatchedLow, ref OutputValueLow);

            ShowRecognitionResults(MatchedHigh, MatchedLow, OutputValueHight, OutputValueLow);
        }

        private void ShowRecognitionResults(string MatchedHigh, string MatchedLow, double OutputValueHight, double OutputValueLow)
        {
            lbl_match1.Text = "1. rez: " + MatchedHigh + " (%" + ((int)100 * OutputValueHight).ToString("##") + ")";
            lbl_match2.Text = "2. rez: " + MatchedLow + " (%" + ((int)100 * OutputValueLow).ToString("##") + ")";

            if (MatchedHigh != "?")
            {
                // replaced textBoxTrainingBrowse.Text with folderProcessedSobel
                // picBox_output1.Image = new Bitmap(new Bitmap(folderUseThisFolder + "\\" + MatchedHigh + ".bmp"),
                //    picBox_output1.Width, picBox_output1.Height);
                resizeMatchHigh = new Bitmap(folderUseThisFolder + "\\" + MatchedHigh + ".bmp");
                showHighMatch = resizeLarger(resizeMatchHigh);
                picBox_output1.Image = resizeMatchHigh;

            }
                
            if (MatchedLow != "?")
            {
                // replaced textBoxTrainingBrowse.Text with folderProcessedSobel
                //picBox_output2.Image = new Bitmap(new Bitmap(folderUseThisFolder + "\\" + MatchedLow + ".bmp"),
                //    picBox_output2.Width, picBox_output2.Height);
                resizeMatchLow = new Bitmap(folderUseThisFolder + "\\" + MatchedLow + ".bmp");
                showLowMatch = resizeLarger(resizeMatchLow);
                picBox_output2.Image = showLowMatch;
            }
        }

        private Bitmap resizeLarger(Bitmap resizeMatch)
        {
            double ratioX;
            double ratioY;
            double ratio;
            int newWidth;
            int newHeight;
            Bitmap resizedImg;

            // calculate img width/height ratio
            ratioX = (double)maxWidth / resizeMatch.Width;
            ratioY = (double)maxHeight / resizeMatch.Height;
            ratio = Math.Min(ratioX, ratioY);
            // calculate the new img size
            newWidth = (int)(resizeMatch.Width * ratio);
            newHeight = (int)(resizeMatch.Height * ratio);

            // draw empty bitmap where to store the image
            resizedImg = new Bitmap(newWidth, newHeight);

            Graphics g = Graphics.FromImage(resizedImg);
            // draw resized bitmap
            g.DrawImage(resizeMatch, 0, 0, newWidth, newHeight);
            
            return resizedImg;
        }

        private void cmd_stopTraining_Click(object sender, EventArgs e)
        {
            ManualReset.Set();

        }

        private void cmd_CleanLibrary_Click(object sender, EventArgs e)
        {

            //ManualReset.Set();

            //txtBox_info.Text = String.Empty;

            deleteGenerated(folderGenerated);
            deleteResized(folderResized);
            deleteProcessedSobel(folderProcessedSobel);
            deleteProcessedCannyRecog(folderCannyRecog);
            deleteProcessed(folderProcessed);
            deleteProcessedSmooth(folderEasyRecog);

        }

        private void deleteProcessedSmooth(string folderEasyRecog)
        {
            string folderToEmpty = folderEasyRecog;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void deleteProcessed(string folderProcessed)
        {
            string folderToEmpty = folderProcessed;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void deleteProcessedSobel(string folderProcessedSobel)
        {
            string folderToEmpty = folderProcessedSobel;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void deleteResized(string folderResized)
        {
            string folderToEmpty = folderResized;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void deleteGenerated(string folderGenerated)
        {
            string folderToEmpty = folderGenerated;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void deleteProcessedCannyRecog(string folderCannyRecog)
        {
            string folderToEmpty = folderCannyRecog;

            DirectoryInfo deleteAllInThisFolder = new DirectoryInfo(folderToEmpty);

            foreach (FileInfo file in deleteAllInThisFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in deleteAllInThisFolder.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        private void cmd_chooseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog browsefiles = new OpenFileDialog();
            browsefiles.Filter = "JPG(*.JPG)|*.jpg";

            if (browsefiles.ShowDialog() == DialogResult.OK)
            {
                chosenImg = browsefiles.FileName;
                showProcessProcessImg.processCropImg(chosenImg);

                Pic = Image.FromFile(chosenImgResized);
                picBox_input.Image = Pic;
            }
        }

        #region Methods To Invoke UI Components If Required
        private delegate void UpdateUI(object o);
        private void SetButtons(object o)
        {
            //if invoke is required for a control, sure, it is also required for others
            //then, it is not needed to check all controls
            if (cmd_stopTraining.InvokeRequired)
            {
                cmd_stopTraining.Invoke(new UpdateUI(SetButtons), o);
            }
            else
            {
                bool b = (bool)o;
                cmd_stopTraining.Enabled = !b;
                cmd_recognize.Enabled = b;
                cmd_trainNet.Enabled = b;
                cmd_loadNet.Enabled = b;
                cmd_saveNet.Enabled = b;
            }
        }

        private void UpdateState(object o)
        {
            if (txtBox_info.InvokeRequired)
            {
                txtBox_info.Invoke(new UpdateUI(UpdateState), o);
            }
            else
            {
                txtBox_info.AppendText((string)o);
            }
        }

        private void UpdateError(object o)
        {
            if (lbl_error.InvokeRequired)
            {
                lbl_error.Invoke(new UpdateUI(UpdateError), o);
            }
            else
            {
                lbl_error.Text = "Kļūdas lielums: " + ((double)o).ToString(".###");
            }
        }

        private void UpdateIteration(object o)
        {
            if (lbl_iteration.InvokeRequired)
            {
                lbl_iteration.Invoke(new UpdateUI(UpdateIteration), o);
            }
            else
            {
                lbl_iteration.Text = "Iterācija nr: " + ((int)o).ToString();
            }
        }

        #endregion

        private void radioButton_Sobel_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Canny.Checked = false;
            radioButton_grayscale.Checked = false;
            radioButton_Sobel.Checked = true;

            // folderUseThisFolder = folderProcessedSobel;

            // Program.Run();
            // ProcessGeneratedFaces.GetImg();
        }

        private void radioButton_Canny_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Sobel.Checked = false;
            radioButton_grayscale.Checked = false;
            radioButton_Canny.Checked = true;

            // folderUseThisFolder = folderCannyRecog;

            // Program.Run();
            // ProcessGeneratedFaces.GetImg();
        }

        private void radioButton_grayscale_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Sobel.Checked = false;
            radioButton_Canny.Checked = false;
            radioButton_grayscale.Checked = true;

            // folderUseThisFolder = folderEasyRecog;

            // Program.Run();
            // ProcessGeneratedFaces.GetImg();
        }
    }
}
