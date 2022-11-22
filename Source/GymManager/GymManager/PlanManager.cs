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
    public partial class PlanManager : Form
    {
        public PlanManager()
        {
            InitializeComponent();
        }

        //Connection to DB
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0S3NU2V;Initial Catalog=GymManager;Integrated Security=True");

        //Public Variables
        public int memberId;
        public int workoutId;

        // Clear All Data Inputs
        void clearAll()
        {
            txtExercise.Text = "";
            txtReps.Text = "";
            txtSets.Text = "";
        }

        //Update Data Grid View
        void UpdateDT()
        {
            try
            {
                String viewQuery = "select workoutId, exercise, reps, sets from tblWorkouts where memberId =" + memberId;
                SqlCommand command = new SqlCommand(viewQuery, con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvWorkout.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Validation Inputs
        private bool ValidateData()
        {
            bool validated = false;
            if(
                txtExercise.Text != "" &&
                txtReps.Text != "" &&
                txtSets.Text != ""
                )
            {
                validated = true;
            }
            return validated;
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

        private void txtReps_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSets_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtMemberId.Text != "" && txtMemberId.Text != "0")
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
                            clearAll();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            

                if (isMember)
                {
                    UpdateDT();
                }
            }            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    //Insert Query Output employeeId
                    String insertQuery = "insert into tblWorkouts (memberId, exercise, reps, sets, updated_at) output inserted.workoutId values ('" + memberId + "','" + txtExercise.Text + "','" + txtReps.Text + "','" + txtSets.Text + "', getdate())";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();
                    workoutId = (int)command.ExecuteScalar();
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
                MessageBox.Show("Please fill out all data to complete the action", "Add Exercise Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlanManager_Load(object sender, EventArgs e)
        {

        }

        private void txtExercise_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvWorkout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgvWorkout.Rows[index];
            workoutId = int.Parse(row.Cells[0].Value.ToString());
            txtExercise.Text = row.Cells[1].Value.ToString();
            txtReps.Text = row.Cells[2].Value.ToString();
            txtSets.Text = row.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(ValidateData() && workoutId != 0)
            {
                try
                {
                    //Update Query Output memberId
                    String updateQuery = "update tblWorkouts set exercise = '" + txtExercise.Text + "', reps = '" + txtReps.Text + "', sets = '" + txtSets.Text + "', updated_at = getdate() output inserted.workoutId where workoutId = " + workoutId;

                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    int employeeId = (int)command.ExecuteScalar();
                    MessageBox.Show("Your workout plan " + workoutId.ToString() + " has been updated.", "Update Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please fill out all data to complete the action", "Update Exercise Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(workoutId != 0)
            {
                String message = "Are you sure want to delete workout ID " + workoutId + " ?";
                String title = "Delete from Workout Plan";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Query for Data Delete
                        String deleteQuery = "delete tblWorkouts where workoutId = " + workoutId;
                        SqlCommand command = new SqlCommand(deleteQuery, con);

                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your Workout ID " + workoutId + " record has deleted successfully.", "Delete Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        workoutId = 0;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error info:" + ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                    UpdateDT();
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please click on exercise to complete the action", "Delete Exercise Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvWorkout.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "WorkoutPlan_"+ lblName.Text + "_" + DateTime.Now.ToString("d-M-yyyy") + ".pdf"; ;

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
                            PdfPTable pTable = new PdfPTable(dgvWorkout.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvWorkout.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in dgvWorkout.Rows)
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

                                Chunk text = new Chunk(lblName.Text + "\nWorkout Plan " + DateTime.Now.ToString("d-M-yyyy") + ".\n\n\n\n", FontFactory.GetFont("Calibri", 16));
                                Paragraph title = new Paragraph();
                                Paragraph footer = new Paragraph("\nGenerated by Gym Management System (Melanne Power Point)");
                                title.Add(text);
                                document.Add(title);
                                document.Add(pTable);
                                document.Add(footer);

                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Your Workout Plan has Exported Successfully.", "Export Successful !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
