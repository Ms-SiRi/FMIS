using CrystalDecisions.CrystalReports.Engine;
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
    public partial class BorrowersLog : Form
    {
        public BorrowersLog()
        {
            InitializeComponent();
        }

        private void icnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        void search()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"SELECT * FROM tblBorrowerSheet WHERE userType LIKE '%" + txtKeyword.Text + "%'  OR date LIKE '%" + txtKeyword.Text + "%' OR status LIKE '%" + txtKeyword.Text + "%' OR bFrom LIKE '%" + txtKeyword.Text + "%' OR bTo LIKE '%" + txtKeyword.Text + "%' OR fromAccount LIKE '%" + txtKeyword.Text + "%' OR toAccount LIKE '%" + txtKeyword.Text + "%' OR borrowedAmount LIKE '%" + txtKeyword.Text + "%' OR remarks LIKE '%" + txtKeyword.Text + "%' ORDER BY date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "BorrowersLog.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
