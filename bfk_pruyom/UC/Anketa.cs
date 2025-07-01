using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using Xceed.Words.NET;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Drawing.Printing;
using bfk_pruyom.Forms;

namespace bfk_pruyom.UC
{
    public partial class Anketa : UserControl
    {
        private bfk_pruyomEntities context;
        private string selectedFilePath;
        private BindingList<AbiturientSort> _data;
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;
        private bool _checkAll = false;
        private readonly Dictionary<string, string> specialtyShortNames = new Dictionary<string, string>
{
    { "Облік і оподаткування", "ОО" },
    { "Фінанси, банківська справа та фондовий ринок", "Ф" },
    { "Менеджмент", "М" },
    { "Маркетинг", "МД" },
    { "Екологія", "Е" },
    { "Комп'ютерні науки", "КН" },
    { "Геодезія та землеустрій", "ГЗ" },
    { "Агрономія", "А" },
    { "Лісове господарство", "Л" },
    { "Садово-паркове господарство", "СП" },
    { "Автомобільний транспорт", "АТ" },
    { "Харчові технології", "Х" },
    { "Комп'ютерна інженерія", "КІ" }
};

        public Anketa()
        {
            InitializeComponent();
            context = new bfk_pruyomEntities();
            LoadCharts();
            sataDateTimePicker1.Enabled = false;
            LoadData();
            ConfigureDataGridView();
            LoadSpecialties();
            sataToggle2.Checked = false;
        }

