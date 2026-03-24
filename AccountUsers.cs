using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FMIS
{
    public partial class AccountUsers : Form
    {
        public AccountUsers()
        {
            InitializeComponent();
        }

        private void AccountUsers_Load(object sender, EventArgs e)
        {
            icnEdit.Enabled = false;
            icnEditAccount.Enabled = false;
            icnAddAccount.Enabled = false;

            SelectALLUSERSDATA();
            if(Program.AccountUserID != null)
            {
                selectAccounts();
            }
            
        }

        void SelectALLUSERSDATA()
        {
            lvUsers.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblAccountUser ORDER BY userYear DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["userID"].ToString());

                lv.SubItems.Add(dr["userName"].ToString());
                lv.SubItems.Add(dr["userDept"].ToString());
                lv.SubItems.Add(dr["userYear"].ToString());
                lv.SubItems.Add(dr["status"].ToString());
                lvUsers.Items.Add(lv);

            }
            lvUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvUsers.Columns[0].Width = 0;
            lvUsers.Columns[4].Width = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void icnAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Text = "Add User";
            addUser.icnSave.Text = "Add";
            //addUser.icnSave.IconChar = Pen;
            addUser.Show();
        }

        private void icnEdit_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Text = "Edit User";
            addUser.icnSave.Text = "Edit";
            addUser.Show();
        }

        private void icnRefresh_Click(object sender, EventArgs e)
        {
            icnAdd.Enabled = true;
            icnEdit.Enabled = false;
            icnInactive.Enabled = false;
            icnEditAccount.Enabled = false;
            icnAddAccount.Enabled = false;
            SelectALLUSERSDATA();
            lvUserAccounts.Items.Clear();
        }

        string userStatus;
        private void lvUsers_MouseClick(object sender, MouseEventArgs e)
        {
            icnEditAccount.Enabled = false;
            icnAddAccount.Enabled = true;
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvUsers.SelectedItems[0];
                Program.AccountUserID = selectedItem.SubItems[0].Text;
                Program.auUserName = selectedItem.SubItems[1].Text.Trim();
                Program.auUserYear = selectedItem.SubItems[3].Text.Trim();
                //Program.UserID = selectedItem.SubItems[1].Text;
                userStatus = selectedItem.SubItems[4].Text;

                icnEdit.Enabled = true;
                icnAdd.Enabled = false;
                icnInactive.Enabled = true;

                if(userStatus == "INACTIVE")
                {
                    icnEdit.Enabled = false;
                    icnAdd.Enabled = false;
                    icnInactive.Enabled = false;
                }
            }
            selectAccounts();
        }

        void selectAccounts()
        {
            lvUserAccounts.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, u.userDept, a.accountName, ua.userAllocatedAmount, ua.userRemainingAmount, ua.userUsedAmount, u.userYear FROM tblUserAccounts ua INNER JOIN tblAccounts a ON ua.accountID = a.accountID INNER JOIN tblAccountUser u ON ua.userID = u.userID WHERE ua.userID = "+Program.AccountUserID + " ORDER BY a.accountName ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["userAccountID"].ToString());

                lv.SubItems.Add(dr["userName"].ToString());
                lv.SubItems.Add(dr["userDept"].ToString());
                lv.SubItems.Add(dr["accountName"].ToString());

                // Format with commas and 2 decimal places, no currency symbol
                lv.SubItems.Add(Convert.ToDecimal(dr["userAllocatedAmount"]).ToString("N2"));
                lv.SubItems.Add(Convert.ToDecimal(dr["userRemainingAmount"]).ToString("N2"));
                lv.SubItems.Add(Convert.ToDecimal(dr["userUsedAmount"]).ToString("N2"));

                lv.SubItems.Add(dr["userYear"].ToString());
                lvUserAccounts.Items.Add(lv);
            }

            lvUserAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvUserAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvUserAccounts.Columns[0].Width = 0;
            lvUserAccounts.Columns[1].Width = 0;
            lvUserAccounts.Columns[2].Width = 0;
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvUsers.SelectedItems[0];
                Program.AccountUserID = selectedItem.SubItems[0].Text;
                Program.accountYear = selectedItem.SubItems[3].Text;
                //Program.UserID = selectedItem.SubItems[1].Text;
                userStatus = selectedItem.SubItems[4].Text;

                icnEdit.Enabled = true;
                icnAdd.Enabled = false;
                icnInactive.Enabled = true;

                if (userStatus == "INACTIVE")
                {
                    icnEdit.Enabled = false;
                    icnAdd.Enabled = false;
                    icnInactive.Enabled = false;
                }

            }
        }

        private void AccountUsers_Activated(object sender, EventArgs e)
        {
            icnEdit.Enabled = false;
            icnEditAccount.Enabled = false;
            icnAddAccount.Enabled = false;
            SelectALLUSERSDATA();
            if(Program.AccountUserID != null)
            {
                selectAccounts();
            }
        }

        private void icnDelete_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        private void deleteUser()
        {

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("DELETE FROM tblAccountUser WHERE userID = @ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Program.AccountUserID);
                SqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Deleted!");

                string activity = "Deleted Account User Details: Account User ID: " + Program.AccountUserID + " User Name: " + Program.auUserName + " Year: " + Program.auUserYear;

                AddUserLog(Program.userName, activity);

                SelectALLUSERSDATA();
            }


        }

        private void icnDeleteAccount_Click(object sender, EventArgs e)
        {
            deleteAccount();
        }

        private void deleteAccount()
        {

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("DELETE FROM tblUserAccounts WHERE userAccountID = @ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Program.UserAccountsID);
                SqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Deleted!");

                string activity = "Deleted User Account Details: User Account ID: " + Program.UserAccountsID + " Account Name: " +Program.auUserAccountName+ " User Name: " + Program.auUserName + " Year: " + Program.auUserYear;

                AddUserLog(Program.userName, activity);

                selectAccounts();
            }


        }

        private void lvUserAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUserAccounts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvUserAccounts.SelectedItems[0];
                Program.UserAccountsID = selectedItem.SubItems[0].Text;
                Program.auUserAccountName = selectedItem.SubItems[3].Text;
                //Program.UserID = selectedItem.SubItems[1].Text;

                icnEditAccount.Enabled = true;
                icnAddAccount.Enabled = false;

            }
        }

        private void icnAddAccount_Click(object sender, EventArgs e)
        {
            AddUserAccount addUserAccount = new AddUserAccount();
            addUserAccount.Text = "Add Account";
            addUserAccount.Show();
        }

        private void icnEditAccount_Click(object sender, EventArgs e)
        {
            AddUserAccount addUserAccount = new AddUserAccount();
            addUserAccount.Text = "Edit Account";
            addUserAccount.Show();
        }

        private void icnRefreshAccount_Click(object sender, EventArgs e)
        {
            icnAddAccount.Enabled = true;
            icnEditAccount.Enabled = false;
            icnAddAccount.Enabled = false;
            selectAccounts();
            
        }

        private void lvUserAccounts_MouseClick(object sender, MouseEventArgs e)
        {
            icnEditAccount.Enabled = true;
            icnAddAccount.Enabled = false;
        }

        private void icnInactive_Click(object sender, EventArgs e)
        {
            inactive();
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

        void inactive()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to set this user to INACTIVE?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes) // proceed only if user clicks Yes
            {
                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    try
                    {
                        con.Open();
                        string query = "UPDATE tblAccountUser SET status = @status WHERE userID = @userID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@status", "INACTIVE");
                            cmd.Parameters.AddWithValue("@userID", Program.AccountUserID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User has been set to INACTIVE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string activity = "Updated status to INACTIVE! Account User Details: Account User ID: "+Program.AccountUserID+" User Name: "+Program.auUserName+" Year: "+Program.auUserYear;

                                AddUserLog(Program.userName, activity);
                            }
                            else
                            {
                                MessageBox.Show("No user found with the given ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void lvUsers_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
    }
}
