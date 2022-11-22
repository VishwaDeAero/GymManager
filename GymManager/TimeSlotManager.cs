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

namespace GymManager
{
    public partial class TimeSlotManager : Form
    {
        public TimeSlotManager()
        {
            InitializeComponent();
        }

        //Connection to DB
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0S3NU2V;Initial Catalog=GymManager;Integrated Security=True");

        //Public Variables
        public int memberId;
        public int timeslotId;

        // Clear All Data Inputs
        void clearAll()
        {
            cmbDay.Text = "";
            cmbTimeSlot.Text = "";
        }

        //Update Data Grid View
        void UpdateDT()
        {
            try
            {
                String viewQuery = "select timeslotId, day, timeslot from tblTimeSlots where memberId =" + memberId;
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvTimeSlot.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info: (UpdateDT)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //Validate Timeslot Data
        private bool ValidateData()
        {
            bool validated = false;

            if (
                cmbDay.Text != "" &&
                cmbTimeSlot.Text != ""
                )
            {
                validated = true;
            }
            return validated;
        }

        //Allocation Count
        void checkAllocation()
        {
            String day = cmbDay.Text;
            String timeslot = cmbTimeSlot.Text;

            try
            {
                //Timeslot Query Output Count
                String timeslotQuery = "select count(*) from tblTimeSlots where day = '" + day + "' and timeslot = '" + timeslot + "'";
                SqlCommand command = new SqlCommand(timeslotQuery, con);

                con.Open();
                int AllocationCount = (int)command.ExecuteScalar();
                con.Close();
                lblMemberCount.Text = AllocationCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info: (checkAllocation)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtMemberId.Text != "")
            {
                memberId = int.Parse(txtMemberId.Text);                

                bool isMember = false;

                try
                {
                    String searchQuery = "select * from tblMembers where memberId = " + memberId + " and deleted_at is null";
                    SqlCommand command = new SqlCommand(searchQuery, con);

                    con.Open();
                    SqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            lblName.Text = read["name"].ToString();
                            isMember = true;
                        }
                    }
                    else
                    {
                        const string message = "Your Member ID is not found in the system. Do you want to add new member instead ?";
                        const string title = "Member Not Found";
                        var result = MessageBox.Show(message, title,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Show Member Manager
                            this.Hide();
                            var memberForm = new MemberManager();
                            memberForm.Closed += (s, args) => this.Close();
                            memberForm.Show();
                        }
                        else
                        {
                            memberId = 0;
                            txtMemberId.Text = "";
                            lblName.Text = "";
                            clearAll();
                        }
                    }
                    lblMemberCount.Text = "0";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info: (Search)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (isMember)
                {
                    UpdateDT();
                }
            }
            else
            {
                MessageBox.Show("Please fill out member ID to complete the action", "Search Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(ValidateData() && memberId != 0)
            {
                try
                {
                    //Insert Query Output employeeId
                    String insertQuery = "insert into tblTimeSlots (memberId, day, timeslot, updated_at) output inserted.timeslotId values ('" + memberId + "','" + cmbDay.Text + "','" + cmbTimeSlot.Text + "', getdate())";
                    SqlCommand command = new SqlCommand(insertQuery, con);

                    con.Open();
                    timeslotId = (int)command.ExecuteScalar();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info: (Insert)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                checkAllocation();
                UpdateDT();
                clearAll();
            }
            else
            {
                MessageBox.Show("Please fill out all data to complete the action", "Add Time Slot Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData() && timeslotId != 0)
            {
                try
                {
                    //Update Query Output memberId
                    String updateQuery = "update tblTimeSlots set day = '" + cmbDay.Text + "', timeslot = '" + cmbTimeSlot.Text + "', updated_at = getdate() output inserted.timeslotId where timeslotId = " + timeslotId;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    int employeeId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your time slot ID " + timeslotId.ToString() + " has been updated.", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info: (Update)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                checkAllocation();
                UpdateDT();
            }
            else
            {
                MessageBox.Show("Please click on the timeslot and fill out all data to complete the action", "Update Time Slot Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (timeslotId != 0)
            {
                String message = "Are you sure want to delete time slot ID " + timeslotId + " ?";
                String title = "Delete from Time Plan";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Query for Data Delete
                        String deleteQuery = "delete tblTimeSlots where timeslotId = " + timeslotId;
                        SqlCommand command = new SqlCommand(deleteQuery, con);

                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your time slot ID " + timeslotId + " record has deleted successfully.", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        timeslotId = 0;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info: (Delete)" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    checkAllocation();
                    UpdateDT();
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please click on the time slot to complete the action", "Delete Time Slot Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void dgvTimeSlot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvTimeSlot.Rows[index];
            timeslotId = int.Parse(row.Cells[0].Value.ToString());
            cmbDay.Text = row.Cells[1].Value.ToString();
            cmbTimeSlot.Text = row.Cells[2].Value.ToString();          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDay.Text != "" && cmbTimeSlot.Text != "")
            {
                checkAllocation();
            }
            else
            {
                lblMemberCount.Text = "";
            }
        }

        private void cmbTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDay.Text != "" && cmbTimeSlot.Text != "")
            {
                checkAllocation();
            }
            else
            {
                lblMemberCount.Text = "";
            }
        }
    }
}
