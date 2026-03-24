using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing;
using System.Drawing.Printing;

namespace FMIS
{
    public partial class EditVoucher : Form
    {
        public EditVoucher()
        {
            InitializeComponent();
        }

        private void alphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAccountID();
            getUserAccountID();

            // MessageBox.Show(comboSource.Text.ToString());
            //// Get Account ID first
            //string retrievedAccountID = getAccountID();

            // Debugging: Check if Account ID is retrieved
            //if (string.IsNullOrEmpty(retrievedAccountID))
            //{
            //    MessageBox.Show("Account ID is not retrieved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; // Stop execution if no account ID
            //}

            //Program.evAccountID = retrievedAccountID;

            //// Get User Account ID
            //getUserAccountID();

            //sourceTypeDeterminer();
        }


        private string getAccountID()
        {
            
            string accountID = null;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT accountID FROM tblAccounts WHERE accountYear = '"+txtUserYear.Text+"' AND accountName = @AccountName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccountName", comboSource.Text.Trim());

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.evAccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }

            return accountID;

        }

        private void getUserAccountID()
        {
            // Check if Account ID is set before executing
            if (string.IsNullOrEmpty(Program.evAccountID))
            {
                MessageBox.Show("Cannot retrieve User Account ID because Account ID is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAccountID FROM tblUserAccounts WHERE userID = @userID AND accountID = @accountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userID", Program.evAccountUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.evAccountID);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.evUserAccountID = dr["userAccountID"].ToString();
                        }
                        else
                        {
                            Program.evUserAccountID = null;
                        }
                    }
                }
            }
        }

        string sourceType;
        private void sourceTypeDeterminer()
        {            
            switch (Program.PRType)
            {
                case 1:
                    {
                        if (comboSource.SelectedIndex == 0)
                        {
                            Program.sourcetypedeterminer = "travexloc";
                        }
                        if (comboSource.SelectedIndex == 1)
                        {
                            Program.sourcetypedeterminer = "trainingex";
                        }
                        if (comboSource.SelectedIndex == 2)
                        {
                            Program.sourcetypedeterminer = "telex";
                        }
                        if (comboSource.SelectedIndex == 3)
                        {
                            Program.sourcetypedeterminer = "internetsubex";
                        }
                        if (comboSource.SelectedIndex == 4)
                        {
                            Program.sourcetypedeterminer = "consultancyser";
                        }
                        if (comboSource.SelectedIndex == 5)
                        {
                            Program.sourcetypedeterminer = "mdco";
                        }
                        if (comboSource.SelectedIndex == 6)
                        {
                            Program.sourcetypedeterminer = "fol";
                        }
                        if (comboSource.SelectedIndex == 7)
                        {
                            Program.sourcetypedeterminer = "ogs";
                        }
                        if (comboSource.SelectedIndex == 8)
                        {
                            Program.sourcetypedeterminer = "travexfor";
                        }
                        if (comboSource.SelectedIndex == 9)
                        {
                            Program.sourcetypedeterminer = "lss";
                        }
                        if (comboSource.SelectedIndex == 10)
                        {
                            Program.sourcetypedeterminer = "fbp";
                        }
                        if (comboSource.SelectedIndex == 11)
                        {
                            Program.sourcetypedeterminer = "advertisingex";
                        }
                        if (comboSource.SelectedIndex == 12)
                        {
                            Program.sourcetypedeterminer = "subsex";
                        }
                        if (comboSource.SelectedIndex == 13)
                        {
                            Program.sourcetypedeterminer = "jo";
                        }
                        if (comboSource.SelectedIndex == 14)
                        {
                            Program.sourcetypedeterminer = "swr";
                        }
                        if (comboSource.SelectedIndex == 15)
                        {
                            Program.sourcetypedeterminer = "swc";
                        }
                        if (comboSource.SelectedIndex == 16)
                        {
                            Program.sourcetypedeterminer = "pera";
                        }
                        if (comboSource.SelectedIndex == 17)
                        {
                            Program.sourcetypedeterminer = "repallowance";
                        }
                        if (comboSource.SelectedIndex == 18)
                        {
                            Program.sourcetypedeterminer = "transpoallowance";
                        }
                        if (comboSource.SelectedIndex == 19)
                        {
                            Program.sourcetypedeterminer = "clothing";
                        }
                        if (comboSource.SelectedIndex == 20)
                        {
                            Program.sourcetypedeterminer = "ot";
                        }
                        if (comboSource.SelectedIndex == 21)
                        {
                            Program.sourcetypedeterminer = "yearend";
                        }
                        if (comboSource.SelectedIndex == 22)
                        {
                            Program.sourcetypedeterminer = "cashgift";
                        }
                        if (comboSource.SelectedIndex == 23)
                        {
                            Program.sourcetypedeterminer = "obam";
                        }
                        if (comboSource.SelectedIndex == 24)
                        {
                            Program.sourcetypedeterminer = "obaa";
                        }
                        if (comboSource.SelectedIndex == 25)
                        {
                            Program.sourcetypedeterminer = "retirement";
                        }
                        if (comboSource.SelectedIndex == 26)
                        {
                            Program.sourcetypedeterminer = "pagibig";
                        }
                        if (comboSource.SelectedIndex == 27)
                        {
                            Program.sourcetypedeterminer = "philhealth";
                        }
                        if (comboSource.SelectedIndex == 28)
                        {
                            Program.sourcetypedeterminer = "ecip";
                        }
                        if (comboSource.SelectedIndex == 29)
                        {
                            Program.sourcetypedeterminer = "tlb";
                        }
                        if (comboSource.SelectedIndex == 30)
                        {
                            Program.sourcetypedeterminer = "opbm";
                        }
                        if (comboSource.SelectedIndex == 31)
                        {
                            Program.sourcetypedeterminer = "opbl";
                        }
                        if (comboSource.SelectedIndex == 32)
                        {
                            Program.sourcetypedeterminer = "opbpei";
                        }
                        if (comboSource.SelectedIndex == 33)
                        {
                            Program.sourcetypedeterminer = "cstre";
                        }
                        if (comboSource.SelectedIndex == 34)
                        {
                            Program.sourcetypedeterminer = "qa";
                        }
                        break;
                    }
                case 2:
                    {
                        if (comboSource.SelectedIndex == 0)
                        {
                            Program.sourcetypedeterminer = "fol";
                        }
                        if (comboSource.SelectedIndex == 1)
                        {
                            Program.sourcetypedeterminer = "rmte";
                        }
                        break;
                    }
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAttachObR_Click(object sender, EventArgs e)
        {

        }

        private void txtObRLoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtParticulars_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getUserID();
            getUsers();
        }

        private void getUsers()
        {
            if (comboDept.SelectedIndex == 0)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+txtUserYear.Text+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                txtUsers.DataSource = table;
                txtUsers.DisplayMember = "userName";
            }

            if (comboDept.SelectedIndex == 1)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '" + txtUserYear.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                txtUsers.DataSource = table;
                txtUsers.DisplayMember = "userName";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPayee_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVoucherYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVoucherCounter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVoucherType_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pdfView_Load(object sender, EventArgs e)
        {

        }

        private void gbVoucher_Enter(object sender, EventArgs e)
        {

        }

        private void EditVoucher_Load(object sender, EventArgs e)
        {
            comboDept.SelectedIndex = 0;
            getUsers();

            if (Program.userType == "superadmin")
            {
                comboDept.Enabled = true;
                txtUsers.Enabled = true;
                comboSource.Enabled = true;

            }
            else
            {
                comboDept.Enabled = false;
                txtUsers.Enabled = false;
                comboSource.Enabled = false;

            }

            retrieveVoucherDetails();
            //loadDocument();
            generateVoucherQR();
            sourceTypeDeterminer();

            LoadOldVoucherDetails();


            voucherCtrl.Text = txtVoucherCtrl.Text.Trim();
            voucherDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            voucherSP.Text = "SP_VGO";
            
        }

        // voucher old values (similar to PR vars)
        private int oldeVUserAccountID;
        private decimal oldCost;
        private decimal oldeVAllocatedAmount;
        private decimal oldeVUsedAmount;
        private decimal oldeVRemainingAmount;

        void LoadOldVoucherDetails()
        {
            // Step 1: Find the userAccountID & amount linked to this voucher via tblBudget
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"
            SELECT TOP 1 b.userAccountID, b.amount
            FROM tblBudget b
            INNER JOIN tblVoucher v 
                ON b.controlNumber = v.voucherControlNumber 
            WHERE v.voucherID = @voucherID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@voucherID", Program.voucherid);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oldeVUserAccountID = dr["userAccountID"] != DBNull.Value ? Convert.ToInt32(dr["userAccountID"]) : 0;
                            oldCost = dr["amount"] != DBNull.Value ? Convert.ToDecimal(dr["amount"]) : 0m;
                        }
                    }
                }
            }

            // Step 2: Load that user’s allocation balances from tblUserAccounts
            if (oldeVUserAccountID > 0)
            {
                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    ISNULL(userAllocatedAmount, 0)   AS userAllocatedAmount,
                    ISNULL(userUsedAmount, 0)        AS userUsedAmount,
                    ISNULL(userRemainingAmount, 0)   AS userRemainingAmount
                FROM tblUserAccounts
                WHERE userAccountID = @userAccountID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userAccountID", oldeVUserAccountID);
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oldeVAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                                oldeVUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                                oldeVRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                            }
                        }
                    }
                }
            }
        }


        private void generateVoucherQR()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
                Margin = 0
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;


            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(txtVoucherCtrl.Text.Trim()));
            qrVoucherPic.Image = result;

        }

        void retrieveVoucherDetails()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "Select * FROM tblVoucher WHERE voucherID = '" + Program.voucherid + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                string userYearData = dr["userYear"].ToString();
                if (userYearData == "")
                {
                    //MessageBox.Show("NULL");
                    txtUserYear.Text = Convert.ToDateTime(dr["date"]).ToString("yyyy");
                }
                else
                {
                    //MessageBox.Show("NOT NULL");
                    txtUserYear.Text = (dr["userYear"]).ToString();
                }

                txtVoucherCtrl.Text = dr["voucherControlNumber"].ToString();
                txtPayee.Text = dr["payee"].ToString();
                comboDept.Text = dr["department"].ToString();
                txtUsers.Text = dr["endUser"].ToString();
                comboSource.Text = dr["source"].ToString();
                txtAmount.Text = dr["amount"].ToString();
                txtParticulars.Text = dr["remarks"].ToString();
                voucherDate.Text = DateTime.Parse(dr["date"].ToString()).ToShortDateString();
                voucherCtrl.Text = dr["voucherControlNumber"].ToString();
                Program.convertedCost = Convert.ToDecimal(dr["amount"].ToString());
                Program.PRType = 1;
                oldCost = Convert.ToDecimal(dr["amount"].ToString());
            }
        }

        void loadDocument()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT * FROM tblFiles WHERE controlNumber = @ctrlID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ctrlID", Program.vouchercontrolnumber);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //  webBrowser1.Visible = true;
                        string fName = reader["filename"].ToString();
                        byte[] pdfData = (byte[])reader["data"];
                        string extension = reader["extension"].ToString();

                        // Save PDF data to a temporary file
                        string tempFilePath = Path.Combine(Path.GetTempPath(), $"{fName}.{extension}");
                        File.WriteAllBytes(tempFilePath, pdfData);

                        // Load the PDF file in the WebBrowser control
                        //webBrowser.Navigate(tempFilePath);

                        System.Diagnostics.Process.Start(tempFilePath);

                        Console.WriteLine(tempFilePath);
                    }
                    else
                    {
                        MessageBox.Show("PDF not found in the database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void icnOpen_Click(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void icnVoucherSave_Click(object sender, EventArgs e)
        {
            
            UpdateVoucher();
            UpdateVoucherBudget();
            getUserID();
            getAccountID();
            getUserAccountID();
            Allocation();

            if (oldeVUserAccountID.ToString() == Program.evUserAccountID)
            {
                updateUserRemainingAmount();
            }
            else
            {
                RestoreOldVoucherAllocation();
                updateNewUserRemainingAmount();
            }
            
        }

        //void UpdateVoucher()
        //{
        //    string date = DateTime.Now.ToString("yyyy-MM-dd");

        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    SqlCommand cmd;
        //    String query = "UPDATE tblVoucher SET amount = @amount WHERE voucherID = @id";
        //    con.Open();

        //    using (cmd = new SqlCommand(query, con))
        //    {
        //        cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
        //        cmd.Parameters.AddWithValue("@id", Program.voucherid);
        //        cmd.ExecuteNonQuery();
        //    }

        //    MessageBox.Show("Updated!");
        //    this.Close();
        //}

        void UpdateVoucher()
        {

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblVoucher SET " +
                               "payee = @payee, " +
                               "department = @dept, " +
                               "endUser = @endUser, " +
                               "source = @source, " +
                               "amount = @amount, " +
                               "remarks = @remarks, " +                               
                               "status = @status " +
                               "WHERE voucherID = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@payee", txtPayee.Text);
                    cmd.Parameters.AddWithValue("@dept", comboDept.Text);
                    cmd.Parameters.AddWithValue("@endUser", txtUsers.Text);
                    cmd.Parameters.AddWithValue("@source", comboSource.Text);
                    cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@remarks", txtParticulars.Text);

                    // Always conclude as Done
                    cmd.Parameters.AddWithValue("@status", "Done");

                    cmd.Parameters.AddWithValue("@id", Program.voucherid);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    string activity = "Edited Voucher - ControlNumber: " + txtVoucherCtrl.Text
                    + " | Payee: " + txtPayee.Text
                    + " | Name: " + txtUsers.Text
                    + " | Dept: " + comboDept.Text
                    + " | Source: " + comboSource.Text
                    + " | Amount: " + Program.convertedCost
                    + " | Remarks: " + txtParticulars.Text;

                    AddUserLog(Program.userName, activity);

                    MessageBox.Show(rowsAffected > 0 ? "Updated!" : "No record found for this voucher.");
                    this.Close();
                }
            }
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


        void UpdateVoucherBudget()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string year = DateTime.Now.ToString("yyyy");

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblBudget SET " +
                               "Name = @Name, " +
                               "Department = @Dept, " +
                               Program.sourcetypedeterminer + " = @source, " +
                               "year = @year, " +
                               "date = @date, " +
                               "description = @description, " +
                               "source = @filesource, " +
                               "amount = @amount, " +
                               "userAccountID = @userAccountID " + // ✅ added
                               "WHERE controlNumber = @ctrlnum";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ctrlnum", Program.vouchercontrolnumber); // matches saveBudget
                    cmd.Parameters.AddWithValue("@Name", txtUsers.Text);                    // from voucher form
                    cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                    cmd.Parameters.AddWithValue("@source", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@description", txtParticulars.Text);
                    cmd.Parameters.AddWithValue("@filesource", comboSource.Text);
                    cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@userAccountID", Program.evUserAccountID); // ✅ use voucher’s userAccountID

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Voucher Budget Updated!");
        }


        void Allocation()
        {

            //string year = dateTimePicker1.Value.ToString("yyyy");
            //string user = comboUser.Text;
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.evUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read()) // Check if there's a row available
                {
                    if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.evRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                    }
                    else
                    {
                        Program.evRemainingAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userUsedAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.evUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                    }
                    else
                    {
                        Program.evUsedAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userAllocatedAmount"] != DBNull.Value) // Check if the value is NULL
                    {

                        Program.evAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                    }
                    else
                    {
                        Program.evAllocatedAmount = 0.00m; // Use 'm' for decimal literals
                    }
                }
                else
                {
                    Program.evRemainingAmount = 0.00m; // Default value when no rows are found
                    Program.evUsedAmount = 0.00m;
                    Program.evAllocatedAmount = 0.00m;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        // 1. Restore the old user's voucher allocation
        void RestoreOldVoucherAllocation()
        {
            // old values from Program.* or variables you set on form load
            decimal restoredUsed = oldeVUsedAmount - oldCost;
            decimal restoredRemaining = oldeVAllocatedAmount - restoredUsed;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblUserAccounts " +
                               "SET userUsedAmount = @used, userRemainingAmount = @remaining " +
                               "WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@used", restoredUsed);
                    cmd.Parameters.AddWithValue("@remaining", restoredRemaining);
                    cmd.Parameters.AddWithValue("@userAccountID", oldeVUserAccountID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 2. Update the new user's voucher allocation
        void updateNewUserRemainingAmount()
        {

            decimal newAmount = Convert.ToDecimal(txtAmount.Text);

            Program.evUsedAmount = Program.evUsedAmount + newAmount;
            Program.evRemainingAmount = Program.evAllocatedAmount - Program.evUsedAmount;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblUserAccounts " +
                               "SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount " +
                               "WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userRemainingAmount", Program.evRemainingAmount);
                    cmd.Parameters.AddWithValue("@userUsedAmount", Program.evUsedAmount);
                    cmd.Parameters.AddWithValue("@userAccountID", Program.evUserAccountID); // new user

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //for same userAccountID
        void updateUserRemainingAmount()
        {

            Program.evUsedAmount = (Program.evUsedAmount - oldCost) + Convert.ToDecimal(txtAmount.Text);

            Program.evRemainingAmount = Program.evAllocatedAmount - Program.evUsedAmount;


            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.evUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                //// Parse and validate numeric inputs
                //decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                //decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                //decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


                //cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.evRemainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", Program.evUsedAmount);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show(Program.evUserAccountID);
            MessageBox.Show("Buget Allocation Updated!");
        }


        String savedCost = "0";
        int returnCost = 0;
        //decimal oldCost = 0; --transferred under load event for the LoadVoucherDetails
        private void txtAmount_Enter(object sender, EventArgs e)
        {
            savedCost = txtAmount.Text;
            txtAmount.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToInt32(result);
                //oldCost = Convert.ToInt32(result);
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.TextLength <= 0)
            {
                txtAmount.Text = returnCost.ToString();
                txtAmount.Text = string.Format("{0:n}", double.Parse(txtAmount.Text));
                if (decimal.TryParse(txtAmount.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtAmount.Text = string.Format("{0:n}", double.Parse(txtAmount.Text));
                if (decimal.TryParse(txtAmount.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                }
            }
        }

        private void comboSource_TextChanged(object sender, EventArgs e)
        {
            // Get Account ID first
            //string retrievedAccountID = getAccountID();

            //// Debugging: Check if Account ID is retrieved
            //if (string.IsNullOrEmpty(retrievedAccountID))
            //{
            //    MessageBox.Show("Account ID is not retrieved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; // Stop execution if no account ID
            //}

            //Program.evAccountID = retrievedAccountID;

            // Get User Account ID
            //getUserAccountID();

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            getAccountID();
            getUserAccountID();

            //MessageBox.Show(Program.evAccountID + " /" + Program.evAccountUserID);
            
            remainingBudget();
        }

        //void remainingBudget()
        //{

        //    string year = DateTime.Now.Year.ToString();
        //    string user = txtUser.Text;
        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    String query = "SELECT (tblEndUsers.travexloc - SUM(tblBudget.travexloc)) as remainingTravExLoc, (tblEndUsers.travexfor - SUM(tblBudget.travexfor)) as remainingTravExFor, (tblEndUsers.trainingex - SUM(tblBudget.trainingex)) as remainingTrainingEx, (tblEndUsers.os - SUM(tblBudget.os)) as remainingOS, (tblEndUsers.fol - SUM(tblBudget.fol)) as remainingFOL, (tblEndUsers.osme - SUM(tblBudget.osme)) as remainingOSME, (tblEndUsers.pcs - SUM(tblBudget.pcs)) as remainingPCS, (tblEndUsers.telex - SUM(tblBudget.telex)) as remainingTelEx, (tblEndUsers.internetsubex - SUM(tblBudget.internetsubex)) as remainingInternetSubEx, (tblEndUsers.lss - SUM(tblBudget.lss)) as remainingLSS, (tblEndUsers.consultancyser - SUM(tblBudget.consultancyser)) as remainingConsultancySer, (tblEndUsers.ogs - SUM(tblBudget.ogs)) as remainingOGS, (tblEndUsers.rmbos - SUM(tblBudget.rmbos)) as remainingRMBOS, (tblEndUsers.rmme - SUM(tblBudget.rmme)) as remainingRMME, (tblEndUsers.rmte - SUM(tblBudget.rmte)) as remainingRMTE, (tblEndUsers.rmff - SUM(tblBudget.rmff)) as remainingRMFF, (tblEndUsers.rmoppe - SUM(tblBudget.rmoppe)) as remainingRMOPPE, (tblEndUsers.fbp - SUM(tblBudget.fbp)) as remainingFBP, (tblEndUsers.advertisingex - SUM(tblBudget.advertisingex)) as remainingAdvertisingEx, (tblEndUsers.ppe - SUM(tblBudget.ppe)) as remainingPPE, (tblEndUsers.repex - SUM(tblBudget.repex)) as remainingRepEx, (tblEndUsers.mdco - SUM(tblBudget.mdco)) as remainingMDCO, (tblEndUsers.subsex - SUM(tblBudget.subsex)) as remainingSubsEx, (tblEndUsers.om - SUM(tblBudget.om)) as remainingOM, (tblEndUsers.jo - SUM(tblBudget.jo)) as remainingJO, (tblEndUsers.co - SUM(tblBudget.co)) as remainingCO, (tblEndUsers.swr - SUM(tblBudget.swr)) as remainingSWR, (tblEndUsers.swc - SUM(tblBudget.swc)) as remainingSWC, (tblEndUsers.pera - SUM(tblBudget.pera)) as remainingPERA, (tblEndUsers.repallowance - SUM(tblBudget.repallowance)) as remainingRepAllowance, (tblEndUsers.transpoallowance - SUM(tblBudget.transpoallowance)) as remainingTranspoAllowance, (tblEndUsers.clothing - SUM(tblBudget.clothing)) as remainingClothing, (tblEndUsers.ot - SUM(tblBudget.ot)) as remainingOT, (tblEndUsers.yearend - SUM(tblBudget.yearend)) as  remainingYearEnd, (tblEndUsers.cashgift - SUM(tblBudget.cashgift)) as remainingCashGift, (tblEndUsers.obam - SUM(tblBudget.obam)) as remainingOBAM, (tblEndUsers.obaa - SUM(tblBudget.obaa)) as remainingOBAA, (tblEndUsers.retirement - SUM(tblBudget.retirement)) as remainingRetirement, (tblEndUsers.pagibig - SUM(tblBudget.pagibig)) as remainingPagibig, (tblEndUsers.philhealth - SUM(tblBudget.philhealth)) as remainingPhilhealth, (tblEndUsers.ecip - SUM(tblBudget.ecip)) as remainingECIP, (tblEndUsers.tlb - SUM(tblBudget.tlb)) as remainingTLB, (tblEndUsers.opbm - SUM(tblBudget.opbm)) as remainingOPBM, (tblEndUsers.opbl - SUM(tblBudget.opbl)) as remainingOPBL, (tblEndUsers.opbpei - SUM(tblBudget.opbpei)) as remainingOPBPEI, (tblEndUsers.vfol - SUM(tblBudget.vfol)) as remainingvFOL, (tblEndUsers.cstre - SUM(tblBudget.cstre)) as remainingCSTRE, (tblEndUsers.qa - SUM(tblBudget.qa)) as remainingQA FROM tblBudget INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE tblBudget.Name = @user AND tblBudget.year = @year GROUP BY tblEndUsers.travexloc, tblEndUsers.travexfor, tblEndUsers.trainingex, tblEndUsers.os, tblEndUsers.fol, tblEndUsers.osme, tblEndUsers.pcs, tblEndUsers.telex, tblEndUsers.internetsubex, tblEndUsers.lss, tblEndUsers.consultancyser, tblEndUsers.ogs, tblEndUsers.rmbos, tblEndUsers.rmme, tblEndUsers.rmte, tblEndUsers.rmff, tblEndUsers.rmoppe, tblEndUsers.fbp, tblEndUsers.advertisingex, tblEndUsers.ppe, tblEndUsers.repex, tblEndUsers.mdco, tblEndUsers.subsex, tblEndUsers.om, tblEndUsers.jo, tblEndUsers.co, tblEndUsers.swr, tblEndUsers.swc, tblEndUsers.pera, tblEndUsers.repallowance, tblEndUsers.transpoallowance, tblEndUsers.clothing, tblEndUsers.ot, tblEndUsers.yearend, tblEndUsers.cashgift, tblEndUsers.obam, tblEndUsers.obaa, tblEndUsers.retirement, tblEndUsers.pagibig, tblEndUsers.philhealth, tblEndUsers.ecip, tblEndUsers.tlb, tblEndUsers.opbm, tblEndUsers.opbl, tblEndUsers.opbpei, tblEndUsers.vfol, tblEndUsers.cstre, tblEndUsers.qa";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    using (cmd = new SqlCommand(query, con))
        //    {
        //        cmd.Parameters.AddWithValue("@user", user);
        //        cmd.Parameters.AddWithValue("@year", year);

        //        //cmd.ExecuteNonQuery();
        //    }

        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {

        //        Program.remainingTravExLoc = Convert.ToInt32(dr["remainingTravExLoc"]);
        //        Program.remainingTravExFor = Convert.ToInt32(dr["remainingTravExFor"]);
        //        Program.remainingTrainingEx = Convert.ToInt32(dr["remainingTrainingEx"]);
        //        Program.remainingOS = Convert.ToInt32(dr["remainingOS"]);
        //        Program.remainingFOL = Convert.ToInt32(dr["remainingFOL"]);
        //        Program.remainingOSME = Convert.ToInt32(dr["remainingOSME"]);
        //        Program.remainingPCS = Convert.ToInt32(dr["remainingPCS"]);
        //        Program.remainingTelEx = Convert.ToInt32(dr["remainingTelEx"]);
        //        Program.remainingInternetSubEx = Convert.ToInt32(dr["remainingInternetSubEx"]);
        //        Program.remainingLSS = Convert.ToInt32(dr["remainingLSS"]);
        //        Program.remainingConsultancySer = Convert.ToInt32(dr["remainingConsultancySer"]);
        //        Program.remainingOGS = Convert.ToInt32(dr["remainingOGS"]);
        //        Program.remainingRMBOS = Convert.ToInt32(dr["remainingRMBOS"]);
        //        Program.remainingRMME = Convert.ToInt32(dr["remainingRMME"]);
        //        Program.remainingRMTE = Convert.ToInt32(dr["remainingRMTE"]);
        //        Program.remainingRMFF = Convert.ToInt32(dr["remainingRMFF"]);
        //        Program.remainingRMOPPE = Convert.ToInt32(dr["remainingRMOPPE"]);
        //        Program.remainingFBP = Convert.ToInt32(dr["remainingFBP"]);
        //        Program.remainingAdvertisingEx = Convert.ToInt32(dr["remainingAdvertisingEx"]);
        //        Program.remainingPPE = Convert.ToInt32(dr["remainingPPE"]);
        //        Program.remainingRepEx = Convert.ToInt32(dr["remainingRepEx"]);
        //        Program.remainingMDCO = Convert.ToInt32(dr["remainingMDCO"]);
        //        Program.remainingSubsEx = Convert.ToInt32(dr["remainingSubsEx"]);
        //        Program.remainingOM = Convert.ToInt32(dr["remainingOM"]);
        //        Program.remainingJO = Convert.ToInt32(dr["remainingJO"]);
        //        Program.remainingCO = Convert.ToInt32(dr["remainingCO"]);
        //        Program.remainingSWR = Convert.ToInt32(dr["remainingSWR"]);
        //        Program.remainingSWC = Convert.ToInt32(dr["remainingSWC"]);
        //        Program.remainingPERA = Convert.ToInt32(dr["remainingPERA"]);
        //        Program.remainingRepAllowance = Convert.ToInt32(dr["remainingRepAllowance"]);
        //        Program.remainingTranspoAllowance = Convert.ToInt32(dr["remainingTranspoAllowance"]);
        //        Program.remainingClothing = Convert.ToInt32(dr["remainingClothing"]);
        //        Program.remainingOT = Convert.ToInt32(dr["remainingOT"]);
        //        Program.remainingYearEnd = Convert.ToInt32(dr["remainingYearEnd"]);
        //        Program.remainingCashGift = Convert.ToInt32(dr["remainingCashGift"]);
        //        Program.remainingOBAM = Convert.ToInt32(dr["remainingOBAM"]);
        //        Program.remainingOBAA = Convert.ToInt32(dr["remainingOBAA"]);
        //        Program.remainingRetirement = Convert.ToInt32(dr["remainingRetirement"]);
        //        Program.remainingPagibig = Convert.ToInt32(dr["remainingPagibig"]);
        //        Program.remainingPhilhealth = Convert.ToInt32(dr["remainingPhilhealth"]);
        //        Program.remainingECIP = Convert.ToInt32(dr["remainingECIP"]);
        //        Program.remainingTLB = Convert.ToInt32(dr["remainingTLB"]);
        //        Program.remainingOPBM = Convert.ToInt32(dr["remainingOPBM"]);
        //        Program.remainingOPBL = Convert.ToInt32(dr["remainingOPBL"]);
        //        Program.remainingOPBPEI = Convert.ToInt32(dr["remainingOPBPEI"]);
        //        Program.remainingvFOL = Convert.ToInt32(dr["remainingvFOL"]);
        //        Program.remainingCSTRE = Convert.ToInt32(dr["remainingCSTRE"]);
        //        Program.remainingQA = Convert.ToInt32(dr["remainingQA"]);
        //    }

        //    checkingVoucherBalance();
        //}


        void remainingBudget()
        {
            int actualc = 0, totalc = 0;


            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.evUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) // Check if there's a row available
            {
                if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                {
                    Program.evRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                }
                else
                {
                    Program.evRemainingAmount = 0.00m; // Use 'm' for decimal literals
                }
            }
            else
            {
                Program.evRemainingAmount = 0.00m; // Default value when no rows are found
            }

            try
            {

                if ((Program.evRemainingAmount + returnCost) < Convert.ToInt32(txtAmount.Text))
                {
                    decimal uneditedCost = Program.evRemainingAmount + returnCost;
                    MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                    txtAmount.Text = string.Empty;
                }
            }

            catch (Exception ex)
            {

            }

        }

        void checkingVoucherBalance()
        {
            try
            {
                if (comboSource.SelectedIndex == 0)
                {

                    if (Program.remainingTravExLoc + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTravExLoc + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 1)
                {

                    if (Program.remainingTrainingEx + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTrainingEx + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 2)
                {

                    if (Program.remainingTelEx + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTelEx + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 3)
                {

                    if (Program.remainingInternetSubEx + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingInternetSubEx + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 4)
                {

                    if (Program.remainingConsultancySer + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingConsultancySer + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 5)
                {

                    if (Program.remainingMDCO + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingMDCO + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 6)
                {

                    if (Program.remainingvFOL + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingvFOL + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 7)
                {

                    if (Program.remainingOGS + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOGS + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 8)
                {

                    if (Program.remainingTravExFor + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTravExFor + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 9)
                {

                    if (Program.remainingLSS + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingLSS + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 10)
                {

                    if (Program.remainingFBP + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingFBP + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 11)
                {

                    if (Program.remainingAdvertisingEx + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingAdvertisingEx + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 12)
                {

                    if (Program.remainingSubsEx + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingSubsEx + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 13)
                {

                    if (Program.remainingJO + returnCost  < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingJO + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 14)
                {

                    if (Program.remainingSWR + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingSWR + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 15)
                {

                    if (Program.remainingSWC + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingSWC + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 16)
                {

                    if (Program.remainingPERA + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingPERA + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 17)
                {

                    if (Program.remainingRepAllowance + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingRepAllowance + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 18)
                {

                    if (Program.remainingTranspoAllowance + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTranspoAllowance + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 19)
                {

                    if (Program.remainingClothing + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingClothing + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 20)
                {

                    if (Program.remainingOT + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOT + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 21)
                {

                    if (Program.remainingYearEnd + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingYearEnd + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 22)
                {

                    if (Program.remainingCashGift + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingCashGift + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 23)
                {

                    if (Program.remainingOBAM + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOBAM + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 24)
                {

                    if (Program.remainingOBAA + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOBAA + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 25)
                {

                    if (Program.remainingRetirement + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingRetirement + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 26)
                {

                    if (Program.remainingPagibig + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingPagibig + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 27)
                {

                    if (Program.remainingPhilhealth + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingPhilhealth + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 28)
                {

                    if (Program.remainingECIP + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingECIP + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 29)
                {

                    if (Program.remainingTLB + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingTLB + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 30)
                {

                    if (Program.remainingOPBM + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOPBM + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 31)
                {

                    if (Program.remainingOPBL + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOPBL + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 32)
                {

                    if (Program.remainingOPBPEI + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingOPBPEI + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 33)
                {

                    if (Program.remainingCSTRE + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingCSTRE + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 34)
                {

                    if (Program.remainingQA + returnCost < Convert.ToInt32(txtAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + (Program.remainingQA + returnCost));
                        txtAmount.Text = string.Empty;
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void icnVoucherGenerate_Click(object sender, EventArgs e)
        {

        }

        private void icnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                //MessageBox.Show("Deleted!");

            }
            
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            getUserID();
            getAccounts();
        }

        void getUserID()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define query with a parameter placeholder
                String query = "SELECT userID FROM tblAccountUser WHERE userYear = '"+txtUserYear.Text+"' AND userName = @userName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@userName", txtUsers.Text.Trim());

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.evAccountUserID = dr["userID"].ToString();
                        }
                    }
                }
            }
        }


        private void getAccounts()
        {

            string dept = comboDept.Text;
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, 
                                u.userDept, a.accountName, a.PR, a.Voucher, 
                                ua.userAllocatedAmount, ua.userRemainingAmount, 
                                ua.userUsedAmount, u.userYear 
                         FROM tblUserAccounts ua 
                         INNER JOIN tblAccounts a ON ua.accountID = a.accountID 
                         INNER JOIN tblAccountUser u ON ua.userID = u.userID 
                         WHERE a.Voucher = 'Yes' AND ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@UserID", Program.evAccountUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    comboSource.DataSource = table;
                    comboSource.DisplayMember = "accountName";
                }
            }


        }

        private void icnVoucherPrint_Click(object sender, EventArgs e)
        {
            printVoucherQR();
        }

        public void printVoucherQR()
        {
            //Show print dialog
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += DocVoucher_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void DocVoucher_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(voucherCtrl.Font.FontFamily, 6);
            Font additionalTextFont2 = new Font(voucherCtrl.Font.FontFamily, 9);
            Font additionalTextFont1 = new Font(voucherSP.Font.FontFamily, 12);

            voucherDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            voucherSP.Text = "SP_VGO";


            // Draw the QR code on the print document
            //e.Graphics.DrawImage(qrVoucherPic.Image, -10, 5, 90, 90);
            e.Graphics.DrawImage(qrVoucherPic.Image, 0, 40, 90, 90);
            // StringFormat for center alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(voucherCtrl.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 120));
            // Draw the additional text on the print document
            e.Graphics.DrawString(voucherDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 135));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 145));

            //ANOTHER COPY

            e.Graphics.DrawImage(qrVoucherPic.Image, 0, 220, 90, 90);
            // StringFormat for center alignment
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(voucherCtrl.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 300));
            // Draw the additional text on the print document
            e.Graphics.DrawString(voucherDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 315));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 325));


            ////Print image
            //Bitmap bm = new Bitmap(qrPanel.Width, qrPanel.Height);
            //qrPanel.DrawToBitmap(bm, new Rectangle(0, 0, qrPanel.Width, qrPanel.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void txtUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUserID();
            getAccounts();
        }

        private void txtUserYear_TextChanged(object sender, EventArgs e)
        {
            getUsers();
        }
    }
}
