using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using FMIS.Report;
using FMIS.FMISDataSetTableAdapters;

namespace FMIS
{
    public partial class BudgetTrackReportsViewer : Form
    {
        public BudgetTrackReportsViewer()
        {
            InitializeComponent();
        }

        private void panelHome_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        

        

       



        private void endUser_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        
        private void pendingList_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void SPList_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        private void lvAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            


        }

        private void VGOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }


        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void alphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void tbUserList_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        int selection;
        private void tbUserList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCO_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOS_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtRMTE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtOM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFOL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtuserName_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        

        private void txtyear_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void lblTB_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_2(object sender, EventArgs e)
        {

        }

       
        

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void icnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void icnPrint_Click(object sender, EventArgs e)
        {
            budgetTracking btmain = new budgetTracking();

            BudgetTrackReportsViewer btr = new BudgetTrackReportsViewer();
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
            bt.SetParameterValue(0, "");
            bt.SetParameterValue(1, "");


            ds.AcceptChanges();

            bt.SetDataSource(ds);
            btr.budgetTrackViewer.ReportSource = bt;
            btr.budgetTrackViewer.Show();
            btr.budgetTrackViewer.Refresh();
        }
    }
}
