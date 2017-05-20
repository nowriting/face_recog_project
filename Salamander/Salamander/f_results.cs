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
    public partial class f_results : Form
    {
        public f_results()
        {
            InitializeComponent();
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            f_main openWin = new f_main();
            openWin.Show();
            this.Close();
        }
    }
}
