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
using Microsoft.Reporting.WinForms;
using FontAwesome.Sharp;

namespace FMIS
{
    public partial class budgetTracking : Form
    {
        public budgetTracking()
        {
            InitializeComponent();
        }

        private void panelHome_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        

        

        void SelectALLDATA()
        {
            allocatedTB.Text = "0";
            allocatedTB.Text = string.Format("{0:n}", double.Parse(allocatedTB.Text));
            allocatedOS.Text = "0";
            allocatedOS.Text = string.Format("{0:n}", double.Parse(allocatedOS.Text));
            allocatedFOL.Text = "0";
            allocatedFOL.Text = string.Format("{0:n}", double.Parse(allocatedFOL.Text));
            allocatedRMTE.Text = "0";
            allocatedRMTE.Text = string.Format("{0:n}", double.Parse(allocatedRMTE.Text));
            allocatedOM.Text = "0";
            allocatedOM.Text = string.Format("{0:n}", double.Parse(allocatedOM.Text));
            allocatedTravExLoc.Text = "0";
            allocatedTravExLoc.Text = string.Format("{0:n}", double.Parse(allocatedTravExLoc.Text));
            allocatedTrainingEx.Text = "0";
            allocatedTrainingEx.Text = string.Format("{0:n}", double.Parse(allocatedTrainingEx.Text));
            allocatedTelEx.Text = "0";
            allocatedTelEx.Text = string.Format("{0:n}", double.Parse(allocatedTelEx.Text));
            allocatedInternetSubEx.Text = "0";
            allocatedInternetSubEx.Text = string.Format("{0:n}", double.Parse(allocatedInternetSubEx.Text));
            allocatedConsultancySer.Text = "0";
            allocatedConsultancySer.Text = string.Format("{0:n}", double.Parse(allocatedConsultancySer.Text));
            allocatedRMTE.Text = "0";
            allocatedRMTE.Text = string.Format("{0:n}", double.Parse(allocatedRMTE.Text));
            allocatedMDCO.Text = "0";
            allocatedMDCO.Text = string.Format("{0:n}", double.Parse(allocatedMDCO.Text));
            allocatedOM.Text = "0";
            allocatedOM.Text = string.Format("{0:n}", double.Parse(allocatedOM.Text));
            allocatedJO.Text = "0";
            allocatedJO.Text = string.Format("{0:n}", double.Parse(allocatedJO.Text));

            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE Name = '"+cmbUser.Text+ "' AND year = '"+cmbYear.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                allocatedTB.Text = dr["tb"].ToString();
                allocatedTB.Text = string.Format("{0:n}", double.Parse(allocatedTB.Text));
                allocatedOS.Text = dr["os"].ToString();
                allocatedOS.Text = string.Format("{0:n}", double.Parse(allocatedOS.Text));
                allocatedFOL.Text = dr["fol"].ToString();
                allocatedFOL.Text = string.Format("{0:n}", double.Parse(allocatedFOL.Text));
                allocatedRMTE.Text = dr["rmte"].ToString();
                allocatedRMTE.Text = string.Format("{0:n}", double.Parse(allocatedRMTE.Text));
                allocatedOM.Text = dr["om"].ToString();
                allocatedOM.Text = string.Format("{0:n}", double.Parse(allocatedOM.Text));
                allocatedTravExLoc.Text = dr["travexloc"].ToString();
                allocatedTravExLoc.Text = string.Format("{0:n}", double.Parse(allocatedTravExLoc.Text));
                allocatedTrainingEx.Text = dr["trainingex"].ToString();
                allocatedTrainingEx.Text = string.Format("{0:n}", double.Parse(allocatedTrainingEx.Text));
                allocatedTelEx.Text = dr["telex"].ToString();
                allocatedTelEx.Text = string.Format("{0:n}", double.Parse(allocatedTelEx.Text));
                allocatedInternetSubEx.Text = dr["internetsubex"].ToString();
                allocatedInternetSubEx.Text = string.Format("{0:n}", double.Parse(allocatedInternetSubEx.Text));
                allocatedConsultancySer.Text = dr["consultancyser"].ToString();
                allocatedConsultancySer.Text = string.Format("{0:n}", double.Parse(allocatedConsultancySer.Text));
                allocatedRMTE.Text = dr["rmte"].ToString();
                allocatedRMTE.Text = string.Format("{0:n}", double.Parse(allocatedRMTE.Text));
                allocatedMDCO.Text = dr["mdco"].ToString();
                allocatedMDCO.Text = string.Format("{0:n}", double.Parse(allocatedMDCO.Text));
                allocatedOM.Text = dr["om"].ToString();
                allocatedOM.Text = string.Format("{0:n}", double.Parse(allocatedOM.Text));
                allocatedJO.Text = dr["ogs"].ToString();
                allocatedJO.Text = string.Format("{0:n}", double.Parse(allocatedJO.Text));
            }
            

        }

