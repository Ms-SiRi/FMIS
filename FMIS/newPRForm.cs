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

namespace FMIS
{
    public partial class newPRForm : Form
    {
        public newPRForm()
        {
            InitializeComponent();

           
        }

        private void newPRForm_Load(object sender, EventArgs e)
        {
            comboType.SelectedIndex= 0;
            comboDept.SelectedIndex= 0;
            comboSource.SelectedIndex= 0;

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
                comboSource.Enabled= false;
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
            String query = "Insert INTO qrMotherTable(ctrlNumber,prType,prDept,prEnduser,prSource,prDescription,prCost,prParticulars,prRemarks,prDate,prFile,prStatus) VALUES(@ctrlNumber,@prType,@prDept,@prEnduser,@prSource,@prDescription,@prCost,@prParticulars, @prRemarks,@prDate,@prFile,@prStatus)";

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
                cmd.Parameters.AddWithValue("@prParticulars",txtParticulars.Text);
                cmd.Parameters.AddWithValue("@prFname", txtPRType.Text + txtyr.Text + txtCounter.Text + "PR_File");
                cmd.Parameters.AddWithValue("@prRemarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@prDate", date);
                cmd.Parameters.AddWithValue("@prFile", content);
                cmd.Parameters.AddWithValue("@prStatus", "1");
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Upload Done!");
        }

        string filename;
        private void btnPRattach_Click(object sender, EventArgs e)
        {
           using(OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this PDF File?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                       filename = txtPRType.Text + txtyr.Text + txtCounter.Text + "PR_File";
                        txtPRLoc.Text = filename;
                        btnGenerate.Enabled = true;
                        qrPrint.Enabled = true;
                    }
                }
            }     
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            UploadFile(filename);
        }
    }
}
