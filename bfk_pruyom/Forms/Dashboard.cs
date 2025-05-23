﻿using bfk_pruyom.UC;
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
        public static string userRole;
        public static string realUserName;

        public Dashboard()
        {
            InitializeComponent();
            label3.Text = realUserName;
            label4.Text = userRole;
            label2.Text = "";

            if(userRole != "Відповідальний секретар")
                sataButton4.Visible = false;
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

        private void sataButton1_Click(object sender, EventArgs e)
        {
            label2.Text = "Анкета абітурієнта";
            Anketa a = new Anketa();
            AddUserControl(a);
        }

        private void AddUserControl(Control c)
        {
            c.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(c);
        }

        private void sataButton3_Click(object sender, EventArgs e)
        {
            label2.Text = "Редактор спеціальностей";
            Specials s = new Specials();
            AddUserControl(s);
        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            label2.Text = "Редактор користувачів";
            ProgramUsers pu = new ProgramUsers();
            AddUserControl(pu);
        }
    }
}
