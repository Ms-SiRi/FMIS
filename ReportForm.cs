using Microsoft.Reporting.WinForms;
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

namespace FMIS
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.budgetReportViewer.RefreshReport();
            //SqlConnection con = new SqlConnection(Program.ConnString);

            //con.Open();

            //SqlCommand cmd = new SqlCommand("SELECT * FROM qrMotherTable INNER JOIN tblBudget ON qrMotherTable.prEnduser = tblBudget.Name INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE qrMotherTable.prEnduser = 'BM Soriano' AND YEAR(prDate) = '2023'", con);
            //SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adap.Fill(ds, "overallData");
            //CrystalReport1 report = new CrystalReport1();
            //report.SetDataSource(ds);
            //crystalReportViewer1.ReportSource = report;
            //crystalReportViewer1.Refresh();
            //con.Close();

            SqlConnection con = new SqlConnection(Program.ConnString);


            SqlCommand cmd = new SqlCommand("SELECT * FROM qrMotherTable INNER JOIN tblBudget ON qrMotherTable.prEnduser = tblBudget.Name INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE qrMotherTable.prEnduser = 'BM Soriano' AND YEAR(prDate) = '2023'", con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            budgetReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            budgetReportViewer.LocalReport.ReportPath = "budgetTrackingReport.rdlc";
            budgetReportViewer.LocalReport.DataSources.Add(source);
            budgetReportViewer.RefreshReport();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            
            this.budgetReportViewer.RefreshReport();
        }
    }
}
