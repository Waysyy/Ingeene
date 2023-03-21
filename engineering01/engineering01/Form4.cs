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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
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

            column5.HeaderText = "Фонд\r\nзаработной\r\nплаты, руб.";
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



            column11.HeaderText = "Должность";
            column11.Name = "Column1";

            column21.HeaderText = "Должностной\r\nоклад, руб.";
            column21.Name = "Column2";

            column31.HeaderText = "Средняя\r\nдневная\r\nставка, руб";
            column31.Name = "Column3";

            column41.HeaderText = "Затраты времени на\r\nразработку, человекодней";
            column41.Name = "Column4";

            column51.HeaderText = "Фонд\r\nзаработной\r\nплаты, руб.";
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

            column22.HeaderText = "Затраты на проект, руб.";
            column22.Name = "Column2";

            column32.HeaderText = "Затраты на аналог,руб.";
            column32.Name = "Column2";

            this.dataGridView3.Columns.AddRange(new DataGridViewColumn[] { column12, column22, column32 });
            dataGridView3.Rows.Add(6);

            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Class1 classCheck = new Class1();

            if (classCheck.ChekTable(dataGridView1, null, null, "double", 0, 0) == true)
            {
                if (classCheck.ChekTable(dataGridView2, null, null, "double", 0, 0) == true)
                {
                    calculation();
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Кажется вы что-то не так ввели");
                }
            }
            else
            {
                MessageBox.Show("Кажется вы что-то не так ввели");
            }
            
        }

        public void calculation()
        {
            int length = dataGridView1.Rows.Count - 1;
            double countRows = 0;
            for (int i = 0; i < length; i++)
            {

                string column1Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string column2Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string column3Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string column4Value = dataGridView1.Rows[i].Cells[3].Value.ToString();

                

                dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble(column2Value) * Convert.ToDouble(column3Value);

            }

            for (int i = 0; i < length; i++)
            {
                string column5Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                countRows += Convert.ToDouble(column5Value);

            }

            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = countRows;

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

            dataGridView3.Rows[0].Cells[0].Value = "Основная и дополнительная\r\nзарплата с отчислениями во";
            dataGridView3.Rows[0].Cells[1].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value;
            dataGridView3.Rows[0].Cells[2].Value = dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[4].Value;

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

            double sumRows4 = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sumRows4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
            }
            double sumRows5 = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sumRows5 += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            }

            table2.Rows.Add();

            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = table2;
            dataGridView3.DataSource = bindingSource2;

            Random rand = new Random();

            dataGridView3.Rows[1].Cells[0].Value = "Амортизационные отчисления";
            dataGridView3.Rows[1].Cells[1].Value = (22500 * 0.2 * 1 * (sumRows4 * 8)) / 1976;
            dataGridView3.Rows[1].Cells[2].Value = (22500 * 0.2 * 1 * (sumRows5 * 8)) / 1976;

            dataGridView3.Rows[2].Cells[0].Value = "Затраты на электроэнергию";
            dataGridView3.Rows[2].Cells[1].Value = rand.Next(2000);
            dataGridView3.Rows[2].Cells[2].Value = rand.Next(2000);

            dataGridView3.Rows[3].Cells[0].Value = "Затраты на текущий ремонт";
            dataGridView3.Rows[3].Cells[1].Value = rand.Next(700);
            dataGridView3.Rows[3].Cells[2].Value = rand.Next(700);

            dataGridView3.Rows[4].Cells[0].Value = "Затраты на материалы";
            dataGridView3.Rows[4].Cells[1].Value = rand.Next(400);
            dataGridView3.Rows[4].Cells[2].Value = rand.Next(400);

            int length4 = dataGridView3.Rows.Count - 1;
            double rowsSum1 = 0;

            double rowsSum2 = 0;

            for (int i = 0; i < length4; i++)
            {
                string column5Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                if (column5Value != "")
                    rowsSum2 += Convert.ToDouble(column5Value);

            }
            for (int i = 0; i < length4; i++)
            {
                string column5Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                if (column5Value != "")
                    rowsSum1 += Convert.ToDouble(column5Value);

            }


            dataGridView3.Rows[5].Cells[0].Value = "Накладные расходы ";
            dataGridView3.Rows[5].Cells[1].Value = rowsSum1 * 0.2;
            dataGridView3.Rows[5].Cells[2].Value = rowsSum2 * 0.2;

            int length3 = dataGridView3.Rows.Count-1;
            double projectCount = 0;
            double competitorCount = 0;
            for (int i = 0; i < length3; i++)
            {
                if(dataGridView3.Rows[i].Cells[1].Value.ToString() != "")
                {
                    string column2Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    projectCount += Convert.ToDouble(column2Value);

                    string column3Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    competitorCount += Convert.ToDouble(column3Value);
                }
                

            }

            

            dataGridView3.Rows[6].Cells[2].Value = competitorCount;
            dataGridView3.Rows[6].Cells[1].Value = projectCount;

            

            for (int i = 0; i < length4; i++)
            {
                string column5Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                if (column5Value != "")
                    rowsSum1 += Convert.ToDouble(column5Value);

            }

            
        }

        private void SaveData()
        {
            if (dataGridView1.DataSource == null) return;

            using (Stream stream = File.Open("data6.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView1.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView2.DataSource == null) return;

            using (Stream stream = File.Open("data7.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView2.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

            if (dataGridView3.DataSource == null) return;

            using (Stream stream = File.Open("data8.dat", FileMode.Create))
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
            if (File.Exists("data6.dat"))
            {
                using (Stream stream = File.Open("data6.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView1.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data7.dat"))
            {
                using (Stream stream = File.Open("data7.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView2.DataSource = formatter.Deserialize(stream);
                }
            }
            if (File.Exists("data8.dat"))
            {
                using (Stream stream = File.Open("data8.dat", FileMode.Open))
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
            createDataSource();
            SaveData();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }
    }
}
