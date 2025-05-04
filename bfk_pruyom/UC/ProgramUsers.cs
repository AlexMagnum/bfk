using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfk_pruyom.UC
{
    public partial class ProgramUsers : UserControl
    {
        private bfk_pruyomEntities context;

        public ProgramUsers()
        {
            InitializeComponent();
            context = new bfk_pruyomEntities();
            LoadData();
        }

        private void LoadData()
        {
            var pUsers = context.Pruyomusers.Select(s => new
            {
                Імя_користувача = s.username,
                Пароль = s.password,
                Реальне_імя = s.realname,
                Прізвище = s.realsurname,
                Посада = s.position
            }).ToList();

            dataGridView1.DataSource = pUsers;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["Імя_користувача"].MinimumWidth = 110;
            dataGridView1.Columns["Пароль"].MinimumWidth = 119;
            dataGridView1.Columns["Посада"].MinimumWidth = 150;
        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            string username = pusername.Texts.Trim();
            string password = userpassword.Texts.Trim();
            string realname = userRealName.Texts.Trim();
            string realsurname = userRealSurname.Texts.Trim();
            string pos = position.Texts.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) 
                || string.IsNullOrWhiteSpace(realname) || string.IsNullOrWhiteSpace(realsurname)
                || string.IsNullOrWhiteSpace(pos))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!", "Помилка вхідних даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (context.Pruyomusers.Any(u => u.username == username))
            {
                MessageBox.Show("Такий користувач вже існує!", "Помилка додавання до бази", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var encryptedPassword = CryptoHelper.Encrypt(password);

            var user = new Pruyomusers
            {
                username = username,
                password = encryptedPassword,
                realname = realname,
                realsurname = realsurname,
                position = pos
            };

            context.Pruyomusers.Add(user);
            context.SaveChanges();

            MessageBox.Show("Користувача успішно додано!", "Користувача додано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pusername.Texts = "";
            userpassword.Texts = "";
            userRealName.Texts = "";
            userRealSurname.Texts = "";
            position.Texts = "";
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                pusername.Texts = row.Cells["Імя_користувача"].Value?.ToString();
                userpassword.Texts = row.Cells["Пароль"].Value?.ToString();
                userRealName.Texts = row.Cells["Реальне_імя"].Value?.ToString();
                userRealSurname.Texts = row.Cells["Прізвище"].Value?.ToString();
                position.Texts = row.Cells["Посада"].Value?.ToString();
            }
        }

        private void enterVerify_Click(object sender, EventArgs e)
        {
            string username = pusername.Texts.Trim();
            string password = userpassword.Texts.Trim();
            string realname = userRealName.Texts.Trim();
            string realsurname = userRealSurname.Texts.Trim();
            string pos = position.Texts.Trim();

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Оберіть користувача для оновлення!", "Користувача не обрано");
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(realname) || string.IsNullOrWhiteSpace(realsurname)
                || string.IsNullOrWhiteSpace(pos))
            {
                MessageBox.Show("Будь ласка змініть або оновіть усі поля!", "Помилка вхідних даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string originalUserName = dataGridView1.CurrentRow.Cells["Імя_користувача"].Value.ToString();

                var programUser = context.Pruyomusers
                    .FirstOrDefault(s => s.username == originalUserName);

                if (programUser == null)
                {
                    MessageBox.Show("Не вдалося знайти користувача для оновлення!", "Користувача не знайдено");
                    return;
                }
            programUser.username = username;
            programUser.password = CryptoHelper.Encrypt(password);
            programUser.realname = realname;
            programUser.realsurname = realsurname;
            programUser.position = pos;
           
            context.SaveChanges();
            MessageBox.Show("Користувача оновлено успішно!", "Користувача оновлено");

            pusername.Texts = "";
            userpassword.Texts = "";
            userRealName.Texts = "";
            userRealSurname.Texts = "";
            position.Texts = "";
            LoadData();


        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Index < 0)
            {
                MessageBox.Show("Оберіть користувача для видалення!", "Користувача не обрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedName = dataGridView1.CurrentRow.Cells["Імя_користувача"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Ви дійсно бажаєте видалити користувача:\n\n{selectedName}?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var context = new bfk_pruyomEntities())
                {
                    var userToDelete = context.Pruyomusers
                        .FirstOrDefault(s => s.username == selectedName);

                    if (selectedName == null)
                    {
                        MessageBox.Show("Не вдалося знайти користувача у базі!", "Спеціальність не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    context.Pruyomusers.Remove(userToDelete);
                    context.SaveChanges();

                    MessageBox.Show("Користувача успішно видалено!", "Користувача видалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    pusername.Texts = "";
                    userpassword.Texts = "";
                    userRealName.Texts = "";
                    userRealSurname.Texts = "";
                    position.Texts = "";
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка під час видалення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
