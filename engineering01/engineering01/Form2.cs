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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        public void calculation()
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                
                string column1Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string column2Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string column3Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string column4Value = dataGridView1.Rows[i].Cells[3].Value.ToString();

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    
                    dataGridView2.Rows[j].Cells[0].Value = column1Value;
                    dataGridView2.Rows[j].Cells[1].Value = column2Value;
                    dataGridView2.Rows[j].Cells[2].Value = column3Value;


                    DateTime currentDate = DateTime.Now.Date;
                    dataGridView2.Rows[j].Cells[3].Value = currentDate.ToShortDateString();

                    
                    int days = Convert.ToInt32(column4Value);
                    
                    DateTime calculatedDate = currentDate.AddDays(days-1);
                    
                    dataGridView2.Rows[j].Cells[4].Value = calculatedDate.ToShortDateString();
                }

                dataGridView1.Rows[i].Cells[4].Value = Math.Round((Convert.ToDouble(column4Value) * 100) / Convert.ToDouble(column3Value));
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculation();
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



            column1.HeaderText = "Содержание работ";
            column1.Name = "Column1";

            column2.HeaderText = "Исполнители";
            column2.Name = "Column2";

            column3.HeaderText = "Длительност\r\nь, дни";
            column3.Name = "Column3";

            column4.HeaderText = "Загрузка (Дни)";
            column4.Name = "Column4";

            column5.HeaderText = "Загрузка (%)";
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



            column11.HeaderText = "Содержание работ";
            column11.Name = "Column1";

            column21.HeaderText = "Исполнители";
            column21.Name = "Column2";

            column31.HeaderText = "Длительност\r\nь, дни";
            column31.Name = "Column3";

            column41.HeaderText = "Начало";
            column41.Name = "Column4";

            column51.HeaderText = "Конец";
            column51.Name = "Column5";


            this.dataGridView2.Columns.AddRange(new DataGridViewColumn[] { column11, column21, column31, column41, column51 });
        }

        private void SaveData()
        {
            if (dataGridView1.DataSource == null) return;

            using (Stream stream = File.Open("data1.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView1.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView2.DataSource == null) return;

            using (Stream stream = File.Open("data2.dat", FileMode.Create))
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
            if (File.Exists("data1.dat"))
            {
                using (Stream stream = File.Open("data1.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView1.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data2.dat"))
            {
                using (Stream stream = File.Open("data2.dat", FileMode.Open))
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
            createDataSource();
            SaveData();
        }
    }
}
