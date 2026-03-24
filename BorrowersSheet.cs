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
using System.Xml.Linq;

namespace FMIS
{
    public partial class BorrowersSheet : Form
    {
        public BorrowersSheet()
        {
            InitializeComponent();
        }

        //private void txtAccountYear_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void icnReturn_Click(object sender, EventArgs e)
        {
            emptyFields();
        }

        private void txtBorrowedAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAvailable_TextChanged(object sender, EventArgs e)
        {

        }

        private void BorrowersSheet_Load(object sender, EventArgs e)
        {
            if(Program.borrowerStatus == "BORROW")
            {
                icnBorrow.Visible = true;
                icnReturn.Visible = false;
                icnTransfer.Visible = false;
                label1.Text = Program.borrowerLabel.ToString();
            }
            else if(Program.borrowerStatus == "RETURN")
            {
                icnTransfer.Visible = false;
                icnReturn.Visible = true;
                icnBorrow.Visible = false;
                label1.Text = Program.borrowerLabel.ToString();
            }
            else if (Program.borrowerStatus == "TRANSFER")
            {
                icnTransfer.Visible = true;
                icnReturn.Visible = false;
                icnBorrow.Visible = false;
                label1.Text = Program.borrowerLabel.ToString();
            }

            Program.bYear = DateTime.Now.Year.ToString();

            fromUsers();
            
            toUsers();

        }

