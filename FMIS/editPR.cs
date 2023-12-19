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

namespace FMIS
{
    public partial class editPR : Form
    {
        public editPR()
        {
            InitializeComponent();
            selectPR();
            generateQR();
            //generatePOQR();

            
            Boolean empty = true;
            if (txtPRLoc.Text.Equals("") != empty)
            {
                empty = true;
                txtPOLoc.Enabled = true;
                lblPO.Enabled = true;
                btnPOattach.Enabled = true;
                btnOpenPO.Enabled = true;

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



        }

        public void selectPR()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "Select * FROM qrMotherTable WHERE ctrlNumber = '" + Program.ctrl +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {
                txtCtrl.Text = dr["ctrlNumber"].ToString();
                comboType.Text = dr["prType"].ToString();
                comboDept.Text = dr["prDept"].ToString();
                comboUser.Text = dr["prEnduser"].ToString();
                comboSource.Text = dr["prSource"].ToString();
                txtdate.Text = DateTime.Parse(dr["prDate"].ToString()).ToShortDateString();
                txtDesc.Text = dr["prDescription"].ToString();
                txtCost.Text = dr["prCost"].ToString();
                txtParticulars.Text = dr["prParticulars"].ToString();
                txtRemarks.Text = dr["prRemarks"].ToString();
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

                string controlnum = txtCtrl.Text;                
                txtPOctrl.Text = controlnum.Substring(controlnum.Length - 4);
                txtPOyr.Text = controlnum.Substring(3, 4);


            }

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
            string controlnumber = txtCtrl.Text;

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
                cmd.Parameters.AddWithValue("@prCost", txtCost.Text);
                cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prDate", date);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Details Updated!");
        }

        void UploadFile(string file)
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");
            
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE qrMotherTable SET prDept = @prDept,prEnduser = @prEnduser,prSource = @prSource" +
                ",prDescription = @prDescription,prCost = @prCost,prParticulars = @prParticulars,prRemarks = @prRemarks,prDate = @prDate," + Program.contentdeterminer + " = @prFile," +
                "prStatus = @prStatus," + Program.fnamedeterminer + " = @prFname WHERE ctrlNumber = @ctrlNumber";

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
                cmd.Parameters.AddWithValue("@prCost", txtCost.Text);
                cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prFname", Program.filelabel);
                cmd.Parameters.AddWithValue("@prDate", date);
                cmd.Parameters.AddWithValue("@prFile", content);
                cmd.Parameters.AddWithValue("@prStatus", Program.filestatus);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Files Updated!");
        }

        string filename;
        private void btnPRattach_Click(object sender, EventArgs e)
        {
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
                        UploadFile(filename);
                    }
                }
            }

            
        }

        private void btnPOattach_Click(object sender, EventArgs e)
        {
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
                        UploadFile(filename);
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
                    }
                }
            }

            
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
                        txtVoucherLoc.Enabled = true;
                        lblVoucher.Enabled = true;
                        btnAttachVouch.Enabled = true;
                        btnOpenVouch.Enabled = true;
                    }
                }
            }

            
        }

        private void btnAttachVouch_Click(object sender, EventArgs e)
        {
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

                        txtInspectionLoc.Enabled = true;
                        lblInspection.Enabled = true;
                        btnAttachInsp.Enabled = true;
                        btnOpenInsp.Enabled = true;
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

                        txtPARLoc.Enabled = true;
                        lblPAR.Enabled = true;
                        btnAttachPAR.Enabled = true;
                        btnOpenPAR.Enabled = true;
                    }
                }
            }

            
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

                        txtMRLoc.Enabled = true;
                        lblMR.Enabled = true;
                        btnAttachMR.Enabled = true;
                        btnOpenMR.Enabled = true;
                    }
                }
            }

            
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

                        txtSummaryLoc.Enabled = true;
                        lblSummary.Enabled = true;
                        btnAttachSum.Enabled = true;
                        btnOpenSum.Enabled = true;
                    }
                }
            }

            
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

                        txtWasteLoc.Enabled = true;
                        lblWaste.Enabled = true;
                        btnAttachWaste.Enabled = true;
                        btnOpenWaste.Enabled = true;
                    }
                }
            }

            
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
                    }
                }
            }

            
        }

        private void editPR_Load(object sender, EventArgs e)
        {
            
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
                Width = 45,
                Height = 45,
                Margin = 0
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;


            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(txtCtrl.Text.ToString()));
            qrPic.Image = result;

        }

        private void txtVoucherLoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void icnUpdate_Click(object sender, EventArgs e)
        {
            emptyFields();
            
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
                    updateFileDetails();
                    clearBudget();
                    updateBudget();
                    this.Close();
                }
                else
                {
                    UploadFile(filename);
                    clearBudget();
                    updateBudget();
                    SaveFile(filename);
                    this.Close();
                }
                
            }
        }

        private void sourceTypeDeterminer()
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
        }

        private void clearBudget()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");
            string year = DateTime.Parse(txtdate.Text).ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblBudget SET os = @os, fol = @fol, rmte = @rmte, om = @om, co = @co  WHERE controlNumber = @ctrlnum";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", Program.ctrl);
                cmd.Parameters.AddWithValue("@os", "");
                cmd.Parameters.AddWithValue("@fol", "");
                cmd.Parameters.AddWithValue("@rmte", "");
                cmd.Parameters.AddWithValue("@om", "");
                cmd.Parameters.AddWithValue("@co", "");
                
                cmd.ExecuteNonQuery();
            }

            //MessageBox.Show("Budget Cleared!");

        }

        private void updateBudget()
        {
            string date = DateTime.Parse(txtdate.Text).ToString("yyyy-MM-dd");
            string year = DateTime.Parse(txtdate.Text).ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblBudget SET Name = @Name, Department = @Dept," + Program.sourcetypedeterminer + " = @source, year = @year, date = @date WHERE controlNumber = @ctrlnum";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", Program.ctrl);
                cmd.Parameters.AddWithValue("@Name", comboUser.Text);
                cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                cmd.Parameters.AddWithValue("@source", txtCost.Text);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();
            }

            //MessageBox.Show("Budget Updated!");

        }

        private void SaveFile(string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);

                string name = new FileInfo(filePath).Name;
                string extn = new FileInfo(filePath).Extension;
                string controlnumber = txtCtrl.Text;

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblFiles (controlNumber, fileType, data, fileName, extension) VALUES (@cnumber, @ftype, @data, @filename, @extn)", con);
                con.Open();
                cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                //cmd.Parameters.Add("@prid", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@ftype", SqlDbType.VarChar).Value = Program.determinedfiletype;
                cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = data;
                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;

                cmd.ExecuteNonQuery();
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
                Width = 45,
                Height = 45,
                Margin = 0
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;


            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(txtcnPO.Text + txtPOyr.Text + txtPOctrl.Text.Trim()));
            qrPOPic.Image = result;

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
            //Print image
            Bitmap bm = new Bitmap(qrPOPic.Width, qrPOPic.Height);
            qrPOPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPOPic.Width, qrPOPic.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
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
            //Print image
            Bitmap bm = new Bitmap(qrPic.Width, qrPic.Height);
            qrPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPic.Width, qrPic.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void icnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                SqlCommand cmd = new SqlCommand("select * from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                comboUser.DataSource = table;
                comboUser.DisplayMember = "Name";
            }

            if (comboDept.SelectedIndex == 1)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select * from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                comboUser.DataSource = table;
                comboUser.DisplayMember = "Name";
            }

        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceTypeDeterminer();
        }
    }


}
