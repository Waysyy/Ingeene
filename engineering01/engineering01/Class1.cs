using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engineering01
{
    public class Class1
    {
        
        public DataTable ConvertDGV(DataGridView dg)
        {
            DataTable ExportDataTable = new DataTable();
            foreach (DataGridViewColumn col in dg.Columns)
            {
                ExportDataTable.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dg.Rows)
            {
                DataRow dRow = ExportDataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                ExportDataTable.Rows.Add(dRow);
            }
            return ExportDataTable;
        }
        public bool ChekTable(DataGridView dataGrid, DataGridView dataGrid2, DataGridView dataGrid3, string typeCheck, int i1, int j1)
        {
            try
            {

                if (dataGrid != null)
                {
                    for (int i = i1; i < dataGrid.Columns.Count - 1; ++i)
                    {
                        for (int j = j1; j < dataGrid.Rows.Count - 1; ++j)
                        {
                            if(typeCheck == "double")
                            {
                                Convert.ToDouble(dataGrid.Rows[j].Cells[i].Value);
                            }
                            if(typeCheck == "string")
                            {
                                if(Convert.ToString(dataGrid.Rows[j].Cells[i].Value) == string.Empty || Convert.ToString(dataGrid.Rows[j].Cells[i].Value) == " ")
                                {
                                    return false;
                                }
                            }

                        }

                    }
                }
                if (dataGrid2 != null)
                {
                    for (int i = i1; i < dataGrid2.Columns.Count - 1; ++i)
                    {
                        for (int j = j1; j < dataGrid2.Rows.Count - 1; ++j)
                        {
                            if (typeCheck == "double")
                            {
                                Convert.ToDouble(dataGrid2.Rows[j].Cells[i].Value);
                            }
                            if (typeCheck == "string")
                            {
                                if (Convert.ToString(dataGrid2.Rows[j].Cells[i].Value) == string.Empty || Convert.ToString(dataGrid2.Rows[j].Cells[i].Value) == " ")
                                {
                                    return false;
                                }
                            }

                        }

                    }
                }
                if (dataGrid3 != null)
                {
                    for (int i = i1; i < dataGrid3.Columns.Count - 1; ++i)
                    {
                        for (int j = j1; j < dataGrid3.Rows.Count - 1; ++j)
                        {
                            if (typeCheck == "double")
                            {
                                Convert.ToDouble(dataGrid3.Rows[j].Cells[i].Value);
                            }
                            if (typeCheck == "string")
                            {
                                if (Convert.ToString(dataGrid3.Rows[j].Cells[i].Value) == string.Empty || Convert.ToString(dataGrid3.Rows[j].Cells[i].Value) == " ")
                                {
                                    return false;
                                }
                            }

                        }

                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
