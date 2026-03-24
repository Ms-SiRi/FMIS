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

namespace FMIS
{
    public partial class PRTracking : Form
    {
        public PRTracking()
        {
            InitializeComponent();

            PRNumber.Text = Program.ctrl;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TrackStatus();
        }

        void TrackStatus()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE qrMotherTable SET prRemarks = @prRemarks WHERE ctrlNumber = @ctrlNumber";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {                
                cmd.Parameters.AddWithValue("@prRemarks", Program.remarks + " \r\n Received at: " + comboRec.Text + " " + txtRem.Text + " by " + txtMes.Text + " on " + date);
                cmd.Parameters.AddWithValue("@ctrlNumber", PRNumber.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Status Tracked!");
        }

        void ClearData()
        {
            txtRem.Text = string.Empty;
            txtMes.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
