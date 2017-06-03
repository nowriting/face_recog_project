using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salamander
{
    public partial class f_show_processing : Form
    {
        Image Pic;

        public f_show_processing()
        {
            InitializeComponent();
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            f_main openWin = new f_main();
            openWin.Show();
            this.Close();
        }

        private void cmd_goToANN_Click(object sender, EventArgs e)
        {
            f_results openWin = new f_results();
            openWin.Show();
            this.Close();
        }

        private void cmd_chooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog browsefiles = new OpenFileDialog();
            browsefiles.Filter = "JPG(*.JPG)|*.jpg";

            if (browsefiles.ShowDialog() == DialogResult.OK)
            {
                string imgName = browsefiles.FileName;
                txtBox_imgLocation.Text = imgName;
                Pic = Image.FromFile(browsefiles.FileName);
                picBox1.Image = Pic;
            }
           
        }
    }
}
