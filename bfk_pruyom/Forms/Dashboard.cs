using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfk_pruyom.Forms
{
    public partial class Dashboard : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        public Dashboard()
        {
            InitializeComponent();

        }
        

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    }
}
