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

                string[] Images = Directory.GetFiles(folderCannyRecog, "*.bmp");
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

            string[] Patterns = Directory.GetFiles(folderCannyRecog, "*.bmp");

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

            // statically defined for now
            double maxError = 5.3;
            neuralNetwork.MaximumError = maxError;
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
                picBox_output1.Image = new Bitmap(new Bitmap(folderCannyRecog + "\\" + MatchedHigh + ".bmp"),
                    picBox_output1.Width, picBox_output1.Height);
            }
                
            if (MatchedLow != "?")
            {
                // replaced textBoxTrainingBrowse.Text with folderProcessedSobel
                picBox_output2.Image = new Bitmap(new Bitmap(folderCannyRecog + "\\" + MatchedLow + ".bmp"),
                    picBox_output2.Width, picBox_output2.Height);
            }
        }

        private void cmd_stopTraining_Click(object sender, EventArgs e)
        {
            ManualReset.Set();
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
