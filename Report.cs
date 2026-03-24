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
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace FMIS
{
    public partial class ReportCrystal : Form
    {
        public ReportCrystal()
        {
            InitializeComponent();
        }

        private void ReportCrystal_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                
                SqlCommand cmd = new SqlCommand("SELECT *, FORMAT(date, 'MM/dd/yyyy') as FormattedDate FROM tblBudget WHERE Name = '" + Program.username + "' AND year = '" + Program.useryear + "' AND controlNumber NOT LIKE '%Extra%' ORDER BY date DESC", con);

                //SqlCommand cmd = new SqlCommand("SELECT * FROM tblBudget INNER JOIN qrMotherTable ON qrMotherTable.ctrlNumber = tblBudget.controlNumber INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE qrMotherTable.prEnduser = '" + Program.username+"' AND YEAR(prDate) = '"+Program.useryear+ "' AND prStatus !='4'", con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    string apppath = Application.StartupPath;
                    string reportpath = "/CrystalReport1.rpt";
                    string fullpath = Path.Combine(apppath, reportpath);
                    ReportDocument rdd = new ReportDocument();  
                    rdd.Load(Application.StartupPath + "\\CrystalReport1.rpt");
                    //rdd.Load(fullpath);
                    rdd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource= rdd;
                }
                else
                {
                    MessageBox.Show("No records found!");
                }
            }
            catch {
            
            }


            
        }
    }
}
