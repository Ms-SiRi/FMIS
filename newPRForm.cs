using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;
using ComboBox = System.Windows.Forms.ComboBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms.VisualStyles;
using System.Reflection;
using System.Web.UI.WebControls;

namespace FMIS
{
    public partial class newPRForm : Form
    {
        public newPRForm()
        {
            InitializeComponent();
            controlidByFileType();
            controlidByFileTypeofVoucher();
            controlidByFileTypeofPO();
        }

        private void newPRForm_Load(object sender, EventArgs e)
        {
            txtUserYear.Text = DateTime.Today.Year.ToString();
            StationIdentifier();
            determiningPRType();
            comboType.SelectedIndex = 0;
            comboDept.SelectedIndex = 0;
            comboSource.SelectedIndex = 0;
            txtyr.Text = DateTime.Now.ToString("yyyy");
            //txtPOctrl.Text = txtCounter.Text;
            txtPOyr.Text = txtyr.Text;
            txtVoucherYear.Text = txtyr.Text;           
            icnSave.Enabled= false;
        }

        void StationIdentifier()
        {
            if(Program.userStation == "VGO")
            {
                txtPRUser.Text = "VGO";
                txtPOUser.Text = "VGO";
                txtVoucherUser.Text = "VGO";
            }
            else if (Program.userStation == "SP")
            {
                txtPRUser.Text = "SP";
                txtPOUser.Text = "SP";
                txtVoucherUser.Text = "SP";
            }
            else if (Program.userStation == "ALL")
            {
                txtPRUser.Text = "A";
                txtPOUser.Text = "A";
                txtVoucherUser.Text = "A";
            }
            else if (Program.userStation == "1st District")
            {
                txtPRUser.Text = "D1";
                txtPOUser.Text = "D1";
                txtVoucherUser.Text = "D1";
            }
            else if (Program.userStation == "2nd District")
            {
                txtPRUser.Text = "D2";
                txtPOUser.Text = "D2";
                txtVoucherUser.Text = "D2";
            }
            else if (Program.userStation == "3rd District")
            {
                txtPRUser.Text = "D3";
                txtPOUser.Text = "D3";
                txtVoucherUser.Text = "D3";
            }
            else if (Program.userStation == "Ex-Officio")
            {
                txtPRUser.Text = "EO";
                txtPOUser.Text = "EO";
                txtVoucherUser.Text = "EO";
            }
        }


        int highestid;
        string zero;
        public void controlidByFileType()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String getquery = "SELECT COUNT(fileID) AS LatestNum, MAX(noOfAttachments) as count_control FROM tblFiles WHERE fileType = 'Purchase Request File' AND year = YEAR(GETDATE());";
            con.Open();
            SqlCommand cmd = new SqlCommand(getquery, con);            
            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
            {
                if(DateTime.Now.ToString("yyyy") == "2024")
                {
                    if (dr["LatestNum"].ToString() == "0")
                    {
                        highestid = 1;
                        controlZeros();
                        txtCounter.Text = zero + highestid;

                    }

                    else
                    {
                        highestid = Convert.ToInt32(dr["count_control"]);
                        highestid++;
                        controlZeros();
                        txtCounter.Text = zero + highestid.ToString();
                    }
                }
                else
                {
                    if (dr["LatestNum"].ToString() == "0")
                    {
                        highestid = 1;
                        controlZeros();
                        txtCounter.Text = zero + highestid;

                    }

                    else
                    {
                        highestid = Convert.ToInt32(dr["LatestNum"]);
                        highestid++;
                        controlZeros();
                        txtCounter.Text = zero + highestid.ToString();
                    }
                }
                
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

        private void controlZeros()
        {

            string controlcounter = highestid.ToString();
            if (controlcounter.Length < 1)
            {
                zero = "0000";
            }
            if (controlcounter.Length == 1)
            {
                zero = "000";
            }
            else if (controlcounter.Length == 2)
            {
                zero = "00";
            }
            else if (controlcounter.Length == 3)
            {
                zero = "0";
            }
            else
            {
                zero = "";
            }
        }

        int highestpoid;
        string pozero;

        public void controlidByFileTypeofPO()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            String getquery = "SELECT COUNT(fileID) AS LatestNum, MAX(noOfAttachments) as count_control FROM tblFiles WHERE fileType = 'Purchase Order File' AND year = YEAR(GETDATE());";
            con.Open();
            SqlCommand cmd = new SqlCommand(getquery, con);
            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
            {
                if (dr["LatestNum"].ToString() == "0")
                {
                    highestpoid = 1;
                    controlZerosofPO();
                    txtPOctrl.Text = pozero + highestpoid;

                }

                else
                {
                    highestpoid = Convert.ToInt32(dr["LatestNum"]);
                    highestpoid++;
                    controlZerosofPO();
                    txtPOctrl.Text = pozero + highestpoid.ToString();
                }
            }
        }


