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
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
