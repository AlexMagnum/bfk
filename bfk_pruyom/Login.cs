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

        private void enterVerify_Click(object sender, EventArgs e)
        {
            string username = userLogin.Texts.Trim();
            string password = userPassword.Texts.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка заповніть поля!", "Помилка вхідних даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new bfk_pruyomEntities())
            {
                var user = context.Pruyomusers.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    try
                    {
                        string decryptedPassword = CryptoHelper.Decrypt(user.password);
                        if (decryptedPassword == password)
                        {
                            Dashboard.realUserName = user.realsurname + " " + user.realname;
                            Dashboard.userRole = user.position;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Помилка при перевірці пароля", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                MessageBox.Show("Невірний логін або пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
