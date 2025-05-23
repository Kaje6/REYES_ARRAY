﻿using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace REYES_ARRAY
{
    public partial class Form2: Form
    {
        Form4 frm4;
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        public Form2()
        {
            frm4 = new Form4();
            InitializeComponent();
            LoadFileFromExcel();
            dgvResult.ForeColor = Color.Black;
        }

        public void LoadFileFromExcel()
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[0];

            DataTable dt = new DataTable();
            dt = sheet.ExportDataTable();
            dgvResult.DataSource = dt;
        }

        public void UpdateToExcel(int ID, string name, string gender, string sports, string address, string email, string birthday, string age, string favColor, string user, string pass, string saying, string course, string status, string profile)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[0];

            int id = ID + 2;
            sheet.Range[id, 1].Value = name;
            sheet.Range[id, 2].Value = gender;
            sheet.Range[id, 3].Value = sports;
            sheet.Range[id, 4].Value = address;
            sheet.Range[id, 5].Value = email;
            sheet.Range[id, 6].Value = birthday;
            sheet.Range[id, 7].Value = age;
            sheet.Range[id, 8].Value = favColor;
            sheet.Range[id, 9].Value = user;
            sheet.Range[id, 10].Value = pass;
            sheet.Range[id, 11].Value = saying;
            sheet.Range[id, 12].Value = course;
            sheet.Range[id, 13].Value = status;
            sheet.Range[id, 14].Value = profile;

            book.SaveToFile(ExcelFilePath);

            int dgvIndex = ID;
            dgvResult.Rows[dgvIndex].Cells[0].Value = name;
            dgvResult.Rows[dgvIndex].Cells[1].Value = gender;
            dgvResult.Rows[dgvIndex].Cells[2].Value = sports;
            dgvResult.Rows[dgvIndex].Cells[3].Value = address;
            dgvResult.Rows[dgvIndex].Cells[4].Value = email;
            dgvResult.Rows[dgvIndex].Cells[5].Value = birthday;
            dgvResult.Rows[dgvIndex].Cells[6].Value = age;
            dgvResult.Rows[dgvIndex].Cells[7].Value = favColor;
            dgvResult.Rows[dgvIndex].Cells[8].Value = user;
            dgvResult.Rows[dgvIndex].Cells[9].Value = pass;
            dgvResult.Rows[dgvIndex].Cells[10].Value = saying;
            dgvResult.Rows[dgvIndex].Cells[11].Value = course;
            dgvResult.Rows[dgvIndex].Cells[11].Value = status;

        }

        private void dgvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form4 frm4 = new Form4();
            Form1 frm1 = new Form1();

            int r = dgvResult.CurrentCell.RowIndex;
         
            frm1.lblID.Text = r.ToString();
            string name = dgvResult.Rows[r].Cells[0].Value.ToString();
            string gender = dgvResult.Rows[r].Cells[1].Value.ToString();
            string sports = dgvResult.Rows[r].Cells[2].Value.ToString();
            string address = dgvResult.Rows[r].Cells[3].Value.ToString();
            string email = dgvResult.Rows[r].Cells[4].Value.ToString();
            string birthday = dgvResult.Rows[r].Cells[5].Value.ToString();
            string age = dgvResult.Rows[r].Cells[6].Value.ToString();
            string favColor = dgvResult.Rows[r].Cells[7].Value.ToString();
            string user = dgvResult.Rows[r].Cells[8].Value.ToString();
            string pass = dgvResult.Rows[r].Cells[9].Value.ToString();
            string saying = dgvResult.Rows[r].Cells[10].Value.ToString();
            string course = dgvResult.Rows[r].Cells[11].Value.ToString();
            string status = dgvResult.Rows[r].Cells[12].Value.ToString();
            string profile = dgvResult.Rows[r].Cells[13].Value.ToString();

            profile = frm4.lblProfPathHolder.Text;
          

            frm1.UpdateTextFields(r, name, gender, sports, address, email, birthday, age, favColor, user, pass, saying, course, status, profile);
            frm1.btnAdd.Visible = false;
            frm1.btnBrowse.Visible = false;
            frm1.lblProfile.Visible = false;
            frm1.txtProfilePath.Visible = false;
            frm1.btnUpdate.Visible = true;
            frm1.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Searched in the active list.");
            string searchText = txtSearch.Text.ToLower();
            bool foundMatch = false;

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please enter the cell you want to search.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            foreach (DataGridViewRow row in dgvResult.Rows)
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
                        cell.Style.BackColor = dgvResult.DefaultCellStyle.BackColor;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = dgvResult.DefaultCellStyle.BackColor;
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Clicked Add another user.");
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void lblReturn_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Returned to homepage.");
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

        private void btnInactiveStud_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to move this student?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (dgvResult.CurrentRow != null)
                {
                    int selectedRowIndex = dgvResult.CurrentRow.Index;


                    MoveStudentBetweenSheets(0, 1, selectedRowIndex);
                    LoadFileFromExcel();
                    Form5 form5 = Application.OpenForms.OfType<Form5>().FirstOrDefault();
                    if (form5 != null)
                    {
                        form5.LoadFileFromExcelInactive();
                    }
                    MyLogs logs = new MyLogs();
                    logs.insertLog(DisplayIt.CurrentUser, "Transferred a active student to the inactive list.");
                }
            }
        }
    }
}
