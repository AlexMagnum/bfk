using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfk_pruyom.Forms
{
    public partial class AbiturientEditor : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;
        private int abiturientId;
        private bfk_pruyomEntities context;

        public AbiturientEditor(int abiturientId)
        {
            InitializeComponent();
            this.abiturientId = abiturientId;
            context = new bfk_pruyomEntities();
            DataLoad();
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

        private void sataButton2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void DataLoad()
        {

        }
    }
}
