using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfk_pruyom.UC
{
    public partial class Anketa : UserControl
    {
        private bfk_pruyomEntities context;
        private string selectedFilePath;

        public Anketa()
        {
            InitializeComponent();
            context = new bfk_pruyomEntities();
            LoadCharts();
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
            List<Abiturients> abit = context.Abiturients.ToList();

            label1.Text = "Всього анкет - " + abit.Count;

            var resultPriority = context.Applications.Where(x => x.priority == 1).GroupBy(x => x.specialtyid).Select(g => new
            {
                SpecialtyId = g.Key,
                AbiturientCount = g.Count()
            }).ToList();

            foreach(var item in resultPriority)
            {
                if(item.SpecialtyId == 6 && item.AbiturientCount > 0)
                    label7.Text = "КН-" + item.AbiturientCount;

                if (item.SpecialtyId == 1 && item.AbiturientCount > 0)
                    label2.Text = "ОО-" + item.AbiturientCount;

                if (item.SpecialtyId == 2 && item.AbiturientCount > 0)
                    label3.Text = "Ф-" + item.AbiturientCount;

                if (item.SpecialtyId == 3 && item.AbiturientCount > 0)
                    label4.Text = "М-" + item.AbiturientCount;

                if (item.SpecialtyId == 4 && item.AbiturientCount > 0)
                    label5.Text = "МД-" + item.AbiturientCount;

                if (item.SpecialtyId == 5 && item.AbiturientCount > 0)
                    label6.Text = "Е-" + item.AbiturientCount;

                if (item.SpecialtyId == 7 && item.AbiturientCount > 0)
                    label8.Text = "ГЗ-" + item.AbiturientCount;

                if (item.SpecialtyId == 8 && item.AbiturientCount > 0)
                    label9.Text = "А-" + item.AbiturientCount;

                if (item.SpecialtyId == 9 && item.AbiturientCount > 0)
                    label10.Text = "Л-" + item.AbiturientCount;

                if (item.SpecialtyId == 10 && item.AbiturientCount > 0)
                    label11.Text = "СП-" + item.AbiturientCount;

                if (item.SpecialtyId == 11 && item.AbiturientCount > 0)
                    label12.Text = "ТТ-" + item.AbiturientCount;

                if (item.SpecialtyId == 12 && item.AbiturientCount > 0)
                    label14.Text = "Х-" + item.AbiturientCount;

                if (item.SpecialtyId == 13 && item.AbiturientCount > 0)
                    label13.Text = "КІ-" + item.AbiturientCount;
            }
        }
    }
}
