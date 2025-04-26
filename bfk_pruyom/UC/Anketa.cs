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
        public Anketa()
        {
            InitializeComponent();
        }

        private void enterVerify_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Завантажте файл .csv|*.csv";
                openFileDialog.Title = "Оберіть файл для завантаження";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

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
                        
                        foreach (var record in records)
                        {
                            MessageBox.Show(record[3]);
                        }
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
    }
}
