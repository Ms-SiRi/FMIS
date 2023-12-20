using FMIS.FMISDataSetTableAdapters;
using FMIS.Report;
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
    public partial class BudgetTrackReportViewer : Form
    {
        public BudgetTrackReportViewer()
        {
            InitializeComponent();
        }

        private void BudgetTrackReportViewer_Load(object sender, EventArgs e)
        {
            budgetTracking btmain = new budgetTracking();

            BudgetTrackReportViewer btr = new BudgetTrackReportViewer();
            btr.Show();

            String user;
            int year;

            BudgetTrack bt = new BudgetTrack(); // instance of my rpt file
            var ds = new FMISDataSet();  // DsBilling is mine XSD
            var table2 = ds.allData;
            var adapter2 = new allDataTableAdapter();
            user = btmain.cmbUser.Text;
            year = Int32.Parse(btmain.cmbYear.Text);
            adapter2.GetData(user, year);
            bt.SetParameterValue("year", "");
            bt.SetParameterValue("User", "");


            ds.AcceptChanges();

            bt.SetDataSource(ds);
            btr.budgetTrackViewer.ReportSource = bt;
            btr.budgetTrackViewer.Show();
            btr.budgetTrackViewer.Refresh();

        }
    }
}
