using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager
{
    public partial class GymMenu : Form
    {
        public GymMenu()
        {
            InitializeComponent();
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

        private void btnMembermenu_Click(object sender, EventArgs e)
        {
            //Show Member Management
            this.Hide();
            var memberForm = new MemberManager();
            memberForm.Show();
        }

        private void btnEmployeemenu_Click(object sender, EventArgs e)
        {
            //Show Employee Management
            this.Hide();
            var employeeForm = new EmployeeManager();
            employeeForm.Show();
        }

        private void btnWorkoutmenu_Click(object sender, EventArgs e)
        {
            //Show Workout Plans Management
            this.Hide();
            var workoutForm = new PlanManager();
            workoutForm.Show();
        }

        private void btnInstructormenu_Click(object sender, EventArgs e)
        {
            //Show Instructor Management
            this.Hide();
            var instructorForm = new InstructorManager();
            instructorForm.Show();
        }

        private void btnTimemenu_Click(object sender, EventArgs e)
        {
            //Show Instructor Management
            this.Hide();
            var timeslotForm = new TimeSlotManager();
            timeslotForm.Show();
        }
    }
}
