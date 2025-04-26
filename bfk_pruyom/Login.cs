using bfk_pruyom.Forms;
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

namespace bfk_pruyom
{
    public partial class Login : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;
        public Login()
        {
            InitializeComponent();
            Dashboard d = new Dashboard();
            d.Show();
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"..\..\Images\close_hover.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"..\..\Images\close.png");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