        private void enterVerify_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Завантажте файл .csv|*.csv";
                    openFileDialog.Title = "Оберіть файл для завантаження";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFilePath = openFileDialog.FileName;
                        sataProgressbar1.Value = 0;
                        backgroundWorker1.RunWorkerAsync(selectedFilePath);
                    }
                }
            }
        }

        private DateTime ConvertDate(string date)
        {
            int gmtIndex = date.IndexOf("GMT", StringComparison.OrdinalIgnoreCase);
            if (gmtIndex != -1)
            {
                date = date.Substring(0, gmtIndex).Trim();
            }

            date = date.Replace("дп", "AM").Replace("пп", "PM").Trim();

            DateTime parsedDate = DateTime.ParseExact(
                date,
                "yyyy/MM/dd h:mm:ss tt",
                CultureInfo.InvariantCulture
            );

            return parsedDate;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = (string)e.Argument;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                var records = new List<dynamic>();

                while (csv.Read())
                {
                    var row = new List<string>();
                    for (int i = 0; csv.TryGetField<string>(i, out var field); i++)
                    {
                        row.Add(field);
                    }
                    records.Add(row);
                }

                int total = records.Count;
                int counter = 0;

                foreach (var record in records)
                {
                    DateTime _date = ConvertDate(record[0]);
                    string _fullname = record[1];
                    string _address = record[2];
                    string _phone = record[3];
                    string _email = record[4];
                    string _study = record[5];
                    string _school = record[6];
                    string _fname = record[7];
                    string _fphone = record[8];
                    string _mname = record[9];
                    string _mphone = record[10];
                    string _spec1 = record[11];
                    string _spec2 = record[12];
                    string _spec3 = record[13];
                    string _spec4 = record[14];
                    string _spec5 = record[15];
                    string _spec6 = record[16];
                    string _group = record[17];
                    string _info = record[18];
                    string _house = record[19];

                    try
                    {
                        var existingAbiturient = context.Abiturients.FirstOrDefault(a => a.fullname == _fullname && a.phone == _phone);

                        if (existingAbiturient == null)
                        {
                            var newAbiturient = new Abiturients
                            {
                                fullname = _fullname,
                                address = _address,
                                phone = _phone,
                                email = _email,
                                study = _study,
                                school = _school,
                                fathername = _fname,
                                fatherphone = _fphone,
                                mothername = _mname,
                                motherphone = _mphone,
                                workgroup = _group,
                                information = _info,
                                dormitory = _house,
                                appdate = _date
                            };
                            context.Abiturients.Add(newAbiturient);
                            context.SaveChanges();

                            int lastId = newAbiturient.id;
                            List<string> specs = new List<string> { _spec1, _spec2, _spec3, _spec4, _spec5, _spec6 };
                            var specialtiesList = context.Specialties.ToList();

                            for (int i = 0; i < specs.Count; i++)
                            {
                                string specName = specs[i];
                                if (!string.IsNullOrWhiteSpace(specName))
                                {
                                    var spec = specialtiesList.FirstOrDefault(s => s.name == specName);
                                    if (spec != null)
                                    {
                                        var application = new Applications
                                        {
                                            abiturientid = lastId,
                                            specialtyid = spec.id,
                                            priority = i + 1
                                        };
                                        context.Applications.Add(application);
                                    }
                                }
                            }
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Помилка при оновленні бази: {ex.Message}", "Помилка оновлення");
                        return;
                    }

                    counter++;
                    int progressPercentage = counter * 100 / total;
                    backgroundWorker1.ReportProgress(progressPercentage);

                    Thread.Sleep(50);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sataProgressbar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMessage("Базу успішно оновлено!", "Оновлення");
            LoadCharts();
            LoadData();
        }

        private void ShowMessage(string message, string caption)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)));
            }
            else
            {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadCharts()
        {
            for (int i = 0; i < sataBarChart1.DataSets[0].Points.Length; i++)
            {
                sataBarChart1.DataSets[0].Points[i] = 0;
            }
            label2.Text = "ОО-0";
            label3.Text = "Ф-0";
            label4.Text = "М-0";
            label5.Text = "МД-0";
            label6.Text = "Е-0";
            label7.Text = "КН-0";
            label8.Text = "ГЗ-0";
            label9.Text = "А-0";
            label10.Text = "Л-0";
            label11.Text = "СП-0";
            label12.Text = "АТ-0";
            label13.Text = "КІ-0";
            label14.Text = "Х-0";

            List<Abiturients> abit = context.Abiturients.ToList();
            int maxValue = 0;
            label1.Text = "Всього анкет - " + abit.Count;

            var resultPriority = context.Applications.Where(x => x.priority == 1).GroupBy(x => x.specialtyid).Select(g => new
            {
                SpecialtyId = g.Key,
                AbiturientCount = g.Count()
            }).ToList();

            foreach (var item in resultPriority)
            {
                if (item.SpecialtyId == 1 && item.AbiturientCount > 0)
                {
                    label2.Text = "ОО-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[0] = item.AbiturientCount;
                    maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 2 && item.AbiturientCount > 0)
                {
                    label3.Text = "Ф-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[1] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 3 && item.AbiturientCount > 0)
                {
                    label4.Text = "М-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[2] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 4 && item.AbiturientCount > 0)
                {
                    label5.Text = "МД-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[3] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 5 && item.AbiturientCount > 0)
                {
                    label6.Text = "Е-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[4] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 6 && item.AbiturientCount > 0)
                {
                    label7.Text = "КН-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[5] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 7 && item.AbiturientCount > 0)
                {
                    label8.Text = "ГЗ-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[6] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 8 && item.AbiturientCount > 0)
                {
                    label9.Text = "А-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[7] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 9 && item.AbiturientCount > 0)
                {
                    label10.Text = "Л-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[8] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 10 && item.AbiturientCount > 0)
                {
                    label11.Text = "СП-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[9] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 11 && item.AbiturientCount > 0)
                {
                    label12.Text = "АТ-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[10] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 13 && item.AbiturientCount > 0)
                {
                    label13.Text = "КІ-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[11] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }

                if (item.SpecialtyId == 12 && item.AbiturientCount > 0)
                {
                    label14.Text = "Х-" + item.AbiturientCount;
                    sataBarChart1.DataSets[0].Points[12] = item.AbiturientCount;
                    if (item.AbiturientCount > maxValue)
                        maxValue = item.AbiturientCount;
                }
            }
            sataBarChart1.MaxValue = maxValue;

        }

        private void LoadChartsApp()
        {
            for (int i = 0; i < sataBarChart1.DataSets[0].Points.Length; i++)
            {
                sataBarChart1.DataSets[0].Points[i] = 0;
            }
            label2.Text = "ОО-0";
            label3.Text = "Ф-0";
            label4.Text = "М-0";
            label5.Text = "МД-0";
            label6.Text = "Е-0";
            label7.Text = "КН-0";
            label8.Text = "ГЗ-0";
            label9.Text = "А-0";
            label10.Text = "Л-0";
            label11.Text = "СП-0";
            label12.Text = "АТ-0";
            label13.Text = "КІ-0";
            label14.Text = "Х-0";

            var applicationsBySpecialty = context.Applications.GroupBy(a => a.specialtyid).Select(g => new
                {
                    SpecialtyId = g.Key,
                    Count = g.Count()
                }).ToList();
            int maxValue = 0;
            label1.Text = "Всього заяв - " + context.Applications.Count();


            foreach (var item in applicationsBySpecialty)
            {
                if (item.SpecialtyId == 1 && item.Count > 0)
                {
                    label2.Text = "ОО-" + item.Count;
                    sataBarChart1.DataSets[0].Points[0] = item.Count;
                    maxValue = item.Count;
                }

                if (item.SpecialtyId == 2 && item.Count > 0)
                {
                    label3.Text = "Ф-" + item.Count;
                    sataBarChart1.DataSets[0].Points[1] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 3 && item.Count > 0)
                {
                    label4.Text = "М-" + item.Count;
                    sataBarChart1.DataSets[0].Points[2] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 4 && item.Count > 0)
                {
                    label5.Text = "МД-" + item.Count;
                    sataBarChart1.DataSets[0].Points[3] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 5 && item.Count > 0)
                {
                    label6.Text = "Е-" + item.Count;
                    sataBarChart1.DataSets[0].Points[4] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 6 && item.Count > 0)
                {
                    label7.Text = "КН-" + item.Count;
                    sataBarChart1.DataSets[0].Points[5] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 7 && item.Count > 0)
                {
                    label8.Text = "ГЗ-" + item.Count;
                    sataBarChart1.DataSets[0].Points[6] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 8 && item.Count > 0)
                {
                    label9.Text = "А-" + item.Count;
                    sataBarChart1.DataSets[0].Points[7] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 9 && item.Count > 0)
                {
                    label10.Text = "Л-" + item.Count;
                    sataBarChart1.DataSets[0].Points[8] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 10 && item.Count > 0)
                {
                    label11.Text = "СП-" + item.Count;
                    sataBarChart1.DataSets[0].Points[9] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 11 && item.Count > 0)
                {
                    label12.Text = "АТ-" + item.Count;
                    sataBarChart1.DataSets[0].Points[10] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 13 && item.Count > 0)
                {
                    label13.Text = "КІ-" + item.Count;
                    sataBarChart1.DataSets[0].Points[11] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }

                if (item.SpecialtyId == 12 && item.Count > 0)
                {
                    label14.Text = "Х-" + item.Count;
                    sataBarChart1.DataSets[0].Points[12] = item.Count;
                    if (item.Count > maxValue)
                        maxValue = item.Count;
                }
            }
            sataBarChart1.MaxValue = maxValue;
        }

        private void sataToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (sataToggle1.Checked)
                sataDateTimePicker1.Enabled = true;
            else
                sataDateTimePicker1.Enabled = false;
        }

        private void LoadData()
        {
            using (var context = new bfk_pruyomEntities())
            {
                var students = context.Abiturients
                    .Select(a => new
                    {
                        a.id,
                        a.fullname,
                        a.phone,
                        a.appdate,
                        Specialties = a.Applications
                            .OrderBy(ap => ap.priority)
                            .Select(ap => ap.Specialties.name)
                    })
                    .AsEnumerable()
                    .Select(a => new AbiturientSort
                    {
                        Id = a.id,
                        Fullname = a.fullname,
                        Phone = a.phone,
                        AppDate = a.appdate,
                        Specialties = string.Join(", ", a.Specialties.Select(name =>
                            specialtyShortNames.TryGetValue(name, out var shortName)
                            ? shortName : name))
                    })
                    .ToList();

                _data = new BindingList<AbiturientSort>(students);
                dataGridView1.Columns.Clear();

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "✓";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "CheckBoxColumn";
                dataGridView1.Columns.Add(checkBoxColumn);

                dataGridView1.DataSource = _data;

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Fullname"].HeaderText = "ПІП";
                dataGridView1.Columns["Fullname"].MinimumWidth = 225;
                dataGridView1.Columns["Phone"].HeaderText = "Телефон";
                dataGridView1.Columns["Specialties"].HeaderText = "Обрані спеціальності";
                dataGridView1.Columns["Specialties"].MinimumWidth = 139;
                dataGridView1.Columns["AppDate"].HeaderText = "Дата подачі";
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var clickedColumn = dataGridView1.Columns[e.ColumnIndex];


            if (clickedColumn.Name == "CheckBoxColumn")
            {
                _checkAll = !_checkAll;

                if (dataGridView1.IsCurrentCellInEditMode)
                    dataGridView1.EndEdit();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["CheckBoxColumn"].Value = _checkAll;
                }

                dataGridView1.Refresh();

                return;
            }

            if (clickedColumn.Name == "CheckBoxColumn")
            {
                _checkAll = !_checkAll;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["CheckBoxColumn"].Value = _checkAll;
                }

                return;
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            if (columnName != "Fullname" && columnName != "AppDate") return;

            if (_lastSortedColumn == columnName)
                _sortAscending = !_sortAscending;
            else
                _sortAscending = true;

            _lastSortedColumn = columnName;

            IEnumerable<AbiturientSort> sorted;
            if (_sortAscending)
                sorted = _data.OrderBy(x => GetPropertyValue(x, columnName));
            else
                sorted = _data.OrderByDescending(x => GetPropertyValue(x, columnName));

            _data = new BindingList<AbiturientSort>(sorted.ToList());
            dataGridView1.DataSource = _data;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == columnName)
                {
                    column.HeaderText = (columnName == "Fullname" ? "ПІП" : "Дата подачі") +
                        (_sortAscending ? " ▲" : " ▼");
                }
                else if (column.DataPropertyName == "Fullname")
                {
                    column.HeaderText = "ПІП";
                }
                else if (column.DataPropertyName == "AppDate")
                {
                    column.HeaderText = "Дата подачі";
                }
            }
        }
        private object GetPropertyValue(AbiturientSort item, string propertyName)
        {
            return typeof(AbiturientSort).GetProperty(propertyName).GetValue(item, null);
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.CurrentCell = null;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = column.Name != "CheckBoxColumn";
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1 && sataDateTimePicker1.Enabled == false)
                LoadFilteredData(specialtyName: comboBox1.SelectedItem.ToString());
            else if (comboBox1.SelectedIndex == -1 && sataDateTimePicker1.Enabled == true)
                LoadFilteredData(appDate: sataDateTimePicker1.Value);
            else if(comboBox1.SelectedIndex != -1 && sataDateTimePicker1.Enabled == true)
                LoadFilteredData(comboBox1.SelectedItem.ToString(), sataDateTimePicker1.Value);
            else
                ShowMessage("Оберіть параметри сортування!", "Дані для сортування не обрано");

        }

        private void LoadFilteredData(string specialtyName = null, DateTime? appDate = null)
        {
            using (var context = new bfk_pruyomEntities())
            {
                var result = context.Abiturients.Include(a => a.Applications.Select(ap => ap.Specialties))
    .ToList()
    .Where(a =>
        (specialtyName == null || a.Applications.Any(ap => ap.priority == 1 && ap.Specialties.name == specialtyName)) &&
        (appDate == null || a.appdate.Date == appDate.Value.Date) 
    )
    .Select(a => new AbiturientSort
    {
        Id = a.id,
        Fullname = a.fullname,
        Phone = a.phone,
        AppDate = a.appdate,
        Specialties = string.Join(", ", a.Applications
                .OrderBy(ap => ap.priority)
                .Select(ap =>
                specialtyShortNames.ContainsKey(ap.Specialties.name)
                    ? specialtyShortNames[ap.Specialties.name]
                    : ap.Specialties.name))
    })
        .ToList();

                _data = new BindingList<AbiturientSort>(result);

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                var checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "✓",
                    Width = 30,
                    Name = "CheckBoxColumn"
                };
                dataGridView1.Columns.Add(checkBoxColumn);

                dataGridView1.DataSource = _data;

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Fullname"].HeaderText = "ПІП";
                dataGridView1.Columns["Fullname"].MinimumWidth = 225;
                dataGridView1.Columns["Phone"].HeaderText = "Телефон";
                dataGridView1.Columns["Specialties"].HeaderText = "Обрані спеціальності";
                dataGridView1.Columns["Specialties"].MinimumWidth = 139;
                dataGridView1.Columns["AppDate"].HeaderText = "Дата подачі";

                ConfigureDataGridView();
            }

        }

        private void LoadSpecialties()
        {
            using (var context = new bfk_pruyomEntities())
            {
                var specialties = context.Specialties
                    .OrderBy(s => s.name)
                    .Select(s => s.name)
                    .ToList();

                comboBox1.DataSource = specialties;
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "Оберіть спеціальність";
            }
        }

        private void FilterByFullname(string fullnameFilter)
        {
            using (var context = new bfk_pruyomEntities())
            {
                var abiturients = context.Abiturients
                    .Include(a => a.Applications)
                    .ToList();

                var filteredAbiturients = abiturients
                    .Where(a =>
                        string.IsNullOrEmpty(fullnameFilter) || a.fullname.ToLower().Contains(fullnameFilter.ToLower())
                    )
                    .Select(a => new AbiturientSort
                    {
                        Id = a.id,
                        Fullname = a.fullname,
                        Phone = a.phone,
                        AppDate = a.appdate,
                        Specialties = string.Join(", ", a.Applications
                            .OrderBy(ap => ap.priority)
                            .Select(ap =>
                                specialtyShortNames.ContainsKey(ap.Specialties.name)
                                    ? specialtyShortNames[ap.Specialties.name]
                                    : ap.Specialties.name
                            ))
                    })
                    .ToList();

                _data = new BindingList<AbiturientSort>(filteredAbiturients);

                dataGridView1.DataSource = _data;


            }
        }

        private void search__TextChanged(object sender, EventArgs e)
        {
            FilterByFullname(search.Texts);
        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string templatePath = @"..\..\template.docx";
            dataGridView1.EndEdit();
            dataGridView1.CurrentCell = null;
            int counter = 0;

            if (!File.Exists(templatePath))
            {
                ShowMessage("Шаблон анкети не знайдено!", "Помилка шаблону анкети");
                return;
            }

            var selectedRows = new List<AbiturientSort>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var isChecked = Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value);
                if (isChecked)
                {

                    var model = new AbiturientSort
                    {
                        Id = (int)row.Cells["Id"].Value,
                        Fullname = row.Cells["Fullname"].Value?.ToString(),
                        Phone = row.Cells["Phone"].Value?.ToString(),
                        AppDate = Convert.ToDateTime(row.Cells["AppDate"].Value),
                        Specialties = row.Cells["Specialties"].Value?.ToString()
                    };
                    selectedRows.Add(model);
                }

            }
            if (selectedRows.Count < 1)
            {
                ShowMessage("Не вибрано жодної анкети!", "Оберіть анкети");
            }
            foreach (var x in selectedRows)
            {
                using (var doc = DocX.Load(templatePath))
                {
                    var abiturient = context.Abiturients.Include(a => a.Applications.Select(app => app.Specialties))
                        .FirstOrDefault(a => a.id == x.Id);
                    var specialties = context.Applications.Where(app => app.abiturientid == x.Id)
                        .OrderBy(app => app.priority).Select(app => app.Specialties.name).ToList();
                    var mainSpecCode = context.Applications.Where(a => a.abiturientid == x.Id)
                        .OrderBy(a => a.priority).Select(a => a.Specialties.code).FirstOrDefault();

                    doc.ReplaceText("{fullname}", abiturient.fullname);
                    doc.ReplaceText("{address}", abiturient.address);
                    doc.ReplaceText("{phone}", abiturient.phone);
                    doc.ReplaceText("{study}", abiturient.study);
                    doc.ReplaceText("{school}", abiturient.school);
                    doc.ReplaceText("{father_fullname}", abiturient.fathername);
                    doc.ReplaceText("{father_phone}", abiturient.fatherphone);
                    doc.ReplaceText("{mother_fullname}", abiturient.mothername);
                    doc.ReplaceText("{mother_phone}", abiturient.motherphone);
                    doc.ReplaceText("{group}", abiturient.workgroup);
                    var parts = abiturient.information.Split(';')
                          .Select(p => p.Trim())
                          .Where(p => !string.IsNullOrEmpty(p))
                          .ToList();
                    doc.ReplaceText("{info}", string.Join(Environment.NewLine, parts.Select(p => $"- {p}")));
                    doc.ReplaceText("{house}", abiturient.dormitory);
                    doc.ReplaceText("{date}", abiturient.appdate.ToString("dd.MM.yyyy"));

                    doc.ReplaceText("{main_spec}", specialties.Count > 0 ? specialties[0] : "");
                    doc.ReplaceText("{spec}", specialties.Count > 0 ? specialties[0] : "");
                    doc.ReplaceText("{code_spec}", mainSpecCode);

                    for (int i = 1; i <= 5; i++)
                    {
                        string placeholder = $"{{spec{i}}}";
                        string value = specialties.Count > i ? specialties[i] : "-";
                        doc.ReplaceText(placeholder, value);
                    }

                    doc.SaveAs(@"..\..\Анкети\" + abiturient.fullname + " Id_" + abiturient.id.ToString() + ".docx");
                    counter++;
                }
                int progress = (int)((counter + 1) * 100.0 / selectedRows.Count);
                backgroundWorker2.ReportProgress(progress);
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sataProgressbar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMessage("Створення анкет завершено!", "Анкети згенеровано");
        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.CurrentCell = null;

            int checkedCount = 0;
            DataGridViewRow checkedRow = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value);
                if (isChecked)
                {
                    checkedCount++;
                    checkedRow = row;
                }
            }

            if (checkedCount != 1)
            {
                ShowMessage("Для редагування оберіть лише одного абітурієнта!", "Помилка вибору абітурієнта");
            }
            else
            { 
                int selectedId = (int)checkedRow.Cells["Id"].Value;
                var form = new AbiturientEditor(selectedId);
                form.ShowDialog();
                if(form.DialogResult == DialogResult.OK)
                {
                    sataToggle2.Checked = false;
                    LoadCharts();
                    LoadData();
                    ConfigureDataGridView();
                    LoadSpecialties();
                }
            } 
        }

        private void sataToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (sataToggle2.Checked)
                LoadChartsApp();
            else
                LoadCharts();
        }
    }
}
