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
    public partial class Form3 : Form
    {
        public double machineHour = 0;
        public Form3()
        {
            InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
            createDataSource();
            SaveData();
        }

        private void SaveData()
        {
            if (dataGridView1.DataSource == null) return;

            using (Stream stream = File.Open("data3.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView1.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView2.DataSource == null) return;

            using (Stream stream = File.Open("data4.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView2.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView3.DataSource == null) return;

            using (Stream stream = File.Open("data5.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView3.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

        }


        private void LoadData()
        {
            if (File.Exists("data3.dat"))
            {
                using (Stream stream = File.Open("data3.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView1.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data4.dat"))
            {
                using (Stream stream = File.Open("data4.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView2.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data5.dat"))
            {
                using (Stream stream = File.Open("data5.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView3.DataSource = formatter.Deserialize(stream);
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

            DataTable table2 = new DataTable();
            table2.Columns.Clear();
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                table2.Columns.Add(column.HeaderText);
            }
            int stopper2 = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                table2.Rows.Add(rowData);
                ++stopper2;
                if (stopper2 == dataGridView3.Rows.Count - 1)
                {
                    break;
                }

            }
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = table2;
            dataGridView3.DataSource = bindingSource2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();


            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();



            column1.HeaderText = "Должность";
            column1.Name = "Column1";

            column2.HeaderText = "Должностной\r\nоклад, руб.";
            column2.Name = "Column2";

            column3.HeaderText = "Средняя\r\nдневная\r\nставка, руб";
            column3.Name = "Column3";

            column4.HeaderText = "Затраты времени на\r\nразработку, человекодней";
            column4.Name = "Column4";

            column5.HeaderText = "ОЗП, руб";
            column5.Name = "Column5";


            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5 });

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();


            var column11 = new DataGridViewTextBoxColumn();
            var column21 = new DataGridViewTextBoxColumn();
            var column31 = new DataGridViewTextBoxColumn();
            var column41 = new DataGridViewTextBoxColumn();
            var column51 = new DataGridViewTextBoxColumn();
            var column61 = new DataGridViewTextBoxColumn();



            column11.HeaderText = "Материалы";
            column11.Name = "Column1";

            column21.HeaderText = "Единица\r\nизмерения";
            column21.Name = "Column2";

            column31.HeaderText = "Требуемое\r\nколичество";
            column31.Name = "Column3";

            column41.HeaderText = "Цена за\r\nединицу, руб.";
            column41.Name = "Column4";

            column51.HeaderText = "Сумма,\r\nруб.\r\n";
            column51.Name = "Column5";


            this.dataGridView2.Columns.AddRange(new DataGridViewColumn[] { column11, column21, column31, column41, column51 });

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();


            var column12 = new DataGridViewTextBoxColumn();
            var column22 = new DataGridViewTextBoxColumn();
            var column32 = new DataGridViewTextBoxColumn();
            var column42 = new DataGridViewTextBoxColumn();
            var column52 = new DataGridViewTextBoxColumn();
            var column62 = new DataGridViewTextBoxColumn();



            column12.HeaderText = "Статьи затрат ";
            column12.Name = "Column1";

            column22.HeaderText = "Сумма, руб.";
            column22.Name = "Column2";


            this.dataGridView3.Columns.AddRange(new DataGridViewColumn[] { column12, column22 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculation();
        }

        public void calculation()
        {
            int length = dataGridView1.Rows.Count-1;
            double countRows = 0;
            for (int i = 0; i < length; i++)
            {

                string column1Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string column2Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string column3Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string column4Value = dataGridView1.Rows[i].Cells[3].Value.ToString();

                if(column1Value.Contains("программист") || column1Value.Contains("Программист"))
                {
                    machineHour = 24 * Convert.ToDouble(column4Value);
                }    


                dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble(column2Value) * Convert.ToDouble(column3Value);
                
            }
            
            for (int i = 0; i < length; i++)
            {
                string column5Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                countRows += Convert.ToDouble(column5Value);
                
            }

            dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[4].Value = countRows;

            int length1 = dataGridView2.Rows.Count - 1;
            double countRows1 = 0;
            for (int i = 0; i < length1; i++)
            {

                string column1Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                string column2Value = dataGridView2.Rows[i].Cells[1].Value.ToString();
                string column3Value = dataGridView2.Rows[i].Cells[2].Value.ToString();
                string column4Value = dataGridView2.Rows[i].Cells[3].Value.ToString();


                dataGridView2.Rows[i].Cells[4].Value = Convert.ToDouble(column2Value) * Convert.ToDouble(column3Value);

            }

            for (int i = 0; i < length1; i++)
            {
                string column5Value = dataGridView2.Rows[i].Cells[4].Value.ToString();
                countRows1 += Convert.ToDouble(column5Value);

            }

            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Value = countRows1;

            
            DataTable table2 = new DataTable();
            

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                table2.Columns.Add(column.HeaderText);
            }
            int stopper2 = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                table2.Rows.Add(rowData);
                ++stopper2;
                if (stopper2 == dataGridView3.Rows.Count - 1)
                {
                    break;
                }

            }
            if(dataGridView3.Rows.Count < 4)
            {
                for (int i = 0; i <= 4; ++i)
                {
                    table2.Rows.Add();
                }
            }
            
            
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = table2;
            dataGridView3.DataSource = bindingSource2;

            dataGridView3.Rows[0].Cells[0].Value = "Основная заработная плата";
            dataGridView3.Rows[0].Cells[1].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value;
            dataGridView3.Rows[1].Cells[0].Value = "Дополнительная заработная плата";
            dataGridView3.Rows[1].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value)*0.4;
            dataGridView3.Rows[2].Cells[0].Value = "Отчисления на социальные нужды";
            dataGridView3.Rows[2].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value) * 0.45;
            dataGridView3.Rows[3].Cells[0].Value = "Затраты на материалы";
            dataGridView3.Rows[3].Cells[1].Value = dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Value;
            dataGridView3.Rows[4].Cells[0].Value = "Затраты на машинное время";
            dataGridView3.Rows[4].Cells[1].Value = machineHour * 20;
            dataGridView3.Rows[5].Cells[0].Value = "Накладные расходы организации";
            dataGridView3.Rows[5].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value) * 0.6;

            int length2 = dataGridView3.Rows.Count - 1;
            double countRows2 = 0;

            for (int i = 0; i < length2; i++)
            {
                string column5Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                if(column5Value != "")
                countRows2 += Convert.ToDouble(column5Value);

            }
            dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[1].Value = countRows2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
