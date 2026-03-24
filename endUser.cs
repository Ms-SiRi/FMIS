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
using CrystalDecisions.Windows.Forms;
using System.Windows.Media.Converters;
using System.Threading;

namespace FMIS
{
    public partial class endUser : Form
    {
        public endUser()
        {
            InitializeComponent();
        }

        private void panelHome_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            emptyFields();
            
        }
        private void saveEmptyBudget()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string datey = DateTime.Now.Year.ToString("yyyy");
            int year = Convert.ToInt32(txtyear.Text);
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBudget(controlNumber, Name, Department,travexloc, travexfor, trainingex, os, fol, osme, pcs, telex, internetsubex, lss, consultancyser, ogs, rmbos, rmme, rmte, rmff, rmoppe, fbp, advertisingex, ppe, repex, mdco, subsex, om, jo, co, swr, swc, pera, repallowance, transpoallowance, clothing, ot, yearend, cashgift, obam, obaa, retirement, pagibig, philhealth, ecip, tlb, opbm, opbl, opbpei, vfol, cstre, qa, year, date) VALUES(@ctrlnum, @Name, @Dept, '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', @year, @date)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", "Extra" + year + "0000");
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                //cmd.Parameters.AddWithValue("@os", '0');
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();
            }

            //MessageBox.Show("Budget Saved!");

        }

        private void savePreLoadEmptyBudget()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string datey = DateTime.Now.Year.ToString("yyyy");
            //int year = Convert.ToInt32(txtyear.Text);
            //Program.preloadyear = Convert.ToInt32(DateTime.Now.ToString("yyyy")) + 1;
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblBudget(controlNumber, Name, Department,travexloc, travexfor, trainingex, os, fol, osme, pcs, telex, internetsubex, lss, consultancyser, ogs, rmbos, rmme, rmte, rmff, rmoppe, fbp, advertisingex, ppe, repex, mdco, subsex, om, jo, co, swr, swc, pera, repallowance, transpoallowance, clothing, ot, yearend, cashgift, obam, obaa, retirement, pagibig, philhealth, ecip, tlb, opbm, opbl, opbpei, vfol, cstre, qa, year, date) VALUES(@ctrlnum, @Name, @Dept, '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0',  '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', @year, @date)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ctrlnum", "Extra" + Program.preloadyear + "0000");
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                //cmd.Parameters.AddWithValue("@os", '0');
                cmd.Parameters.AddWithValue("@year", Program.preloadyear);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Preload Budget Saved!");

        }


        private void savePreLoadUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblEndUsers(Name,Department, tb, travexloc, travexfor, trainingex, os, fol, osme, pcs, telex, internetsubex, lss, consultancyser, ogs, rmbos, rmme, rmte, rmff, rmoppe, fbp, advertisingex, ppe, repex, mdco, subsex, om, jo, co, swr, swc, pera, repallowance, transpoallowance, clothing, ot, yearend, cashgift, obam, obaa, retirement, pagibig, philhealth, ecip, tlb, opbm, opbl, opbpei, vfol, cstre, qa, year) SELECT Name, Department, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "+Program.preloadyear+" FROM tblEndUsers AS src WHERE src.year = YEAR(GETDATE()) AND NOT EXISTS (SELECT 1 FROM tblEndUsers WHERE Name = src.Name AND year = "+Program.preloadyear+");";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@year", Program.preloadyear);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved Preload Users!");
            dataClear();
        }


        private void emptyFields()
        {
            if (txtuserName.Text == "" || cmbDepartment.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                saveEmptyBudget();
                saveUser();
                SelectALLDATA();
            }
        }

        private void emptyPreloadFields()
        {
            if (txtuserName.Text == "" || cmbDepartment.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                savePreLoadEmptyBudget();
                savePreLoadUser();
                SelectALLDATA();
            }
        }

        private void saveUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblEndUsers(Name,Department, tb, travexloc, travexfor, trainingex, os, fol, osme, pcs, telex, internetsubex, lss, consultancyser, ogs, rmbos, rmme, rmte, rmff, rmoppe, fbp, advertisingex, ppe, repex, mdco, subsex, om, jo, co, swr, swc, pera, repallowance, transpoallowance, clothing, ot, yearend, cashgift, obam, obaa, retirement, pagibig, philhealth, ecip, tlb, opbm, opbl, opbpei, vfol, cstre, qa, year) VALUES (@Name,@Dept, @tb,  @travexloc, @travexfor, @trainingex, @os, @fol, @osme, @pcs, @telex, @internetsubex, @lss, @consultancyser, @ogs, @rmbos, @rmme, @rmte, @rmff, @rmoppe, @fbp, @advertisingex, @ppe, @repex, @mdco, @subsex, @om, @jo, @co, @swr, @swc, @pera, @repallowance, @transpoallowance, @clothing, @ot, @yearend, @cashgift, @obam, @obaa, @retirement, @pagibig, @philhealth, @ecip, @tlb, @opbm, @opbl, @opbpei, @vfol, @cstre, @qa, @year)";

            con.Open();
            
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@tb", txtTB.Text);
                cmd.Parameters.AddWithValue("@travexloc", travexlocbudget);
                cmd.Parameters.AddWithValue("@travexfor", travexforbudget);
                cmd.Parameters.AddWithValue("@trainingex", trainingexbudget);
                cmd.Parameters.AddWithValue("@os", osbudget);
                cmd.Parameters.AddWithValue("@fol", folbudget);
                cmd.Parameters.AddWithValue("@osme", osmebudget);
                cmd.Parameters.AddWithValue("@pcs", pcsbudget);
                cmd.Parameters.AddWithValue("@telex", telexbudget);
                cmd.Parameters.AddWithValue("@internetsubex", internetsubexbudget);
                cmd.Parameters.AddWithValue("@lss", lssbudget);
                cmd.Parameters.AddWithValue("@consultancyser", consultancyserbudget);
                cmd.Parameters.AddWithValue("@ogs", ogsbudget);
                cmd.Parameters.AddWithValue("@rmbos", rmbosbudget);
                cmd.Parameters.AddWithValue("@rmme", rmmebudget);
                cmd.Parameters.AddWithValue("@rmte", rmtebudget);
                cmd.Parameters.AddWithValue("@rmff", rmffbudget);
                cmd.Parameters.AddWithValue("@rmoppe", rmoppebudget);
                cmd.Parameters.AddWithValue("@fbp", fbpbudget);
                cmd.Parameters.AddWithValue("@advertisingex", advertisingexbudget);
                cmd.Parameters.AddWithValue("@ppe", ppebudget);
                cmd.Parameters.AddWithValue("@repex", repexbudget);
                cmd.Parameters.AddWithValue("@mdco", mdcobudget);
                cmd.Parameters.AddWithValue("@subsex", subsexbudget);
                cmd.Parameters.AddWithValue("@om", ombudget);
                cmd.Parameters.AddWithValue("@jo", jobudget);
                cmd.Parameters.AddWithValue("@co", cobudget);
                cmd.Parameters.AddWithValue("@swr", swrbudget);
                cmd.Parameters.AddWithValue("@swc", swcbudget);
                cmd.Parameters.AddWithValue("@pera", perabudget);
                cmd.Parameters.AddWithValue("@repallowance", repallowancebudget);
                cmd.Parameters.AddWithValue("@transpoallowance", transpoallowancebudget);
                cmd.Parameters.AddWithValue("@clothing", clothingbudget);
                cmd.Parameters.AddWithValue("@ot", otbudget);
                cmd.Parameters.AddWithValue("@yearend", yearendbudget);
                cmd.Parameters.AddWithValue("@cashgift", cashgiftbudget);
                cmd.Parameters.AddWithValue("@obam", obambudget);
                cmd.Parameters.AddWithValue("@obaa", obaabudget);
                cmd.Parameters.AddWithValue("@retirement", retirementbudget);
                cmd.Parameters.AddWithValue("@pagibig", pagibigbudget);
                cmd.Parameters.AddWithValue("@philhealth", philhealthbudget);
                cmd.Parameters.AddWithValue("@ecip", ecipbudget);
                cmd.Parameters.AddWithValue("@tlb", tlbbudget);
                cmd.Parameters.AddWithValue("@opbm", opbmbudget);
                cmd.Parameters.AddWithValue("@opbl", opblbudget);
                cmd.Parameters.AddWithValue("@opbpei", opbpeibudget);
                cmd.Parameters.AddWithValue("@vfol", folbudget);
                cmd.Parameters.AddWithValue("@cstre", cstrebudget);
                cmd.Parameters.AddWithValue("@qa", qabudget);
                cmd.Parameters.AddWithValue("@year", txtyear.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved!");
            dataClear();
        }

        void SelectALLDATA()
        {
            lvAllUsers.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE year = YEAR(GETDATE())ORDER BY year ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["userID"].ToString());

                lv.SubItems.Add(dr["Name"].ToString());
                lv.SubItems.Add(dr["Department"].ToString());
                lv.SubItems.Add(dr["tb"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["co"].ToString());
                lv.SubItems.Add(dr["repex"].ToString());
                lv.SubItems.Add(dr["year"].ToString());
                lvAllUsers.Items.Add(lv);

            }
            lvAllUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAllUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvAllUsers.Columns[0].Width = 0;
        }

        void selectSPUsers()
        {
            SPList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' WHERE year = YEAR(GETDATE())ORDER BY year ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["userID"].ToString());

                lv.SubItems.Add(dr["Name"].ToString());
                lv.SubItems.Add(dr["Department"].ToString());
                lv.SubItems.Add(dr["tb"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["co"].ToString());
                lv.SubItems.Add(dr["repex"].ToString());
                lv.SubItems.Add(dr["year"].ToString());
                SPList.Items.Add(lv);

            }
            SPList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            SPList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SPList.Columns[0].Width = 0;
        }

        void selectVGOUsers()
        {
            VGOList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' WHERE year = YEAR(GETDATE())ORDER BY year ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["userID"].ToString());

                lv.SubItems.Add(dr["Name"].ToString());
                lv.SubItems.Add(dr["Department"].ToString());
                lv.SubItems.Add(dr["tb"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["co"].ToString());
                lv.SubItems.Add(dr["repex"].ToString());
                lv.SubItems.Add(dr["year"].ToString());
                VGOList.Items.Add(lv);

            }
            VGOList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            VGOList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            VGOList.Columns[0].Width = 0;
        }

        private void endUser_Load(object sender, EventArgs e)
        {
            
            txtyear.Text = DateTime.Now.ToString("yyyy");
            //txtyear.Text = "2025";
            cmbDepartment.SelectedIndex = 0;
            SelectALLDATA();
        }

        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editUser();            
        }

        private void editUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblEndUsers SET Name = @Name, Department = @Dept, tb = @tb, travexloc = @travexloc, travexfor = @travexfor, trainingex = @trainingex, os = @os, fol = @fol, osme = @osme, pcs = @pcs, telex = @telex, internetsubex = @internetsubex, lss = @lss, consultancyser = @consultancyser, ogs = @ogs, rmbos = @rmbos, rmme = @rmme, rmte = @rmte, rmff = @rmff, rmoppe = @rmoppe, fbp = @fbp, advertisingex = @advertisingex, ppe = @ppe, repex = @repex, mdco = @mdco, subsex = @subsex, om = @om, jo = @jo, co = @co, swr = @swr, swc = @swc, pera = @pera, repallowance = @repallowance, transpoallowance = @transpoallowance, clothing = @clothing, ot = @ot, yearend = @yearend, cashgift = @cashgift, obam = @obam, obaa = @obaa, retirement = @retirement, pagibig = @pagibig, philhealth = @philhealth, ecip = @ecip, tlb = @tlb, opbm = @opbm, opbl = @opbl, opbpei = @opbpei, cstre = @cstre, qa = @qa, year = @year WHERE userID = @ID";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", Program.userID);
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@tb", txtTB.Text);
                cmd.Parameters.AddWithValue("@travexloc", travexlocbudget);
                cmd.Parameters.AddWithValue("@travexfor", travexforbudget);
                cmd.Parameters.AddWithValue("@trainingex", trainingexbudget);
                cmd.Parameters.AddWithValue("@os", osbudget);
                cmd.Parameters.AddWithValue("@fol", folbudget);
                cmd.Parameters.AddWithValue("@osme", osmebudget);
                cmd.Parameters.AddWithValue("@pcs", pcsbudget);
                cmd.Parameters.AddWithValue("@telex", telexbudget);
                cmd.Parameters.AddWithValue("@internetsubex", internetsubexbudget);
                cmd.Parameters.AddWithValue("@lss", lssbudget);
                cmd.Parameters.AddWithValue("@consultancyser", consultancyserbudget);
                cmd.Parameters.AddWithValue("@ogs", ogsbudget);
                cmd.Parameters.AddWithValue("@rmbos", rmbosbudget);
                cmd.Parameters.AddWithValue("@rmme", rmmebudget);
                cmd.Parameters.AddWithValue("@rmte", rmtebudget);
                cmd.Parameters.AddWithValue("@rmff", rmffbudget);
                cmd.Parameters.AddWithValue("@rmoppe", rmoppebudget);
                cmd.Parameters.AddWithValue("@fbp", fbpbudget);
                cmd.Parameters.AddWithValue("@advertisingex", advertisingexbudget);
                cmd.Parameters.AddWithValue("@ppe", ppebudget);
                cmd.Parameters.AddWithValue("@repex", repexbudget);
                cmd.Parameters.AddWithValue("@mdco", mdcobudget);
                cmd.Parameters.AddWithValue("@subsex", subsexbudget);
                cmd.Parameters.AddWithValue("@om", ombudget);
                cmd.Parameters.AddWithValue("@jo", jobudget);
                cmd.Parameters.AddWithValue("@co", cobudget);
                cmd.Parameters.AddWithValue("@swr", swrbudget);
                cmd.Parameters.AddWithValue("@swc", swcbudget);
                cmd.Parameters.AddWithValue("@pera", perabudget);
                cmd.Parameters.AddWithValue("@repallowance", repallowancebudget);
                cmd.Parameters.AddWithValue("@transpoallowance", transpoallowancebudget);
                cmd.Parameters.AddWithValue("@clothing", clothingbudget);
                cmd.Parameters.AddWithValue("@ot", otbudget);
                cmd.Parameters.AddWithValue("@yearend", yearendbudget);
                cmd.Parameters.AddWithValue("@cashgift", cashgiftbudget);
                cmd.Parameters.AddWithValue("@obam", obambudget);
                cmd.Parameters.AddWithValue("@obaa", obaabudget);
                cmd.Parameters.AddWithValue("@retirement", retirementbudget);
                cmd.Parameters.AddWithValue("@pagibig", pagibigbudget);
                cmd.Parameters.AddWithValue("@philhealth", philhealthbudget);
                cmd.Parameters.AddWithValue("@ecip", ecipbudget);
                cmd.Parameters.AddWithValue("@tlb", tlbbudget);
                cmd.Parameters.AddWithValue("@opbm", opbmbudget);
                cmd.Parameters.AddWithValue("@opbl", opblbudget);
                cmd.Parameters.AddWithValue("@opbpei", opbpeibudget);
                cmd.Parameters.AddWithValue("@vfol", folbudget);
                cmd.Parameters.AddWithValue("@cstre", cstrebudget);
                cmd.Parameters.AddWithValue("@qa", qabudget);
                //cmd.Parameters.AddWithValue("@cstre", txtCSTRE.Text);
                cmd.Parameters.AddWithValue("@year", txtyear.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Updated!");
            dataClear();
            SelectALLDATA();
        }
       
        private void pendingList_MouseClick(object sender, MouseEventArgs e)
        {
            //Program.ctrl = pendingList.SelectedItems[0].ToString();
            //MessageBox.Show(Program.ctrl);
        }

        private void SPList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SPList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = SPList.SelectedItems[0];


                Program.userID = selectedItem.SubItems[0].Text;
                getUserDetailsByID();
                //txtuserName.Text = selectedItem.SubItems[1].Text;
                //cmbDepartment.Text = selectedItem.SubItems[2].Text;
                //txtTB.Text = selectedItem.SubItems[3].Text;
                //txtOS.Text = selectedItem.SubItems[4].Text;
                //txtFOL.Text = selectedItem.SubItems[5].Text;
                //txtRMTE.Text = selectedItem.SubItems[6].Text;
                //txtOM.Text = selectedItem.SubItems[7].Text;
                //txtCO.Text = selectedItem.SubItems[8].Text;
                //txtRepEx.Text = selectedItem.SubItems[9].Text;
                //txtyear.Text = selectedItem.SubItems[10].Text;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;

            }

        }

        void getUserDetailsByID()
        {
            SPList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE userID = "+Program.userID;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtuserName.Text = dr["Name"].ToString();
                cmbDepartment.Text = dr["Department"].ToString();
                txtyear.Text = dr["year"].ToString();
                txtTB.Text = dr["tb"].ToString();
                txtTravExLoc.Text = dr["travexloc"].ToString();
                txtTravExFor.Text = dr["travexfor"].ToString();
                txtTrainingEx.Text = dr["trainingex"].ToString();
                txtOS.Text = dr["os"].ToString();
                txtFOL.Text = dr["fol"].ToString();
                txtOSME.Text = dr["osme"].ToString();
                txtPCS.Text = dr["pcs"].ToString();
                txtTelEx.Text = dr["telex"].ToString();
                txtInternetSubEx.Text = dr["internetsubex"].ToString();
                txtLSS.Text = dr["lss"].ToString();
                txtConsultancySer.Text = dr["consultancyser"].ToString();
                txtOGS.Text = dr["ogs"].ToString();
                txtRMBOS.Text = dr["rmbos"].ToString();
                txtRMME.Text = dr["rmme"].ToString();
                txtRMTE.Text = dr["rmte"].ToString();
                txtRMFF.Text = dr["rmff"].ToString();
                txtRMOPPE.Text = dr["rmoppe"].ToString();
                txtFBP.Text = dr["fbp"].ToString();
                txtAdvertisingEx.Text = dr["advertisingex"].ToString();
                txtPPE.Text = dr["ppe"].ToString();
                txtRepEx.Text = dr["repex"].ToString();
                txtMDCO.Text = dr["mdco"].ToString();
                txtSubsEx.Text = dr["subsex"].ToString();
                txtOM.Text = dr["om"].ToString();
                txtJO.Text = dr["jo"].ToString();
                txtCO.Text = dr["co"].ToString();
                txtSWR.Text = dr["swr"].ToString();
                txtSWC.Text = dr["swc"].ToString();
                txtPERA.Text = dr["pera"].ToString();
                txtRepAllowance.Text = dr["repallowance"].ToString();
                txtTranspoAllowance.Text = dr["transpoallowance"].ToString();
                txtClothing.Text = dr["clothing"].ToString();
                txtOT.Text = dr["ot"].ToString();
                txtYearEnd.Text = dr["yearend"].ToString();
                txtCashGift.Text = dr["cashgift"].ToString();
                txtOBAM.Text = dr["obam"].ToString();
                txtOBAA.Text = dr["obaa"].ToString();
                txtRetirement.Text = dr["retirement"].ToString();
                txtPagibig.Text = dr["pagibig"].ToString();
                txtPhilhealth.Text = dr["philhealth"].ToString();
                txtECIP.Text = dr["ecip"].ToString();
                txtTLB.Text = dr["tlb"].ToString();
                txtOPBM.Text = dr["opbm"].ToString();
                txtOPBL.Text = dr["opbl"].ToString();
                txtOPBPEI.Text = dr["opbpei"].ToString();
                txtCSTRE.Text = dr["cstre"].ToString();
                txtQA.Text = dr["qa"].ToString();
                //txtvFOL.Text = dr["vfol"].ToString();

            }
        }

        private void lvAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvAllUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAllUsers.SelectedItems[0];


                Program.userID = selectedItem.SubItems[0].Text;
                Program.userID = selectedItem.SubItems[0].Text;
                getUserDetailsByID();
                //txtuserName.Text = selectedItem.SubItems[1].Text;
                //cmbDepartment.Text = selectedItem.SubItems[2].Text;
                //txtTB.Text = selectedItem.SubItems[3].Text;
                //txtOS.Text = selectedItem.SubItems[4].Text;
                //txtFOL.Text = selectedItem.SubItems[5].Text;
                //txtRMTE.Text = selectedItem.SubItems[6].Text;
                //txtOM.Text = selectedItem.SubItems[7].Text;
                //txtCO.Text = selectedItem.SubItems[8].Text;
                //txtRepEx.Text = selectedItem.SubItems[9].Text;
                //txtyear.Text = selectedItem.SubItems[10].Text;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;

            }


        }

        private void VGOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VGOList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = VGOList.SelectedItems[0];


                Program.userID = selectedItem.SubItems[0].Text;
                Program.userID = selectedItem.SubItems[0].Text;
                getUserDetailsByID();
                //txtuserName.Text = selectedItem.SubItems[1].Text;
                //cmbDepartment.Text = selectedItem.SubItems[2].Text;
                //txtTB.Text = selectedItem.SubItems[3].Text;
                //txtOS.Text = selectedItem.SubItems[4].Text;
                //txtFOL.Text = selectedItem.SubItems[5].Text;
                //txtRMTE.Text = selectedItem.SubItems[6].Text;
                //txtOM.Text = selectedItem.SubItems[7].Text;
                //txtCO.Text = selectedItem.SubItems[8].Text;
                //txtRepEx.Text = selectedItem.SubItems[9].Text;
                //txtyear.Text = selectedItem.SubItems[10].Text;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbUserList.SelectedIndex = 0;
            SelectALLDATA();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser();
        }


        private void deleteUser()
        {
           
                DialogResult dialog = MessageBox.Show("Are you sure you want to delete this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblEndUsers WHERE userID = @ID", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", Program.userID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    MessageBox.Show("Deleted!");
                    dataClear();
                    SelectALLDATA();
                }
                
           
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
            if (tbUserList.SelectedIndex == 0)
            {
                SelectALLDATA();
            }
            else if (tbUserList.SelectedIndex == 1)
            {
                selection = 1;
                selectSPUsers();
            }
            else if (tbUserList.SelectedIndex == 2)
            {
                selection = 2;
                selectVGOUsers();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataClear();
        }

        void clearAllocations()
        {
            totalBudget = 0;
            os = 0;
            fol = 0;
            rmte = 0;
            om = 0;
            co= 0;
            repex= 0;
            travexloc = 0;
            trainingex = 0;
            telex = 0;
            internetsubex = 0;
            consultancyser = 0;
            mdco = 0;
            ogs = 0;
            osme = 0;
            pcs = 0;
            rmbos = 0;
            rmme = 0;
            rmff = 0;
            rmoppe = 0;
            ppe = 0;
        }

        private void dataClear()
        {
            clearAllocations();
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtuserName.Clear();
            cmbDepartment.SelectedIndex = 0;
            txtTB.Clear();
            txtTravExLoc.Clear();
            txtTravExFor.Clear();
            txtTrainingEx.Clear();
            txtOS.Clear();
            txtFOL.Clear();
            txtOSME.Clear();
            txtPCS.Clear();
            txtTelEx.Clear();
            txtInternetSubEx.Clear();
            txtLSS.Clear();
            txtConsultancySer.Clear();
            txtOGS.Clear();
            txtRMBOS.Clear();
            txtRMME.Clear();
            txtRMTE.Clear();
            txtRMFF.Clear();
            txtRMOPPE.Clear();
            txtFBP.Clear();
            txtAdvertisingEx.Clear();
            txtPPE.Clear();
            txtRepEx.Clear();
            txtMDCO.Clear();
            txtSubsEx.Clear();
            txtOM.Clear();
            txtJO.Clear();
            txtCO.Clear();
            txtSWR.Clear();
            txtSWC.Clear();
            txtPERA.Clear();
            txtRepAllowance.Clear();
            txtTranspoAllowance.Clear();
            txtClothing.Clear();
            txtOT.Clear();
            txtYearEnd.Clear();
            txtCashGift.Clear();
            txtOBAM.Clear();
            txtOBAA.Clear();
            txtRetirement.Clear();
            txtPagibig.Clear();
            txtPhilhealth.Clear();
            txtECIP.Clear();
            txtTLB.Clear();
            txtOPBM.Clear();
            txtOPBL.Clear();
            txtOPBPEI.Clear();
            txtFOL.Clear();
            txtCSTRE.Clear();
            txtQA.Clear();
            txtyear.Clear();
            txtTB.Clear();
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
            existenceTrap();
        }

        private void existenceTrap()
        {
            
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE Name = '"+txtuserName.Text+"' and year = '"+txtyear.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Program.userID = dr["userID"].ToString();
                //txtuserName.Text = dr["Name"].ToString();
                //cmbDepartment.Text = dr["Department"].ToString();
                //txtyear.Text = dr["year"].ToString();
                //txtTB.Text = dr["tb"].ToString();
                //txtOS.Text = dr["os"].ToString();
                //txtFOL.Text = dr["fol"].ToString();
                //txtRMTE.Text = dr["rmte"].ToString();
                //txtOM.Text = dr["om"].ToString();
                //txtCO.Text = dr["co"].ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = false;

                lvAllUsers.Items.Clear();
                ListViewItem lv = new ListViewItem(dr["userID"].ToString());

                lv.SubItems.Add(dr["Name"].ToString());
                lv.SubItems.Add(dr["Department"].ToString());
                lv.SubItems.Add(dr["tb"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["co"].ToString());
                lv.SubItems.Add(dr["repex"].ToString());
                lv.SubItems.Add(dr["year"].ToString());
                lvAllUsers.Items.Add(lv);
            }


            else
            {
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                //txtTB.Text = "";
                //txtOS.Text = "";
                //txtFOL.Text = "";
                //txtRMTE.Text = "";
                //txtOM.Text = "";
                //txtCO.Text = "";

            }


            lvAllUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAllUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvAllUsers.Columns[0].Width = 0;

        }

        private void txtyear_KeyUp(object sender, KeyEventArgs e)
        {
            existenceTrap();
        }

        private void txtuserName_Enter(object sender, EventArgs e)
        {
            tbUserList.SelectedIndex = 0;
            txtuserName.Focus();
        }

        private void txtyear_Enter(object sender, EventArgs e)
        {
            tbUserList.SelectedIndex = 0;
            txtyear.Focus();
        }

        private void txtyear_TextChanged(object sender, EventArgs e)
        {

        }

        decimal totalBudget, subsex = 0, swr =0, swc = 0, pera = 0, repallowance = 0, transpoallowance = 0, clothing = 0, qa = 0, ot = 0, yearend = 0, cashgift = 0, obam = 0, obaa = 0, retirement = 0, pagibig = 0, philhealth = 0, ecip = 0, tlb = 0, opbm = 0, opbl = 0, opbpei = 0, cstre = 0, fbp = 0, advertisingex = 0, jo = 0, lss = 0, os = 0, fol = 0, rmte = 0, om = 0, co = 0, repex = 0, travexloc = 0, trainingex = 0, telex = 0, internetsubex = 0, consultancyser = 0, mdco = 0, ogs = 0, osme = 0, pcs = 0, rmbos = 0, rmme = 0, rmff = 0, rmoppe = 0, ppe = 0, travexfor = 0;

        private void txtSWC_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtPERA_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRepAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTranspoAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtQA_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtClothing_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOT_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtYearEnd_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtCashGift_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOBAM_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOBAA_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRetirement_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtPagibig_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtPhilhealth_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtECIP_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTLB_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOPBM_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOPBL_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTravExLoc_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtTravExFor_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtTrainingEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOS_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtFOL_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOSME_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtPCS_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtTelEx_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtTelEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtInternetSubEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtLSS_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtConsultancySer_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOGS_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMBOS_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMME_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtCSTRE_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMTE_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMFF_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMOPPE_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtFBP_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtAdvertisingEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtPPE_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRepEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtMDCO_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtSubsEx_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOM_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtJO_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtCO_TextChanged_1(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtSWR_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtSWC_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtPERA_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRepAllowance_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtTranspoAllowance_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtQA_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtClothing_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOT_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtYearEnd_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtCashGift_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOBAM_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOBAA_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtRetirement_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtPagibig_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtPhilhealth_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtECIP_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtTLB_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOPBM_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOPBL_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOPBPEI_TextChanged(object sender, EventArgs e)
        {
            BudgetComputation();
        }

        private void txtOSME_Leave(object sender, EventArgs e)
        {
            if (txtOSME.TextLength <= 0)
            {
                txtOSME.Text = returnCost.ToString();
                txtOSME.Text = string.Format("{0:n}", double.Parse(txtOSME.Text));
                if (decimal.TryParse(txtOSME.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    osmebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOSME.Text = string.Format("{0:n}", double.Parse(txtOSME.Text));
                if (decimal.TryParse(txtOSME.Text, out decimal result))
                {
                    osmebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOSME_Enter(object sender, EventArgs e)
        {
            savedCost = txtOSME.Text;
            //txtOSME.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtPCS_Leave(object sender, EventArgs e)
        {
            if (txtPCS.TextLength <= 0)
            {
                txtPCS.Text = returnCost.ToString();
                txtPCS.Text = string.Format("{0:n}", double.Parse(txtPCS.Text));
                if (decimal.TryParse(txtPCS.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    pcsbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtPCS.Text = string.Format("{0:n}", double.Parse(txtPCS.Text));
                if (decimal.TryParse(txtPCS.Text, out decimal result))
                {
                    pcsbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtPCS_Enter(object sender, EventArgs e)
        {
            savedCost = txtPCS.Text;
            //txtPCS.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtTelEx_Leave(object sender, EventArgs e)
        {
            if (txtTelEx.TextLength <= 0)
            {
                txtTelEx.Text = returnCost.ToString();
                txtTelEx.Text = string.Format("{0:n}", double.Parse(txtTelEx.Text));
                if (decimal.TryParse(txtTelEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    telexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTelEx.Text = string.Format("{0:n}", double.Parse(txtTelEx.Text));
                if (decimal.TryParse(txtTelEx.Text, out decimal result))
                {
                    telexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtTelEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtTelEx.Text;
            //txtTelEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtInternetSubEx_Leave(object sender, EventArgs e)
        {
            if (txtInternetSubEx.TextLength <= 0)
            {
                txtInternetSubEx.Text = returnCost.ToString();
                txtInternetSubEx.Text = string.Format("{0:n}", double.Parse(txtInternetSubEx.Text));
                if (decimal.TryParse(txtInternetSubEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    internetsubexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtInternetSubEx.Text = string.Format("{0:n}", double.Parse(txtInternetSubEx.Text));
                if (decimal.TryParse(txtInternetSubEx.Text, out decimal result))
                {
                    internetsubexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtInternetSubEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtInternetSubEx.Text;
            //txtInternetSubEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtLSS_Leave(object sender, EventArgs e)
        {
            if (txtLSS.TextLength <= 0)
            {
                txtLSS.Text = returnCost.ToString();
                txtLSS.Text = string.Format("{0:n}", double.Parse(txtLSS.Text));
                if (decimal.TryParse(txtLSS.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    lssbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtLSS.Text = string.Format("{0:n}", double.Parse(txtLSS.Text));
                if (decimal.TryParse(txtLSS.Text, out decimal result))
                {
                    lssbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtLSS_Enter(object sender, EventArgs e)
        {
            savedCost = txtLSS.Text;
            //txtLSS.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtConsultancySer_Leave(object sender, EventArgs e)
        {
            if (txtConsultancySer.TextLength <= 0)
            {
                txtConsultancySer.Text = returnCost.ToString();
                txtConsultancySer.Text = string.Format("{0:n}", double.Parse(txtConsultancySer.Text));
                if (decimal.TryParse(txtConsultancySer.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    consultancyserbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtConsultancySer.Text = string.Format("{0:n}", double.Parse(txtConsultancySer.Text));
                if (decimal.TryParse(txtConsultancySer.Text, out decimal result))
                {
                    consultancyserbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtConsultancySer_Enter(object sender, EventArgs e)
        {
            savedCost = txtConsultancySer.Text;
            //txtConsultancySer.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOGS_Leave(object sender, EventArgs e)
        {
            if (txtOGS.TextLength <= 0)
            {
                txtOGS.Text = returnCost.ToString();
                txtOGS.Text = string.Format("{0:n}", double.Parse(txtOGS.Text));
                if (decimal.TryParse(txtOGS.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    ogsbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOGS.Text = string.Format("{0:n}", double.Parse(txtOGS.Text));
                if (decimal.TryParse(txtOGS.Text, out decimal result))
                {
                    ogsbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOGS_Enter(object sender, EventArgs e)
        {
            savedCost = txtOGS.Text;
            //txtOGS.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRMBOS_Leave(object sender, EventArgs e)
        {
            if (txtRMBOS.TextLength <= 0)
            {
                txtRMBOS.Text = returnCost.ToString();
                txtRMBOS.Text = string.Format("{0:n}", double.Parse(txtRMBOS.Text));
                if (decimal.TryParse(txtRMBOS.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    rmbosbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRMBOS.Text = string.Format("{0:n}", double.Parse(txtRMBOS.Text));
                if (decimal.TryParse(txtRMBOS.Text, out decimal result))
                {
                    rmbosbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRMBOS_Enter(object sender, EventArgs e)
        {
            savedCost = txtRMBOS.Text;
            //txtRMBOS.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRMME_Leave(object sender, EventArgs e)
        {
            if (txtRMME.TextLength <= 0)
            {
                txtRMME.Text = returnCost.ToString();
                txtRMME.Text = string.Format("{0:n}", double.Parse(txtRMME.Text));
                if (decimal.TryParse(txtRMME.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    rmtebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRMME.Text = string.Format("{0:n}", double.Parse(txtRMME.Text));
                if (decimal.TryParse(txtRMME.Text, out decimal result))
                {
                    rmtebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRMME_Enter(object sender, EventArgs e)
        {
            savedCost = txtRMME.Text;
            //txtRMME.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtCSTRE_Leave(object sender, EventArgs e)
        {
            if (txtCSTRE.TextLength <= 0)
            {
                txtCSTRE.Text = returnCost.ToString();
                txtCSTRE.Text = string.Format("{0:n}", double.Parse(txtCSTRE.Text));
                if (decimal.TryParse(txtCSTRE.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    cstrebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtCSTRE.Text = string.Format("{0:n}", double.Parse(txtCSTRE.Text));
                if (decimal.TryParse(txtCSTRE.Text, out decimal result))
                {
                    cstrebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtCSTRE_Enter(object sender, EventArgs e)
        {
            savedCost = txtCSTRE.Text;
            //txtCSTRE.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRMTE_Leave(object sender, EventArgs e)
        {
            if (txtRMTE.TextLength <= 0)
            {
                txtRMTE.Text = returnCost.ToString();
                txtRMTE.Text = string.Format("{0:n}", double.Parse(txtRMTE.Text));
                if (decimal.TryParse(txtRMTE.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    rmtebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRMTE.Text = string.Format("{0:n}", double.Parse(txtRMTE.Text));
                if (decimal.TryParse(txtRMTE.Text, out decimal result))
                {
                    rmtebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRMTE_Enter(object sender, EventArgs e)
        {
            savedCost = txtRMTE.Text;
            //txtRMTE.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRMFF_Leave(object sender, EventArgs e)
        {
            if (txtRMFF.TextLength <= 0)
            {
                txtRMFF.Text = returnCost.ToString();
                txtRMFF.Text = string.Format("{0:n}", double.Parse(txtRMFF.Text));
                if (decimal.TryParse(txtRMFF.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    rmffbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRMFF.Text = string.Format("{0:n}", double.Parse(txtRMFF.Text));
                if (decimal.TryParse(txtRMFF.Text, out decimal result))
                {
                    rmffbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRMFF_Enter(object sender, EventArgs e)
        {
            savedCost = txtRMFF.Text;
            //txtRMFF.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRMOPPE_Leave(object sender, EventArgs e)
        {
            if (txtRMOPPE.TextLength <= 0)
            {
                txtRMOPPE.Text = returnCost.ToString();
                txtRMOPPE.Text = string.Format("{0:n}", double.Parse(txtRMOPPE.Text));
                if (decimal.TryParse(txtRMOPPE.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    rmoppebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRMOPPE.Text = string.Format("{0:n}", double.Parse(txtRMOPPE.Text));
                if (decimal.TryParse(txtRMOPPE.Text, out decimal result))
                {
                    rmoppebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRMOPPE_Enter(object sender, EventArgs e)
        {
            savedCost = txtRMOPPE.Text;
            //txtRMOPPE.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtFBP_Leave(object sender, EventArgs e)
        {
            if (txtFBP.TextLength <= 0)
            {
                txtFBP.Text = returnCost.ToString();
                txtFBP.Text = string.Format("{0:n}", double.Parse(txtFBP.Text));
                if (decimal.TryParse(txtFBP.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    fbpbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtFBP.Text = string.Format("{0:n}", double.Parse(txtFBP.Text));
                if (decimal.TryParse(txtFBP.Text, out decimal result))
                {
                    fbpbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtFBP_Enter(object sender, EventArgs e)
        {
            savedCost = txtFBP.Text;
            //txtFBP.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtAdvertisingEx_Leave(object sender, EventArgs e)
        {
            if (txtAdvertisingEx.TextLength <= 0)
            {
                txtAdvertisingEx.Text = returnCost.ToString();
                txtAdvertisingEx.Text = string.Format("{0:n}", double.Parse(txtAdvertisingEx.Text));
                if (decimal.TryParse(txtAdvertisingEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    advertisingexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtAdvertisingEx.Text = string.Format("{0:n}", double.Parse(txtAdvertisingEx.Text));
                if (decimal.TryParse(txtAdvertisingEx.Text, out decimal result))
                {
                    advertisingexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtAdvertisingEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtAdvertisingEx.Text;
            //txtAdvertisingEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtPPE_Leave(object sender, EventArgs e)
        {
            if (txtPPE.TextLength <= 0)
            {
                txtPPE.Text = returnCost.ToString();
                txtPPE.Text = string.Format("{0:n}", double.Parse(txtPPE.Text));
                if (decimal.TryParse(txtPPE.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    ppebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtPPE.Text = string.Format("{0:n}", double.Parse(txtPPE.Text));
                if (decimal.TryParse(txtPPE.Text, out decimal result))
                {
                    ppebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtPPE_Enter(object sender, EventArgs e)
        {
            savedCost = txtPPE.Text;
            //txtPPE.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRepEx_Leave(object sender, EventArgs e)
        {
            if (txtRepEx.TextLength <= 0)
            {
                txtRepEx.Text = returnCost.ToString();
                txtRepEx.Text = string.Format("{0:n}", double.Parse(txtRepEx.Text));
                if (decimal.TryParse(txtRepEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    repexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRepEx.Text = string.Format("{0:n}", double.Parse(txtRepEx.Text));
                if (decimal.TryParse(txtRepEx.Text, out decimal result))
                {
                    repexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtMDCO_Leave(object sender, EventArgs e)
        {
            if (txtMDCO.TextLength <= 0)
            {
                txtMDCO.Text = returnCost.ToString();
                txtMDCO.Text = string.Format("{0:n}", double.Parse(txtMDCO.Text));
                if (decimal.TryParse(txtMDCO.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    mdcobudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtMDCO.Text = string.Format("{0:n}", double.Parse(txtMDCO.Text));
                if (decimal.TryParse(txtMDCO.Text, out decimal result))
                {
                    mdcobudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRepEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtRepEx.Text;
            //txtRepEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtMDCO_Enter(object sender, EventArgs e)
        {
            savedCost = txtMDCO.Text;
            //txtMDCO.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtSubsEx_Leave(object sender, EventArgs e)
        {
            if (txtSubsEx.TextLength <= 0)
            {
                txtSubsEx.Text = returnCost.ToString();
                txtSubsEx.Text = string.Format("{0:n}", double.Parse(txtSubsEx.Text));
                if (decimal.TryParse(txtSubsEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    subsexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtSubsEx.Text = string.Format("{0:n}", double.Parse(txtSubsEx.Text));
                if (decimal.TryParse(txtSubsEx.Text, out decimal result))
                {
                    subsexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtSubsEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtSubsEx.Text;
            //txtSubsEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOM_Leave(object sender, EventArgs e)
        {
            if (txtOM.TextLength <= 0)
            {
                txtOM.Text = returnCost.ToString();
                txtOM.Text = string.Format("{0:n}", double.Parse(txtOM.Text));
                if (decimal.TryParse(txtOM.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    ombudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOM.Text = string.Format("{0:n}", double.Parse(txtOM.Text));
                if (decimal.TryParse(txtOM.Text, out decimal result))
                {
                    ombudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOM_Enter(object sender, EventArgs e)
        {
            savedCost = txtOM.Text;
            //txtOM.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtJO_Leave(object sender, EventArgs e)
        {
            if (txtJO.TextLength <= 0)
            {
                txtJO.Text = returnCost.ToString();
                txtJO.Text = string.Format("{0:n}", double.Parse(txtJO.Text));
                if (decimal.TryParse(txtJO.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    jobudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtJO.Text = string.Format("{0:n}", double.Parse(txtJO.Text));
                if (decimal.TryParse(txtJO.Text, out decimal result))
                {
                    jobudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtJO_Enter(object sender, EventArgs e)
        {
            savedCost = txtJO.Text;
            //txtJO.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtCO_Leave(object sender, EventArgs e)
        {
            if (txtCO.TextLength <= 0)
            {
                txtCO.Text = returnCost.ToString();
                txtCO.Text = string.Format("{0:n}", double.Parse(txtCO.Text));
                if (decimal.TryParse(txtCO.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    cobudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtCO.Text = string.Format("{0:n}", double.Parse(txtCO.Text));
                if (decimal.TryParse(txtCO.Text, out decimal result))
                {
                    cobudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtCO_Enter(object sender, EventArgs e)
        {
            savedCost = txtCO.Text;
            //txtCO.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtSWR_Leave(object sender, EventArgs e)
        {
            if (txtSWR.TextLength <= 0)
            {
                txtSWR.Text = returnCost.ToString();
                txtSWR.Text = string.Format("{0:n}", double.Parse(txtSWR.Text));
                if (decimal.TryParse(txtSWR.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    swrbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtSWR.Text = string.Format("{0:n}", double.Parse(txtSWR.Text));
                if (decimal.TryParse(txtSWR.Text, out decimal result))
                {
                    swrbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtSWR_Enter(object sender, EventArgs e)
        {
            savedCost = txtSWR.Text;
            //txtSWR.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtSWC_Leave(object sender, EventArgs e)
        {
            if (txtSWC.TextLength <= 0)
            {
                txtSWC.Text = returnCost.ToString();
                txtSWC.Text = string.Format("{0:n}", double.Parse(txtSWC.Text));
                if (decimal.TryParse(txtSWC.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    swcbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtSWC.Text = string.Format("{0:n}", double.Parse(txtSWC.Text));
                if (decimal.TryParse(txtSWC.Text, out decimal result))
                {
                    swcbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtSWC_Enter(object sender, EventArgs e)
        {
            savedCost = txtSWC.Text;
            //txtSWC.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtPERA_Leave(object sender, EventArgs e)
        {
            if (txtPERA.TextLength <= 0)
            {
                txtPERA.Text = returnCost.ToString();
                txtPERA.Text = string.Format("{0:n}", double.Parse(txtPERA.Text));
                if (decimal.TryParse(txtPERA.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    perabudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtPERA.Text = string.Format("{0:n}", double.Parse(txtPERA.Text));
                if (decimal.TryParse(txtPERA.Text, out decimal result))
                {
                    perabudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtPERA_Enter(object sender, EventArgs e)
        {
            savedCost = txtPERA.Text;
            //txtPERA.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRepAllowance_Leave(object sender, EventArgs e)
        {
            if (txtRepAllowance.TextLength <= 0)
            {
                txtRepAllowance.Text = returnCost.ToString();
                txtRepAllowance.Text = string.Format("{0:n}", double.Parse(txtRepAllowance.Text));
                if (decimal.TryParse(txtRepAllowance.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    repallowancebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRepAllowance.Text = string.Format("{0:n}", double.Parse(txtRepAllowance.Text));
                if (decimal.TryParse(txtRepAllowance.Text, out decimal result))
                {
                    repallowancebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRepAllowance_Enter(object sender, EventArgs e)
        {
            savedCost = txtRepAllowance.Text;
            //txtRepAllowance.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtTranspoAllowance_Leave(object sender, EventArgs e)
        {
            if (txtTranspoAllowance.TextLength <= 0)
            {
                txtTranspoAllowance.Text = returnCost.ToString();
                txtTranspoAllowance.Text = string.Format("{0:n}", double.Parse(txtTranspoAllowance.Text));
                if (decimal.TryParse(txtTranspoAllowance.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    transpoallowancebudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTranspoAllowance.Text = string.Format("{0:n}", double.Parse(txtTranspoAllowance.Text));
                if (decimal.TryParse(txtTranspoAllowance.Text, out decimal result))
                {
                    transpoallowancebudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtTranspoAllowance_Enter(object sender, EventArgs e)
        {
            savedCost = txtTranspoAllowance.Text;
            //txtTranspoAllowance.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtQA_Leave(object sender, EventArgs e)
        {
            if (txtQA.TextLength <= 0)
            {
                txtQA.Text = returnCost.ToString();
                txtQA.Text = string.Format("{0:n}", double.Parse(txtQA.Text));
                if (decimal.TryParse(txtQA.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    qabudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtQA.Text = string.Format("{0:n}", double.Parse(txtQA.Text));
                if (decimal.TryParse(txtQA.Text, out decimal result))
                {
                    qabudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtQA_Enter(object sender, EventArgs e)
        {
            savedCost = txtQA.Text;
            //txtQA.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtClothing_Leave(object sender, EventArgs e)
        {
            if (txtClothing.TextLength <= 0)
            {
                txtClothing.Text = returnCost.ToString();
                txtClothing.Text = string.Format("{0:n}", double.Parse(txtClothing.Text));
                if (decimal.TryParse(txtClothing.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    clothingbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtClothing.Text = string.Format("{0:n}", double.Parse(txtClothing.Text));
                if (decimal.TryParse(txtClothing.Text, out decimal result))
                {
                    clothingbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtClothing_Enter(object sender, EventArgs e)
        {
            savedCost = txtClothing.Text;
            //txtClothing.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOT_Leave(object sender, EventArgs e)
        {
            if (txtOT.TextLength <= 0)
            {
                txtOT.Text = returnCost.ToString();
                txtOT.Text = string.Format("{0:n}", double.Parse(txtOT.Text));
                if (decimal.TryParse(txtOT.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    otbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOT.Text = string.Format("{0:n}", double.Parse(txtOT.Text));
                if (decimal.TryParse(txtOT.Text, out decimal result))
                {
                    otbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOT_Enter(object sender, EventArgs e)
        {
            savedCost = txtOT.Text;
            //txtOT.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtYearEnd_Leave(object sender, EventArgs e)
        {
            if (txtYearEnd.TextLength <= 0)
            {
                txtYearEnd.Text = returnCost.ToString();
                txtYearEnd.Text = string.Format("{0:n}", double.Parse(txtYearEnd.Text));
                if (decimal.TryParse(txtYearEnd.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    yearendbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtYearEnd.Text = string.Format("{0:n}", double.Parse(txtYearEnd.Text));
                if (decimal.TryParse(txtYearEnd.Text, out decimal result))
                {
                    yearendbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtYearEnd_Enter(object sender, EventArgs e)
        {
            savedCost = txtYearEnd.Text;
            //txtYearEnd.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtCashGift_Leave(object sender, EventArgs e)
        {
            if (txtCashGift.TextLength <= 0)
            {
                txtCashGift.Text = returnCost.ToString();
                txtCashGift.Text = string.Format("{0:n}", double.Parse(txtCashGift.Text));
                if (decimal.TryParse(txtCashGift.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    cashgiftbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtCashGift.Text = string.Format("{0:n}", double.Parse(txtCashGift.Text));
                if (decimal.TryParse(txtCashGift.Text, out decimal result))
                {
                    cashgiftbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtCashGift_Enter(object sender, EventArgs e)
        {
            savedCost = txtCashGift.Text;
            //txtCashGift.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOBAM_Leave(object sender, EventArgs e)
        {
            if (txtOBAM.TextLength <= 0)
            {
                txtOBAM.Text = returnCost.ToString();
                txtOBAM.Text = string.Format("{0:n}", double.Parse(txtOBAM.Text));
                if (decimal.TryParse(txtOBAM.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    obambudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOBAM.Text = string.Format("{0:n}", double.Parse(txtOBAM.Text));
                if (decimal.TryParse(txtOBAM.Text, out decimal result))
                {
                    obambudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOBAM_Enter(object sender, EventArgs e)
        {
            savedCost = txtOBAM.Text;
            //txtOBAM.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOBAA_Leave(object sender, EventArgs e)
        {
            if (txtOBAA.TextLength <= 0)
            {
                txtOBAA.Text = returnCost.ToString();
                txtOBAA.Text = string.Format("{0:n}", double.Parse(txtOBAA.Text));
                if (decimal.TryParse(txtOBAA.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    obaabudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOBAA.Text = string.Format("{0:n}", double.Parse(txtOBAA.Text));
                if (decimal.TryParse(txtOBAA.Text, out decimal result))
                {
                    obaabudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOBAA_Enter(object sender, EventArgs e)
        {
            savedCost = txtOBAA.Text;
            //txtOBAA.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtRetirement_Leave(object sender, EventArgs e)
        {
            if (txtRetirement.TextLength <= 0)
            {
                txtRetirement.Text = returnCost.ToString();
                txtRetirement.Text = string.Format("{0:n}", double.Parse(txtRetirement.Text));
                if (decimal.TryParse(txtRetirement.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    retirementbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtRetirement.Text = string.Format("{0:n}", double.Parse(txtRetirement.Text));
                if (decimal.TryParse(txtRetirement.Text, out decimal result))
                {
                    retirementbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtRetirement_Enter(object sender, EventArgs e)
        {
            savedCost = txtRetirement.Text;
            //txtRetirement.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtPagibig_Leave(object sender, EventArgs e)
        {
            if (txtPagibig.TextLength <= 0)
            {
                txtPagibig.Text = returnCost.ToString();
                txtPagibig.Text = string.Format("{0:n}", double.Parse(txtPagibig.Text));
                if (decimal.TryParse(txtPagibig.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    pagibigbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtPagibig.Text = string.Format("{0:n}", double.Parse(txtPagibig.Text));
                if (decimal.TryParse(txtPagibig.Text, out decimal result))
                {
                    pagibigbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtPagibig_Enter(object sender, EventArgs e)
        {
            savedCost = txtPagibig.Text;
            //txtPagibig.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtPhilhealth_Leave(object sender, EventArgs e)
        {
            if (txtPhilhealth.TextLength <= 0)
            {
                txtPhilhealth.Text = returnCost.ToString();
                txtPhilhealth.Text = string.Format("{0:n}", double.Parse(txtPhilhealth.Text));
                if (decimal.TryParse(txtPhilhealth.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    philhealthbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtPhilhealth.Text = string.Format("{0:n}", double.Parse(txtPhilhealth.Text));
                if (decimal.TryParse(txtPhilhealth.Text, out decimal result))
                {
                    philhealthbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtPhilhealth_Enter(object sender, EventArgs e)
        {
            savedCost = txtPhilhealth.Text;
            //txtPhilhealth.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtECIP_Leave(object sender, EventArgs e)
        {
            if (txtECIP.TextLength <= 0)
            {
                txtECIP.Text = returnCost.ToString();
                txtECIP.Text = string.Format("{0:n}", double.Parse(txtECIP.Text));
                if (decimal.TryParse(txtECIP.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    ecipbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtECIP.Text = string.Format("{0:n}", double.Parse(txtECIP.Text));
                if (decimal.TryParse(txtECIP.Text, out decimal result))
                {
                    ecipbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtECIP_Enter(object sender, EventArgs e)
        {
            savedCost = txtECIP.Text;
            //txtECIP.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtTLB_Leave(object sender, EventArgs e)
        {
            if (txtTLB.TextLength <= 0)
            {
                txtTLB.Text = returnCost.ToString();
                txtTLB.Text = string.Format("{0:n}", double.Parse(txtTLB.Text));
                if (decimal.TryParse(txtTLB.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    tlbbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTLB.Text = string.Format("{0:n}", double.Parse(txtTLB.Text));
                if (decimal.TryParse(txtTLB.Text, out decimal result))
                {
                    tlbbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtTLB_Enter(object sender, EventArgs e)
        {
            savedCost = txtTLB.Text;
            //txtTLB.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtOPBM_Leave(object sender, EventArgs e)
        {
            if (txtOPBM.TextLength <= 0)
            {
                txtOPBM.Text = returnCost.ToString();
                txtOPBM.Text = string.Format("{0:n}", double.Parse(txtOPBM.Text));
                if (decimal.TryParse(txtOPBM.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    opbmbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOPBM.Text = string.Format("{0:n}", double.Parse(txtOPBM.Text));
                if (decimal.TryParse(txtOPBM.Text, out decimal result))
                {
                    opbmbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOPBM_Enter(object sender, EventArgs e)
        {
            savedCost = txtOPBM.Text;
            //txtOPBM.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtOPBL_Leave(object sender, EventArgs e)
        {
            if (txtOPBL.TextLength <= 0)
            {
                txtOPBL.Text = returnCost.ToString();
                txtOPBL.Text = string.Format("{0:n}", double.Parse(txtOPBL.Text));
                if (decimal.TryParse(txtOPBL.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    opblbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOPBL.Text = string.Format("{0:n}", double.Parse(txtOPBL.Text));
                if (decimal.TryParse(txtOPBL.Text, out decimal result))
                {
                    opblbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOPBL_Enter(object sender, EventArgs e)
        {
            savedCost = txtOPBL.Text;
            //txtOPBL.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtOPBPEI_Leave(object sender, EventArgs e)
        {
            if (txtOPBPEI.TextLength <= 0)
            {
                txtOPBPEI.Text = returnCost.ToString();
                txtOPBPEI.Text = string.Format("{0:n}", double.Parse(txtOPBPEI.Text));
                if (decimal.TryParse(txtOPBPEI.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    opbpeibudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOPBPEI.Text = string.Format("{0:n}", double.Parse(txtOPBPEI.Text));
                if (decimal.TryParse(txtOPBPEI.Text, out decimal result))
                {
                    opbpeibudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOPBPEI_Enter(object sender, EventArgs e)
        {
            savedCost = txtOPBPEI.Text;
            //txtOPBPEI.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void cmbDepartment_Click(object sender, EventArgs e)
        {

        }

        private void txtuserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTB_Enter(object sender, EventArgs e)
        {

        }

        private void icnPreload_Click(object sender, EventArgs e)
        {
            NewModule newModule = new NewModule();
            newModule.ShowDialog();
            //SavePreload();
        }

        private void PreloadExistenceTrapping()
        {

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblEndUsers AS src WHERE src.year = YEAR(GETDATE()) AND NOT EXISTS (SELECT 1 FROM tblEndUsers WHERE Name = src.Name AND year = "+Program.preloadyear+")", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                savePreLoadUser();
                savePreLoadEmptyBudget();
                //MessageBox.Show("Preload Saved!");
                dataClear();
                SelectALLDATA();
            }
            else
            {
                MessageBox.Show("Record/s already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        void SavePreload()
        {
            Program.preloadyear = Convert.ToInt32(DateTime.Now.ToString("yyyy")) + 1;

            DialogResult dialog = MessageBox.Show("Are you sure you want to duplicate users for the year " + Program.preloadyear + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                PreloadExistenceTrapping();
            }
        }

        private void ckbYear_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbYear.Checked == true)
            //{
            //    txtyear.Enabled = true;
            //}
            //else
            //{
            //    txtyear.Enabled = false;
            //}
        }

        private void txtOPBPEI_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtSWR_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtJO_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtSubsEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtAdvertisingEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtFBP_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtCSTRE_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtLSS_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtFOL_Enter(object sender, EventArgs e)
        {
            savedCost = txtFOL.Text;
            //txtFOL.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtFOL_Leave(object sender, EventArgs e)
        {
            if (txtFOL.TextLength <= 0)
            {
                txtFOL.Text = returnCost.ToString();
                txtFOL.Text = string.Format("{0:n}", double.Parse(txtFOL.Text));
                if (decimal.TryParse(txtFOL.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    folbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtFOL.Text = string.Format("{0:n}", double.Parse(txtFOL.Text));
                if (decimal.TryParse(txtFOL.Text, out decimal result))
                {
                    folbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtOS_Enter(object sender, EventArgs e)
        {
            savedCost = txtOS.Text;
            //txtOS.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtOS_Leave(object sender, EventArgs e)
        {
            if (txtOS.TextLength <= 0)
            {
                txtOS.Text = returnCost.ToString();
                txtOS.Text = string.Format("{0:n}", double.Parse(txtOS.Text));
                if (decimal.TryParse(txtOS.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    osbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtOS.Text = string.Format("{0:n}", double.Parse(txtOS.Text));
                if (decimal.TryParse(txtOS.Text, out decimal result))
                {
                    osbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtTrainingEx_Enter(object sender, EventArgs e)
        {
            savedCost = txtTrainingEx.Text;
            //txtTrainingEx.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }

        }

        private void txtTrainingEx_Leave(object sender, EventArgs e)
        {
            if (txtTrainingEx.TextLength <= 0)
            {
                txtTrainingEx.Text = returnCost.ToString();
                txtTrainingEx.Text = string.Format("{0:n}", double.Parse(txtTrainingEx.Text));
                if (decimal.TryParse(txtTrainingEx.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    trainingexbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTrainingEx.Text = string.Format("{0:n}", double.Parse(txtTrainingEx.Text));
                if (decimal.TryParse(txtTrainingEx.Text, out decimal result))
                {
                    trainingexbudget = Convert.ToDecimal(result);
                }
            }
        }

        private void txtTrainingEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtInternetSubEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtConsultancySer_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtMDCO_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTB_Leave(object sender, EventArgs e)
        {

        }

        float returnCost = 0;
        decimal subsexbudget = 0, swrbudget = 0, swcbudget = 0, perabudget = 0, repallowancebudget = 0, transpoallowancebudget = 0, clothingbudget = 0, qabudget = 0, otbudget = 0, yearendbudget = 0, cashgiftbudget = 0, obambudget = 0, obaabudget = 0, retirementbudget = 0, pagibigbudget = 0, philhealthbudget = 0, ecipbudget = 0, tlbbudget = 0, opbmbudget = 0, opblbudget = 0, opbpeibudget = 0, cstrebudget = 0, fbpbudget = 0, advertisingexbudget = 0, jobudget = 0, lssbudget = 0, osbudget = 0, folbudget = 0, rmtebudget = 0, ombudget = 0, cobudget = 0, repexbudget = 0, travexlocbudget = 0, trainingexbudget = 0, telexbudget = 0, internetsubexbudget = 0, consultancyserbudget = 0, mdcobudget = 0, ogsbudget = 0, osmebudget = 0, pcsbudget = 0, rmbosbudget = 0, rmmebudget = 0, rmffbudget = 0, rmoppebudget = 0, ppebudget = 0, travexforbudget = 0;
        private void txtTravExLoc_Leave(object sender, EventArgs e)
        {
            if (txtTravExLoc.TextLength <= 0)
            {
                txtTravExLoc.Text = returnCost.ToString();
                txtTravExLoc.Text = string.Format("{0:n}", double.Parse(txtTravExLoc.Text));
                if (decimal.TryParse(txtTravExLoc.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    travexlocbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTravExLoc.Text = string.Format("{0:n}", double.Parse(txtTravExLoc.Text));
                if (decimal.TryParse(txtTravExLoc.Text, out decimal result))
                {
                    travexlocbudget = Convert.ToDecimal(result);
                }
            }
        }

        String savedCost = "0";
        private void txtTravExLoc_Enter(object sender, EventArgs e)
        {
            savedCost = txtTravExLoc.Text;
            //txtTravExLoc.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        //decimal travexforbudget;
        private void txtTravExFor_Leave(object sender, EventArgs e)
        {
            if (txtTravExFor.TextLength <= 0)
            {
                txtTravExFor.Text = returnCost.ToString();
                txtTravExFor.Text = string.Format("{0:n}", double.Parse(txtTravExFor.Text));
                if (decimal.TryParse(txtTravExFor.Text, out decimal result))
                {
                    //Program.convertedCost = Convert.ToInt32(result);
                    travexforbudget = Convert.ToDecimal(result);
                }

            }
            else
            {
                txtTravExFor.Text = string.Format("{0:n}", double.Parse(txtTravExFor.Text));
                if (decimal.TryParse(txtTravExFor.Text, out decimal result))
                {
                    travexforbudget = Convert.ToDecimal(result);
                }
            }

        }

        private void txtTravExFor_Enter(object sender, EventArgs e)
        {
            savedCost = txtTravExFor.Text;
            //txtTravExFor.Text = string.Empty;

            if (decimal.TryParse(savedCost, out decimal result))
            {
                returnCost = Convert.ToSingle(result);

            }
        }

        private void txtTravExFor_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTravelExLoc_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOGS_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtPPE_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMOPPE_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMFF_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMME_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtRMBOS_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtTelEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtPCS_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtOSME_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        void BudgetComputation()
        {
            if (decimal.TryParse(txtRepEx.Text, out decimal result))
            {
                repex = Convert.ToDecimal(result);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }

            if (decimal.TryParse(txtCO.Text, out decimal result1))
            {
                co = Convert.ToDecimal(result1);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }

            if (decimal.TryParse(txtOM.Text, out decimal result2))
            {
                om = Convert.ToDecimal(result2);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }

            if (decimal.TryParse(txtRMTE.Text, out decimal result3))
            {
                rmte = Convert.ToDecimal(result3);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }

            if (decimal.TryParse(txtFOL.Text, out decimal result4))
            {
                fol = Convert.ToDecimal(result4);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOS.Text, out decimal result5))
            {
                os = Convert.ToDecimal(result5);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTravExLoc.Text, out decimal result6))
            {
                travexloc = Convert.ToDecimal(result6);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTrainingEx.Text, out decimal result7))
            {
                trainingex = Convert.ToDecimal(result7);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTelEx.Text, out decimal result8))
            {
                telex = Convert.ToDecimal(result8);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtInternetSubEx.Text, out decimal result9))
            {
                internetsubex = Convert.ToDecimal(result9);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtConsultancySer.Text, out decimal result10))
            {
                consultancyser = Convert.ToDecimal(result10);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtMDCO.Text, out decimal result11))
            {
                mdco = Convert.ToDecimal(result11);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOSME.Text, out decimal result12))
            {
                osme = Convert.ToDecimal(result12);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtPCS.Text, out decimal result13))
            {
                pcs = Convert.ToDecimal(result13);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRMBOS.Text, out decimal result14))
            {
                rmbos = Convert.ToDecimal(result14);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRMME.Text, out decimal result15))
            {
                rmme = Convert.ToDecimal(result15);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRMFF.Text, out decimal result16))
            {
                rmff = Convert.ToDecimal(result16);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRMOPPE.Text, out decimal result17))
            {
                rmoppe = Convert.ToDecimal(result17);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtPPE.Text, out decimal result18))
            {
                ppe = Convert.ToDecimal(result18);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOGS.Text, out decimal result19))
            {
                ogs = Convert.ToDecimal(result19);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTravExFor.Text, out decimal result20))
            {
                travexfor = Convert.ToDecimal(result20);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtSWR.Text, out decimal result21))
            {
                swr = Convert.ToDecimal(result21);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtSWC.Text, out decimal result22))
            {
                swc = Convert.ToDecimal(result22);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtPERA.Text, out decimal result23))
            {
                pera = Convert.ToDecimal(result23);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRepAllowance.Text, out decimal result24))
            {
                repallowance = Convert.ToDecimal(result24);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTranspoAllowance.Text, out decimal result25))
            {
                transpoallowance = Convert.ToDecimal(result25);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtClothing.Text, out decimal result26))
            {
                clothing = Convert.ToDecimal(result26);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtQA.Text, out decimal result27))
            {
                qa = Convert.ToDecimal(result27);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOT.Text, out decimal result28))
            {
                ot = Convert.ToDecimal(result28);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtYearEnd.Text, out decimal result29))
            {
                yearend = Convert.ToDecimal(result29);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtCashGift.Text, out decimal result30))
            {
                cashgift = Convert.ToDecimal(result30);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOBAM.Text, out decimal result31))
            {
                obam = Convert.ToDecimal(result31);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOBAA.Text, out decimal result32))
            {
                obaa = Convert.ToDecimal(result32);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtRetirement.Text, out decimal result33))
            {
                retirement = Convert.ToDecimal(result33);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtPagibig.Text, out decimal result34))
            {
                pagibig = Convert.ToDecimal(result34);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtPhilhealth.Text, out decimal result35))
            {
                philhealth = Convert.ToDecimal(result35);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtECIP.Text, out decimal result36))
            {
                ecip = Convert.ToDecimal(result36);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtTLB.Text, out decimal result37))
            {
                tlb = Convert.ToDecimal(result37);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOPBM.Text, out decimal result38))
            {
                opbm = Convert.ToDecimal(result38);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOPBL.Text, out decimal result39))
            {
                opbl = Convert.ToDecimal(result39);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtOPBPEI.Text, out decimal result40))
            {
                opbpei = Convert.ToDecimal(result40);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtCSTRE.Text, out decimal result41))
            {
                cstre = Convert.ToDecimal(result41);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtFBP.Text, out decimal result42))
            {
                fbp = Convert.ToDecimal(result42);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtAdvertisingEx.Text, out decimal result43))
            {
                advertisingex = Convert.ToDecimal(result43);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtJO.Text, out decimal result44))
            {
                jo = Convert.ToDecimal(result44);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtLSS.Text, out decimal result45))
            {
                lss = Convert.ToDecimal(result45);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
            if (decimal.TryParse(txtSubsEx.Text, out decimal result46))
            {
                subsex = Convert.ToDecimal(result46);
                totalBudget = subsex + swr + swc + pera + repallowance + transpoallowance + clothing + qa + ot + yearend + cashgift + obam + obaa + retirement + pagibig + philhealth + ecip + tlb + opbm + opbl + opbpei + cstre + fbp + advertisingex + jo + lss + os + fol + rmte + om + co + repex + travexloc + trainingex + telex + internetsubex + consultancyser + mdco + ogs + osme + pcs + rmbos + rmme + rmff + rmoppe + ppe + travexfor;
                txtTB.Text = totalBudget.ToString();
            }
        }

        private void txtRepEx_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
            //if (decimal.TryParse(txtRepEx.Text, out decimal result))
            //{
            //    repex = Convert.ToInt32(result);
            //    totalBudget = os + fol + rmte + om + co + repex;
            //    txtTB.Text = totalBudget.ToString();
            //}
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtRMFF_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCO_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
            //if (decimal.TryParse(txtCO.Text, out decimal result))
            //{
            //    co = Convert.ToInt32(result);
            //    totalBudget = os + fol + rmte + om + co + repex;
            //    txtTB.Text = totalBudget.ToString();
            //}
        }

        private void txtOM_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
            //if (decimal.TryParse(txtOM.Text, out decimal result))
            //{
            //    om = Convert.ToInt32(result);
            //    totalBudget = os + fol + rmte + om + co + repex;
            //    txtTB.Text = totalBudget.ToString();
            //}
        }

        private void txtRMTE_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        private void txtFOL_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }

        int additionalBudget = 0;
        private void txtOS_KeyUp(object sender, KeyEventArgs e)
        {
            BudgetComputation();
        }
    }
}
