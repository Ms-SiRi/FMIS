using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ZXing.QrCode;
using ZXing;
using System.Drawing.Printing;
using System.Net.Mime;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.Web.UI.WebControls;

namespace FMIS
{
    public partial class editPR : Form
    {
        public editPR()
        {
            InitializeComponent();
            
            //generatePOQR();
            //generateVoucher();
            generateQR();
            generatePO();
            selectPR();

            //generatePOQR();


            Boolean empty = true;
            if (txtPRLoc.Text.Equals("") != empty)
            {
                empty = true;
                txtPOLoc.Enabled = true;
                lblPO.Enabled = true;
                btnPOattach.Enabled = true;
                btnOpenPO.Enabled = true;

            }

            if (txtPOLoc.Text.Equals("") != empty)
            {
                empty = true;

                txtAwardLoc.Enabled = true;
                lblAward.Enabled = true;
                btnAttachAw.Enabled = true;
                btnOpenAw.Enabled = true;
            }

            if (txtAwardLoc.Text.Equals("") != empty)
            {
                txtPOLoc.Enabled = true;
                lblPO.Enabled = true;
                btnPOattach.Enabled = true;
                btnOpenPO.Enabled = true;

                txtAwardLoc.Enabled = true;
                lblAward.Enabled = true;
                btnAttachAw.Enabled = true;
                btnOpenAw.Enabled = true;

                txtObRLoc.Enabled = true;
                lblObr.Enabled = true;
                btnAttachObR.Enabled = true;
                btnOpenObR.Enabled = true;
                
            }

            if (txtObRLoc.Text.Equals("") != empty)
            {

                txtVoucherLoc.Enabled = true;
                lblVoucher.Enabled = true;
                btnAttachVouch.Enabled = true;
                btnOpenVouch.Enabled = true;
            }

            if (txtVoucherLoc.Text.Equals("") != empty)
            {
                txtInspectionLoc.Enabled = true;
                lblInspection.Enabled = true;
                btnAttachInsp.Enabled = true;
                btnOpenInsp.Enabled = true;
            }

            if (txtInspectionLoc.Text.Equals("") != empty)
            {
                txtPARLoc.Enabled = true;
                lblPAR.Enabled = true;
                btnAttachPAR.Enabled = true;
                btnOpenPAR.Enabled = true;
            }

            if (txtPARLoc.Text.Equals("") != empty)
            {
                txtMRLoc.Enabled = true;
                lblMR.Enabled = true;
                btnAttachMR.Enabled = true;
                btnOpenMR.Enabled = true;
            }

            if (txtMRLoc.Text.Equals("") != empty)
            {
                txtSummaryLoc.Enabled = true;
                lblSummary.Enabled = true;
                btnAttachSum.Enabled = true;
                btnOpenSum.Enabled = true;
            }

            if (txtSummaryLoc.Text.Equals("") != empty)
            {
                txtWasteLoc.Enabled = true;
                lblWaste.Enabled = true;
                btnAttachWaste.Enabled = true;
                btnOpenWaste.Enabled = true;
            }

            //ffor enabling Actual Cost Textbox
            if (txtAwardLoc.Text.Equals("") != empty && txtPOLoc.Text.Equals("") != empty)
            {
                txtActualCost.Enabled = false;
            }

            if (txtObRLoc.Text.Equals("") != empty)
            {
                txtActualCost.Enabled = false;
            }

            //trapping of OBR Enability
            if (txtAwardLoc.Text.Equals("") == empty || txtPOLoc.Text.Equals("") == empty)
            {
                txtActualCost.Enabled = true;
                btnAttachObR.Enabled = false;
                txtObRLoc.Enabled = false;
            }


        }

        //public void selectPR()
        //{
        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    String query = "Select * FROM qrMotherTable WHERE ctrlNumber = '" + Program.ctrl +"'";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();


        //    while (dr.Read())
        //    {
        //        Program.ePRID = dr["ctrlNumber"].ToString();

        //        if (dr["poControlNumber"] == DBNull.Value)
        //        {
        //            txtdbPOCtrl.Visible = false;
        //            //txtPOUser.Visible = false;
        //            pocontrol = (txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text + txtPOUser.Text).Trim();
        //        }
        //        else
        //        {
        //            txtdbPOCtrl.Visible = true;
        //            //txtPOUser.Visible = true;
        //            txtdbPOCtrl.Text = dr["poControlNumber"].ToString();
        //            pocontrol = txtdbPOCtrl.Text.Trim();
        //            generatePOQR();
        //        }

        //        if (dr["voucherControlNumber"] == DBNull.Value)
        //        {
        //            txtdbVoucherCtrl.Visible = false;
        //            vouchercontrol = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim() + txtVoucherUser.Text;
        //        }
        //        else
        //        {
        //            txtdbVoucherCtrl.Visible = true;
        //            txtdbVoucherCtrl.Text = dr["voucherControlNumber"].ToString();
        //            vouchercontrol= txtdbVoucherCtrl.Text.Trim();
        //            generateVoucher();
        //        }

        //        txtCtrl.Text = dr["ctrlNumber"].ToString();
        //        comboType.Text = dr["prType"].ToString();
        //        comboDept.Text = dr["prDept"].ToString();
        //        comboUser.Text = dr["prEnduser"].ToString();
        //        comboSource.Text = dr["prSource"].ToString();
        //        txtdate.Text = DateTime.Parse(dr["prDate"].ToString()).ToShortDateString();
        //        txtDesc.Text = dr["prDescription"].ToString();
        //        txtCost.Text = dr["proposedCost"].ToString();
        //        txtCost.Text = string.Format("{0:n}", double.Parse(txtCost.Text));
        //        txtActualCost.Text = dr["prCost"].ToString();
        //        txtActualCost.Text = string.Format("{0:n}", double.Parse(txtActualCost.Text));
        //        txtParticulars.Text = dr["prParticulars"].ToString();
        //        txtRemarks.Text = dr["prRemarks"].ToString();
        //        txtPRLoc.Text = dr["prFname"].ToString();
        //        txtPOLoc.Text = dr["poFname"].ToString();
        //        txtAwardLoc.Text = dr["awardFname"].ToString();
        //        txtObRLoc.Text = dr["obrFname"].ToString();
        //        txtVoucherLoc.Text = dr["voucherFname"].ToString();
        //        txtInspectionLoc.Text = dr["inspectionFnam"].ToString();                
        //        txtPARLoc.Text = dr["parFname"].ToString();
        //        txtMRLoc.Text = dr["mrFname"].ToString();
        //        txtSummaryLoc.Text = dr["summaryFname"].ToString();
        //        txtWasteLoc.Text = dr["wasteFname"].ToString();

