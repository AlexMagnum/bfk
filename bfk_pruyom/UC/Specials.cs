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
    public partial class Specials : UserControl
    {
        private bfk_pruyomEntities context;

        public Specials()
        {
            InitializeComponent();
            context = new bfk_pruyomEntities();
            LoadData();
        }

        private void LoadData()
        {
            var specialties = context.Specialties.Select(s => new
                 {
                     Код = s.code,
                     Назва = s.name
                 }).ToList();

            dataGridView1.DataSource = specialties;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["Назва"].MinimumWidth = 197;
        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            string code = codeSpec.Texts.Trim();
            string name = nameSpec.Texts.Trim();

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!", "Помилка вхідних даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new bfk_pruyomEntities())
            {
                bool exists = context.Specialties
                    .Any(s => s.code == code && s.name == name);

                if (exists)
                {
                    MessageBox.Show("Така спеціальність вже існує!", "Помилка додавання до бази", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var newSpec = new Specialties
                {
                    code = code,
                    name = name
                };

                context.Specialties.Add(newSpec);
                context.SaveChanges();

                MessageBox.Show("Спеціальність успішно додана!", "Спеціальність додано", MessageBoxButtons.OK, MessageBoxIcon.Information);
                codeSpec.Texts = "";
                nameSpec.Texts = "";
                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                codeSpec.Texts = row.Cells["Код"].Value?.ToString();
                nameSpec.Texts = row.Cells["Назва"].Value?.ToString();
            }
        }

        private void enterVerify_Click(object sender, EventArgs e)
        {
            string code = codeSpec.Texts;
            string name = nameSpec.Texts;
            
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Оберіть спеціальність для оновлення!", "Спеціальність не обрано");
                return;
            }

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Будь ласка, змініть значення у полях!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            string originalCode = dataGridView1.CurrentRow.Cells["Код"].Value.ToString();
            string originalName = dataGridView1.CurrentRow.Cells["Назва"].Value.ToString();

            using (var context = new bfk_pruyomEntities())
            {
                var specialty = context.Specialties
                    .FirstOrDefault(s => s.code == originalCode && s.name == originalName);

                if (specialty == null)
                {
                    MessageBox.Show("Не вдалося знайти спеціальність для оновлення!", "Спеціальність не знайдено");
                    return;
                }

                specialty.code = code;
                specialty.name = name;

                context.SaveChanges();
                MessageBox.Show("Спеціальність оновлено успішно!", "Спеціальність оновлено");

                codeSpec.Texts = "";
                nameSpec.Texts = "";
                LoadData();
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Index < 0)
            {
                MessageBox.Show("Оберіть спеціальність для видалення!", "Спеціальність не обрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCode = dataGridView1.CurrentRow.Cells["Код"].Value?.ToString();
            string selectedName = dataGridView1.CurrentRow.Cells["Назва"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Ви дійсно бажаєте видалити спеціальність:\n\n{selectedCode} - {selectedName}?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var context = new bfk_pruyomEntities())
                {
                    var specToDelete = context.Specialties
                        .FirstOrDefault(s => s.code == selectedCode && s.name == selectedName);

                    if (specToDelete == null)
                    {
                        MessageBox.Show("Не вдалося знайти спеціальність у базі!", "Спеціальність не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    context.Specialties.Remove(specToDelete);
                    context.SaveChanges();

                    MessageBox.Show("Спеціальність успішно видалена!", "Спеціальність видалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    codeSpec.Texts = "";
                    nameSpec.Texts = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка під час видалення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
