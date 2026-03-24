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

namespace FMIS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            login();
        }

        private void AddUserLog(string employeeName, string activity)
        {
            if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(activity))
            {
                MessageBox.Show("Employee name and activity cannot be empty.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();

                string query = @"INSERT INTO tblLogs
                         (logDate, userEmployeeName, activity)
                         VALUES
                         (@logDate, @userEmployeeName, @activity)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@logDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@userEmployeeName", employeeName.Trim());
                    cmd.Parameters.AddWithValue("@activity", activity.Trim());

                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void login()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd = new SqlCommand("Select * from tbl_login where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                Program.userType = dr["userType"].ToString();
                Program.userName = dr["employeeName"].ToString();
                Program.userStation = dr["station"].ToString();
                //MessageBox.Show(Program.userType);

                string activity = "Logged in";

                AddUserLog(Program.userName, activity);

                this.Hide();

                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();



                txtPassword.Text = String.Empty;
                txtUsername.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtPassword.Text = String.Empty;
            }

        }

        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (chkshow.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.ForeColor = Color.Black;
            }
            else
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.Black;
            }
        }


    }
}
