using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GymManager
{
    public partial class EmployeeManager : Form
    {
        public EmployeeManager()
        {
            InitializeComponent();
        }

        //Connection to DB
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0S3NU2V;Initial Catalog=GymManager;Integrated Security=True");

        //Exit Program
        public static void Exit()
        {
            const string message = "Are you sure want to close the system ?";
            const string title = "Exit from System";
            var result = MessageBox.Show(message, title,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        //Update Data Grid View
        void UpdateDT()
        {
            try
            {
                String viewQuery = "select employeeId, name, dob, gender, mobile_number from tblEmployees where deleted_at is null";
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvEmployee.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Clear All Data Inputs
        void clearAll()
        {
            txtName.Text = "";
            txtDOB.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtAddress.Text = "";
            txtMobile.Text = "";
        }

        // Check Validation
        private bool ValidateData()
        {
            bool validated = false;

            if(
                txtName.Text != "" &&
                txtDOB.Text != "" &&
                txtAddress.Text != ""
                )
            {
                if(rdbMale.Checked == true || rdbFemale.Checked == true)
                {
                    validated = true;
                }
            }
            return validated;
        }

        //Search Function
        void SearchEmployee(int employeeId)
        {
            try {
                String searchQuery = "select * from tblEmployees where employeeId = " + employeeId + " and deleted_at is null";
                SqlCommand command = new SqlCommand(searchQuery, con);

                con.Open();
                SqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        txtEmployeeId.Text = read["employeeId"].ToString();
                        txtName.Text = read["name"].ToString();
                        txtDOB.Text = read["dob"].ToString();
                        if (read["gender"].ToString() == "Male")
                        {
                            rdbMale.Checked = true;
                        }
                        else if (read["gender"].ToString() == "Female")
                        {
                            rdbFemale.Checked = true;
                        }
                        txtAddress.Text = read["address"].ToString();
                        txtMobile.Text = read["mobile_number"].ToString();
                    }
                }
                else
                {
                    clearAll();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            UpdateDT();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Show Menu
            this.Hide();
            var menuForm = new GymMenu();
            menuForm.Closed += (s, args) => this.Close();
            menuForm.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                String gender = "";
                if (rdbMale.Checked == true)
                {
                    gender = "Male";
                }
                else if (rdbFemale.Checked == true)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "-";
                }

                try {
                    //Insert Query Output employeeId
                    String insertQuery = "insert into tblEmployees (name, dob, gender, address, mobile_number, created_at, updated_at) output inserted.employeeId values ('" + txtName.Text + "','" + txtDOB.Text + "','" + gender + "','" + txtAddress.Text + "','" + txtMobile.Text + "', getdate(), getdate())";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();
                    int employeeId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your employee has registered successfully,\n The Employee ID is " + employeeId.ToString() + ".", "Registration Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    UpdateDT();
                    clearAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Registration Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData() && txtEmployeeId.Text != "")
            {
                String gender = "";
                if (rdbMale.Checked == true)
                {
                    gender = "Male";
                }
                else if (rdbFemale.Checked == true)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "-";
                }

                try {
                    //Update Query Output memberId
                    String updateQuery = "update tblEmployees set name = '" + txtName.Text + "', dob = '" + txtDOB.Text + "', gender = '" + gender + "', address = '" + txtAddress.Text + "', mobile_number = " + txtMobile.Text + ", updated_at = getdate() output inserted.employeeId where employeeId = " + txtEmployeeId.Text;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    int employeeId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your details has updated successfully,\n The Employee ID is " + employeeId.ToString() + ".", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch(Exception ex) {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                UpdateDT();
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Update Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtEmployeeId.Text != "")
            {
                String message = "Are you sure want to delete Employee ID " + txtEmployeeId.Text + " ?";
                String title = "Delete from System";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        //Delete Query
                        String deleteQuery = "update tblEmployees set deleted_at = getdate() where employeeId = " + txtEmployeeId.Text;

                        SqlCommand command = new SqlCommand(deleteQuery, con);
                        con.Open();
                        command.ExecuteNonQuery();
                        int employeeId = int.Parse(txtEmployeeId.Text);
                        MessageBox.Show("Your Employee ID " + employeeId.ToString() + " details has deleted successfully.\n", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        UpdateDT();
                        clearAll();
                        txtEmployeeId.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter employee ID to complete this action", "Delete Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int searchId = int.Parse(txtEmployeeId.Text);
            SearchEmployee(searchId);
        }

        private void txtEmployeeId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmployeeId_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[index];
            int employeeId = int.Parse(row.Cells[0].Value.ToString());

            SearchEmployee(employeeId);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "ActiveEmployeesReport_" + DateTime.Now.ToString("d-M-yyyy") + ".pdf"; ;

                bool errormsg = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            errormsg = true;
                            MessageBox.Show("Error info:" + ex.Message, "Unable to Write Data in the Disk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!errormsg)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvEmployee.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvEmployee.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in dgvEmployee.Rows)
                            {
                                foreach (DataGridViewCell dCell in viewRow.Cells)
                                {
                                    pTable.AddCell(dCell.Value.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Chunk text = new Chunk("Active Employees Report " + DateTime.Now.ToString("d-M-yyyy") + ".\n\n\n\n", FontFactory.GetFont("Calibri", 16));
                                Paragraph title = new Paragraph();
                                Paragraph footer = new Paragraph("\nGenerated by Gym Management System (Melanne Power Point)");
                                title.Add(text);
                                document.Add(title);
                                document.Add(pTable);
                                document.Add(footer);

                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Your Employee Report has Exported Successfully.\n", "Export Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error info:" + ex.Message, "Unable to Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No records found in table to export.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