        //        string controlnum = txtCtrl.Text;
        //        //txtPOctrl.Text = controlnum.Substring(controlnum.Length - 4);
        //        //txtPOyr.Text = controlnum.Substring(3, 4);

        //        oldCost = Convert.ToDecimal(dr["prCost"].ToString());

        //    }

        //}

        public void selectPR()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"SELECT * 
                         FROM qrMotherTable 
                         WHERE ctrlNumber = @ctrlNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ctrlNumber", Program.ctrl);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read()) return;

                        Program.ePRID = dr["ctrlNumber"].ToString();

                        string userYearData = dr["userYear"].ToString();
                        if (userYearData == "")
                        {
                            //MessageBox.Show("NULL");
                            txtUserYear.Text = Convert.ToDateTime(dr["prDate"]).ToString("yyyy");
                        }
                        else
                        {
                            //MessageBox.Show("NOT NULL");
                            txtUserYear.Text = (dr["userYear"]).ToString();
                        }
                            
                        
                        // ================= PO CONTROL =================
                        if (dr["poControlNumber"] == DBNull.Value)
                        {
                            txtdbPOCtrl.Visible = false;
                            pocontrol = (txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text + txtPOUser.Text).Trim();
                        }
                        else
                        {
                            txtdbPOCtrl.Visible = true;
                            txtdbPOCtrl.Text = dr["poControlNumber"].ToString();
                            pocontrol = txtdbPOCtrl.Text.Trim();
                            generatePOQR();
                        }

                        // ================= VOUCHER CONTROL =================
                        if (dr["voucherControlNumber"] == DBNull.Value)
                        {
                            txtdbVoucherCtrl.Visible = false;
                            vouchercontrol = txtVoucherType.Text
                                           + txtVoucherYear.Text
                                           + txtVoucherCounter.Text.Trim()
                                           + txtVoucherUser.Text;
                        }
                        else
                        {
                            txtdbVoucherCtrl.Visible = true;
                            txtdbVoucherCtrl.Text = dr["voucherControlNumber"].ToString();
                            vouchercontrol = txtdbVoucherCtrl.Text.Trim();
                            generateVoucher();
                        }

                        // ================= BASIC FIELDS =================
                        txtCtrl.Text = dr["ctrlNumber"].ToString();
                        comboType.Text = dr["prType"].ToString();
                        comboDept.Text = dr["prDept"].ToString();
                        
                        // ✅ FIX: TEXT-BASED COMBOBOX SELECTION
                        comboUser.Text = dr["prEnduser"].ToString().Trim();
                        comboSource.Text = dr["prSource"].ToString().Trim();

                        txtdate.Text = Convert.ToDateTime(dr["prDate"]).ToShortDateString();

                        

                        txtDesc.Text = dr["prDescription"].ToString();

                        txtCost.Text = string.Format("{0:n}", Convert.ToDecimal(dr["proposedCost"]));
                        txtActualCost.Text = string.Format("{0:n}", Convert.ToDecimal(dr["prCost"]));

                        txtParticulars.Text = dr["prParticulars"].ToString();
                        txtRemarks.Text = dr["prRemarks"].ToString();

                        // ================= FILE LOCATIONS =================
                        txtPRLoc.Text = dr["prFname"].ToString();
                        txtPOLoc.Text = dr["poFname"].ToString();
                        txtAwardLoc.Text = dr["awardFname"].ToString();
                        txtObRLoc.Text = dr["obrFname"].ToString();
                        txtVoucherLoc.Text = dr["voucherFname"].ToString();
                        txtInspectionLoc.Text = dr["inspectionFnam"].ToString();
                        txtPARLoc.Text = dr["parFname"].ToString();
                        txtMRLoc.Text = dr["mrFname"].ToString();
                        txtSummaryLoc.Text = dr["summaryFname"].ToString();
                        txtWasteLoc.Text = dr["wasteFname"].ToString();

