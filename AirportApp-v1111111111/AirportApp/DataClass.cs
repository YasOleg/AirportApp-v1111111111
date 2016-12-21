using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace AirportApp
{
    public static class DataClass
    {
        public static void dataAdd(string lines)
        {
            try
            {
                FileStream fileStream = new FileStream("Airport_INFO.txt", FileMode.Append);//запись в конец файла
                StreamWriter strWriter = new StreamWriter(fileStream);
                strWriter.Write("\r\n" + lines);
                strWriter.Close();
                MessageBox.Show("Information added", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        public static void DataRead(DataGridView dataGridView1)
        {
            DataSet dsSet = new DataSet();
            StreamReader strReader = new StreamReader("Airport_INFO.txt");
            dsSet.Tables.Add(new DataTable());
            string header = strReader.ReadLine();

            string[] colName = System.Text.RegularExpressions.Regex.Split(header, ",");

            for (int i = 0; i < colName.Length; i++)
            {
                dsSet.Tables[0].Columns.Add(colName[i]);
            }
            string row = strReader.ReadLine();
            while (row != null)
            {
                string[] rowValue = System.Text.RegularExpressions.Regex.Split(row, "/");
                dsSet.Tables[0].Rows.Add(rowValue);
                row = strReader.ReadLine();
            }

            dataGridView1.DataSource = dsSet.Tables[0];
            strReader.Close();
        }

    }
}
