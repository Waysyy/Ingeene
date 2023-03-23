using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ingeenering02
{
    public partial class Form1 : Form
    {
        private double a, b, c, d = 0;
        
        public Form1()
        {
            InitializeComponent();
            PREC1.Checked = true;
            FLEX1.Checked = true;
            RESL1.Checked = true;
            TEAM1.Checked = true;
            PMAT1.Checked = true;

            reliability1.Checked = true;
            size1.Checked = true;
            complex1.Checked = true;
            limit1.Checked = true;
            memory1.Checked = true;
            env1.Checked = true;
            reset1.Checked = true;
            analytic1.Checked = true;
            exp1.Checked = true;
            ability1.Checked = true;
            expVirtual1.Checked = true;
            expDev1.Checked = true;
            application1.Checked = true;
            useInstrumental1.Checked = true;
            req1.Checked = true;


        }

        public double[,] ExcelRead(string path)
        {
            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook workbook = excelApp.Workbooks.Open(path);

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            Excel.Range range = worksheet.UsedRange;

            int numRows = range.Rows.Count;
            int numCols = range.Columns.Count;

            object[,] data = new object[numRows, numCols];

            for (int i = 1; i <= numRows; i++)
            {
                for (int j = 1; j <= numCols; j++)
                {
                    data[i - 1, j - 1] = range.Cells[i, j].Value2;
                }
            }

            workbook.Close();
            excelApp.Quit();

           /* Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);*/

            double[,] convertedData = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    string strValue = data[i, j]?.ToString()?.Replace(",", ".");
                    strValue = data[i, j]?.ToString()?.Replace('"',' ');
                    strValue = data[i, j]?.ToString()?.Replace(" ", "");
                    double doubleValue;
                    if (double.TryParse(strValue, out doubleValue))
                    {
                        convertedData[i, j] = doubleValue;
                    }
                    else
                    {
                        convertedData[i, j] = 0;
                    }
                }
            }
            return convertedData;
        }
        public double[] EMAdvanced()
        {
            double[,] EMArray = ExcelRead(@"A:\GitProjects\Ingeene\Ingeenering02\Ingeenering02\bin\Debug\EM1.xlsx");

            double[] EM = new double[1];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox14.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox13.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox12.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox11.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox10.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox9.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox8.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox21.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox22.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox19.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox18.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox17.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox16.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox15.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox24.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox23.SelectedItem)];
            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox22.SelectedItem)];
            

            return EM;
        }
        public double[] EMEarly()
        {
            double[,] EMArray = ExcelRead(@"A:\GitProjects\Ingeene\Ingeenering02\Ingeenering02\bin\Debug\EM0.xlsx");

            double[] EM = new double[1];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox1.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox2.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox3.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox4.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox5.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox6.SelectedItem)];

            Array.Resize(ref EM, EM.Length + 1);
            EM[EM.Length - 1] = EMArray[0, Convert.ToInt32(listBox7.SelectedItem)];

            return EM;
        }

        private void next2_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel10.Visible = true;
            panel19.Visible = false;
            panel18.Visible = false;
        }
        public double[] ValueAssigmentCOCOMO2()
        {
            double[] SF = new double[1];

            

            if (PREC1.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (6.2);
            }
            if (PREC2.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (4.96);
            }
            if (PREC3.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (3.72);
            }
            if (PREC4.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (2.48);
            }
            if (PREC5.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (1.24);
            }
            if (FLEX1.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (5.07);
            }
            if (FLEX2.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (4.05);
            }
            if (FLEX3.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (3.04);
            }
            if (FLEX4.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (2.03);
            }
            if (FLEX5.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (1.01);
            }
            if (RESL1.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (7.07);
            }
            if (RESL2.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (5.65);
            }
            if (RESL3.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (4.24);
            }
            if (RESL4.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (2.83);
            }
            if (RESL5.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (1.41);
            }
            if (TEAM1.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (5.48);
            }
            if (TEAM2.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (4.38);
            }
            if (TEAM3.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (3.29);
            }
            if (TEAM4.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (2.19);
            }
            if (TEAM5.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (1.1);
            }
            if (PMAT1.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (7.8);
            }
            if (PMAT2.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (6.24);
            }
            if (PMAT3.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (4.68);
            }
            if (PMAT4.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (3.12);
            }
            if (PMAT5.Checked)
            {
                Array.Resize(ref SF, SF.Length + 1);
                SF[SF.Length - 1] = (1.56);
            }
            
            return SF;
        }
        public double[] ValueAssigment()
        {
            double[] CD = new double[1];
            if (radioButton1.Checked)
            {
                if (type1.Checked)
                {
                    a = 2.4;
                    b = 1.05;
                    c = 2.5;
                    d = 0.38;
                }
                if (type2.Checked)
                {
                    a = 3;
                    b = 1.12;
                    c = 2.5;
                    d = 0.35;
                }
                if (type3.Checked)
                {
                    a = 3.6;
                    b = 1.2;
                    c = 2.5;
                    d = 0.32;
                }
            }
            if (radioButton2.Checked)
            {
                if (type1.Checked)
                {
                    a = 3.2;
                    b = 1.05;
                    c = 2.5;
                    d = 0.38;

                }
                if (type2.Checked)
                {
                    a = 3;
                    b = 1.12;
                    c = 2.5;
                    d = 0.35;

                }
                if (type3.Checked)
                {
                    a = 2.8;
                    b = 1.2;
                    c = 2.5;
                    d = 0.32;

                }
            }
            if (reliability1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.75);
            }
            if (reliability2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.88);
            }
            if (reliability3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (reliability4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.15);
            }
            if (reliability5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.4);
            }
            if (size2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.94);
            }
            if (size3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (size4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.08);
            }
            if (size5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.16);
            }
            if (complex1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.7);
            }
            if (complex2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.85);
            }
            if (complex3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (complex4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.15);
            }
            if (complex5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.3);
            }
            if (complex6.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.65);
            }
            if (limit3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (limit4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.11);
            }
            if (limit5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.30);
            }
            if (limit6.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.66);
            }

            if (memory3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (memory4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.06);
            }
            if (memory5 .Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.21);
            }
            if (memory6.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.56);
            }
            if (env2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.87);
            }
            if (env3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (env4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.15);
            }
            if (env5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.3);
            }
            if (reset2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.87);
            }
            if (reset3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (reset4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.07);
            }
            if (reset5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.15);
            }
            if (analytic1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.46);
            }
            if (analytic2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.19);
            }
            if (analytic3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (analytic4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.86);
            }
            if (analytic5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.71);
            }
            if (exp1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.29);
            }
            if (exp2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.13);
            }
            if (exp3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (exp4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.91);
            }
            if (exp5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.82);
            }
            if (ability1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.42);
            }
            if (ability2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.17);
            }
            if (ability3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (ability4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.86);
            }
            if (ability5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.7);
            }
            if (expVirtual1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.21);
            }
            if (expVirtual2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.1);
            }
            if (expVirtual3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (expVirtual4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.9);
            }
            if (expDev1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.14);
            }
            if (expDev2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.07);
            }
            if (expDev3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (expDev4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.95);
            }
            if (application1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.24);
            }
            if (application2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.1);
            }
            if (application3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (application4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.91);
            }
            if (application5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.82);
            }
            if (useInstrumental1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.24);
            }
            if (useInstrumental2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.1);
            }
            if (useInstrumental3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (useInstrumental4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.91);
            }
            if (useInstrumental5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(0.83);
            }
            if (req1.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.23);
            }
            if (req2.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.08);
            }
            if (req3.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1);
            }
            if (req4.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.04);
            }
            if (req5.Checked)
            {
                Array.Resize(ref CD, CD.Length + 1);
                CD[CD.Length - 1] =(1.1);
            }
            return CD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            calculations();
        }

        private void next2_Click_1(object sender, EventArgs e)
        {
            panel12.Visible = true;
            
            
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel10.Visible = true;
            panel18.Visible = true;
            panel19.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel18.Visible = true;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            COCOMO2Early();
        }

        public void COCOMO2Advanced()
        {
            double A = 2.45;
            double B = 0.91;

            double PM = 0;
            double TM = 0;

            double EAF = 1;
            double[] SF = ValueAssigmentCOCOMO2();
            double[] EM = EMAdvanced();
            double SFEnd = 1;

            for (int i = 1; i < SF.Length; ++i)
            {
                SFEnd *= SF[i];
            }
            for (int i = 1; i < EM.Length; ++i)
            {
                EAF *= EM[i];
            }
            double E = B + 0.01 * SFEnd;

            if(textBox3.Text != String.Empty)
            {
                PM = EAF * A * Math.Pow(Convert.ToDouble(textBox3.Text), E);
                TM = 3.67 * Math.Pow(PM, (0.28 + 0.2 * (E - B)));
                label46.Text = PM.ToString();
                label44.Text = TM.ToString();
            }
            else
            {
                MessageBox.Show("Заполните поля!");
                
            }

            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            COCOMO2Advanced();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel19.Visible = false;
            panel18.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel18.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                panel11.Visible = false;
                panel12.Visible = false;
            }
            else
            {
                panel12.Visible = false;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
                panel11.Visible = false;
             
          
            
        }

        public void COCOMO2Early()
        {
            double A = 2.45;
            double B = 0.91;

            double PM = 0;
            double TM = 0;

            double EAF = 1;
            double[] SF = ValueAssigmentCOCOMO2();
            double[] EM = EMEarly();
            double SFEnd = 1;

            for (int i = 1; i < SF.Length; ++i)
            {
                SFEnd *= SF[i];
            }
            for (int i = 1; i < EM.Length; ++i)
            {
                    EAF *= EM[i];
            }
            double E = B + 0.01 * SFEnd;
            if (textBox2.Text != String.Empty)
            {
                PM = EAF * A * Math.Pow(Convert.ToDouble(textBox2.Text), E);
                TM = 3.67 * Math.Pow(PM, (0.28 + 0.2 * (E - B)));
                label41.Text = PM.ToString();
                label43.Text = TM.ToString();
            }
            else
            {
                MessageBox.Show("Заполните поля!");

            }



        }

        public void calculations()
        {
            double PM = 0;
            double TM = 0;
            double[] CD  =  ValueAssigment();

            if (radioButton2.Checked)
            {
                double EAF = 1;

                for (int i = 1; i < CD.Length; ++i)
                {
                    EAF *= CD[i];
                }
                if (textBox1.Text != String.Empty)
                {
                    PM = EAF * a * Math.Pow(Convert.ToDouble(textBox1.Text), b);
                    TM = c * Math.Pow(PM, d);
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            if (radioButton1.Checked)
            {
                if (textBox1.Text != String.Empty)
                {
                    PM = a * Math.Pow(Convert.ToDouble(textBox1.Text), b); //трудоемкость
                    TM = c * Math.Pow(PM,d); //время разработки в месяцах
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            if (textBox2.Text != String.Empty)
            {
                label13.Text = PM.ToString();
                label14.Text = TM.ToString();
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel11.Visible = true;
                panel12.Visible = true;
                
            }
            if (radioButton2.Checked)
            {
                panel11.Visible = true;
            }
            
        }
    }
}
