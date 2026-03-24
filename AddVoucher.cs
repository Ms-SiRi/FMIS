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
using ZXing.QrCode;
using ZXing;
using System.Drawing.Printing;
using System.IO;
using Apitron.PDF.Rasterizer;

namespace FMIS
{
    public partial class AddVoucher : Form
    {
        public AddVoucher()
        {
            InitializeComponent();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUsers();
        }

        private void getUsers()
        {
            if(Program.userStation == "ALL")
            {
                if (comboDept.SelectedIndex == 0)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE')", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    comboUser.DataSource = table;
                    comboUser.DisplayMember = "userName";
                }

                if (comboDept.SelectedIndex == 1)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE')", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    comboUser.DataSource = table;
                    comboUser.DisplayMember = "userName";
                }
            }
            else
            {
                if (comboDept.SelectedIndex == 0)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE') AND district = '" + Program.userStation + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    comboUser.DataSource = table;
                    comboUser.DisplayMember = "userName";
                }

                if (comboDept.SelectedIndex == 1)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE') AND district = '" + Program.userStation + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    comboUser.DataSource = table;
                    comboUser.DisplayMember = "userName";
                }
            }

        }

        private void AddVoucher_Load(object sender, EventArgs e)
        {
            txtUserYear.Text = DateTime.Today.Year.ToString();
            StationIdentifier();
            Program.PRType = 1;
            controlidByFileTypeofVoucher();
            txtVoucherYear.Text = DateTime.Now.ToString("yyyy");
        }

        void StationIdentifier()
        {
            if (Program.userStation == "VGO")
            {
                txtVoucherUser.Text = "VGO";
                
            }
            else if (Program.userStation == "SP")
            {
                txtVoucherUser.Text = "SP";
                
            }
            else if (Program.userStation == "ALL")
            {
                txtVoucherUser.Text = "A";
                
            }
            else if (Program.userStation == "1st District")
            {
                txtVoucherUser.Text = "D1";
               
            }
            else if (Program.userStation == "2nd District")
            {
                txtVoucherUser.Text = "D2";
                
            }
            else if (Program.userStation == "3rd District")
            {
                txtVoucherUser.Text = "D3";
                
            }
            else if (Program.userStation == "Ex-Officio")
            {
                txtVoucherUser.Text = "EO";

            }
        }

        int highestvoucherid;
        string voucherzero;
        public void controlidByFileTypeofVoucher()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            String getquery = "SELECT COUNT(fileID) AS LatestNum, MAX(noOfAttachments) as count_control FROM tblFiles WHERE fileType = 'Voucher File' AND year = YEAR(GETDATE());";
            con.Open();
            SqlCommand cmd = new SqlCommand(getquery, con);
            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
            {
                if (DateTime.Now.ToString("yyyy") == "2024")
                {
                    if (dr["LatestNum"].ToString() == "0")
                    {
                        highestvoucherid = 1;
                        controlZerosofVoucher();
                        txtVoucherCounter.Text = voucherzero + highestvoucherid;

                    }

                    else
                    {
                        highestvoucherid = Convert.ToInt32(dr["count_control"]);
                        highestvoucherid++;
                        controlZerosofVoucher();
                        txtVoucherCounter.Text = voucherzero + highestvoucherid.ToString();
                    }
                }
                else
                {
                    if (dr["LatestNum"].ToString() == "0")
                    {
                        highestvoucherid = 1;
                        controlZerosofVoucher();
                        txtVoucherCounter.Text = voucherzero + highestvoucherid;

                    }

                    else
                    {
                        highestvoucherid = Convert.ToInt32(dr["LatestNum"]);
                        highestvoucherid++;
                        controlZerosofVoucher();
                        txtVoucherCounter.Text = voucherzero + highestvoucherid.ToString();
                    }
                }
                
            }
        }

        private void controlZerosofVoucher()
        {

            string vouchercontrolcounter = highestvoucherid.ToString();
            if (vouchercontrolcounter.Length < 1)
            {
                voucherzero = "0000";
            }
            if (vouchercontrolcounter.Length == 1)
            {
                voucherzero = "000";
            }
            else if (vouchercontrolcounter.Length == 2)
            {
                voucherzero = "00";
            }
            else if (vouchercontrolcounter.Length == 3)
            {
                voucherzero = "0";
            }
            else
            {
                voucherzero = "";
            }
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@userName", comboUser.Text.Trim());

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.nvAccountUserID = dr["userID"].ToString();
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
                    cmd.Parameters.AddWithValue("@UserID", Program.nvAccountUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    comboSource.DataSource = table;
                    comboSource.DisplayMember = "accountName";
                }
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPayee_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void icnVoucherGenerate_Click(object sender, EventArgs e)
        {
            generateVoucherQR();
            icnVoucherSave.Enabled = true;
            icnVoucherPrint.Enabled = true;
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
            var result = new Bitmap(qr.Write(txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim() + txtVoucherUser.Text));
            qrVoucherPic.Image = result;

            voucherCtrl.Text = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim() + txtVoucherUser.Text;
            voucherDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            voucherSP.Text = "SP_VGO";
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
            // Draw the QR code on the print document
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

        private void icnVoucherSave_Click(object sender, EventArgs e)
        {
            emptyFields();
        }

        private void emptyFields()
        {
            if (txtVoucherType.Text.Equals("") || txtVoucherYear.Text == "" || txtVoucherCounter.Text == "" || txtPayee.Text == "" || comboDept.Text == "" || comboUser.Text == "" || comboSource.Text == ""  || txtAmount.Text == "" || txtParticulars.Text == "" || txtParticulars.Text == "" || txtObRLoc.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                UploadFile(filename);
                SaveFile(filename);
                saveBudget();
                Allocation();
                updateUserRemainingAmount();
                MessageBox.Show("Saved!");
                this.Close();

            }
        }

        void Allocation()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.nvUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read()) // Check if there's a row available
                {
                    if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.nvRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                    }
                    else
                    {
                        Program.nvRemainingAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userUsedAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.nvUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                    }
                    else
                    {
                        Program.nvUsedAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userAllocatedAmount"] != DBNull.Value) // Check if the value is NULL
                    {

                        Program.nvAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                    }
                    else
                    {
                        Program.nvAllocatedAmount = 0.00m; // Use 'm' for decimal literals
                    }
                }
                else
                {
                    Program.nvRemainingAmount = 0.00m; // Default value when no rows are found
                    Program.nvUsedAmount = 0.00m;
                    Program.nvAllocatedAmount = 0.00m;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        void updateUserRemainingAmount()
        {
            Program.nvRemainingAmount = Program.nvAllocatedAmount - (Program.nvUsedAmount + Program.convertedCost);

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.nvUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                //// Parse and validate numeric inputs
                //decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                //decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                //decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


                //cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.nvRemainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", Program.nvUsedAmount + Program.convertedCost);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Buget Allocation Updated!");
        }

        void UploadFile(string file)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblVoucher(voucherControlNumber,payee,department,endUser,source,amount,remarks, date, voucherFile, status, userYear) VALUES(@voucherControlNumber,@payee,@department,@endUser,@source, @amount,@remarks, @date, @voucherFile, 'Done', @userYear)";

            con.Open();
            FileStream fstream = File.OpenRead(file);
            byte[] content = new byte[fstream.Length];
            fstream.Read(content, 0, content.Length);
            fstream.Close();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@voucherControlNumber", txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text);
                cmd.Parameters.AddWithValue("@payee", txtPayee.Text);
                cmd.Parameters.AddWithValue("@department", comboDept.Text);
                cmd.Parameters.AddWithValue("@endUser", comboUser.Text);
                cmd.Parameters.AddWithValue("@source", comboSource.Text);
                cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                cmd.Parameters.AddWithValue("@remarks", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@voucherFile", content);
                cmd.Parameters.AddWithValue("@userYear", txtUserYear.Text);
                //cmd.Parameters.AddWithValue("@poControlNumber", txtPOtype.Text + txtPOyr.Text + txtPOctrl.Text);
                //cmd.Parameters.AddWithValue("@voucherControlNumber", txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text);
                cmd.ExecuteNonQuery();

                string activity = "Created new Voucher - ControlNumber: "
                + txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text
                + " | Payee: " + txtPayee.Text
                + " | Name: " + comboUser.Text
                + " | Dept: " + comboDept.Text
                + " | Source: " + comboSource.Text
                + " | Date: " + date
                + " | Amount: " + Program.convertedCost
                + " | Remarks: " + txtParticulars.Text;

                AddUserLog(Program.userName, activity);
            }
            MessageBox.Show(Program.convertedCost.ToString());
            MessageBox.Show("Upload Done!");
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

        private void SaveFile(string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);

                string name = new FileInfo(filePath).Name;
                string extn = new FileInfo(filePath).Extension;
                string controlnumber = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text;
                int fileyear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblFiles (controlNumber, fileType, data, fileName, extension, noOfAttachments, year) VALUES (@cnumber, @ftype, @data, @filename, @extn, @attachments, @year)", con);
                con.Open();
                cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                //cmd.Parameters.Add("@prid", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@ftype", SqlDbType.VarChar).Value = "Voucher File";
                cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = data;
                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                cmd.Parameters.Add("@attachments", SqlDbType.Int).Value = txtVoucherCounter.Text;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = fileyear;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("tblFiles");
            }
        }


        private void saveBudget()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string year = DateTime.Now.ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBudget(controlNumber, Name,Department," + Program.sourcetypedeterminer + ", year, date, description, source, amount, userAccountID) VALUES(@ctrlnum, @Name, @Dept, @source, @year, @date, @description, @filesource, @amount, @userAccountID)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text);
                cmd.Parameters.AddWithValue("@Name", comboUser.Text);
                cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                cmd.Parameters.AddWithValue("@source", Program.convertedCost);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@description", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@filesource", comboSource.Text);
                cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                cmd.Parameters.AddWithValue("@userAccountID", Program.nvUserAccountID);
                cmd.ExecuteNonQuery();
            }
            //MessageBox.Show("tblBudget");
            //MessageBox.Show("Budget Saved!");

        }

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

        String savedCost = "0";
        int returnCost = 0;
        private void txtAmount_Enter(object sender, EventArgs e)
        {
            savedCost = txtAmount.Text;
            txtAmount.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToInt32(result);

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

        string filename;
        FileStream fs;
        private void btnAttachObR_Click(object sender, EventArgs e)
        {
            //FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtObRLoc.Text = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text + "Obr_File";
                        icnVoucherGenerate.Enabled = true;
                        qrVoucherPic.Enabled = true;

                        //Program.filestatus = 1;

                        try
                        {
                            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            pdfView.Document = new Document(fs);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAmount.Text = "0";
            sourceTypeDeterminer();

            getAccountID();
            getUserAccountID();
        }

        private void getAccountID()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define query with a parameter placeholder
                String query = "SELECT accountID FROM tblAccounts WHERE accountYear = '"+txtUserYear.Text+"' AND accountName = @AccountName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@AccountName", comboSource.Text.Trim());

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.nvAccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }
        }

        private void getUserAccountID()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define query with a parameter placeholder
                String query = "SELECT userAccountID FROM tblUserAccounts WHERE userID = @userID AND accountID = @accountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@userID", Program.nvAccountUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.nvAccountID);

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.nvUserAccountID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }


        private void comboDept_TextChanged(object sender, EventArgs e)
        {
            getUsers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            remainingBudget();
        }

        //void remainingBudget()
        //{

        //    string year = DateTime.Now.Year.ToString();
        //    string user = comboUser.Text;
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

        //    try
        //    {
        //        if (comboSource.SelectedIndex == 0)
        //        {

        //            if (Program.remainingTravExLoc < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTravExLoc);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 1)
        //        {

        //            if (Program.remainingTrainingEx < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTrainingEx);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 2)
        //        {

        //            if (Program.remainingTelEx < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTelEx);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 3)
        //        {

        //            if (Program.remainingInternetSubEx < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingInternetSubEx);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 4)
        //        {

        //            if (Program.remainingConsultancySer < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingConsultancySer);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 5)
        //        {

        //            if (Program.remainingMDCO < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingMDCO);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 6)
        //        {

        //            if (Program.remainingFOL < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingFOL);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 7)
        //        {

        //            if (Program.remainingOGS < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOGS);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 8)
        //        {

        //            if (Program.remainingTravExFor < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTravExFor);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 9)
        //        {

        //            if (Program.remainingLSS < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingLSS);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 10)
        //        {

        //            if (Program.remainingFBP < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingFBP);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 11)
        //        {

        //            if (Program.remainingAdvertisingEx < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingAdvertisingEx);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 12)
        //        {

        //            if (Program.remainingSubsEx < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingSubsEx);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 13)
        //        {

        //            if (Program.remainingJO < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingJO);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 14)
        //        {

        //            if (Program.remainingSWR < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingSWR);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 15)
        //        {

        //            if (Program.remainingSWC < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingSWC);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 16)
        //        {

        //            if (Program.remainingPERA < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPERA);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 17)
        //        {

        //            if (Program.remainingRepAllowance < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRepAllowance);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 18)
        //        {

        //            if (Program.remainingTranspoAllowance < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTranspoAllowance);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 19)
        //        {

        //            if (Program.remainingClothing < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingClothing);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 20)
        //        {

        //            if (Program.remainingOT < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOT);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 21)
        //        {

        //            if (Program.remainingYearEnd < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingYearEnd);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 22)
        //        {

        //            if (Program.remainingCashGift < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingCashGift);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 23)
        //        {

        //            if (Program.remainingOBAM < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOBAM);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 24)
        //        {

        //            if (Program.remainingOBAA < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOBAA);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 25)
        //        {

        //            if (Program.remainingRetirement < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRetirement);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 26)
        //        {

        //            if (Program.remainingPagibig < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPagibig);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 27)
        //        {

        //            if (Program.remainingPhilhealth < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPhilhealth);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 28)
        //        {

        //            if (Program.remainingECIP < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingECIP);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 29)
        //        {

        //            if (Program.remainingTLB < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTLB);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 30)
        //        {

        //            if (Program.remainingOPBM < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOPBM);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 31)
        //        {

        //            if (Program.remainingOPBL < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOPBL);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 32)
        //        {

        //            if (Program.remainingOPBPEI < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOPBPEI);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 33)
        //        {

        //            if (Program.remainingCSTRE < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingCSTRE);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 34)
        //        {

        //            if (Program.remainingQA < Convert.ToInt32(txtAmount.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingQA);
        //                txtAmount.Text = string.Empty;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }


        //}

        void remainingBudget()
        {

           
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.nvUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) // Check if there's a row available
            {
                if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                {
                    Program.nvRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                }
                else
                {
                    Program.nvRemainingAmount = 0.00m; // Use 'm' for decimal literals
                }
            }
            else
            {
                Program.nvRemainingAmount = 0.00m; // Default value when no rows are found
            }

            try
            {
                if (Program.nvRemainingAmount < Convert.ToInt32(txtAmount.Text))
                {
                    MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.nvRemainingAmount);
                    txtAmount.Text = string.Empty;
                }
            }

            catch (Exception ex)
            {

            }


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

        private void comboUser_TextChanged(object sender, EventArgs e)
        {
            getUserID();
            getAccounts();
        }

        private void comboSource_TextChanged(object sender, EventArgs e)
        {
            getAccountID();
            getUserAccountID();
        }

        private void txtUserYear_KeyUp(object sender, KeyEventArgs e)
        {
            getUsers();
        }
    }
}
