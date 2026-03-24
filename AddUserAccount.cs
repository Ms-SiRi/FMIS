using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FMIS
{
    public partial class AddUserAccount : Form
    {
        public AddUserAccount()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void alphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icnSave_Click(object sender, EventArgs e)
        {
            emptyFields();
        }

        private void emptyFields()
        {
            if (cmbAccountName.Text == "" || txtAllocatedAmount.Text == "" || txtRemainingAmount.Text == "" || txtUsedAmount.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                if (this.Text == "Add Account")
                {
                    saveUserAccount();
                }
                else if (this.Text == "Edit Account")
                {
                    updateUserAccount();
                }
            }
        }

        void saveUserAccount()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblUserAccounts(accountID,userID, userAllocatedAmount, userRemainingAmount, userUsedAmount) VALUES (@accountID,@userID,@userAllocatedAmount, @userRemainingAmount, @userUsedAmount)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                // Parse and validate numeric inputs
                decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


                cmd.Parameters.AddWithValue("@accountID", Program.AccountID);
                cmd.Parameters.AddWithValue("@userID", Program.AccountUserID);
                cmd.Parameters.AddWithValue("@userAllocatedAmount", allocatedAmount);
                cmd.Parameters.AddWithValue("@userRemainingAmount", remainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", usedAmount);
                cmd.ExecuteNonQuery();
            }

            string activity = "Created new User Account - User Name: "
                + Program.auUserName
                + " | Account Name: " + cmbAccountName.Text
                + " | User Year: " + Program.auUserYear                
                + " | Allocated Amount: " + txtAllocatedAmount.Text
                + " | Used Amount: " + txtUsedAmount.Text
                + " | Remaining Amount: " + txtRemainingAmount.Text;


            AddUserLog(Program.userName, activity);

            MessageBox.Show("Account Added!");
            dataClear();
            this.Close();
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

        void updateUserAccount()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET accountID = @accountID,userID = @userID, userAllocatedAmount = @userAllocatedAmount, userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.UserAccountsID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                // Parse and validate numeric inputs
                decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


                cmd.Parameters.AddWithValue("@accountID", Program.AccountID);
                cmd.Parameters.AddWithValue("@userID", Program.AccountUserID);
                cmd.Parameters.AddWithValue("@userAllocatedAmount", allocatedAmount);
                cmd.Parameters.AddWithValue("@userRemainingAmount", remainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", usedAmount);
                cmd.ExecuteNonQuery();
            }

            string activity = "Updated User Account - User Name: "
                + Program.auUserName
                + " | Account Name: " + cmbAccountName.Text
                + " | User Year: " + Program.auUserYear
                + " | Allocated Amount: " + txtAllocatedAmount.Text
                + " | Used Amount: " + txtUsedAmount.Text
                + " | Remaining Amount: " + txtRemainingAmount.Text;


            AddUserLog(Program.userName, activity);

            MessageBox.Show("Account Updated!");
            dataClear();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsedAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAllocatedAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemainingAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpAllocatedAmount_Enter(object sender, EventArgs e)
        {

        }

        private void grpRemainingAmount_Enter(object sender, EventArgs e)
        {

        }

        private void grpAccountName_Enter(object sender, EventArgs e)
        {

        }

        private void AddUserAccount_Load(object sender, EventArgs e)
        {

            if (this.Text == "Add Account")
            {
                txtAccountYear.Enabled = false;
                txtAccountYear.Text = Program.accountYear;
                dataClear();
                LoadComboBoxAccount();
                totalUsedBudget();
            }
            else if (this.Text == "Edit Account")
            {
                txtAccountYear.Enabled = false;
                txtAccountYear.Text = Program.accountYear;
                cmbAccountName.Enabled = false;
                SelectACCOUNTDATA();
                getAccountID();
                totalUsedBudget();
                remainingAmountComputation();
                //LoadComboBoxAccount();
            }
        }

        private void LoadComboBoxAccount()
        {
            string accountYear = txtAccountYear.Text;
            // Query to get data
            string query = "SELECT DISTINCT(accountName), accountID, accountYear FROM tblAccounts WHERE accountYear = '"+accountYear+"' ORDER BY accountName ASC";

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add account names to the ComboBox
                                cmbAccountName.Items.Add(reader["accountName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        void SelectACCOUNTDATA()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, u.userDept, a.accountName, ua.userAllocatedAmount, ua.userRemainingAmount, ua.userUsedAmount, u.userYear FROM tblUserAccounts ua INNER JOIN tblAccounts a ON ua.accountID = a.accountID INNER JOIN tblAccountUser u ON ua.userID = u.userID WHERE ua.userAccountID = " + Program.UserAccountsID ;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbAccountName.Text = dr["accountName"].ToString();
                txtAllocatedAmount.Text = dr["userAllocatedAmount"].ToString();
                txtRemainingAmount.Text = dr["userRemainingAmount"].ToString();
                txtRemainingAmount.Text = dr["userUsedAmount"].ToString();
            }

        }

        void dataClear()
        {
            cmbAccountName.Text = "";
            txtAllocatedAmount.Text = "0";
            txtRemainingAmount.Text = "0";
            txtUsedAmount.Text = "0";
        }

        private void cmbAccountName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getAccountID();
            dataClear();
        }

        private void getAccountID()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define query with a parameter placeholder
                String query = "SELECT accountID FROM tblAccounts WHERE accountName = @accountName AND accountYear = @accountYear";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@accountName", cmbAccountName.Text);
                    cmd.Parameters.AddWithValue("@accountYear", txtAccountYear.Text);

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            //MessageBox.Show(dr["accountID"].ToString());
                            // Retrieve accountID and assign it
                            Program.AccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }
        }

        private void txtAllocatedAmount_KeyUp(object sender, KeyEventArgs e)
        {
            remainingAmountComputation();
        }

        void remainingAmountComputation()
        {
            // Validate input for txtAllocated and txtUsed
            if (decimal.TryParse(txtAllocatedAmount.Text, out decimal allocated) &&
                decimal.TryParse(txtUsedAmount.Text, out decimal used))
            {
                // Calculate the remaining balance
                decimal remaining = allocated - used;

                // Update the remaining textbox
                txtRemainingAmount.Text = remaining.ToString("N2"); // Format with two decimal places
            }
            else
            {
                // Clear remaining textbox if input is invalid
                txtRemainingAmount.Text = string.Empty;
            }
        }

        void totalUsedBudget()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT SUM(amount) as usedBudget FROM tblBudget WHERE tblBudget.userAccountID = "+Program.UserAccountsID;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                object result = dr["usedBudget"];
                if (result != DBNull.Value)
                {
                    double budget = Convert.ToDouble(result);
                    txtUsedAmount.Text = string.Format("{0:n}", budget);
                }
                else
                {
                    txtUsedAmount.Text = "0"; // or another default value
                }

            }
        }

        private void AddUserAccount_Activated(object sender, EventArgs e)
        {
            //dataClear();
        }

        private void grpRemainingAmount_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtAllocatedAmount_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtAccountYear_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtAccountYear_KeyDown(object sender, KeyEventArgs e)
        {
            dataClear();
            LoadComboBoxAccount();
            totalUsedBudget();
        }

        private void cmbAccountName_MouseEnter(object sender, EventArgs e)
        {
            dataClear();
            LoadComboBoxAccount();
            totalUsedBudget();
        }
    }
}
