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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
