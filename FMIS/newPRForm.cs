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

namespace FMIS
{
    public partial class newPRForm : Form
    {
        public newPRForm()
        {
            InitializeComponent();
            controlidByFileType();

        }

        private void newPRForm_Load(object sender, EventArgs e)
        {
            comboType.SelectedIndex = 0;
            comboDept.SelectedIndex = 0;
            comboSource.SelectedIndex = 0;
            txtyr.Text = DateTime.Now.ToString("yyyy");
            txtPOctrl.Text = txtCounter.Text;
            txtPOyr.Text = txtyr.Text;
        }

        int highestid;
        string zero;
        public void controlidByFileType()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String getquery = "SELECT COUNT(fileID) AS LatestNum, MAX(noOfAttachments) as count_control FROM tblFiles WHERE fileType = 'Purchase Request File';";
            con.Open();
            SqlCommand cmd = new SqlCommand(getquery, con);            
            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
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

        private void selectingFile()
        {
           
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboType.SelectedIndex == 0)
            {
                txtPRType.Text = "PRR";
            }
            else if (comboType.SelectedIndex == 1)
            {
                txtPRType.Text = "PRE";
                comboSource.SelectedIndex = 1;
                comboSource.Enabled = false;
            }
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
            var result = new Bitmap(qr.Write(txtPRType.Text + txtyr.Text + txtCounter.Text.Trim()));
            qrPic.Image = result;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateQR();
        }

        public void printQR()
        {
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument1_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(qrPic.Width, qrPic.Height);
            qrPic.DrawToBitmap(bm, new Rectangle(0, 0, qrPic.Width, qrPic.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void qrPrint_Click(object sender, EventArgs e)
        {
            printQR();
        }

        //UPLOAD pdf file to prFile
        void UploadFile(string file)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO qrMotherTable(ctrlNumber,prType,prDept,prEnduser,prSource,prDescription,prCost" +
                ",prParticulars,prRemarks,prDate,prFile,prStatus,prFname) VALUES(@ctrlNumber,@prType,@prDept,@prEnduser,@prSource," +
                "@prDescription,@prCost,@prParticulars, @prRemarks,@prDate,@prFile,@prStatus,@prFname)";

            con.Open();
            FileStream fstream = File.OpenRead(file);
            byte[] content = new byte[fstream.Length];
            fstream.Read(content, 0, (int)fstream.Length);
            fstream.Close();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlNumber", txtPRType.Text + txtyr.Text + txtCounter.Text);
                cmd.Parameters.AddWithValue("@prType", txtPRType.Text);
                cmd.Parameters.AddWithValue("@prDept", comboDept.Text);
                cmd.Parameters.AddWithValue("@prEnduser", comboUser.Text);
                cmd.Parameters.AddWithValue("@prSource", comboSource.Text);
                cmd.Parameters.AddWithValue("@prDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@prCost", txtCost.Text);
                cmd.Parameters.AddWithValue("@prParticulars", txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prFname", txtPRLoc.Text);
                cmd.Parameters.AddWithValue("@prDate", date);
                cmd.Parameters.AddWithValue("@prFile", content);
                cmd.Parameters.AddWithValue("@prStatus", Program.filestatus);
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
                        txtPRLoc.Text = txtPRType.Text + txtyr.Text + txtCounter.Text + "PR_File";
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
                MessageBox.Show("Saved!");
                this.Close();

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

        private void saveBudget()
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string year = dateTimePicker1.Value.ToString("yyyy");
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBudget(controlNumber, Name,Department,"+Program.sourcetypedeterminer+", year, date) VALUES(@ctrlnum, @Name, @Dept, @source, @year, @date)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", txtPRType.Text + txtyr.Text + txtCounter.Text);
                cmd.Parameters.AddWithValue("@Name", comboUser.Text);
                cmd.Parameters.AddWithValue("@Dept", comboDept.Text);
                cmd.Parameters.AddWithValue("@source", txtCost.Text);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();
            }

            //MessageBox.Show("Budget Saved!");
            
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
                string controlnumber = txtPRType.Text + txtyr.Text + txtCounter.Text;

                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblFiles (controlNumber, fileType, data, fileName, extension, noOfAttachments) VALUES (@cnumber, @ftype, @data, @filename, @extn, @attachments)", con);
                con.Open();
                cmd.Parameters.Add("@cnumber", SqlDbType.VarChar).Value = controlnumber;
                //cmd.Parameters.Add("@prid", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@ftype", SqlDbType.VarChar).Value = Program.determinedfiletype;
                cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = data;
                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                cmd.Parameters.Add("@attachments", SqlDbType.Int).Value = txtCounter.Text;

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
            var result = new Bitmap(qr.Write(txtPOtype.Text + txtPOyr.Text + txtPOctrl.Text.Trim()));
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

        private void icnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboDept_TextChanged(object sender, EventArgs e)
        {
            getUsers();
        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceTypeDeterminer();
        }
    }
}

