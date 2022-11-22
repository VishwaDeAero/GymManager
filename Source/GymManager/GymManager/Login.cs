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
    public partial class Login : Form
    {
        public Login()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                String query = "select count(*) from tblUsers where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                int userCount = (int)command.ExecuteScalar();
                con.Close();
                if (userCount == 1)
                {
                    //Show Menu
                    this.Hide();
                    var menuForm = new GymMenu();
                    menuForm.Closed += (s, args) => this.Close();
                    menuForm.Show();
                    //MessageBox.Show("You have logged in to the system successfully","Login Successful !",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your Username or Password is Incorrect, Please Try Again.", "Login Failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Username or Password cannot be empty. Please fill all the details.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProviderLogin.SetError(txtUsername, "Username cannot be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProviderLogin.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderLogin.SetError(txtPassword, "Password cannot be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProviderLogin.SetError(txtPassword, "");
            }
        }
    }
}