        void remainingBudget()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.ConnString);
                String query = "SELECT (tblEndUsers.os - SUM(tblBudget.os)) as remainingOS, (tblEndUsers.fol - SUM(tblBudget.fol)) AS remainingFOL, (tblEndUsers.rmte - SUM(tblBudget.rmte)) AS remainingRMTE, (tblEndUsers.om - SUM(tblBudget.om)) AS remainingOM, (tblEndUsers.travexloc - SUM(tblBudget.travexloc)) AS remainingTravExLoc, (tblEndUsers.trainingex - SUM(tblBudget.trainingex)) AS remainingTrainingEx, (tblEndUsers.telex - SUM(tblBudget.telex)) AS remainingTelEx, (tblEndUsers.internetsubex - SUM(tblBudget.internetsubex)) AS remainingInternetSubEx, (tblEndUsers.consultancyser - SUM(tblBudget.consultancyser)) AS remainingConsultancySer, (tblEndUsers.mdco - SUM(tblBudget.mdco)) AS remainingMDCO, (tblEndUsers.ogs - SUM(tblBudget.ogs)) AS remainingOGS, ((tblEndUsers.os - SUM(tblBudget.os)) + (tblEndUsers.fol - SUM(tblBudget.fol)) + (tblEndUsers.rmte - SUM(tblBudget.rmte)) + (tblEndUsers.om - SUM(tblBudget.om)) + (tblEndUsers.travexloc - SUM(tblBudget.travexloc)) + (tblEndUsers.trainingex - SUM(tblBudget.trainingex)) + (tblEndUsers.telex - SUM(tblBudget.telex)) + (tblEndUsers.internetsubex - SUM(tblBudget.internetsubex)) + (tblEndUsers.consultancyser - SUM(tblBudget.consultancyser)) + (tblEndUsers.mdco - SUM(tblBudget.mdco)) + (tblEndUsers.ogs - SUM(tblBudget.ogs))) AS remainingTB FROM tblBudget INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE tblBudget.Name = '" + cmbUser.Text + "' AND tblBudget.year = '" + cmbYear.Text + "' GROUP BY tblEndUsers.os, tblEndUsers.fol, tblEndUsers.rmte, tblEndUsers.om, tblEndUsers.travexloc, tblEndUsers.trainingex, tblEndUsers.telex, tblEndUsers.internetsubex, tblEndUsers.consultancyser, tblEndUsers.mdco, tblEndUsers.om, tblEndUsers.ogs";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    remainingTB.Text = dr["remainingTB"].ToString();
                    remainingTB.Text = string.Format("{0:n}", double.Parse(remainingTB.Text));
                    remainingOS.Text = dr["remainingOS"].ToString();
                    remainingOS.Text = string.Format("{0:n}", double.Parse(remainingOS.Text));
                    remainingFOL.Text = dr["remainingFOL"].ToString();
                    remainingFOL.Text = string.Format("{0:n}", double.Parse(remainingFOL.Text));
                    remainingRMTE.Text = dr["remainingRMTE"].ToString();
                    remainingRMTE.Text = string.Format("{0:n}", double.Parse(remainingRMTE.Text));
                    remainingOM.Text = dr["remainingOM"].ToString();
                    remainingOM.Text = string.Format("{0:n}", double.Parse(remainingOM.Text));
                    remainingTravExLoc.Text = dr["remainingTravExLoc"].ToString();
                    remainingTravExLoc.Text = string.Format("{0:n}", double.Parse(remainingTravExLoc.Text));
                    remainingTrainingEx.Text = dr["remainingTrainingEx"].ToString();
                    remainingTrainingEx.Text = string.Format("{0:n}", double.Parse(remainingTrainingEx.Text));
                    remainingTelEx.Text = dr["remainingTelEx"].ToString();
                    remainingTelEx.Text = string.Format("{0:n}", double.Parse(remainingTelEx.Text));
                    remainingInternetSubEx.Text = dr["remainingInternetSubEx"].ToString();
                    remainingInternetSubEx.Text = string.Format("{0:n}", double.Parse(remainingInternetSubEx.Text));
                    remainingConsultancySer.Text = dr["remainingConsultancySer"].ToString();
                    remainingConsultancySer.Text = string.Format("{0:n}", double.Parse(remainingConsultancySer.Text));
                    remainingRMTE.Text = dr["remainingRMTE"].ToString();
                    remainingRMTE.Text = string.Format("{0:n}", double.Parse(remainingRMTE.Text));
                    remainingMDCO.Text = dr["remainingMDCO"].ToString();
                    remainingMDCO.Text = string.Format("{0:n}", double.Parse(remainingMDCO.Text));
                    remainingOM.Text = dr["remainingOM"].ToString();
                    remainingOM.Text = string.Format("{0:n}", double.Parse(remainingOM.Text));
                    remainingJO.Text = dr["remainingOGS"].ToString();
                    remainingJO.Text = string.Format("{0:n}", double.Parse(remainingJO.Text));
                    ////remainingTB.Text = dr["remainingTB"].ToString();
                    //remainingOS.Text = dr["remainingOS"].ToString();
                    //remainingOS.Text = string.Format("{0:n}", double.Parse(remainingOS.Text));
                    //remainingFOL.Text = dr["remainingFOL"].ToString();
                    //remainingFOL.Text = string.Format("{0:n}", double.Parse(remainingFOL.Text));
                    //remainingRMTE.Text = dr["remainingRMTE"].ToString();
                    //remainingRMTE.Text = string.Format("{0:n}", double.Parse(remainingRMTE.Text));
                    //remainingOM.Text = dr["remainingOM"].ToString();
                    //remainingOM.Text = string.Format("{0:n}", double.Parse(remainingOM.Text));
                    //remainingCO.Text = dr["remainingCO"].ToString();
                    //remainingCO.Text = string.Format("{0:n}", double.Parse(remainingCO.Text));
                    //remainingTB.Text = dr["remainingTB"].ToString();
                    //remainingTB.Text = string.Format("{0:n}", double.Parse(remainingTB.Text));

                }
            }
            catch
            {

            }
            
        }

        void usedBudget()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT (SUM(tblBudget.os)) as usedOS, (SUM(tblBudget.fol)) AS usedFOL, (SUM(tblBudget.rmte)) AS usedRMTE, (SUM(tblBudget.om)) AS usedOM, (SUM(tblBudget.travexloc)) AS usedTravExLoc, (SUM(tblBudget.trainingex)) AS usedTrainingEx, (SUM(tblBudget.telex)) AS usedTelEx, (SUM(tblBudget.internetsubex)) AS usedInternetSubEx, (SUM(tblBudget.consultancyser)) AS usedConsultancySer, (SUM(tblBudget.mdco)) AS usedMDCO, (SUM(tblBudget.ogs)) AS usedOGS, ((SUM(tblBudget.os)) + (SUM(tblBudget.fol)) + (SUM(tblBudget.rmte)) + (SUM(tblBudget.om)) + (SUM(tblBudget.travexloc)) + (SUM(tblBudget.trainingex)) + (SUM(tblBudget.telex)) + (SUM(tblBudget.internetsubex)) + (SUM(tblBudget.consultancyser)) + (SUM(tblBudget.mdco)) + (SUM(tblBudget.ogs))) AS usedTB FROM tblBudget INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE tblBudget.Name = '" + cmbUser.Text + "' AND tblBudget.year = '" + cmbYear.Text + "' GROUP BY tblEndUsers.os, tblEndUsers.fol, tblEndUsers.rmte, tblEndUsers.om, tblEndUsers.travexloc, tblEndUsers.trainingex, tblEndUsers.telex, tblEndUsers.internetsubex, tblEndUsers.consultancyser, tblEndUsers.mdco, tblEndUsers.om, tblEndUsers.ogs";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usedTB.Text = dr["usedTB"].ToString();
                usedTB.Text = string.Format("{0:n}", double.Parse(usedTB.Text));
                usedOS.Text = dr["usedOS"].ToString();
                usedOS.Text = string.Format("{0:n}", double.Parse(usedOS.Text));
                usedFOL.Text = dr["usedFOL"].ToString();
                usedFOL.Text = string.Format("{0:n}", double.Parse(usedFOL.Text));
                usedRMTE.Text = dr["usedRMTE"].ToString();
                usedRMTE.Text = string.Format("{0:n}", double.Parse(usedRMTE.Text));
                usedOM.Text = dr["usedOM"].ToString();
                usedOM.Text = string.Format("{0:n}", double.Parse(usedOM.Text));
                usedTravExLoc.Text = dr["usedTravExLoc"].ToString();
                usedTravExLoc.Text = string.Format("{0:n}", double.Parse(usedTravExLoc.Text));
                usedTrainingEx.Text = dr["usedTrainingEx"].ToString();
                usedTrainingEx.Text = string.Format("{0:n}", double.Parse(usedTrainingEx.Text));
                usedTelEx.Text = dr["usedTelEx"].ToString();
                usedTelEx.Text = string.Format("{0:n}", double.Parse(usedTelEx.Text));
                usedInternetSubEx.Text = dr["usedInternetSubEx"].ToString();
                usedInternetSubEx.Text = string.Format("{0:n}", double.Parse(usedInternetSubEx.Text));
                usedConsultancySer.Text = dr["usedConsultancySer"].ToString();
                usedConsultancySer.Text = string.Format("{0:n}", double.Parse(usedConsultancySer.Text));
                usedRMTE.Text = dr["usedRMTE"].ToString();
                usedRMTE.Text = string.Format("{0:n}", double.Parse(usedRMTE.Text));
                usedMDCO.Text = dr["usedMDCO"].ToString();
                usedMDCO.Text = string.Format("{0:n}", double.Parse(usedMDCO.Text));
                usedOM.Text = dr["usedOM"].ToString();
                usedOM.Text = string.Format("{0:n}", double.Parse(usedOM.Text));
                usedJO.Text = dr["usedOGS"].ToString();
                usedJO.Text = string.Format("{0:n}", double.Parse(usedJO.Text));
            }
        }

        void budgetData()
        {
            SelectALLDATA();
            lvBudget.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblBudget WHERE Name = '"+cmbUser.Text+ "' AND year = '"+cmbYear.Text+ "' AND controlNumber NOT LIKE '%Extra%' ORDER BY date DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["budgetID"].ToString());

                string date = DateTime.Parse(dr["date"].ToString()).ToShortDateString();
                lv.SubItems.Add(date);

                lv.SubItems.Add(dr["controlNumber"].ToString());
                lv.SubItems.Add(dr["description"].ToString());
                lv.SubItems.Add(dr["travexloc"].ToString());
                lv.SubItems.Add(dr["trainingex"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["telex"].ToString());
                lv.SubItems.Add(dr["internetsubex"].ToString());
                lv.SubItems.Add(dr["consultancyser"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["mdco"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["ogs"].ToString());
                //lv.SubItems.Add(dr["rmbos"].ToString());
                //lv.SubItems.Add(dr["rmme"].ToString());
                //lv.SubItems.Add(dr["rmte"].ToString());
                //lv.SubItems.Add(dr["rmff"].ToString());
                //lv.SubItems.Add(dr["rmoppe"].ToString());
                //lv.SubItems.Add(dr["fbp"].ToString());
                //lv.SubItems.Add(dr["advertisingex"].ToString());
                //lv.SubItems.Add(dr["ppe"].ToString());
                //lv.SubItems.Add(dr["repex"].ToString());
                //lv.SubItems.Add(dr["mdco"].ToString());
                //lv.SubItems.Add(dr["subsex"].ToString());
                //lv.SubItems.Add(dr["om"].ToString());
                //lv.SubItems.Add(dr["jo"].ToString());
                //lv.SubItems.Add(dr["co"].ToString());
                //lv.SubItems.Add(dr["swr"].ToString());
                //lv.SubItems.Add(dr["swc"].ToString());
                //lv.SubItems.Add(dr["pera"].ToString());
                //lv.SubItems.Add(dr["repallowance"].ToString());
                //lv.SubItems.Add(dr["transpoallowance"].ToString());
                //lv.SubItems.Add(dr["clothing"].ToString());
                //lv.SubItems.Add(dr["ot"].ToString());
                //lv.SubItems.Add(dr["yearend"].ToString());
                //lv.SubItems.Add(dr["cashgift"].ToString());
                //lv.SubItems.Add(dr["obam"].ToString());
                //lv.SubItems.Add(dr["obaa"].ToString());
                //lv.SubItems.Add(dr["retirement"].ToString());
                //lv.SubItems.Add(dr["pagibig"].ToString());
                //lv.SubItems.Add(dr["philhealth"].ToString());
                //lv.SubItems.Add(dr["ecip"].ToString());
                //lv.SubItems.Add(dr["tlb"].ToString());
                //lv.SubItems.Add(dr["opbm"].ToString());
                //lv.SubItems.Add(dr["opbl"].ToString());
                //lv.SubItems.Add(dr["opbpei"].ToString());

                //lv.SubItems.Add(dr["year"].ToString());
                
                lvBudget.Items.Add(lv);

                

            }

            lvBudget.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvBudget.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvBudget.Columns[0].Width = 0;
        }



        private void endUser_Load(object sender, EventArgs e)
        {
            //if(Program.userType == "superadmin")
            //{
            //    cmbYear.Enabled = true;
            //}
            //else
            //{
            //    cmbYear.Enabled = false;
            //}

            comboDept.SelectedIndex = 0;
            SelectALLDATA();
            budgetData();
            remainingBudget();
            usedBudget();
            lblyear.Text = cmbYear.Text;
     
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        
        private void pendingList_MouseClick(object sender, MouseEventArgs e)
        {
            //Program.ctrl = pendingList.SelectedItems[0].ToString();
            //MessageBox.Show(Program.ctrl);
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

        private void getUsers()
        {
            if (comboDept.SelectedIndex == 0)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND Name LIKE 'BM %'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' ORDER BY year DESC", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
            }

            if (comboDept.SelectedIndex == 1)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND Name LIKE 'BM %'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' ORDER BY year DESC", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
                //cmbYear.DataSource = table;
                //cmbYear.DisplayMember = "year";
            }

        }

        private void getUsersofCurrentYear()
        {
            if (comboDept.SelectedIndex == 0)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE())", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE()) ORDER BY year DESC ", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
            }

            if (comboDept.SelectedIndex == 1)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND year = YEAR(GETDATE())", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND year = YEAR(GETDATE()) ORDER BY year DESC", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
                //cmbYear.DataSource = table;
                //cmbYear.DisplayMember = "year";
            }

        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            allClear();
            SelectALLDATA();
            budgetData();
            remainingBudget();
            usedBudget();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(Program.userType == "superadmin")
            //{
            //    getUsers();
            //}
            //else
            //{
            //    getUsersofCurrentYear();
            //}
            getUsers();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblyear.Text = cmbYear.Text;
            //allClear();
            //SelectALLDATA();
            //budgetData();
            //remainingBudget();
        }

        void allClear()
        {
            allocatedTB.Text = "";
            allocatedTravExLoc.Text = "";
            allocatedTrainingEx.Text = "";
            allocatedOS.Text = "";
            allocatedFOL.Text = "";
            allocatedTelEx.Text = "";

            remainingTB.Text = string.Empty;
            remainingOS.Text = string.Empty;
            remainingFOL.Text = string.Empty;
            remainingRMTE.Text = string.Empty;
            remainingOM.Text = string.Empty;
        }

        private void icnSearch_Click(object sender, EventArgs e)
        {

            allClear();
            SelectALLDATA();
            budgetData();
            remainingBudget();
            usedBudget();
        }

        private void icnPrint_Click(object sender, EventArgs e)
        {
            Program.username = cmbUser.Text;
            Program.useryear= cmbYear.Text;
            
            ReportCrystal reportForm = new ReportCrystal();
            reportForm.ShowDialog();

            //BudgetTrackReportsViewer budgetTrackReportsViewer = new BudgetTrackReportsViewer();
            //budgetTrackReportsViewer.Show();
            //SqlConnection con = new SqlConnection(Program.ConnString);


            //SqlCommand cmd = new SqlCommand("SELECT * FROM qrMotherTable INNER JOIN tblBudget ON qrMotherTable.prEnduser = tblBudget.Name INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE qrMotherTable.prEnduser = '" + cmbUser.Text + "' AND YEAR(prDate) = '" + cmbYear.Text + "'", con);
            //SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);


            //budgetTrackReportsViewer.budgetReportViewer.LocalReport.DataSources.Clear();
            //ReportDataSource source = new ReportDataSource("DataSet1", dt);
            //budgetTrackReportsViewer.budgetReportViewer.LocalReport.ReportPath = "budgetTrackingReport.rdlc";
            //budgetTrackReportsViewer.budgetReportViewer.LocalReport.DataSources.Add(source);
            //budgetTrackReportsViewer.budgetReportViewer.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void lvBudget_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblOS_Click(object sender, EventArgs e)
        {

        }
    }
}
