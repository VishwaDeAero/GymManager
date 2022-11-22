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
    public partial class InstructorManager : Form
    {
        public InstructorManager()
        {
            InitializeComponent();
        }

        //Public Variable
        public int instructorID;

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
        private bool ValidateInstructorData()
        {
            bool validated = false;

            if (
                txtName.Text != "" &&
                txtDOB.Text != "" &&
                txtAddress.Text != ""
                )
            {
                if (rdbMale.Checked == true || rdbFemale.Checked == true)
                {
                    validated = true;
                }
            }
            return validated;
        }

        private bool ValidateShiftData()
        {
            bool validated = false;

            if (
                cmbDay.Text != "" &&
                cmbShift.Text != ""
                )
            {
                validated = true;
            }
            return validated;
        }

        // Instructor Data Grid View
        void UpdateDTI()
        {
            try
            {
                String viewQuery = "select instructorId, name, address, mobile_number from tblInstructors where deleted_at is null";
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dti = new DataTable();
                sd.Fill(dti);
                dgvInstructor.DataSource = dti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        // Shifts Data Grid View
        void UpdateDTS(int instructorId)
        {
            try
            {
                String viewQuery = "select shiftId, day, shift from tblShift where instructorId = " + instructorId;
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dts = new DataTable();
                sd.Fill(dts);
                dgvShift.DataSource = dts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Search Function
        void SearchInstructor(int searchId)
        {
            String searchQuery = "select * from tblInstructors where instructorId = " + searchId + " and deleted_at is null";
            SqlCommand command = new SqlCommand(searchQuery, con);

            con.Open();
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                try
                {
                    while (read.Read())
                    {
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
                        lblInstructorName.Text = read["name"].ToString();
                        instructorID = searchId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else
            {
                lblInstructorName.Text = "";
                instructorID = 0;
                clearAll();
            }
            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Show Menu
            this.Hide();
            var menuForm = new GymMenu();
            menuForm.Closed += (s, args) => this.Close();
            menuForm.Show();
        }

        private void txtInstructorId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnInsertInstructor_Click(object sender, EventArgs e)
        {
            if (ValidateInstructorData())
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

                try
                {
                    //Insert Query Output memberId
                    String insertQuery = "insert into tblInstructors (name, dob, gender, address, mobile_number, created_at, updated_at) output inserted.instructorId values ('" + txtName.Text + "','" + txtDOB.Text + "','" + gender + "','" + txtAddress.Text + "','" + txtMobile.Text + "', getdate(), getdate())";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();
                    instructorID = (int)command.ExecuteScalar();
                    MessageBox.Show("Your Instructor has registered successfully,\n The Instructor ID is " + instructorID.ToString() + ".", "Registration Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblInstructorName.Text = txtName.Text;
                UpdateDTI();
                UpdateDTS(instructorID);
                clearAll();
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Registration Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void InstructorManager_Load(object sender, EventArgs e)
        {
            UpdateDTI();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtInstructorId.Text != "")
            {
                int searchId = int.Parse(txtInstructorId.Text);
                SearchInstructor(searchId);
                UpdateDTS(searchId);
            }
            else
            {
                MessageBox.Show("Please fill out the Instructor ID to complete the action", "Search Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnUpdateInstructor_Click(object sender, EventArgs e)
        {
            if (ValidateInstructorData() && txtInstructorId.Text != "")
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

                try
                {
                    //Update Query Output instructorId
                    String updateQuery = "update tblInstructors set name = '" + txtName.Text + "', dob = '" + txtDOB.Text + "', gender = '" + gender + "', address = '" + txtAddress.Text + "', mobile_number = " + txtMobile.Text + ", updated_at = getdate() output inserted.instructorId where instructorId = " + txtInstructorId.Text;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    int memberId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your details has updated successfully,\n The Member ID is " + memberId.ToString() + ".", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDTI();
                lblInstructorName.Text = txtName.Text;
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Update Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            if (txtInstructorId.Text != "" && txtInstructorId.Text != "0")
            {
                String message = "Are you sure want to delete InstructorId " + txtInstructorId.Text + " ?";
                String title = "Delete from System";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        String deleteQuery = "update tblInstructors set deleted_at = getdate() where instructorId = " + txtInstructorId.Text;
                        String deleteShiftQuery = "delete from tblShift where instructorId = " + txtInstructorId.Text;
                        SqlCommand command = new SqlCommand(deleteQuery, con);
                        SqlCommand command2 = new SqlCommand(deleteShiftQuery, con);
                        con.Open();
                        command.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        instructorID = int.Parse(txtInstructorId.Text);
                        MessageBox.Show("Your Instructor ID " + instructorID.ToString() + " details has deleted successfully.\n", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateDTI();
                    UpdateDTS(instructorID);
                    clearAll();
                    txtInstructorId.Text = "";
                    lblInstructorName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please fill out the Instructor ID to complete the action", "Delete Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void dgvInstructor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvInstructor.Rows[index];
            int instructorId = int.Parse(row.Cells[0].Value.ToString());
            txtInstructorId.Text = instructorId.ToString();
            SearchInstructor(instructorId);
            UpdateDTS(instructorID);
        }

        //Shift Details---------------------------------------------------------------------------

        //Allocation Count
        void checkAllocation() {
            String day = cmbDay.Text;
            String shift = cmbShift.Text;

            try
            {
                //Shift Query Output Count
                String shiftQuery = "select count(*) from tblShift where day = '" + day + "' and shift = '" + shift + "'";

                SqlCommand command = new SqlCommand(shiftQuery, con);
                con.Open();
                int AllocationCount = (int)command.ExecuteScalar();
                con.Close();
                lblInstructorCount.Text = AllocationCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnInsertShift_Click(object sender, EventArgs e)
        {
            if (ValidateShiftData())
            {
                String day = cmbDay.Text;
                String shift = cmbShift.Text;

                try
                {
                    //Insert Query Output memberId
                    String insertQuery = "insert into tblShift (instructorId, day, shift, created_at, updated_at) output inserted.shiftId values ('" + instructorID + "','" + day + "','" + shift + "', getdate(), getdate())";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();
                    int shiftId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your shift has allocated successfully,\n The Shift ID is " + shiftId.ToString() + ".", "Allocation Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    lblShiftId.Text = shiftId.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDTS(instructorID);
                checkAllocation();
            }
            else
            {
                MessageBox.Show("Please fill out all shift data to complete the action", "Insert Shift Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateShift_Click(object sender, EventArgs e)
        {
            if (ValidateShiftData() && lblShiftId.Text != "")
            {
                String day = cmbDay.Text;
                String shift = cmbShift.Text;

                try
                {
                    //Update Query Output instructorId
                    String updateQuery = "update tblShift set day = '" + day + "', shift = '" + shift + "', updated_at = getdate() output inserted.shiftId where shiftId = " + lblShiftId.Text;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    int shiftId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your shift has updated successfully,\n The Shift ID is " + shiftId.ToString() + ".", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDTS(instructorID);
                checkAllocation();
            }
            else
            {
                MessageBox.Show("Please fill out all shift data to complete the action", "Update Shift Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            if(lblShiftId.Text != "" && lblShiftId.Text != "0")
            {
                String message = "Are you sure want to delete Shift ID " + lblShiftId.Text + " ?";
                String title = "Delete from Instructors' Shifts";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Query for Data Delete
                        String deleteQuery = "delete tblShift where shiftId = " + lblShiftId.Text;

                        SqlCommand command = new SqlCommand(deleteQuery, con);
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your Shift ID " + lblShiftId.Text + " record has deleted successfully.", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblShiftId.Text = "";
                        lblInstructorCount.Text = "";
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateDTS(instructorID);
                    cmbDay.Text = "";
                    cmbShift.Text = "";
                    checkAllocation();
                }
            }
            else
            {
                MessageBox.Show("Please select any shift to complete the action", "Delete Shift Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvShift.Rows[index];
            int shiftId = int.Parse(row.Cells[0].Value.ToString());
            lblShiftId.Text = shiftId.ToString();
            cmbDay.Text = row.Cells[1].Value.ToString();
            cmbShift.Text = row.Cells[2].Value.ToString();
            checkAllocation();
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDay.Text != "" && cmbShift.Text != "")
            {
                checkAllocation();
            }
            else
            {
                lblInstructorCount.Text = "";
            }          
        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDay.Text != "" && cmbShift.Text != "")
            {
                checkAllocation();
            }
            else
            {
                lblInstructorCount.Text = "";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvInstructor.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "ActiveInstructorsReport_" + DateTime.Now.ToString("d-M-yyyy") + ".pdf"; ;

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
                            PdfPTable pTable = new PdfPTable(dgvInstructor.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvInstructor.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in dgvInstructor.Rows)
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

                                Chunk text = new Chunk("Active Instructors Report " + DateTime.Now.ToString("d-M-yyyy") + ".\n\n\n\n", FontFactory.GetFont("Calibri", 16));
                                Paragraph title = new Paragraph();
                                Paragraph footer = new Paragraph("\nGenerated by Gym Management System (Melanne Power Point)");
                                title.Add(text);
                                document.Add(title);
                                document.Add(pTable);
                                document.Add(footer);

                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Your Instructor Report has Exported Successfully.\n", "Export Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
