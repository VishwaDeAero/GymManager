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
    public partial class MemberManager : Form
    {
        public MemberManager()
        {
            InitializeComponent();
        }

        //Public Variable
        public int memberID;

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

        // Update DataGrid
        void UpdateDT()
        {
            try
            {
                String viewQuery = "select memberId, name, dob, gender, weight, height, mobile_number from tblMembers where deleted_at is null";
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvMember.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //Search Function
        void SearchMember(int memberid)
        {
            try
            {
                String searchQuery = "select * from tblMembers where memberId = " + memberid + " and deleted_at is null";
                SqlCommand command = new SqlCommand(searchQuery, con);
                memberID = memberid;

                con.Open();
                SqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
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
                        txtWeight.Text = read["weight"].ToString();
                        txtHeight.Text = read["height"].ToString();
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

        // Clear Inputs
        void clearAll()
        {
            txtName.Text = "";
            txtDOB.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
        }

        // Check Validation
        private bool ValidateData()
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

                try
                {
                    //Insert Query Output memberId
                    String insertQuery = "insert into tblMembers (name, dob, gender, weight, height, address, mobile_number, created_at, updated_at) output inserted.memberId values ('" + txtName.Text + "','" + txtDOB.Text + "','" + gender + "','" + int.Parse(txtWeight.Text) + "','" + int.Parse(txtHeight.Text) + "','" + txtAddress.Text + "','" + txtMobile.Text + "', getdate(), getdate())";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();
                    memberID = (int)command.ExecuteScalar();
                    MessageBox.Show("Your member has registered successfully,\n The Member ID is " + memberID.ToString() + ".", "Registration Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
                UpdateDT();
                clearAll();
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Registration Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MemberManager_Load(object sender, EventArgs e)
        {
            UpdateDT();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMemberId.Text != "")
            {
                int searchId = int.Parse(txtMemberId.Text);
                SearchMember(searchId);
            }
            else
            {
                MessageBox.Show("Please fill out member ID to complete the action", "Search Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMemberId_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtMemberId_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Show Menu
            this.Hide();
            var menuForm = new GymMenu();
            menuForm.Closed += (s, args) => this.Close();
            menuForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData() && txtMemberId.Text != "")
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
                    //Update Query Output memberId
                    String updateQuery = "update tblMembers set name = '" + txtName.Text + "', dob = '" + txtDOB.Text + "', gender = '" + gender + "', weight = " + txtWeight.Text + ", height = " + txtHeight.Text + ", address = '" + txtAddress.Text + "', mobile_number = " + txtMobile.Text + ", updated_at = getdate() output inserted.memberId where memberId = " + txtMemberId.Text;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    memberID = (int)command.ExecuteScalar();
                    MessageBox.Show("Your details has updated successfully,\n The Member ID is " + memberID.ToString() + ".", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
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
            if (txtMemberId.Text != "")
            {
                String message = "Are you sure want to delete memberId " + txtMemberId.Text + " ?";
                String title = "Delete from System";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        String deleteQuery = "update tblMembers set deleted_at = getdate() where memberId = " + txtMemberId.Text;
                        SqlCommand command = new SqlCommand(deleteQuery, con);

                        con.Open();
                        command.ExecuteNonQuery();
                        memberID = int.Parse(txtMemberId.Text);
                        MessageBox.Show("Your Member ID " + memberID.ToString() + " details has deleted successfully.\n", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                    UpdateDT();
                    clearAll();
                    txtMemberId.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please fill out member ID to complete the action", "Delete Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvMember.Rows[index];
            memberID = int.Parse(row.Cells[0].Value.ToString());
            txtMemberId.Text = memberID.ToString();
            SearchMember(memberID);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvMember.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "ActiveMembersReport_"+ DateTime.Now.ToString("d-M-yyyy")+".pdf"; ;

                bool errormsg = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch(Exception ex)
                        {
                            errormsg = true;
                            MessageBox.Show("Error info:" + ex.Message, "Unable to Write Data in the Disk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!errormsg)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvMember.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach(DataGridViewColumn col in dgvMember.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach(DataGridViewRow viewRow in dgvMember.Rows)
                            {
                                foreach(DataGridViewCell dCell in viewRow.Cells)
                                {
                                    pTable.AddCell(dCell.Value.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Chunk text = new Chunk("Active Members Report " + DateTime.Now.ToString("d-M-yyyy") + ".\n\n\n\n", FontFactory.GetFont("Calibri", 16));
                                Paragraph title = new Paragraph();
                                Paragraph footer = new Paragraph("\nGenerated by Gym Management System (Melanne Power Point)");
                                title.Add(text);
                                document.Add(title);
                                document.Add(pTable);
                                document.Add(footer);

                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Your Member Report has Exported Successfully.\n", "Export Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex)
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
