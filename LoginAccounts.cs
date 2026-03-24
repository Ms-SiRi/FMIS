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
    public partial class LoginAccounts : Form
    {
        public LoginAccounts()
        {
            InitializeComponent();
        }

        private void LoginAccounts_Load(object sender, EventArgs e)
        {
            LoadLoginAccounts();
            icnSave.Enabled = true;
            icnEdit.Enabled = false;
            icnDelete.Enabled = false;
        }

        private void LoadLoginAccounts()
        {
            lvLoginAccounts.Items.Clear();

            string query = "SELECT * FROM tbl_login";

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["ID"].ToString());
                    item.SubItems.Add(reader["employeeID"].ToString());
                    item.SubItems.Add(reader["username"].ToString());
                    item.SubItems.Add(reader["password"].ToString());
                    item.SubItems.Add(reader["employeeName"].ToString());
                    item.SubItems.Add(reader["userType"].ToString());
                    item.SubItems.Add(reader["station"].ToString());

                    lvLoginAccounts.Items.Add(item);
                }
            }

            lvLoginAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvLoginAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvLoginAccounts.Columns[0].Width = 0;   // hide ID
        }

        private void lvLoginAccounts_MouseClick(object sender, MouseEventArgs e)
        {
            icnSave.Enabled = false;
            icnEdit.Enabled = true;
            icnDelete.Enabled = true;

            if (lvLoginAccounts.SelectedItems.Count > 0)
            {
                ListViewItem item = lvLoginAccounts.SelectedItems[0];

                Program.laAccountID = Convert.ToInt32(item.SubItems[0].Text);
                txtEmployeeID.Text = item.SubItems[1].Text;
                txtUsername.Text = item.SubItems[2].Text;
                txtPassword.Text = item.SubItems[3].Text;
                txtEmployeeName.Text = item.SubItems[4].Text;
                cmbUserType.Text = item.SubItems[5].Text;
                cmbStation.Text = item.SubItems[6].Text;
            }
        }

        private void icnRefresh_Click(object sender, EventArgs e)
        {
            icnSave.Enabled = true;
            icnEdit.Enabled = false;
            icnDelete.Enabled = false;
            Clear();
        }

        void Clear()
        {
            Program.laAccountID = 0;

            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            cmbUserType.SelectedIndex = 0;
            cmbStation.SelectedIndex = 0;
        }

        private void icnSave_Click(object sender, EventArgs e)
        {
            SaveLoginAccount();
        }

        private void SaveLoginAccount()
        {
            // Validate empty fields
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(cmbUserType.Text) ||
                string.IsNullOrWhiteSpace(cmbStation.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();

                string query = @"INSERT INTO tbl_login
                        (employeeID, username, password, employeeName, userType, station)
                        VALUES
                        (@employeeID, @username, @password, @employeeName, @userType, @station)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeeName", txtEmployeeName.Text.Trim());
                    cmd.Parameters.AddWithValue("@userType", cmbUserType.Text);
                    cmd.Parameters.AddWithValue("@station", cmbStation.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Account saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Clear();
            LoadLoginAccounts();
        }

        private void icnEdit_Click(object sender, EventArgs e)
        {
            EditLoginAccount();
        }

        private void EditLoginAccount()
        {
            if (Program.laAccountID <= 0)
            {
                MessageBox.Show("Please select an account to edit.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate empty fields
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(cmbUserType.Text) ||
                string.IsNullOrWhiteSpace(cmbStation.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();

                string query = @"UPDATE tbl_login SET
                            employeeID = @employeeID,
                            username = @username,
                            password = @password,
                            employeeName = @employeeName,
                            userType = @userType,
                            station = @station
                         WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeeName", txtEmployeeName.Text.Trim());
                    cmd.Parameters.AddWithValue("@userType", cmbUserType.Text);
                    cmd.Parameters.AddWithValue("@station", cmbStation.Text);
                    cmd.Parameters.AddWithValue("@id", Program.laAccountID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Clear();
            LoadLoginAccounts();
        }

        private void icnDelete_Click(object sender, EventArgs e)
        {
            DeleteLoginAccount();
        }

        private void DeleteLoginAccount()
        {
            if (Program.laAccountID <= 0)
            {
                MessageBox.Show("Please select an account to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();

                string query = "DELETE FROM tbl_login WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Program.laAccountID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Account deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Clear();
            LoadLoginAccounts();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
