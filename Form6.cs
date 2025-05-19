using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;

namespace REYES_ARRAY
{
    public partial class Form6: Form
    {
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        public Form6()
        {

            InitializeComponent();
            LoadLogsFromExcel();
            dgvLogs.ForeColor = Color.Black;
        }

        public void LoadLogsFromExcel()
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[2];

            DataTable dt = new DataTable();
            dt = sheet.ExportDataTable();
            dgvLogs.DataSource = dt;
        }

        private void lblReturn_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Returned to homepage.");
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Searched in the active list.");
            string searchText = txtSearch2.Text.ToLower();
            bool foundMatch = false;

            if (string.IsNullOrEmpty(txtSearch2.Text))
            {
                MessageBox.Show("Please enter the cell you want to search.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            foreach (DataGridViewRow row in dgvLogs.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Split(' ').Contains(searchText))
                    {
                        cell.Style.BackColor = Color.Yellow;
                        foundMatch = true;
                    }
                    else
                    {
                        cell.Style.BackColor = dgvLogs.DefaultCellStyle.BackColor;
                    }
                }
            }

            if (foundMatch)
            {
                MessageBox.Show("Matching cells have been highlighted.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No matching cells found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
