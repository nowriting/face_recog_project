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
    public partial class f_open_resave : Form
    {
        Image Pic;

    public f_open_resave()
        {
            InitializeComponent();
    }

        private void cmd_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog browsefiles = new OpenFileDialog();
            browsefiles.Filter = "JPG(*.JPG)|*.jpg";

            if (browsefiles.ShowDialog() == DialogResult.OK)
            {
                Pic = Image.FromFile(browsefiles.FileName);
                box_openpic.Image = Pic;
            }
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog browsefiles = new SaveFileDialog();
            browsefiles.Filter = "JPG(*.JPG)|*.jpg";

            if (browsefiles.ShowDialog() == DialogResult.OK)
            {
                Pic.Save(browsefiles.FileName);
            }
        }
    }
}
