using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engineering01
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadDataFiles();
            createDataSource();
            SaveData();
            this.Hide();
            this.Visible = true;
        }

        private void SaveData()
        {
            if (dataGridView1.DataSource == null) return;

            using (Stream stream = File.Open("data9.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView1.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView2.DataSource == null) return;

            using (Stream stream = File.Open("data10.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView2.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

        }


        private void LoadData()
        {
            if (File.Exists("data9.dat"))
            {
                using (Stream stream = File.Open("data9.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView1.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data10.dat"))
            {
                using (Stream stream = File.Open("data10.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView2.DataSource = formatter.Deserialize(stream);
                }
            }

        }

        private void createDataSource()
        {
            DataTable table = new DataTable();
            table.Columns.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                table.Columns.Add(column.HeaderText);
            }
            int stopper = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                table.Rows.Add(rowData);
                ++stopper;
                if (stopper == dataGridView1.Rows.Count - 1)
                {
                    break;
                }

            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;

            DataTable table1 = new DataTable();
            table1.Columns.Clear();
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                table1.Columns.Add(column.HeaderText);
            }
            int stopper1 = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                table1.Rows.Add(rowData);
                ++stopper1;
                if (stopper1 == dataGridView2.Rows.Count - 1)
                {
                    break;
                }

            }
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = table1;
            dataGridView2.DataSource = bindingSource1;


        }
        private void ReadDataFiles()
        {
            if (File.Exists("data8.dat"))
            {
                using (Stream stream = File.Open("data8.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    DataTable dataGrid1 = new DataTable();
                    dataGrid1 = (DataTable)formatter.Deserialize(stream);
                    double rowsSum1 = 0;
                    for (int i = 0; i < dataGrid1.Rows.Count - 1; i++)
                    {
                        string column5Value = dataGrid1.Rows[i][1].ToString();
                        if (column5Value != "")
                            rowsSum1 += Convert.ToDouble(column5Value);

                    }
                    dataGridView1.Rows[0].Cells[2].Value = rowsSum1.ToString();
                    dataGridView1.Rows[1].Cells[1].Value = (22500*1*6*247/(247*8));
                    rowsSum1 = 0;
                    for (int i = 0; i < dataGrid1.Rows.Count - 1; i++)
                    {
                        string column5Value = dataGrid1.Rows[i][2].ToString();
                        if (column5Value != "")
                            rowsSum1 += Convert.ToDouble(column5Value);

                    }
                    dataGridView1.Rows[0].Cells[1].Value = rowsSum1.ToString();
                    dataGridView1.Rows[1].Cells[1].Value = 80800;

                }
            }
            if (File.Exists("data5.dat"))
            {
                double sum1 = 0;
                using (Stream stream = File.Open("data5.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    DataTable dataGrid1 = new DataTable();
                    dataGrid1 = (DataTable)formatter.Deserialize(stream);
                    double rowsSum1 = 0;
                    for (int i = 0; i < dataGrid1.Rows.Count - 1; i++)
                    {
                        string column5Value = dataGrid1.Rows[i][1].ToString();
                        if (column5Value != "")
                            rowsSum1 += Convert.ToDouble(column5Value);

                    }
                    //dataGridView1.Rows[1].Cells[2].Value = rowsSum1+16875;
                    sum1 = rowsSum1 + 16875;


                }
                using (Stream stream = File.Open("data3.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    DataTable dataGrid1 = new DataTable();
                    dataGrid1 = (DataTable)formatter.Deserialize(stream);
                    double rowsSum1 = 0;
                    for (int i = 0; i < dataGrid1.Rows.Count - 1; i++)
                    {
                        string column5Value = dataGrid1.Rows[i][4].ToString();
                        if (column5Value != "")
                            rowsSum1 += Convert.ToDouble(column5Value);

                    }
                    dataGridView1.Rows[1].Cells[2].Value = rowsSum1 + sum1;

                }
            }
            double val1_column1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);
            double val2_column1 = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value);
            double val1_column2 = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
            double val2_column2 = Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value);
            double val3_column1 = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value);
            dataGridView1.Rows[2].Cells[1].Value = val1_column1 + 0.33 * val2_column1;
            dataGridView1.Rows[2].Cells[2].Value = val1_column2 + 0.33 * val2_column2;
            dataGridView1.Rows[3].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value) * 1.6 - Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value);
            dataGridView1.Rows[3].Cells[2].Value = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value) * 1.6 - Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value);

            double val3_column2 = Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value);

            dataGridView2.Rows[0].Cells[1].Value = val3_column2.ToString();
            dataGridView2.Rows[1].Cells[1].Value = val1_column2.ToString();

            double econ_effect = val1_column2 * 1.6 - val3_column2;
            dataGridView2.Rows[2].Cells[1].Value = econ_effect.ToString();
            double Tok = val2_column2 / econ_effect;
            dataGridView2.Rows[3].Cells[1].Value = (1/Tok).ToString();
            dataGridView2.Rows[4].Cells[1].Value = Tok.ToString();

        }

        private void Calculation()
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();


            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();




            column1.HeaderText = "Характеристика";
            column1.Name = "Column1";

            column2.HeaderText = "продукт-аналог";
            column2.Name = "Column2";

            column3.HeaderText = "разрабатываемый\r\nпродукт";
            column3.Name = "Column3";


            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3 });

            dataGridView1.Rows.Add(4);

            dataGridView1.Rows[0].Cells[0].Value = "Себестоимость (текущие эксплуатационные\r\nзатраты), руб.";
            dataGridView1.Rows[1].Cells[0].Value = "Суммарные затраты, связанные с внедрением\r\nпроекта, руб.";
            dataGridView1.Rows[2].Cells[0].Value = "Приведенные затраты на единицу работ, руб.";
            dataGridView1.Rows[3].Cells[0].Value = "Экономический эффект от использования\r\nразрабатываемой системы, руб. ";
            


            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();


            var column11 = new DataGridViewTextBoxColumn();
            var column21 = new DataGridViewTextBoxColumn();




            column11.HeaderText = "Характеристика проекта ";
            column11.Name = "Column1";

            column21.HeaderText = "Значение";
            column21.Name = "Column2";

            this.dataGridView2.Columns.AddRange(new DataGridViewColumn[] { column11, column21 });

            dataGridView2.Rows.Add(5);

            dataGridView2.Rows[0].Cells[0].Value = "Затраты на разработку и внедрение проекта, руб.";
            dataGridView2.Rows[1].Cells[0].Value = "Общие эксплуатационные затраты, руб.";
            dataGridView2.Rows[2].Cells[0].Value = "Экономический эффект, руб";
            dataGridView2.Rows[3].Cells[0].Value = "Коэффициент экономической эффективности";
            dataGridView2.Rows[4].Cells[0].Value = "Срок окупаемости, лет";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }

}
