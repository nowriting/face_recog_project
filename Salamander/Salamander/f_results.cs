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
            
            // buttonRecognize.Enabled = true;
            // buttonSave.Enabled = true;

            openNet.Dispose();
        }

        private void cmd_trainNet_Click(object sender, EventArgs e)
        {
            //UpdateState("Began Training Process..\r\n");
            //SetButtons(false);
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

            double[] input = ImageProcessing.ToMatrix(drawingPanel1.ImageOnPanel,
                av_ImageHeight, av_ImageWidth);

            neuralNetwork.Recognize(input, ref MatchedHigh, ref OutputValueHight,
                ref MatchedLow, ref OutputValueLow);

            ShowRecognitionResults(MatchedHigh, MatchedLow, OutputValueHight, OutputValueLow);
        }

        private void cmd_stopTraining_Click(object sender, EventArgs e)
        {
            ManualReset.Set();
        }

    }
}
