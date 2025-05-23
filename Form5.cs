﻿using System;
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
    public partial class Form5: Form
    {
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        public Form5()
        {
            InitializeComponent();
            LoadFileFromExcelInactive();
            dgvResultIn.ForeColor = Color.Black;
        }

        public void LoadFileFromExcelInactive()
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[1];

            DataTable dt = new DataTable();
            dt = sheet.ExportDataTable();
            dgvResultIn.DataSource = dt;
        }

        private void btnActiveStud_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to move this student?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);



            if (result == DialogResult.Yes)
            {
                if (dgvResultIn.CurrentRow != null)
                {
                    MyLogs logs = new MyLogs();
                    logs.insertLog(DisplayIt.CurrentUser, "Transferred a inactive Student in the active list.");

                    int selectedRowIndex = dgvResultIn.CurrentRow.Index;


                    MoveStudentBetweenSheets(1, 0, selectedRowIndex);
                    LoadFileFromExcelInactive();
                    Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
                    if (form2 != null)
                    {
                        form2.LoadFileFromExcel();

                    }
                }
            }
        }

        private void lblReturn_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Return to homepage.");
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        public void MoveStudentBetweenSheets(int fromSheetIndex, int toSheetIndex, int rowIndexToMove)
        {

            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);

            Worksheet fromSheet = book.Worksheets[fromSheetIndex];
            Worksheet toSheet = book.Worksheets[toSheetIndex];

            int lastRow = toSheet.LastRow + 1;

            for (int col = 1; col <= fromSheet.LastColumn; col++)
            {
                var value = fromSheet.Range[rowIndexToMove + 2, col].Value ?? string.Empty;


                if (col == 13)
                {
                    value = (toSheetIndex == 0) ? "1" : "0";

                }
                toSheet.Range[lastRow, col].Text = value.ToString();
            }


            fromSheet.DeleteRow(rowIndexToMove + 2);

            book.SaveToFile(ExcelFilePath, ExcelVersion.Version2016);

            MessageBox.Show("The student has been successfully transferred!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Searched in the Inactive list.");

            string searchText = txtSearch2.Text.ToLower();
            bool foundMatch = false;

            if (string.IsNullOrEmpty(txtSearch2.Text))
            {
                MessageBox.Show("Please enter the cell you want to search.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            foreach (DataGridViewRow row in dgvResultIn.Rows)
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
                        cell.Style.BackColor = dgvResultIn.DefaultCellStyle.BackColor;
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

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch2.Text.ToLower();

            foreach (DataGridViewRow row in dgvResultIn.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = dgvResultIn.DefaultCellStyle.BackColor;
                }
            }
        }
    }
}
