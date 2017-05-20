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
    public partial class f_main : Form
    {
        public f_main()
        {
            InitializeComponent();
        }

        private void b_take_photo_Click(object sender, EventArgs e)
        {
            f_open_camera openWin = new f_open_camera();
            openWin.Show();
            // Hides, not closes -> fix later
            this.Hide();

        }

        private void b_recognize_Click(object sender, EventArgs e)
        {
            f_results openWin = new f_results();
            openWin.Show();
            this.Hide();
        }

        private void b_settings_Click(object sender, EventArgs e)
        {
            f_settings openWin = new f_settings();
            openWin.Show();
            this.Hide();
        }

        private void b_open_resave_Click(object sender, EventArgs e)
        {
            f_open_resave openWin = new f_open_resave();
            openWin.Show();
            this.Hide();
        }

        private void cmd_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
