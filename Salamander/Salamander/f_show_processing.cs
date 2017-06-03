using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salamander
{
    public partial class f_show_processing : Form
    {
        Image Pic;
        string imgName;
        string proImg1 = @"testImages/ShowFaces/main_resized.bmp";
        string proImg2 = @"testImages/ShowFaces/pro0.bmp";
        string proImg3 = @"testImages/ShowFaces/pro1.bmp";
        string proImg4 = @"testImages/ShowFaces/pro2.bmp";
        string proImg5 = @"testImages/ShowFaces/pro3.bmp";
        string proImg6 = @"testImages/ShowFaces/pro4.bmp";
        string proImg7 = @"testImages/ShowFaces/pro5.bmp";
        string proImg8 = @"testImages/ShowFaces/pro6.bmp";
        

        public f_show_processing()
        {
            InitializeComponent();

            // initialize all descriptions to false 
            lbl_picBox1.Visible = false;
            lbl_picBox2.Visible = false;
            lbl_picBox3.Visible = false;
            lbl_picBox4.Visible = false;
            lbl_picBox5.Visible = false;
            lbl_picBox6.Visible = false;
            lbl_picBox7.Visible = false;
            lbl_picBox8.Visible = false;
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
                imgName = browsefiles.FileName;
                txtBox_imgLocation.Text = imgName;
            }
           
        }

        private void cmd_processImage_Click(object sender, EventArgs e)
        {
            showProcessProcessImg.processCropImg(imgName);

            Pic = Image.FromFile(proImg1);
            picBox1.Image = Pic;
            lbl_picBox1.Visible = true;

            Pic = Image.FromFile(proImg2);
            picBox2.Image = Pic;
            lbl_picBox2.Visible = true;

            Pic = Image.FromFile(proImg3);
            picBox3.Image = Pic;
            lbl_picBox3.Visible = true;

            Pic = Image.FromFile(proImg4);
            picBox4.Image = Pic;
            lbl_picBox4.Visible = true;

            Pic = Image.FromFile(proImg5);
            picBox5.Image = Pic;
            lbl_picBox5.Visible = true;

            Pic = Image.FromFile(proImg6);
            picBox6.Image = Pic;
            lbl_picBox6.Visible = true;

            Pic = Image.FromFile(proImg7);
            picBox7.Image = Pic;
            lbl_picBox7.Visible = true;

            Pic = Image.FromFile(proImg8);
            picBox8.Image = Pic;
            lbl_picBox8.Visible = true;

        }
        
    }
}
