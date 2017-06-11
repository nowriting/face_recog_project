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
    public partial class f_settings : Form
    {
        public f_settings()
        {
            InitializeComponent();
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            f_main openWin = new f_main();
            openWin.Show();
            this.Close();
        }

        private void cmd_imgPro_Click(object sender, EventArgs e)
        {
            f_show_processing openWin = new f_show_processing();
            openWin.Show();
            this.Close();
        }

        private void cmd_toRecog_Click(object sender, EventArgs e)
        {
            f_results openWin = new f_results();
            openWin.Show();
            this.Close();
        }

        private void txtBox_maxError_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