        void fromUsers()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userYear = @year", con);
                cmd.Parameters.AddWithValue("@year", Program.bYear);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbFrom.DataSource = table;
                cmbFrom.DisplayMember = "userName";
            }
        }

        void toUsers()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userYear = @year", con);
                cmd.Parameters.AddWithValue("@year", Program.bYear);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbTo.DataSource = table;
                cmbTo.DisplayMember = "userName";
            }
        }

        

        void getBorrowerUserID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userID FROM tblAccountUser WHERE userYear = @year AND userName = @userName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", cmbTo.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", selectedYear);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.borrowerUserID = dr["userID"].ToString();
                        }
                    }
                }
            }
        }

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLenderUserID();
            getLenderAccounts();

            getLenderAccountID();
            getLenderUserAccountID();
            lenderRemainingAmount();

            getBorrowerUserID();
            getBorrowerAccounts();

            getBorrowerAccountID();
            getBorrowerUserAccountID();
            borrowerAllocatedAmount();
        }

        void getLenderUserID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userID FROM tblAccountUser WHERE userYear = @year AND userName = @userName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", cmbFrom.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", selectedYear);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.lenderUserID = dr["userID"].ToString();
                        }
                    }
                }
            }
        }

        private void getLenderAccounts()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, 
                                u.userDept, a.accountName, a.PR, a.Voucher, 
                                ua.userAllocatedAmount, ua.userRemainingAmount, 
                                ua.userUsedAmount, u.userYear 
                         FROM tblUserAccounts ua 
                         INNER JOIN tblAccounts a ON ua.accountID = a.accountID 
                         INNER JOIN tblAccountUser u ON ua.userID = u.userID 
                         WHERE ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Program.lenderUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    cmbFromAccount.DataSource = table;
                    cmbFromAccount.DisplayMember = "accountName";
                }
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBorrowerUserID();
            getBorrowerAccounts();

            getLenderAccountID();
            getLenderUserAccountID();
            lenderRemainingAmount();

            getBorrowerAccountID();
            getBorrowerUserAccountID();
            borrowerAllocatedAmount();
        }

        private void getBorrowerAccounts()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, 
                                u.userDept, a.accountName, a.PR, a.Voucher, 
                                ua.userAllocatedAmount, ua.userRemainingAmount, 
                                ua.userUsedAmount, u.userYear 
                         FROM tblUserAccounts ua 
                         INNER JOIN tblAccounts a ON ua.accountID = a.accountID 
                         INNER JOIN tblAccountUser u ON ua.userID = u.userID 
                         WHERE ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Program.borrowerUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    cmbToAccount.DataSource = table;
                    cmbToAccount.DisplayMember = "accountName";
                }
            }
        }

        private void cmbFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBorrowedAmount.Text = "0";

            getLenderAccountID();
            getLenderUserAccountID();
            lenderRemainingAmount();
            
            getBorrowerAccountID();
            getBorrowerUserAccountID();
            borrowerAllocatedAmount();

            //MessageBox.Show(Program.borrowerAllocatedAmount.ToString());
        }

        void getLenderAccountID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT accountID FROM tblAccounts WHERE accountName = @accountName AND accountYear = @accountYear";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@accountName", cmbFromAccount.Text.Trim());
                    cmd.Parameters.AddWithValue("@accountYear", Program.bYear.Trim());

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.lenderAccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }
        }

        void getBorrowerAccountID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT accountID FROM tblAccounts WHERE accountName = @accountName AND accountYear = @accountYear";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@accountName", cmbToAccount.Text.Trim());
                    cmd.Parameters.AddWithValue("@accountYear", Program.bYear.Trim());

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.borrowerAccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }
        }

        public void lenderRemainingAmount()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userAccountID", Program.lenderUserAccountID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["userRemainingAmount"] != DBNull.Value)
                                {
                                    double amount = Convert.ToDouble(dr["userRemainingAmount"]);
                                    txtAvailable.Text = string.Format("{0:n}", amount);
                                    Program.lenderRemainingAmount = Convert.ToDecimal(amount);
                                }
                                else
                                {
                                    txtAvailable.Text = "0.00";
                                }

                                if (dr["userAllocatedAmount"] != DBNull.Value)
                                {
                                    double amount = Convert.ToDouble(dr["userAllocatedAmount"]);
                                    Program.lenderAllocatedAmount = Convert.ToDecimal(amount);
                                }
                                else
                                {
                                    txtAvailable.Text = "0.00";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (optional: log error, show message, etc.)
                        txtAvailable.Text = "0.00";
                    }
                }
            }
        }

        public void borrowerAllocatedAmount()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userAccountID", Program.borrowerUserAccountID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["userRemainingAmount"] != DBNull.Value)
                                {
                                    double amount = Convert.ToDouble(dr["userRemainingAmount"]);
                                    //txtAvailable.Text = string.Format("{0:n}", amount);
                                    Program.borrowerRemainingAmount = Convert.ToDecimal(amount);
                                }

                                if (dr["userAllocatedAmount"] != DBNull.Value)
                                {
                                    double amount = Convert.ToDouble(dr["userAllocatedAmount"]);
                                    Program.borrowerAllocatedAmount = Convert.ToDecimal(amount);
                                }
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (optional: log error, show message, etc.)
                        txtAvailable.Text = "0.00";
                    }
                }
            }
        }

        void getLenderUserAccountID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAccountID FROM tblUserAccounts WHERE userID = @userID AND accountID = @accountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userID", Program.lenderUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.lenderAccountID);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.lenderUserAccountID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }

        void getBorrowerUserAccountID()
        {
            if (Program.bYear == null || !int.TryParse(Program.bYear.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAccountID FROM tblUserAccounts WHERE userID = @userID AND accountID = @accountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userID", Program.borrowerUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.borrowerAccountID);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.borrowerUserAccountID = dr["userAccountID"].ToString();
                            //MessageBox.Show(Program.borrowerUserAccountID.ToString());
                        }
                    }
                }
            }
        }

        private void txtBorrowedAmount_Enter(object sender, EventArgs e)
        {
            Program.bsSavedCost = txtBorrowedAmount.Text;
            txtBorrowedAmount.Text = string.Empty;

            if (decimal.TryParse(Program.bsSavedCost, out decimal result))
            {
                Program.bsReturnCost = Convert.ToSingle(result);

            }
        }

        private void txtBorrowedAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (decimal.TryParse(txtAvailable.Text, out decimal result))
            {
                Program.bsAvailableAmount = Convert.ToDecimal(result);
            }
            
            try
            {
                if (Program.bsAvailableAmount < Convert.ToInt32(txtBorrowedAmount.Text))
                {
                    MessageBox.Show("Insufficient Balance! Remaining Balance: " + txtAvailable.Text);
                    txtBorrowedAmount.Text = string.Empty;
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void txtBorrowedAmount_Leave(object sender, EventArgs e)
        {
            if (txtBorrowedAmount.TextLength <= 0)
            {
                txtBorrowedAmount.Text = Program.bsReturnCost.ToString();
                txtBorrowedAmount.Text = string.Format("{0:n}", double.Parse(txtBorrowedAmount.Text));
                if (decimal.TryParse(txtBorrowedAmount.Text, out decimal result))
                {
                    Program.bsConvertedCost = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtBorrowedAmount.Text = string.Format("{0:n}", double.Parse(txtBorrowedAmount.Text));
                if (decimal.TryParse(txtBorrowedAmount.Text, out decimal result))
                {
                    Program.bsConvertedCost = Convert.ToDecimal(result);
                }
            }            
        }

        private void icnTransfer_Click(object sender, EventArgs e)
        {
            emptyFieldsTransfer();
        }

        private void emptyFields()
        {
            if (cmbFrom.Text == "" || cmbTo.Text == "" || cmbFromAccount.Text == "" || txtAvailable.Text == "" || txtBorrowedAmount.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                //if (Program.borrowerStatus == "BORROW")
                //{
                //    borrowFund();
                //    borrowerLogs();
                //}
                //else if (Program.borrowerStatus == "RETURN")
                //{
                //    returnFund();
                //    borrowerLogs();
                //}

                transferFund();
                borrowerLogs();
            }
        }

        private void emptyFieldsTransfer()
        {
            if (cmbFrom.Text == "" || cmbTo.Text == "" || cmbFromAccount.Text == "" || txtAvailable.Text == "" || txtBorrowedAmount.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                //if (Program.borrowerStatus == "BORROW")
                //{
                //    borrowFund();
                //    borrowerLogs();
                //}
                //else if (Program.borrowerStatus == "RETURN")
                //{
                //    returnFund();
                //    borrowerLogs();
                //}

                //transferFund();
                updateBorrowerAllocation();
                borrowerLogs();
            }
        }

        void transferFund()
        {
            updateBorrowerAllocation();
            updateLenderAllocation();
            
        }

        void updateBorrowerAllocation()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userAllocatedAmount = @userAllocatedAmount, userRemainingAmount = @userRemainingAmount WHERE userAccountID =" + Program.borrowerUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAllocatedAmount", Program.borrowerAllocatedAmount + Program.bsConvertedCost);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.borrowerRemainingAmount + Program.bsConvertedCost);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Fund Transferred!");
            this.Close();
        }

        void updateLenderAllocation()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userAllocatedAmount = @userAllocatedAmount, userRemainingAmount = @userRemainingAmount WHERE userAccountID =" + Program.lenderUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAllocatedAmount", Program.lenderAllocatedAmount - Program.bsConvertedCost);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.lenderRemainingAmount - Program.bsConvertedCost);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Fund Reduced!");
            this.Close();
        }

        void returnFund()
        {
            
        }

        void borrowerLogs()
        {
            string date = dtDate.Value.ToString("MM/dd/yyyy hh:mm");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBorrowerSheet(date, status,bFrom, bTo, fromAccount, toAccount, availableAmount, borrowedAmount, remarks, userType) VALUES (@date, @status,@bFrom,@bTo, @fromAccount, @toAccount, @availableAmount, @borrowedAmount, @remarks, @userType)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@status", Program.borrowerStatus);
                cmd.Parameters.AddWithValue("@bFrom", cmbFrom.Text);
                cmd.Parameters.AddWithValue("@bTo", cmbTo.Text);
                cmd.Parameters.AddWithValue("@fromAccount", cmbFromAccount.Text);
                cmd.Parameters.AddWithValue("@toAccount", cmbToAccount.Text);
                cmd.Parameters.AddWithValue("@availableAmount", Convert.ToDecimal(txtAvailable.Text));
                cmd.Parameters.AddWithValue("@borrowedAmount", Program.bsConvertedCost);
                cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@userType", Program.userName);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Recorded!");
            this.Close();
        }

        private void cmbToAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBorrowedAmount.Text = "0";

            getLenderAccountID();
            getLenderUserAccountID();
            lenderRemainingAmount();
            
            getBorrowerAccountID();
            getBorrowerUserAccountID();
            borrowerAllocatedAmount();
        }

        private void icnBorrow_Click(object sender, EventArgs e)
        {
            emptyFields();
        }
    }
}