                        oldCost = Convert.ToDecimal(dr["prCost"]);
                    }
                }
            }
        }



        int tempPO;
        string zero;
        private void generatePO()
        {
            selectCount();

            string controlcounter = tempPO.ToString();
            if (controlcounter.Length < 1)
            {
                zero = "0000";
                txtPOctrl.Text = zero + tempPO.ToString();

            }
            if (controlcounter.Length == 1)
            {
                zero = "000";
                txtPOctrl.Text = zero + tempPO.ToString();
            }
            else if (controlcounter.Length == 2)
            {
                zero = "00";
                txtPOctrl.Text = zero + tempPO.ToString();
            }
            else if (controlcounter.Length == 3)
            {
                zero = "0";
                txtPOctrl.Text = zero + tempPO.ToString();
            }
            else
            {
                zero = "";
                txtPOctrl.Text = zero + tempPO.ToString();
            }


        }
        private void selectCount()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "Select COUNT(prPO) AS POcount FROM qrMotherTable WHERE prPO IS NOT NULL";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                tempPO = 1 + Convert.ToInt32(dr["POcount"]);
                

            }

            txtPOyr.Text = DateTime.Now.ToString("yyyy");
        }


        private void txtSummaryLoc_TextChanged(object sender, EventArgs e)
        {
             
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

        private void OpenFile()
        {
            //string controlnumber = txtCtrl.Text;

            //SqlConnection con = new SqlConnection(Program.ConnString);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM tblFiles WHERE controlNumber = @cnumber AND fileType = @filetype", con);
            //con.Open();
            //cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
            //cmd.Parameters.Add("@filetype", SqlDbType.VarChar).Value = Program.determinedfiletype;
            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    var name = dr["fileName"].ToString();
            //    var data = (byte[])dr["data"];
            //    var extn = dr["extension"].ToString();

            //    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyy")) + extn;
            //    File.WriteAllBytes(newFileName, data);

            //    System.Diagnostics.Process.Start(newFileName);
            //}

            using (SqlConnection connection = new SqlConnection(Program.ConnString))
            {
                string controlnumber = txtCtrl.Text;
                string query = "SELECT * FROM tblFiles WHERE controlNumber = @cnumber AND fileType = @filetype";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                command.Parameters.Add("@filetype", SqlDbType.VarChar).Value = Program.determinedfiletype;

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

        private void btnPROpen_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 1;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenPO_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 2;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenAw_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 3;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenObR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 4;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenVouch_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 5;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenInsp_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 6;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenPAR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 7;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenMR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 8;
            FileTypeDeterminer();
            OpenFile();

        }

        private void btnOpenSum_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 9;
            FileTypeDeterminer();
            OpenFile();
        }

        private void btnOpenWaste_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 10;
            FileTypeDeterminer();
            OpenFile();
        }

        private void updateFileDetails()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE qrMotherTable SET prDept = @prDept,prEnduser = @prEnduser,prSource = @prSource" +
                ",prDescription = @prDescription,prCost = @prCost,prParticulars = @prParticulars,prRemarks = @prRemarks,prDate = @prDate WHERE ctrlNumber = @ctrlNumber";

            con.Open();
            


            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlNumber", txtCtrl.Text);
                //cmd.Parameters.AddWithValue("@prType", txtPRType.Text);
                cmd.Parameters.AddWithValue("@prDept", comboDept.Text);
                cmd.Parameters.AddWithValue("@prEnduser", comboUser.Text);
                cmd.Parameters.AddWithValue("@prSource", comboSource.Text);
                cmd.Parameters.AddWithValue("@prDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@prCost", Program.convertedCost);
                cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prDate", date);

                cmd.ExecuteNonQuery();

                string activity = "Edited PR - CtrlNumber: " + txtCtrl.Text
                + " | Name: " + comboUser.Text
                + " | Dept: " + comboDept.Text
                + " | Source: " + comboSource.Text
                + " | Date: " + date
                + " | Description: " + txtDesc.Text
                + " | Old Cost: " + txtCost.Text
                + " | New Cost: " + txtActualCost.Text
                + " | Particulars: " + txtParticulars.Text
                + " | Remarks: " + txtRemarks.Text;

                AddUserLog(Program.userName, activity);
            }

            MessageBox.Show("Details Updated!");
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

        void UploadFile(string file)
        {
            try
            {
                string controlnumber = txtCtrl.Text;
                String controltype = "ctrlNumber";
                Program.controltypevalue = controlnumber;
                //Program.controltypevalue = txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text;
                switch (Program.controltype)
                {

                    case 1:
                        {
                            if(txtdbPOCtrl.Visible == false)
                            {
                                controltype = "poControlNumber";
                                Program.controltypevalue = txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text + txtPOUser.Text;  
                            }
                            break;
                        }
                    case 2:
                        {
                            if (txtdbVoucherCtrl.Visible == false)
                            {
                                controltype = "voucherControlNumber";
                                Program.controltypevalue = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text;
                            }                           
                            break;
                        }

                }

                

                string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd;
                String query = "UPDATE qrMotherTable SET prDept = @prDept,prEnduser = @prEnduser,prSource = @prSource" +
                    ",prDescription = @prDescription,prCost = @prCost,prParticulars = @prParticulars,prRemarks = @prRemarks,prDate = @prDate," + Program.contentdeterminer + " = @prFile," +
                    "prStatus = @prStatus," + Program.fnamedeterminer + " = @prFname, " + controltype + " = @controltypevalue WHERE ctrlNumber = @ctrlNumber";

                con.Open();
                FileStream fstream = File.OpenRead(file);
                byte[] content = new byte[fstream.Length];
                fstream.Read(content, 0, (int)fstream.Length);
                fstream.Close();


                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ctrlNumber", txtCtrl.Text);
                    //cmd.Parameters.AddWithValue("@prType", txtPRType.Text);
                    cmd.Parameters.AddWithValue("@prDept", comboDept.Text);
                    cmd.Parameters.AddWithValue("@prEnduser", comboUser.Text);
                    cmd.Parameters.AddWithValue("@prSource", comboSource.Text);
                    cmd.Parameters.AddWithValue("@prDescription", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@prCost", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                    cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                    cmd.Parameters.AddWithValue("@prFname", Program.filelabel);
                    cmd.Parameters.AddWithValue("@prDate", date);
                    cmd.Parameters.AddWithValue("@prFile", content);
                    cmd.Parameters.AddWithValue("@prStatus", Program.filestatus);
                    cmd.Parameters.AddWithValue("@controltypevalue", Program.controltypevalue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Files Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        string filename;
        private void btnPRattach_Click(object sender, EventArgs e)
        {
            Program.controltype = 0;
            Program.filetypedeterminer = 1;
            Program.contentdeterminer = "prFile";
            Program.fnamedeterminer = "prFname";

            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtPRLoc.Text = txtCtrl.Text + "PR_File";
                        btnGenerate.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 1;
                        Program.filelabel = txtPRLoc.Text;
                        txtAwardLoc.Enabled = true;
                        btnAttachAw.Enabled = true;
                        UploadFile(filename);
                        completeAttachements();
                    }
                }
            }

            
        }

        private void btnPOattach_Click(object sender, EventArgs e)
        {
            Program.controltype = 1;
            Program.filetypedeterminer = 2;
            Program.contentdeterminer = "prPO";
            Program.fnamedeterminer = "poFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtPOLoc.Text = txtCtrl.Text + "PO_File";
                        icnPOGenerate.Enabled = true;
                        icnPOPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 1;
                        Program.filelabel = txtPOLoc.Text;
                        txtAwardLoc.Enabled = true;
                        btnAttachAw.Enabled = true;
                        btnOpenAw.Enabled = true;
                        UploadFile(filename);
                        SaveFile(filename);
                        completeAttachements();
                    }
                }
            }

            
        }

        private void btnAttachAw_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 3;
            Program.contentdeterminer = "prAward";
            Program.fnamedeterminer = "awardFname";
            FileTypeDeterminer();
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtAwardLoc.Text = txtCtrl.Text + "Award_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtAwardLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        completeAttachements();
                        updateFileDetails();
                        txtActualCost.Enabled = true;
                        txtObRLoc.Enabled = true;
                        lblObr.Enabled = true;
                        btnAttachObR.Enabled = true;
                        btnOpenObR.Enabled = true;
                    }
                }
            }
            this.Close();

            
        }

        private void btnAttachObR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 4;
            Program.contentdeterminer = "prObR";
            Program.fnamedeterminer = "obrFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtObRLoc.Text = txtCtrl.Text + "Obligation_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtObRLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        txtVoucherLoc.Enabled = true;
                        lblVoucher.Enabled = true;
                        btnAttachVouch.Enabled = true;
                        btnOpenVouch.Enabled = true;
                        completeAttachements();
                        updateFileDetails();
                        txtActualCost.Enabled = false;
                    }
                }
            }

            this.Close();
        }

        private void btnAttachVouch_Click(object sender, EventArgs e)
        {
            Program.controltype = 2;
            Program.filetypedeterminer = 5;
            Program.contentdeterminer = "prVoucher";
            Program.fnamedeterminer = "voucherFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtVoucherLoc.Text = txtCtrl.Text + "Voucher_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtObRLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        updateFileDetails();
                        txtInspectionLoc.Enabled = true;
                        lblInspection.Enabled = true;
                        btnAttachInsp.Enabled = true;
                        btnOpenInsp.Enabled = true;
                        completeAttachements();
                    }
                }
            }

            
        }

        private void btnAttachInsp_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 6;
            Program.contentdeterminer = "prInspection";
            Program.fnamedeterminer = "inspectionFnam";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtInspectionLoc.Text = txtCtrl.Text + "Inspection_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtInspectionLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        txtPARLoc.Enabled = true;
                        lblPAR.Enabled = true;
                        btnAttachPAR.Enabled = true;
                        btnOpenPAR.Enabled = true;
                        completeAttachements();
                    }
                }
            }

            this.Close();
        }

        private void btnAttachPAR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 7;
            Program.contentdeterminer = "prPAR";
            Program.fnamedeterminer = "parFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtPARLoc.Text = txtCtrl.Text + "PAR_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtPARLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        txtMRLoc.Enabled = true;
                        lblMR.Enabled = true;
                        btnAttachMR.Enabled = true;
                        btnOpenMR.Enabled = true;
                        completeAttachements();
                    }
                }
            }

            this.Close();
        }

        private void btnAttachMR_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 8;
            Program.contentdeterminer = "prMR";
            Program.fnamedeterminer = "mrFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtMRLoc.Text = txtCtrl.Text + "MR_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtMRLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        txtSummaryLoc.Enabled = true;
                        lblSummary.Enabled = true;
                        btnAttachSum.Enabled = true;
                        btnOpenSum.Enabled = true;
                        completeAttachements();
                    }
                }
            }

            this.Close();
        }

        private void btnAttachSum_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 9;
            Program.contentdeterminer = "prSummary";
            Program.fnamedeterminer = "summaryFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtSummaryLoc.Text = txtCtrl.Text + "Summary_File";
                        icnPOPrint.Enabled = true;
                        qrPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 2;
                        Program.filelabel = txtSummaryLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        txtWasteLoc.Enabled = true;
                        lblWaste.Enabled = true;
                        btnAttachWaste.Enabled = true;
                        btnOpenWaste.Enabled = true;
                        completeAttachements();
                    }
                }
            }

            this.Close();
        }

        private void btnAttachWaste_Click(object sender, EventArgs e)
        {
            Program.filetypedeterminer = 10;
            Program.contentdeterminer = "prWaste";
            Program.fnamedeterminer = "wasteFname";
            FileTypeDeterminer();

            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        filename = dlg.FileName;
                        txtWasteLoc.Text = txtCtrl.Text + "Waste_File";
                        btnGenerate.Enabled = true;
                        icnPOPrint.Enabled = true;
                        Program.updatedeterminer = 1;
                        Program.filestatus = 3;
                        Program.filelabel = txtWasteLoc.Text;
                        UploadFile(filename);
                        SaveFile(filename);
                        completeAttachements();
                    }
                }
            }

            this.Close();
        }

        void StationIdentifier()
        {
            if (Program.userStation == "VGO")
            {
                //txtPRUser.Text = "VGO";
                txtPOUser.Text = "VGO";
                txtVoucherUser.Text = "VGO";
            }
            else if (Program.userStation == "SP")
            {
                //txtPRUser.Text = "SP";
                txtPOUser.Text = "SP";
                txtVoucherUser.Text = "SP";
            }
            else if (Program.userStation == "ALL")
            {
                //txtPRUser.Text = "A";
                txtPOUser.Text = "A";
                txtVoucherUser.Text = "A";
            }
            else if (Program.userStation == "1st District")
            {
                //txtPRUser.Text = "D1";
                txtPOUser.Text = "D1";
                txtVoucherUser.Text = "D1";
            }
            else if (Program.userStation == "2nd District")
            {
                //txtPRUser.Text = "D2";
                txtPOUser.Text = "D2";
                txtVoucherUser.Text = "D2";
            }
            else if (Program.userStation == "3rd District")
            {
                //txtPRUser.Text = "D3";
                txtPOUser.Text = "D3";
                txtVoucherUser.Text = "D3";
            }
        }

        decimal firstActualCost;
        int oldeUserAccountID;            // Old user’s account ID
        decimal oldeAllocatedAmount;      // Old user’s allocated budget
        decimal oldeUsedAmount;           // Old user’s already used budget
        decimal oldeRemainingAmount;
        private void editPR_Load(object sender, EventArgs e)
        {
            StationIdentifier();
            comboDept.SelectedIndex = 0;
            getUsers();
            if(Program.userType == "superadmin")
            {
                comboDept.Enabled = true;
                comboUser.Enabled = true;
                comboSource.Enabled = true;               
                //txtActualCost.Enabled = true;
                


                //if (decimal.TryParse(txtActualCost.Text, out decimal firstactualcostresult))
                //{
                //    firstActualCost = Convert.ToDecimal(firstactualcostresult);

                //}
            }
            else
            {
                comboDept.Enabled = false;
                comboUser.Enabled = false;
                comboSource.Enabled = false;
                //txtActualCost.Enabled = false;
            }

                savedCost = txtActualCost.Text;
            txtActualCost.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result1))
            {
                Program.convertedCost = Convert.ToDecimal(result1);

            }

            if (txtdbPOCtrl.Visible == true)
            {
                lblPOCN.Text = txtdbPOCtrl.Text;
            }

            txtPRLoc.Enabled = false;
            btnPRattach.Enabled = false;
            btnPROpen.Enabled = true;
            controlidByFileTypeofVoucher();
            controlidByFileTypeofPO();
            txtVoucherYear.Text = DateTime.Now.ToString("yyyy");
            selectPR();
            if (decimal.TryParse(txtActualCost.Text, out decimal result))
            {
                Program.convertedCost = Convert.ToDecimal(result);
            }

            //determiningPRType();
            if (txtPOLoc.Text != String.Empty)
            {
                //generatePOQR();
                icnPOGenerate.Enabled = true;
                icnPOPrint.Enabled=true;
            }

            LoadOldPRDetails();

        }

        

        void LoadOldPRDetails()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAccountID, amount " +
                               "FROM tblBudget WHERE controlNumber = @prID";  // <-- your PR table/identifier

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@prID", Program.ePRID); // Store PRID globally when editing
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        oldeUserAccountID = Convert.ToInt32(dr["userAccountID"]);
                        firstActualCost = Convert.ToDecimal(dr["amount"]);
                    }
                }
            }

            // Now also load the old user’s allocation balances
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAllocatedAmount, userUsedAmount, userRemainingAmount " +
                               "FROM tblUserAccounts WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userAccountID", oldeUserAccountID);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        oldeAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                        oldeUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                        oldeRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                    }
                }
            }
        }


        int highestvoucherid;
        string voucherzero;
        int highestpoid;
        string pozero;
        public void controlidByFileTypeofVoucher()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            String getquery = "SELECT COUNT(fileID) AS LatestNum, MAX(noOfAttachments) as count_control FROM tblFiles WHERE fileType = 'Voucher File' AND year = YEAR(GETDATE());";
            con.Open();
            SqlCommand cmd = new SqlCommand(getquery, con);
            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
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



        void determiningPRType()
        {
            if (comboType.SelectedIndex == 0)
            {
                comboType.Text = "PRR";
                Program.PRType = 1;
                sourceItems();
            }
            else if (comboType.SelectedIndex == 1)
            {
                comboType.Text = "PRE";
                comboSource.SelectedIndex = 1;
                //comboSource.Enabled = false;
                Program.PRType = 2;
                sourceItems();
            }
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
                comboSource.SelectedIndex = 0;
            }
            else if (Program.PRType == 2)
            {
                comboSource.Items.Clear();
                comboSource.Items.Add("Fuel, Oil, Lubricants");
                comboSource.Items.Add("R/M-Trans. Equipment");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void generateQR()
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
            var result = new Bitmap(qr.Write(Program.ctrl.ToString()));
            qrPic.Image = result;

            lblPRCN.Text = Program.ctrl.ToString();
        }

        private void txtVoucherLoc_TextChanged(object sender, EventArgs e)
        {

        }



        private void icnUpdate_Click(object sender, EventArgs e)
        {
            emptyFields();
            
        }

        void updateCost()
        {
            updateFileDetails();
        }

        void finishedFileStatus()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE qrMotherTable SET prCost = @prCost, prStatus = @prStatus WHERE ctrlNumber = @ctrlNumber";

            con.Open();



            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlNumber", txtCtrl.Text);
                cmd.Parameters.AddWithValue("@prCost", Program.convertedCost);
                cmd.Parameters.AddWithValue("@prStatus", Program.filestatus);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Request Completed!");
        }

        void saveFunction()
        {  
            if(txtActualCost.Enabled == true)
            {
                updateCost();
            }
            else
            {
                if(Program.requeststatus == "Done")
                {
                    Program.filestatus = 3;
                    finishedFileStatus();
                }
            }
        }

        //floated cost
        private void floatedCost()
        {
            if (txtActualCost.TextLength <= 0)
            {
                txtActualCost.Text = returnCost.ToString();
                txtActualCost.Text = string.Format("{0:n}", double.Parse(txtActualCost.Text));
                if (decimal.TryParse(txtActualCost.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                    Program.actualc = Convert.ToDecimal(result);
                    Program.totalc = 0;
                }
                if (decimal.TryParse(txtCost.Text, out decimal resultc))
                {
                    Program.totalc = Convert.ToDecimal(resultc);
                }

            }
            else
            {
                txtActualCost.Text = string.Format("{0:n}", double.Parse(txtActualCost.Text));
                if (decimal.TryParse(txtActualCost.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                    Program.actualc = Convert.ToDecimal(result);
                }
                if (decimal.TryParse(txtCost.Text, out decimal resultc))
                {
                    Program.totalc = Convert.ToDecimal(resultc);
                }
            }
        }

        private void emptyFields()
        {
            if (txtCtrl.Text.Equals("") || txtcnPO.Text == "" || txtPOyr.Text == "" || txtPOctrl.Text == "" || comboType.Text == "" || comboDept.Text == "" || comboSource.Text == "" || txtdate.Text == "" || txtDesc.Text == "" || txtCost.Text == "" || txtParticulars.Text == "" || txtRemarks.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                if (Program.updatedeterminer == 0)
                {
                    floatedCost();
                    updateFileDetails();
                    clearBudget();
                    updateBudget();
                    Allocation();


                    int oldUserAccountID = Convert.ToInt32(oldeUserAccountID);
                    int evUserAccountID = Convert.ToInt32(Program.eUserAccountID);

                    if (oldUserAccountID == evUserAccountID)
                    {
                        updateUserRemainingAmount();
                        
                    }
                    else
                    {
                        RestoreOldUserAllocation();
                        updateNewUserRemainingAmount();
                        
                    }


                    this.Close();
                }
                else
                {                   
                    UploadFile(filename);
                    floatedCost();
                    //SaveFile(filename);
                    updateFileDetails();
                    clearBudget();
                    updateBudget();
                    Allocation();

                    int oldUserAccountID = Convert.ToInt32(oldeUserAccountID);
                    int evUserAccountID = Convert.ToInt32(Program.eUserAccountID);

                    if (oldUserAccountID == evUserAccountID)
                    {
                        updateUserRemainingAmount();

                    }
                    else
                    {
                        RestoreOldUserAllocation();
                        updateNewUserRemainingAmount();

                    }



                    this.Close();
                }
                
            }
        }

        private void sourceTypeDeterminer()
        {
            switch (Program.PRType)
            {
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

        private void clearBudget()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");
            string year = DateTime.Parse(txtdate.Text).ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblBudget SET os = @os, fol = @fol, rmte = @rmte, om = @om, co = @co, repex = @repex  WHERE controlNumber = @ctrlnum";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", Program.ctrl);
                cmd.Parameters.AddWithValue("@os", 0);
                cmd.Parameters.AddWithValue("@fol", 0);
                cmd.Parameters.AddWithValue("@rmte", 0);
                cmd.Parameters.AddWithValue("@om", 0);
                cmd.Parameters.AddWithValue("@co", 0);
                cmd.Parameters.AddWithValue("@repex", 0);

                cmd.ExecuteNonQuery();
            }

            //MessageBox.Show("Budget Cleared!");

        }

        private void updateBudget()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");
            string year = DateTime.Parse(txtdate.Text).ToString("yyyy");

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();
                SqlCommand cmd;

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

                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ctrlnum", Program.ctrl);
                    cmd.Parameters.AddWithValue("@Name", comboUser.Text);
                    cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                    cmd.Parameters.AddWithValue("@source", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@description", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@filesource", comboSource.Text);
                    cmd.Parameters.AddWithValue("@amount", Program.convertedCost);
                    cmd.Parameters.AddWithValue("@userAccountID", Program.eUserAccountID); // ✅ added
                    cmd.ExecuteNonQuery();
                }
            }

            //MessageBox.Show("Budget Updated!");
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
                cmd.Parameters.AddWithValue("@userAccountID", Program.eUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read()) // Check if there's a row available
                {
                    if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.eRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                    }
                    else
                    {
                        Program.eRemainingAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userUsedAmount"] != DBNull.Value) // Check if the value is NULL
                    {
                        Program.eUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                    }
                    else
                    {
                        Program.eUsedAmount = 0.00m; // Use 'm' for decimal literals
                    }

                    if (dr["userAllocatedAmount"] != DBNull.Value) // Check if the value is NULL
                    {

                        Program.eAllocatedAmount = Convert.ToDecimal(dr["userAllocatedAmount"]);
                    }
                    else
                    {
                        Program.eAllocatedAmount = 0.00m; // Use 'm' for decimal literals
                    }
                }
                else
                {
                    Program.eRemainingAmount = 0.00m; // Default value when no rows are found
                    Program.eUsedAmount = 0.00m;
                    Program.eAllocatedAmount = 0.00m;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        void RestoreOldUserAllocation()
        {
            decimal restoredUsed = oldeUsedAmount - firstActualCost;
            decimal restoredRemaining = oldeAllocatedAmount - restoredUsed;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblUserAccounts " +
                               "SET userUsedAmount = @used, userRemainingAmount = @remaining " +
                               "WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@used", restoredUsed);
                    cmd.Parameters.AddWithValue("@remaining", restoredRemaining);
                    cmd.Parameters.AddWithValue("@userAccountID", oldeUserAccountID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        void updateNewUserRemainingAmount() //New User
        {
            decimal newActualCost = Convert.ToDecimal(txtActualCost.Text);

            // Add the new cost to this new user's usage
            Program.eUsedAmount = Program.eUsedAmount + newActualCost;
            Program.eRemainingAmount = Program.eAllocatedAmount - Program.eUsedAmount;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "UPDATE tblUserAccounts " +
                               "SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount " +
                               "WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userRemainingAmount", Program.eRemainingAmount);
                    cmd.Parameters.AddWithValue("@userUsedAmount", Program.eUsedAmount);
                    cmd.Parameters.AddWithValue("@userAccountID", Program.eUserAccountID); // new user
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void updateUserRemainingAmount()
        {
            decimal newActualCost = Convert.ToDecimal( txtActualCost.Text);
            MessageBox.Show("User Account Cost:" + Convert.ToDecimal(txtActualCost.Text));

            Program.eUsedAmount = (Program.eUsedAmount - firstActualCost) + Convert.ToDecimal(txtActualCost.Text);
            Program.eRemainingAmount = Program.eAllocatedAmount - Program.eUsedAmount;

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.eUserAccountID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                //// Parse and validate numeric inputs
                //decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
                //decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
                //decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;

                //cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
                cmd.Parameters.AddWithValue("@userRemainingAmount", Program.eRemainingAmount);
                cmd.Parameters.AddWithValue("@userUsedAmount", Program.eUsedAmount);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Buget Allocation Updated!");
        }


        //void updateUserRemainingAmount()
        //{
        //    Program.eUsedAmount = (Program.eUsedAmount - firstActualCost) + Convert.ToDecimal(txtActualCost.Text);
        //    Program.eRemainingAmount = Program.eAllocatedAmount - Program.eUsedAmount;

        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    SqlCommand cmd;
        //    String query = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = " + Program.eUserAccountID;

        //    con.Open();

        //    using (cmd = new SqlCommand(query, con))
        //    {
        //        //// Parse and validate numeric inputs
        //        //decimal allocatedAmount = decimal.TryParse(txtAllocatedAmount.Text, out allocatedAmount) ? allocatedAmount : 0;
        //        //decimal remainingAmount = decimal.TryParse(txtRemainingAmount.Text, out remainingAmount) ? remainingAmount : 0;
        //        //decimal usedAmount = decimal.TryParse(txtUsedAmount.Text, out usedAmount) ? usedAmount : 0;


        //        //cmd.Parameters.AddWithValue("@userAccountID", Program.nUserAccountID);
        //        cmd.Parameters.AddWithValue("@userRemainingAmount", Program.eRemainingAmount);
        //        cmd.Parameters.AddWithValue("@userUsedAmount", Program.eUsedAmount);
        //        cmd.ExecuteNonQuery();
        //    }

        //    MessageBox.Show("Buget Allocation Updated!");
        //}

        private void SaveFile(string filePath)
        {
            string controlnumber = txtCtrl.Text;
            String controltype = "poControlNumber";
            Program.controltypevalue = "";
            int fileyear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            //Program.controltypevalue = txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text;
            switch (Program.controltype)
            {
                case 1:
                    {
                        controltype = "poControlNumber";
                        Program.controltypevalue = txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text + txtPOUser.Text;
                        break;
                    }
                case 2:
                    {
                        controltype = "voucherControlNumber";
                        Program.controltypevalue = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text + txtVoucherUser.Text;
                        break;
                    }

            }

            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);

                string name = new FileInfo(filePath).Name;
                string extn = new FileInfo(filePath).Extension;
                //string controlnumber = txtCtrl.Text;

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblFiles (controlNumber, fileType, data, fileName, extension,"+controltype+", year) VALUES (@cnumber, @ftype, @data, @filename, @extn, @controltypevalue, @year)", con);
                con.Open();
                cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                //cmd.Parameters.Add("@prid", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@ftype", SqlDbType.VarChar).Value = Program.determinedfiletype;
                cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = data;
                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                cmd.Parameters.Add("@controltypevalue", SqlDbType.Char).Value = Program.controltypevalue;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = fileyear;
                cmd.ExecuteNonQuery();
            }

            //this.Close();
        }

        private void icnPOGenerate_Click(object sender, EventArgs e)
        {
            generatePOQR();
        }

        string pocontrol;
        private void generatePOQR()
        {
            //pocontrol= txtdbPOCtrl.Text;
            //if (txtdbPOCtrl.Visible = false)
            //{
            //    pocontrol = (txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text).Trim();
            //}
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
            var result = new Bitmap(qr.Write(pocontrol));
            qrPOPic.Image = result;

            lblPOCN.Text = pocontrol;

        }

        private void icnPOPrint_Click(object sender, EventArgs e)
        {
            printPOQR();
        }

        public void printPOQR()
        {
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocumentPO_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void printDocumentPO_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(lblPOCN.Font.FontFamily, 5);
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
            //Bitmap bm = new Bitmap(qrPOPic.Width, qrPOPic.Height);
            //qrPOPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPOPic.Width, qrPOPic.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void qrPrint_Click(object sender, EventArgs e)
        {
            printQR();
        }
        public void printQR()
        {
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocumentPR_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void printDocumentPR_PrintPage(object sender, PrintPageEventArgs e)
        {
            lblPRCN.Text = Program.ctrl;
            // Font for the additional text with size 12
            Font additionalTextFont = new Font(lblPRCN.Font.FontFamily, 5);
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




            //lblPRCN.Text = txtCtrl.Text.Trim();
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

        private void icnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                //MessageBox.Show("Deleted!");

            }
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                comboUser.DataSource = table;
                comboUser.DisplayMember = "userName";
            }

            if (comboDept.SelectedIndex == 1)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '" + txtUserYear.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                comboUser.DataSource = table;
                comboUser.DisplayMember = "userName";
            }

        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtActualCost.Text = "0";
            sourceTypeDeterminer();

            //FMIS 2025 Version
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
                            Program.eAccountID = dr["accountID"].ToString();
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
                    cmd.Parameters.AddWithValue("@userID", Program.eAccountUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.eAccountID);

                    // Open connection
                    con.Open();

                    // Execute query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Check if data exists
                        {
                            // Retrieve accountID and assign it
                            Program.eUserAccountID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }

        void completeAttachements()
        {
            if(Program.sourcetypedeterminer == "os" || Program.sourcetypedeterminer == "om")
            {
                if(txtInspectionLoc.Text != String.Empty)
                {
                    Program.requeststatus = "Done";
                    saveFunction();
                }
            }

            if (Program.sourcetypedeterminer == "co")
            {
                if (txtMRLoc.Text != String.Empty)
                {
                    Program.requeststatus = "Done";
                    saveFunction();
                }
            }

            if (Program.sourcetypedeterminer == "fol" || Program.sourcetypedeterminer == "rmte")
            {
                if (txtWasteLoc.Text != String.Empty)
                {
                    Program.requeststatus = "Done";
                    saveFunction();
                }
            }
        }

        String savedCost = "0";
        decimal returnCost = 0;
        int previousCost = 0;
        private void txtCost_Leave(object sender, EventArgs e)
        {
            if (txtCost.TextLength <= 0)
            {
                txtCost.Text = returnCost.ToString();
                txtCost.Text = string.Format("{0:n}", double.Parse(txtCost.Text));
                if (decimal.TryParse(txtCost.Text, out decimal result))
                {
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

        private void txtCost_Enter(object sender, EventArgs e)
        {
            savedCost = txtCost.Text;
            txtCost.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToDecimal(result);

            }
        }

        private void txtCost_KeyUp(object sender, KeyEventArgs e)
        {
            //remainingBudget();
        }

        void checkingBalance()
        {
            try
            {
                if (comboSource.SelectedIndex == 0)
                {

                    if ((Program.remainingOS + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingOS + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 1)
                {

                    if ((Program.remainingFOL + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingFOL + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 2)
                {

                    if ((Program.remainingRMTE + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingRMTE + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 3)
                {

                    if ((Program.remainingOM + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingOM + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 4)
                {

                    if ((Program.remainingCO + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingCO + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 5)
                {

                    if ((Program.remainingRepEx + returnCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.remainingRepEx + returnCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 6)
                {

                    if (Program.remainingOSME < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingOSME);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 7)
                {

                    if (Program.remainingPCS < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPCS);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 8)
                {

                    if (Program.remainingRMBOS < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMBOS);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 9)
                {

                    if (Program.remainingRMME < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMME);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 10)
                {

                    if (Program.remainingRMFF < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMFF);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 11)
                {

                    if (Program.remainingRMOPPE < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingRMOPPE);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 12)
                {

                    if (Program.remainingPPE < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingPPE);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 13)
                {

                    if (Program.remainingAdvertisingEx < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingAdvertisingEx);
                        txtCost.Text = string.Empty;
                    }
                }
                if (comboSource.SelectedIndex == 14)
                {

                    if (Program.remainingTravExLoc < Convert.ToInt32(txtCost.Text))
                    {
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + Program.remainingTravExLoc);
                        txtCost.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        void remainingBudget()
        {
            int actualc = 0, totalc = 0;

            
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userAccountID", Program.eUserAccountID);

                //cmd.ExecuteNonQuery();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) // Check if there's a row available
            {
                if (dr["userRemainingAmount"] != DBNull.Value) // Check if the value is NULL
                {
                    Program.eRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                }
                else
                {
                    Program.eRemainingAmount = 0.00m; // Use 'm' for decimal literals
                }
            }
            else
            {
                Program.eRemainingAmount = 0.00m; // Default value when no rows are found
            }

            try
            {
                if (txtActualCost.TextLength <= 0)
                {
                    if (decimal.TryParse(txtActualCost.Text, out decimal result))
                    {
                        Program.actualc = Convert.ToInt32(result);
                        Program.totalc = Convert.ToInt32(txtCost.Text);
                    }
                    if (decimal.TryParse(txtCost.Text, out decimal resultc))
                    {
                        Program.totalc = Convert.ToInt32(resultc);
                    }

                }
                else
                {
                    if (decimal.TryParse(txtActualCost.Text, out decimal result))
                    {
                        Program.convertedCost = Convert.ToInt32(result);
                        Program.actualc = Convert.ToInt32(result);
                    }
                    if (decimal.TryParse(txtCost.Text, out decimal resultc))
                    {
                        Program.totalc = Convert.ToInt32(resultc);
                    }
                }

                if (Program.totalc >= Program.actualc)
                {
                    //checkingBalance(); -- FMIS 2024 Version

                    if ((Program.eRemainingAmount + firstActualCost) < Convert.ToInt32(txtActualCost.Text))
                    {
                        decimal uneditedCost = Program.eRemainingAmount + firstActualCost;
                        MessageBox.Show("Insufficient Balance! Remaining Balance: " + uneditedCost);
                        txtActualCost.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Actual Cost must not exceed the Total Cost!");
                    txtActualCost.Clear();
                }

                
               
            }

            catch (Exception ex)
            {

            }

           

            
             
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            determiningPRType();
        }

        private void txtActualCost_Leave(object sender, EventArgs e)
        {
            

            if (txtActualCost.TextLength <= 0)
            {
                txtActualCost.Text = returnCost.ToString();
                txtActualCost.Text = string.Format("{0:n}", double.Parse(txtActualCost.Text));
                if (decimal.TryParse(txtActualCost.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                    Program.actualc = Convert.ToDecimal(result);
                    Program.totalc = 0;
                }
                if (decimal.TryParse(txtCost.Text, out decimal resultc))
                {                    
                    Program.totalc = Convert.ToDecimal(resultc);
                }

            }
            else
            {
                txtActualCost.Text = string.Format("{0:n}", double.Parse(txtActualCost.Text));
                if (decimal.TryParse(txtActualCost.Text, out decimal result))
                {
                    Program.convertedCost = Convert.ToDecimal(result);
                    Program.actualc = Convert.ToDecimal(result);
                }
                if (decimal.TryParse(txtCost.Text, out decimal resultc))
                {
                    Program.totalc = Convert.ToDecimal(resultc);
                }
            }
        }

        

        private void txtCtrl_TextChanged(object sender, EventArgs e)
        {

        }

        decimal oldCost = 0;
        private void txtActualCost_Enter(object sender, EventArgs e)
        {
            savedCost = txtActualCost.Text;
            txtActualCost.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToDecimal(result);
                oldCost = Convert.ToDecimal(result);

            }
        }

        private void txtActualCost_KeyUp(object sender, KeyEventArgs e)
        {
            remainingBudget();
            
        }

        private void icnVoucherGenerate_Click(object sender, EventArgs e)
        {
            generateVoucher();
            icnVoucherPrint.Enabled = true;
        }

        string vouchercontrol;
        private void generateVoucher()
        {
            //vouchercontrol = txtdbVoucherCtrl.Text;
            //if (txtdbVoucherCtrl.Visible = false)
            //{
            //    vouchercontrol = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim();
            //}

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
            var result = new Bitmap(qr.Write(vouchercontrol));
            qrVoucherPic.Image = result;

            voucherCtrl.Text = vouchercontrol;
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
            voucherCtrl.Text = txtVoucherType.Text + txtVoucherYear.Text + txtVoucherCounter.Text.Trim() + txtVoucherUser.Text;

            voucherDate.Text = $"{DateTime.Now:MM-dd-yyyy HH:mm}";


            // Font for the additional text with size 12
            Font additionalTextFont = new Font(voucherCtrl.Font.FontFamily, 5);
            Font additionalTextFont2 = new Font(voucherCtrl.Font.FontFamily, 9);
            Font additionalTextFont1 = new Font(voucherSP.Font.FontFamily, 12);

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
            //Bitmap bm = new Bitmap(qrPic.Width, qrPic.Height);
            //qrPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPic.Width, qrPic.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void comboSource_SelectedValueChanged(object sender, EventArgs e)
        {

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
                            Program.eAccountUserID = dr["userID"].ToString();
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
                         WHERE a.PR = 'Yes' AND ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@UserID", Program.eAccountUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    comboSource.DataSource = table;
                    comboSource.DisplayMember = "accountName";
                }
            }


        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtVoucherUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserYear_TextChanged(object sender, EventArgs e)
        {
            getUsers();
        }
    }


}
