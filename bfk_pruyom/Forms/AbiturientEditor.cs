using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            LoadCombobox();
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
            var abiturient = context.Abiturients.FirstOrDefault(a => a.id == abiturientId);

            sataTextBox1.Texts = abiturient.fullname;
            sataTextBox2.Texts = abiturient.address;
            sataTextBox3.Texts = abiturient.phone;
            sataTextBox4.Texts = abiturient.email;
            sataTextBox5.Texts = abiturient.study;
            sataTextBox6.Texts = abiturient.school;
            sataTextBox7.Texts = abiturient.fathername;
            sataTextBox8.Texts = abiturient.fatherphone;
            sataTextBox9.Texts = abiturient.mothername;
            sataTextBox10.Texts = abiturient.motherphone;
            sataTextBox11.Texts = abiturient.workgroup;
            if (abiturient.dormitory == "Так")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            string[] selectedItems = abiturient.information.Split(';', (char)StringSplitOptions.RemoveEmptyEntries);
            var cleanedSelectedItems = selectedItems.Select(s => Regex.Replace(s, @"\s+", " ").Trim()).ToList();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    string checkText = Regex.Replace(checkBox.Text, @"\s+", " ").Trim();
                    checkBox.Checked = cleanedSelectedItems.Contains(checkText);
                }
            }

            int[] specialties = new int[6];

            var applications = context.Applications.Include(a => a.Specialties).Where(a => a.abiturientid == abiturientId)
                .OrderBy(a => a.priority).ToList();

            for (int i = 0; i < applications.Count && i < specialties.Length; i++)
            {
                specialties[i] = applications[i].Specialties.id;
            }

            comboBox1.SelectedValue = specialties[0];

            if (specialties[1] != 0)
                comboBox2.SelectedValue = specialties[1];
            else
            {
                comboBox2.SelectedValue = 0;
            }
            if (specialties[2] != 0)
                comboBox3.SelectedValue = specialties[2];
            else
            {
                comboBox3.SelectedValue = 0;
            }
            if (specialties[3] != 0)
                comboBox4.SelectedValue = specialties[3];
            else
            {
                comboBox4.SelectedValue = 0;
            }
            if (specialties[4] != 0)
                comboBox5.SelectedValue = specialties[4];
            else
            {
                comboBox5.SelectedValue = 0;
            }
            if (specialties[5] != 0)
                comboBox6.SelectedValue = specialties[5];
            else
            {
                comboBox6.SelectedValue = 0;
            }
        }

        private void LoadCombobox()
        {
            var specialties = context.Specialties.OrderBy(s => s.name).ToList();
            var specialtiesForFirst = context.Specialties.OrderBy(s => s.name).ToList();
            specialties.Insert(0, new Specialties { id = 0, name = "Спеціальність не обрана" });

            comboBox1.DataSource = specialtiesForFirst;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = new List<Specialties>(specialties);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

            comboBox3.DataSource = new List<Specialties>(specialties);
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";

            comboBox4.DataSource = new List<Specialties>(specialties);
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "Id";

            comboBox5.DataSource = new List<Specialties>(specialties);
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "Id";

            comboBox6.DataSource = new List<Specialties>(specialties);
            comboBox6.DisplayMember = "Name";
            comboBox6.ValueMember = "Id";
        }

        private void enterVerify_Click(object sender, EventArgs e)
        {
            var abiturient = context.Abiturients.FirstOrDefault(a => a.id == abiturientId);

            var checkedBoxes = this.Controls.OfType<CheckBox>().Where(cb => cb.Checked)
                .Select(cb => Regex.Replace(cb.Text, @"\s+", " ").Trim());

            if (abiturient != null)
            {
                if (sataTextBox1.Texts == "" || sataTextBox2.Texts == "" || sataTextBox3.Texts == ""
                    || sataTextBox4.Texts == "" || sataTextBox5.Texts == "" || sataTextBox6.Texts == ""
                    || sataTextBox7.Texts == "" || sataTextBox8.Texts == "" || sataTextBox9.Texts == ""
                    || sataTextBox10.Texts == "" || sataTextBox11.Texts == "" || !checkedBoxes.Any())
                {
                    MessageBox.Show("Потрібно заповнити всі обов'язкові поля!", "Не заповнені обов'язкові значення",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    abiturient.fullname = sataTextBox1.Texts;
                    abiturient.address = sataTextBox2.Texts;
                    abiturient.phone = sataTextBox3.Texts;
                    abiturient.email = sataTextBox4.Texts;
                    abiturient.study = sataTextBox5.Texts;
                    abiturient.school = sataTextBox6.Texts;
                    abiturient.fathername = sataTextBox7.Texts;
                    abiturient.fatherphone = sataTextBox8.Texts;
                    abiturient.mothername = sataTextBox9.Texts;
                    abiturient.motherphone = sataTextBox10.Texts;
                    abiturient.workgroup = sataTextBox11.Texts;

                    var existingApps = context.Applications.Where(a => a.abiturientid == abiturientId).ToList();
                    context.Applications.RemoveRange(existingApps);
                    List<(int specialtyId, int priority)> updatedApplications = new List<(int specialtyId, int priority)>();

                    updatedApplications.Add(((int)comboBox1.SelectedValue, 1));
                    if(comboBox2.Text != "Спеціальність не обрана")
                        updatedApplications.Add(((int)comboBox2.SelectedValue, 2));
                    if (comboBox3.Text != "Спеціальність не обрана")
                        updatedApplications.Add(((int)comboBox3.SelectedValue, 3));
                    if (comboBox4.Text != "Спеціальність не обрана")
                        updatedApplications.Add(((int)comboBox4.SelectedValue, 4));
                    if (comboBox5.Text != "Спеціальність не обрана")
                        updatedApplications.Add(((int)comboBox5.SelectedValue, 5));
                    if (comboBox6.Text != "Спеціальність не обрана")
                        updatedApplications.Add(((int)comboBox6.SelectedValue, 6));

                    foreach (var app in updatedApplications)
                    {
                        context.Applications.Add(new Applications
                        {
                            abiturientid = abiturientId,
                            specialtyid = app.specialtyId,
                            priority = app.priority
                        });
                    }

                    string result = string.Join(";", checkedBoxes);
                    abiturient.information = result;

                    if (radioButton1.Checked == true)
                        abiturient.dormitory = "Так";
                    if (radioButton2.Checked == true)
                        abiturient.dormitory = "Ні";

                    context.SaveChanges();
                    MessageBox.Show("Дані абітурієнта успішнно оновлені!", "Операція успішна",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Абітурієнта не знайдено!", "Помилка оновлення",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            var abiturient = context.Abiturients.FirstOrDefault(a => a.id == abiturientId);

            if (abiturient != null)
            {
                context.Abiturients.Remove(abiturient);

                context.SaveChanges();
                MessageBox.Show("Абітурієнта успішно видалено з бази!", "Абітурієнта видалено",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Абітурієнта не знайдено!", "Помилка оновлення",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