        private void controlZerosofPO()
        {

            string pocontrolcounter = highestpoid.ToString();
            if (pocontrolcounter.Length < 1)
            {
                pozero = "0000";
            }
            if (pocontrolcounter.Length == 1)
            {
                pozero = "000";
            }
            else if (pocontrolcounter.Length == 2)
            {
                pozero = "00";
            }
            else if (pocontrolcounter.Length == 3)
            {
                pozero = "0";
            }
            else
            {
                pozero = "";
            }
        }


        private void selectingFile()
        {
           
        }

        void determiningPRType()
        {
            if (comboType.SelectedIndex == 0)
            {
                txtPRType.Text = "PRR";
                Program.PRType = 1;
                sourceItems();
            }
            else if (comboType.SelectedIndex == 1)
            {
                txtPRType.Text = "PRE";
                comboSource.SelectedIndex = 1;
                //comboSource.Enabled = false;
                Program.PRType = 2;
                sourceItems();
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            determiningPRType();
        }

        void sourceItems()
        {
            if (Program.PRType == 1)
            {
                comboSource.Items.Clear();
                comboSource.Items.Add("Office Supplies");
                comboSource.Items.Add("Fuel, Oil, Lubricants");
                comboSource.Items.Add("R/M-Trans. Equipment");
                comboSource.Items.Add("Other MOOE");
                comboSource.Items.Add("Capital Outlay");
                comboSource.Items.Add("Representation Expenses");
                comboSource.Items.Add("Other Supplies and Material Expenses");
                comboSource.Items.Add("Postage and Courier Services");
                //comboSource.Items.Add("Telephone Expenses");
                //comboSource.Items.Add("Other General Services");
                comboSource.Items.Add("R/M-Buildings and Other Structures");
                comboSource.Items.Add("R/M-Machinery and Equipment");
                comboSource.Items.Add("R/M-Furniture and Fixtures");
                comboSource.Items.Add("R/M-Other PPE");
                comboSource.Items.Add("Printing and Publication Expenses");
                comboSource.Items.Add("Advertising Expenses");
                comboSource.Items.Add("Traveling Expenses - Local");
                comboSource.SelectedIndex=0;
            }
            else if (Program.PRType == 2)
            {
                comboSource.Items.Clear();
                comboSource.Items.Add("Fuel, Oil, Lubricants");
                comboSource.Items.Add("R/M-Trans. Equipment");
            }
        }

        

        private void generateQR()
        {
            lblPRCN.Text = txtPRType.Text + txtyr.Text + txtCounter.Text.Trim() + txtPRUser.Text;
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
            var result = new Bitmap(qr.Write(txtPRType.Text + txtyr.Text + txtCounter.Text.Trim() + txtPRUser.Text));
            qrPic.Image = result;

        }

        private void generateVoucher()
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

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateQR();
            icnSave.Enabled = true;
        }

        private void DocPR_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(lblPRCN.Font.FontFamily, 6);
            Font additionalTextFont2 = new Font(lblPRCN.Font.FontFamily, 9);
            Font additionalTextFont1 = new Font(lblPRSP.Font.FontFamily, 12);

            lblPRDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            lblPRSP.Text = "SP_VGO";


            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPic.Image, 0, 40, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(lblPRCN.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 120));
            // Draw the additional text on the print document
            e.Graphics.DrawString(lblPRDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 135));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 145));

            
            
            //ANOTHER COPY
            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPic.Image, 0, 220, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(lblPRCN.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 300));
            // Draw the additional text on the print document
            e.Graphics.DrawString(lblPRDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 315));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 325));




            ////Print image
            //Bitmap bm = new Bitmap(qrPanel.Width, qrPanel.Height);
            //qrPanel.DrawToBitmap(bm, new Rectangle(0, 0, qrPanel.Width, qrPanel.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        int counter;
        public void printPRQR()
        {
            //Show print dialog
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += DocPR_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();

            //if (counter != 1)
            //{
            //    MessageBox.Show("Copy QR 0/1 Printed. Print Again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Copy QR 2/2 Printed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //counter = 1;

            //while (counter <= 1)
            //{
            //    //Show print dialog
            //    System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            //    PrintDocument doc = new PrintDocument();
            //    doc.PrintPage += DocPR_PrintPage;
            //    pd.Document = doc;
            //    if (pd.ShowDialog() == DialogResult.OK)
            //        doc.Print();

            //    if (counter != 1)
            //    {
            //        MessageBox.Show("Copy QR 0/1 Printed. Print Again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Copy QR 2/2 Printed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    counter++;
            //}

            //System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            //PrintDocument doc = new PrintDocument();
            //doc.PrintPage += printDocument1_PrintPage;
            //pd.Document = doc;
            //if (pd.ShowDialog() == DialogResult.OK)
            //    doc.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            lblPRCN.Text = (txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text).Trim();
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(lblPRCN.Font.FontFamily, 5);
            Font additionalTextFont2 = new Font(lblPRCN.Font.FontFamily, 6);
            Font additionalTextFont1 = new Font(lblPRSP.Font.FontFamily, 12);

            lblPRDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            lblPRSP.Text = "SP_VGO";


            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPic.Image, -10, 5, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(lblPRCN.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("-1.85"), 90));
            // Draw the additional text on the print document
            e.Graphics.DrawString(lblPRDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.90"), 100));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("-1.90"), 105));

            //lblPRCN.Text = txtPRType.Text + txtyr.Text + txtCounter.Text.Trim();
            //// Font for the additional text with size 12
            //Font additionalTextFont = new Font(lblPRCN.Font.FontFamily, 7);

            //lblPRDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";


            //// Draw the QR code on the print document
            //e.Graphics.DrawImage(qrPic.Image, new Point(10, 10));

            //// StringFormat for center alignment
            //StringFormat stringFormat = new StringFormat();
            //stringFormat.Alignment = StringAlignment.Center;


            //// Draw the additional text on the print document
            //e.Graphics.DrawString(lblPRDate.Text, additionalTextFont, Brushes.Black, new PointF(17, 120));

            //e.Graphics.DrawString(lblPRCN.Text, additionalTextFont, Brushes.Black, new PointF(24, 130));

            //// Draw the additional text on the print document
            //e.Graphics.DrawString("SP-VGO", additionalTextFont, Brushes.Black, new PointF(34, 140));

            ////Print image
            //Bitmap bm = new Bitmap(qrPic.Width, qrPic.Height);
            //qrPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPic.Width, qrPic.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void qrPrint_Click(object sender, EventArgs e)
        {
            printPRQR();
        }

        //UPLOAD pdf file to prFile
        void UploadFile(string file)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO qrMotherTable(ctrlNumber,prType,prDept,prEnduser,prSource,prDescription,prCost" +
                ",prParticulars,prRemarks,prDate,prFile,prStatus,prFname, proposedCost, userYear) VALUES(@ctrlNumber,@prType,@prDept,@prEnduser,@prSource," +
                "@prDescription,@prCost,@prParticulars, @prRemarks,@prDate,@prFile,@prStatus,@prFname, @proposedCost, @userYear)";

            con.Open();
            FileStream fstream = File.OpenRead(file);
            byte[] content = new byte[fstream.Length];
            fstream.Read(content, 0, (int)fstream.Length);
            fstream.Close();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlNumber", txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text);
                cmd.Parameters.AddWithValue("@prType", txtPRType.Text);
                cmd.Parameters.AddWithValue("@prDept", comboDept.Text);
                cmd.Parameters.AddWithValue("@prEnduser", comboUser.Text);
                cmd.Parameters.AddWithValue("@prSource", comboSource.Text);
                cmd.Parameters.AddWithValue("@prDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@prCost",  Program.convertedCost);
                cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prFname", txtPRLoc.Text);
                cmd.Parameters.AddWithValue("@prDate", date);
                cmd.Parameters.AddWithValue("@prFile", content);
                cmd.Parameters.AddWithValue("@prStatus", Program.filestatus);
                cmd.Parameters.AddWithValue("@proposedCost", Program.convertedCost);
                cmd.Parameters.AddWithValue("@userYear", txtUserYear.Text);
                //cmd.Parameters.AddWithValue("@poControlNumber", txtPOtype.Text + txtPOyr.Text + txtPOctrl.Text);
                //cmd.Parameters.AddWithValue("@voucherControlNumber", txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Upload Done!");
        }


        string filename;
        private void btnPRattach_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 1;
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtPRLoc.Text = txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text + "PR_File";
                        btnGenerate.Enabled = true;
                        qrPrint.Enabled = true;

                        Program.filestatus = 1;
                    }
                }
            }
        }

        private void icnSave_Click(object sender, EventArgs e)
        {
            emptyFields();
        }

        private void emptyFields()
        {
            if (txtPRType.Text.Equals("") || txtyr.Text == "" || txtCounter.Text == "" || txtPOtype.Text == "" || txtPOyr.Text == "" || txtPOctrl.Text == "" || comboType.Text == "" || comboDept.Text == "" || comboUser.Text == "" || comboSource.Text == "" || dateTimePicker1.Text == "" || txtDesc.Text == "" || txtCost.Text == "" || txtParticulars.Text == "" || txtRemarks.Text == "" || txtPRLoc.Text == "")
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

        //void remainingBudget()
        //{

        //    string year = dateTimePicker1.Value.ToString("yyyy");
        //    string user = comboUser.Text;
        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    String query = "SELECT (tblEndUsers.os - SUM(tblBudget.os)) as remainingOS, (tblEndUsers.fol - SUM(tblBudget.fol)) AS remainingFOL, (tblEndUsers.rmte - SUM(tblBudget.rmte)) AS remainingRMTE, (tblEndUsers.om - SUM(tblBudget.om)) AS remainingOM, (tblEndUsers.co - SUM(tblBudget.co)) AS remainingCO, (tblEndUsers.repex - SUM(tblBudget.repex)) as remainingRepEx, (tblEndUsers.osme - SUM(tblBudget.osme)) as remainingOSME, (tblEndUsers.pcs - SUM(tblBudget.pcs)) as remainingPCS, (tblEndUsers.telex - SUM(tblBudget.telex)) as remainingTelEx, (tblEndUsers.ogs - SUM(tblBudget.ogs)) as remainingOGS, (tblEndUsers.rmbos - SUM(tblBudget.rmbos)) as remainingRMBOS, (tblEndUsers.rmme - SUM(tblBudget.rmme)) as remainingRMME, (tblEndUsers.rmff - SUM(tblBudget.rmff)) as remainingRMFF, (tblEndUsers.rmoppe - SUM(tblBudget.rmoppe)) as remainingRMOPPE, (tblEndUsers.ppe - SUM(tblBudget.ppe)) as remainingPPE, (tblEndUsers.advertisingex - SUM(tblBudget.advertisingex)) as remainingAdvertisingEx, (tblEndUsers.travexloc - SUM(tblBudget.travexloc)) as remainingTravExLoc, (tblEndUsers.qa - SUM(tblBudget.qa)) as remainingQA, ((tblEndUsers.os - SUM(tblBudget.os)) + (tblEndUsers.fol - SUM(tblBudget.fol)) + (tblEndUsers.rmte - SUM(tblBudget.rmte)) + (tblEndUsers.om - SUM(tblBudget.om)) + (tblEndUsers.co - SUM(tblBudget.co)) + (tblEndUsers.repex - SUM(tblBudget.repex)) + (tblEndUsers.osme - SUM(tblBudget.osme)) + (tblEndUsers.pcs - SUM(tblBudget.pcs)) + (tblEndUsers.telex - SUM(tblBudget.telex)) + (tblEndUsers.ogs - SUM(tblBudget.ogs)) + (tblEndUsers.rmbos - SUM(tblBudget.rmbos)) + (tblEndUsers.rmme - SUM(tblBudget.rmme)) + (tblEndUsers.rmff - SUM(tblBudget.rmff)) + (tblEndUsers.rmoppe - SUM(tblBudget.rmoppe)) + (tblEndUsers.ppe - SUM(tblBudget.ppe)) + (tblEndUsers.travexloc - SUM(tblBudget.travexloc)) + (tblEndUsers.qa - SUM(tblBudget.qa))) AS remainingTB FROM tblBudget INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE tblBudget.Name = @user AND tblBudget.year = @year GROUP BY tblEndUsers.os, tblEndUsers.fol, tblEndUsers.rmte, tblEndUsers.om, tblEndUsers.co, tblEndUsers.repex, tblEndUsers.osme, tblEndUsers.pcs, tblEndUsers.telex, tblEndUsers.ogs, tblEndUsers.rmbos, tblEndUsers.rmme, tblEndUsers.rmff, tblEndUsers.rmoppe, tblEndUsers.ppe, tblEndUsers.advertisingex, tblEndUsers.travexloc, tblEndUsers.qa";
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

        //        //remainingTB.Text = dr["remainingTB"].ToString();
        //        Program.remainingOS = Convert.ToInt32(dr["remainingOS"]);
        //        Program.remainingFOL = Convert.ToInt32(dr["remainingFOL"]);
        //        Program.remainingRMTE = Convert.ToInt32(dr["remainingRMTE"]);
        //        Program.remainingOM = Convert.ToInt32(dr["remainingOM"]);
        //        Program.remainingCO = Convert.ToInt32(dr["remainingCO"]);
        //        Program.remainingRepEx = Convert.ToInt32(dr["remainingRepEx"]);
        //        Program.remainingTB = Convert.ToInt32(dr["remainingTB"]);
        //        Program.remainingOSME = Convert.ToInt32(dr["remainingOSME"]);
        //        Program.remainingPCS = Convert.ToInt32(dr["remainingPCS"]);
        //        Program.remainingTelEx = Convert.ToInt32(dr["remainingTelEx"]);
        //        Program.remainingOGS = Convert.ToInt32(dr["remainingOGS"]);
        //        Program.remainingRMBOS = Convert.ToInt32(dr["remainingRMBOS"]);
        //        Program.remainingRMME = Convert.ToInt32(dr["remainingRMME"]);
        //        Program.remainingRMFF = Convert.ToInt32(dr["remainingRMFF"]);
        //        Program.remainingRMOPPE = Convert.ToInt32(dr["remainingRMOPPE"]);
        //        Program.remainingPPE = Convert.ToInt32(dr["remainingPPE"]);
        //        Program.remainingAdvertisingEx = Convert.ToInt32(dr["remainingAdvertisingEx"]);
        //        Program.remainingTravExLoc = Convert.ToInt32(dr["remainingTravExLoc"]);
        //    }

        //    try
        //    {
        //        if (comboSource.SelectedIndex == 0)
        //        {

        //            if (Program.remainingOS < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOS);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 1)
        //        {

        //            if (Program.remainingFOL < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingFOL);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 2)
        //        {

        //            if (Program.remainingRMTE < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMTE);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 3)
        //        {

        //            if (Program.remainingOM < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOM);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 4)
        //        {

        //            if (Program.remainingCO < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingCO);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 5)
        //        {

        //            if (Program.remainingRepEx < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRepEx);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 6)
        //        {

        //            if (Program.remainingOSME < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOSME);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 7)
        //        {

        //            if (Program.remainingPCS < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPCS);
        //                txtCost.Text = string.Empty;
        //            }
        //        }                                
        //        if (comboSource.SelectedIndex == 8)
        //        {

        //            if (Program.remainingRMBOS < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMBOS);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 9)
        //        {

        //            if (Program.remainingRMME < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMME);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 10)
        //        {

        //            if (Program.remainingRMFF < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMFF);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 11)
        //        {

        //            if (Program.remainingRMOPPE < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMOPPE);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 12)
        //        {

        //            if (Program.remainingPPE < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPPE);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 12)
        //        {

        //            if (Program.remainingPPE < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPPE);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 13)
        //        {

        //            if (Program.remainingAdvertisingEx < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingAdvertisingEx);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //        if (comboSource.SelectedIndex == 14)
        //        {

        //            if (Program.remainingTravExLoc < Convert.ToInt32(txtCost.Text))
        //            {
        //                MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTravExLoc);
        //                txtCost.Text = string.Empty;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }

            
        //}


        void remainingBudget()
        {
            
            string year = dateTimePicker1.Value.ToString("yyyy");
            string user = comboUser.Text;
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) // Check if there's a row available
            {
                if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                {
                    Program.nRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                }
                else
                {
                    Program.nRemainingAmount = 0.00m; // Use 'm' for decimal literals
                }
            }
            else
            {
                Program.nRemainingAmount = 0.00m; // Default value when no rows are found
            }

            try
            {
                if (Program.nRemainingAmount < Convert.ToInt32(txtCost.Text))
                {
                    MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.nRemainingAmount);
                    txtCost.Text = string.Empty;
                } 
            }

            catch (Exception ex)
            {

            }


        }

        private void sourceTypeDeterminer()
        {
            switch (Program.PRType) { 
                case 1:
                    {
                        if (comboSource.SelectedIndex == 0)
                        {
                            Program.sourcetypedeterminer = "os";                           
                        }                        
                        if (comboSource.SelectedIndex == 1)
                        {
                            Program.sourcetypedeterminer = "fol";
                        }
                        if (comboSource.SelectedIndex == 2)
                        {
                            Program.sourcetypedeterminer = "rmte";
                        }
                        if (comboSource.SelectedIndex == 3)
                        {
                            Program.sourcetypedeterminer = "om";
                        }
                        if (comboSource.SelectedIndex == 4)
                        {
                            Program.sourcetypedeterminer = "co";
                        }
                        if (comboSource.SelectedIndex == 5)
                        {
                            Program.sourcetypedeterminer = "repex";
                        }
                        if (comboSource.SelectedIndex == 6)
                        {
                            Program.sourcetypedeterminer = "osme";
                        }
                        if (comboSource.SelectedIndex == 7)
                        {
                            Program.sourcetypedeterminer = "pcs";
                        }
                        //if (comboSource.SelectedIndex == 8)
                        //{
                        //    Program.sourcetypedeterminer = "telex";
                        //}
                        //if (comboSource.SelectedIndex == 9)
                        //{
                        //    Program.sourcetypedeterminer = "ogs";
                        //}
                        if (comboSource.SelectedIndex == 8)
                        {
                            Program.sourcetypedeterminer = "rmbos";
                        }
                        if (comboSource.SelectedIndex == 9)
                        {
                            Program.sourcetypedeterminer = "rmme";
                        }
                        if (comboSource.SelectedIndex == 10)
                        {
                            Program.sourcetypedeterminer = "rmff";
                        }
                        if (comboSource.SelectedIndex == 11)
                        {
                            Program.sourcetypedeterminer = "rmoppe";
                        }
                        if (comboSource.SelectedIndex == 12)
                        {
                            Program.sourcetypedeterminer = "ppe";
                        }
                        if (comboSource.SelectedIndex == 13)
                        {
                            Program.sourcetypedeterminer = "advertisingex";
                        }
                        if (comboSource.SelectedIndex == 14)
                        {
                            Program.sourcetypedeterminer = "travexloc";
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

        void Allocation()
        {

            string year = dateTimePicker1.Value.ToString("yyyy");
            string user = comboUser.Text;
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read()) // Check if there's a row available
                {
                    if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.nRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                    }
                    else
                    {
                        Program.nRemainingAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userUsedAmount"] != DBNull.Value) // Check if the value is NULL
                    {                       
                        Program.nUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);  
                    }
                    else
                    {
                        Program.nUsedAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userAllocatedAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        
                        Program.nAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                    }
                    else
                    {
                        Program.nAllocatedAmount = 0.00m; // Use 'm' for decimal literals
                    }
                }
                else
                {
                    Program.nRemainingAmount = 0.00m; // Default value when no rows are found
                    Program.nUsedAmount = 0.00m;
                    Program.nAllocatedAmount = 0.00m;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        void subtractingBudget()
        {
            Program.nRemainingAmount = Program.nAllocatedAmount - (Program.nUsedAmount + Program.convertedCost);
        }

        void updateUserRemainingAmount()
        {
            Program.nRemainingAmount = Program.nAllocatedAmount - (Program.nUsedAmount + Program.convertedCost);

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.nUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                //// Parse and validate numeric inputs
                //decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                //decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                //decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


                //cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.nRemainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", Program.nUsedAmount + Program.convertedCost);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Buget Allocation Updated!");
        }

        private void saveBudget()
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string year = dateTimePicker1.Value.ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBudget(controlNumber, Name,Department,"+Program.sourcetypedeterminer+ ", year, date, description, source, amount, userAccountID) VALUES(@ctrlnum, @Name, @Dept, @source, @year, @date, @description, @filesource, @amount, @userAccountID)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text);
                cmd.Parameters.AddWithValue("@Name", comboUser.Text);
                cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                cmd.Parameters.AddWithValue("@source", Program.convertedCost);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@description", txtDesc.Text);
                cmd.Parameters.AddWithValue("@filesource", comboSource.Text);
                cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
                cmd.ExecuteNonQuery();

                string activity = "Created new PR - "
                + txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text
                + " | Name: " + comboUser.Text
                + " | Dept: " + comboDept.Text
                + " | Source: " + comboSource.Text
                + " | Date: " + date
                + " | Description: " + txtDesc.Text                
                + " | Cost: " + Program.convertedCost
                + " | Particulars: " + txtParticulars.Text
                + " | Remarks: " + txtRemarks.Text;


                AddUserLog(Program.userName, activity);
            }

            //MessageBox.Show("Budget Saved!");
            
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

        private void FileTypeDeterminer()
        {
            switch (Program.filetypedeterminer)
            {
                case 1:
                    Program.determinedfiletype = "Purchase Request File";
                    break;

                case 2:
                    Program.determinedfiletype = "Purchase Order File";
                    break;

                case 3:
                    Program.determinedfiletype = "Notice of Award File";
                    break;

                case 4:
                    Program.determinedfiletype = "Obligation Request File";
                    break;

                case 5:
                    Program.determinedfiletype = "Voucher File";
                    break;

                case 6:
                    Program.determinedfiletype = "Inspection File";
                    break;

                case 7:
                    Program.determinedfiletype = "PAR File";
                    break;

                case 8:
                    Program.determinedfiletype = "MR File";
                    break;

                case 9:
                    Program.determinedfiletype = "Summary File";
                    break;

                case 10:
                    Program.determinedfiletype = "Waste File";
                    break;
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
                string controlnumber = txtPRType.Text + txtyr.Text + txtCounter.Text + txtPRUser.Text;
                int fileyear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblFiles (controlNumber, fileType, data, fileName, extension, noOfAttachments, year) VALUES (@cnumber, @ftype, @data, @filename, @extn, @attachments, @year)", con);
                con.Open();
                cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                //cmd.Parameters.Add("@prid", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@ftype", SqlDbType.VarChar).Value = Program.determinedfiletype;
                cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = data;
                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                cmd.Parameters.Add("@attachments", SqlDbType.Int).Value = txtCounter.Text;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = fileyear;
                cmd.ExecuteNonQuery();
            }
        }


        private void OpenFile()
        {
            string controlnumber = txtPRType.Text + txtyr.Text + txtCounter.Text;

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblFiles WHERE controlNumber = @cnumber AND fileType = @filetype", con);
            con.Open();
            cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
            cmd.Parameters.Add("@filetype", SqlDbType.VarChar).Value = Program.determinedfiletype;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var name = dr["fileName"].ToString();
                var data = (byte[])dr["data"];
                var extn = dr["extension"].ToString();

                var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyy")) + extn;
                File.WriteAllBytes(newFileName, data);

                System.Diagnostics.Process.Start(newFileName);
            }

        }

        private void btnPROpen_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 1;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnPOattach_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 2;
            FileTypeDeterminer();
        }

        private void btnOpenPO_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 2;
            FileTypeDeterminer();
        }

        private void btnAttachAw_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 3;
            FileTypeDeterminer();
        }

        private void btnOpenAw_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 3;
            FileTypeDeterminer();
        }

        private void btnAttachObR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 4;
            FileTypeDeterminer();
        }

        private void btnOpenObR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 4;
            FileTypeDeterminer();
        }

        private void btnAttachVouch_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 5;
            FileTypeDeterminer();
        }

        private void btnOpenVouch_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 5;
            FileTypeDeterminer();
        }

        private void btnAttachInsp_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 6;
            FileTypeDeterminer();
        }

        private void btnOpenInsp_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 6;
            FileTypeDeterminer();
        }

        private void btnAttachPAR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 7;
            FileTypeDeterminer();
        }

        private void btnOpenPAR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 7;
            FileTypeDeterminer();
        }

        private void btnAttachMR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 8;
            FileTypeDeterminer();
        }

        private void btnOpenMR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 8;
            FileTypeDeterminer();
        }

        private void btnAttachSum_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 9;
            FileTypeDeterminer();
        }

        private void btnOpenSum_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 9;
            FileTypeDeterminer();
        }

        private void btnAttachWaste_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 10;
            FileTypeDeterminer();
        }

        private void btnOpenWaste_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 10;
            FileTypeDeterminer();
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE');", con);
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
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE');", con);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+txtUserYear.Text+"' AND (status IS NULL OR status <> 'INACTIVE') AND district = '" + Program.userStation + "';", con);
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
                         WHERE a.PR = 'Yes' AND ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@UserID", Program.nAccountUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    comboSource.DataSource = table;
                    comboSource.DisplayMember = "accountName";
                }
            }
            

        }

        private void icnPOGenerate_Click(object sender, EventArgs e)
        {
            generatePOQR();
        }

        private void generatePOQR()
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
            var result = new Bitmap(qr.Write(txtPOtype.Text + txtPOyr.Text + txtPOctrl.Text.Trim() + txtPOUser.Text));
            qrPOPic.Image = result;

        }

        private void icnPOPrint_Click(object sender, EventArgs e)
        {
            printPOQR();
        }

        private void DocPO_PrintPage(object sender, PrintPageEventArgs e)
        {
            //lblPOCN.Text = ;
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(lblPOCN.Font.FontFamily, 6);
            Font additionalTextFont2 = new Font(lblPOCN.Font.FontFamily, 9);
            Font additionalTextFont1 = new Font(lblPOSP.Font.FontFamily, 12);

            lblPODate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";
            lblPOSP.Text = "SP_VGO";


            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPOPic.Image, 0, 40, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(lblPOCN.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 120));
            // Draw the additional text on the print document
            e.Graphics.DrawString(lblPODate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 135));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 145));



            //ANOTHER COPY
            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPOPic.Image, 0, 220, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(lblPOCN.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 300));
            // Draw the additional text on the print document
            e.Graphics.DrawString(lblPODate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 315));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 325));



            ////Print image
            //Bitmap bm = new Bitmap(qrPanel.Width, qrPanel.Height);
            //qrPanel.DrawToBitmap(bm, new Rectangle(0, 0, qrPanel.Width, qrPanel.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        int counterPO;
        public void printPOQR()
        {
            //Show print dialog
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += DocPO_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();

            //counterPO = 1;

            //while (counterPO <= 1)
            //{
                

            //    if (counterPO != 1)
            //    {
            //        MessageBox.Show("Copy QR 0/1 Printed. Print Again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Copy QR 2/2 Printed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    counterPO++;
            //}

            //System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            //PrintDocument doc = new PrintDocument();
            //doc.PrintPage += printDocument1_PrintPage;
            //pd.Document = doc;
            //if (pd.ShowDialog() == DialogResult.OK)
            //    doc.Print();
        }

        private void printDocumentPO_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(qrPOPic.Width, qrPOPic.Height);
            qrPOPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPOPic.Width, qrPOPic.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
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

        private void comboDept_TextChanged(object sender, EventArgs e)
        {
            getUsers();
        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCost.Text = "0";
            sourceTypeDeterminer();

            //getAccountID();
            //getUserAccountID();
            
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
                    cmd.Parameters.AddWithValue("@AccountName", comboSource.Text);

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.nAccountID = dr["accountID"].ToString();
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
                    cmd.Parameters.AddWithValue("@userID", Program.nAccountUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.nAccountID);

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.nUserAccountID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }

        private void txtCost_KeyUp(object sender, KeyEventArgs e)
        {
            getUserID();
            getAccountID();
            getUserAccountID();

            //MessageBox.Show(Program.nUserAccountID);

            remainingBudget();
            
        }

        private void txtCost_Leave(object sender, EventArgs e)
        {
            
            
            if (txtCost.TextLength <= 0)
            {
                txtCost.Text = returnCost.ToString();
                txtCost.Text = string.Format("{0:n}", double.Parse(txtCost.Text));
                if (decimal.TryParse(txtCost.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    Program.convertedCost = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtCost.Text = string.Format("{0:n}", double.Parse(txtCost.Text));
                if (decimal.TryParse(txtCost.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                }
            }

        }

        private void txtCost_MouseLeave(object sender, EventArgs e)
        {
            
        }

        String savedCost = "0";
        float returnCost = 0;
        private void txtCost_Enter(object sender, EventArgs e)
        {

            savedCost = txtCost.Text;
            txtCost.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
          
        }

        private void icnVoucherGenerate_Click(object sender, EventArgs e)
        {
            generateVoucher();
            icnVoucherPrint.Enabled = true;
        }

        private void icnPOGenerate_Click_1(object sender, EventArgs e)
        {

        }

        private void icnPOPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void icnVoucherPrint_Click(object sender, EventArgs e)
        {
            printVoucherQR();
        }

        public void printVoucherQR()
        {
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument2_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            voucherCtrl.Text = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim();

            voucherDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";


            // Font for the additional text with size 12
            Font additionalTextFont = new Font(voucherCtrl.Font.FontFamily, 6);
            Font additionalTextFont2 = new Font(voucherCtrl.Font.FontFamily, 9);
            Font additionalTextFont1 = new Font(voucherSP.Font.FontFamily, 12);

            // Draw the QR code on the print document
            e.Graphics.DrawImage(qrPOPic.Image, 0, 40, 90, 90);

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
            e.Graphics.DrawImage(qrPOPic.Image, 0, 220, 90, 90);

            // StringFormat for center alignment
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(voucherCtrl.Text, additionalTextFont2, Brushes.Black, new PointF(float.Parse("1"), 300));
            // Draw the additional text on the print document
            e.Graphics.DrawString(voucherDate.Text, additionalTextFont, Brushes.Black, new PointF(float.Parse("-1.50"), 315));


            // Draw the additional text on the print document
            e.Graphics.DrawString("SP-VGO", additionalTextFont1, Brushes.Black, new PointF(float.Parse("1"), 325));




            ////Print image
            //Bitmap bm = new Bitmap(qrPic.Width, qrPic.Height);
            //qrPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPic.Width, qrPic.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUserID();
            getAccounts();
        }

        private void comboUser_TextChanged(object sender, EventArgs e)
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
                            Program.nAccountUserID = dr["userID"].ToString();
                        }
                    }
                }
            }
        }

        private void comboSource_TextChanged(object sender, EventArgs e)
        {
            //getUserID();
            //getAccountID();
            //getUserAccountID();

            
        }

        private void newPRForm_Activated(object sender, EventArgs e)
        {

        }

        private void txtUserYear_KeyUp(object sender, KeyEventArgs e)
        {
            getUsers();
        }
    }
}

