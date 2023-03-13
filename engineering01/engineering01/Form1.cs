using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engineering01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
         
            InitializeComponent();
            LoadData();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void check_KTU()
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                double column2Value = 0;
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                    column2Value = 0;
                else {
                    column2Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                }

                

                
                double column3Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);

                
                double result = column2Value * column3Value;

                
                dataGridView1.Rows[i].Cells[3].Value = result;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                
                double column2Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);

                
                double column5Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

                
                double result = column2Value * column5Value;

                
                dataGridView1.Rows[i].Cells[5].Value = result;
            }
            double result1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                
                double column6Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);

                
                result1 = result1 + column6Value;

                
            }
            label4.Text = Convert.ToString(result1);
            double result2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                double column4Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

                result2 = result2 + column4Value;

                
            }
            label3.Text = Convert.ToString(result2);

            double A = result2 / result1;
            if(A > 1)
            { label8.Text = "да";
                label8.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label8.Text = "нет";
                label8.ForeColor = System.Drawing.Color.Red;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_KTU();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            createDataSource();
            SaveData();
        }

        private void SaveData()
        {
            if (dataGridView1.DataSource == null) return;

            using (Stream stream = File.Open("data.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataTable dataTable = ((BindingSource)dataGridView1.DataSource).DataSource as DataTable;
                if (dataTable != null)
                {
                    formatter.Serialize(stream, dataTable);
                }
            }

        }


        private void LoadData()
        {
            if (File.Exists("data.dat"))
            {
                using (Stream stream = File.Open("data.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataGridView1.DataSource = formatter.Deserialize(stream);
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
                if(stopper == dataGridView1.Rows.Count-1)
                {
                    break;
                }

            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;


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



            column1.HeaderText = "Показатели качества";
            column1.Name = "Column1";

            column2.HeaderText = "Коэффициент\r\nвесомости";
            column2.Name = "Column2";

            column3.HeaderText = "Проект";
            column3.Name = "Column3";

            column4.HeaderText = "Столбец с результатом";
            column4.Name = "Column4";

            column5.HeaderText = "Аналог";
            column5.Name = "Column5";

            column6.HeaderText = "Столбец с результатом2";
            column6.Name = "Column6";

            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5, column6 });



            dataGridView1.Rows.Add("Удобство работы \n(пользовательский интерфейс)");
            dataGridView1.Rows.Add("Новизна (соответствие современным\r\nтребованиям)");
            dataGridView1.Rows.Add("Соответствие профилю деятельности\r\nзаказчика");
            dataGridView1.Rows.Add("Ресурсная эффективность");
            dataGridView1.Rows.Add("Надежность (защита данных) ");
            dataGridView1.Rows.Add("Скорость доступа к данным");
            dataGridView1.Rows.Add("Гибкость настройки");
            dataGridView1.Rows.Add("Обучаемость персонала");
            dataGridView1.Rows.Add("Соотношение стоимость/возможности ");
        }
    }
}
