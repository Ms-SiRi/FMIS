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
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Threading.Tasks;

namespace FMIS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panelHome_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnNewPR_Click(object sender, EventArgs e)
        {
            newPRForm newPR = new newPRForm();
            newPR.ShowDialog();
        }

        void SelectAllDataOfCurrentYear ()
        {
            if(Program.userStation == "ALL")
            {
                SelectAllStationDataOfCurrentYear();
            }
            else
            {
                SelectAllDataOfCurrentYearByStation();
            }
        }

        void SelectAllStationDataOfCurrentYear()
        {
            try
            {
                listviewPR.Items.Clear();
                SqlConnection con = new SqlConnection(Program.ConnString);
                String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus != 6 AND (year(prDate) = YEAR(GETDATE()) OR year(prDate) = YEAR(GETDATE())-1)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    listviewPR.Items.Add(lv);

                }
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listviewPR.Columns[0].Width = 0;
                listviewPR.Columns[11].Width = 0;
                listviewPR.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void SelectAllDataOfCurrentYearByStation()
        {
            try
            {
                listviewPR.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus != 6
                    AND (YEAR(m.prDate) = YEAR(GETDATE()) OR YEAR(m.prDate) = YEAR(GETDATE())-1)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            listviewPR.Items.Add(lv);
                        }
                    }
                }

                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listviewPR.Columns[0].Width = 0;
                listviewPR.Columns[11].Width = 0;
                listviewPR.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void SelectALLDATA()
        {
            //MessageBox.Show(Program.userStation);
            if (Program.userStation == "ALL")
            {
                SelectAllStationData();
            }
            else
            {
                SelectByStationDATA();
            }

        }

        void SelectAllStationData() {
            try
            {
                listviewPR.Items.Clear();
                SqlConnection con = new SqlConnection(Program.ConnString);
                String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus != 6";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    listviewPR.Items.Add(lv);

                }
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listviewPR.Columns[0].Width = 0;
                listviewPR.Columns[11].Width = 0;
                listviewPR.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void SelectByStationDATA()
        {
            try
            {
                listviewPR.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus != 6";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            listviewPR.Items.Add(lv);
                        }
                    }
                }

                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listviewPR.Columns[0].Width = 0;
                listviewPR.Columns[11].Width = 0;
                listviewPR.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            UpdateAllUserAllocations();

            //MessageBox.Show(Program.userType);
            if (Program.userType == "superadmin")
            {
                //MessageBox.Show("X");
                label9.Visible = true;
                label7.Visible = true;
                dateFROM.Visible = true;
                dateTO.Visible = true;
                btnOK.Visible = true;
                btnSettings.Visible = true;
                btnSettings.Enabled = true;
                btnTrackBudget.Enabled = false;
                btnTrackBudget.Visible = false;

                SelectALLDATA();
                
            }
            else
            {
                //MessageBox.Show("E");
                label9.Visible = false;
                label7.Visible = false;
                dateFROM.Visible = false;
                dateTO.Visible = false;
                btnOK.Visible = false;
                btnSettings.Visible = false;
                btnSettings.Enabled = false;
                btnTrackBudget.Enabled = false;
                btnTrackBudget.Visible = false;

                SelectAllDataOfCurrentYear();
            }

            btnCancelPR.Enabled = false;
            
            checkingNumberOfRecords();

        }

        void UpdateAllUserAllocations()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();

                // 1. Get all user accounts
                string getAccountsQuery = "SELECT userAccountID, userAllocatedAmount FROM tblUserAccounts";
                using (SqlCommand getAccountsCmd = new SqlCommand(getAccountsQuery, con))
                using (SqlDataReader dr = getAccountsCmd.ExecuteReader())
                {
                    List<(int userAccountID, decimal allocated)> accounts = new List<(int, decimal)>();

                    while (dr.Read())
                    {
                        int userAccountID = Convert.ToInt32(dr["userAccountID"]);

                        decimal allocated = dr["userAllocatedAmount"] != DBNull.Value
                                            ? Convert.ToDecimal(dr["userAllocatedAmount"])
                                            : 0; // default to 0 if null

                        accounts.Add((userAccountID, allocated));
                    }

                    dr.Close();

                    // 2. For each account, recalc totals from tblBudget
                    foreach (var acc in accounts)
                    {
                        decimal used = 0;

                        string sumQuery = "SELECT SUM(amount) as usedBudget FROM tblBudget WHERE userAccountID = @userAccountID";
                        using (SqlCommand sumCmd = new SqlCommand(sumQuery, con))
                        {
                            sumCmd.Parameters.AddWithValue("@userAccountID", acc.userAccountID);

                            object result = sumCmd.ExecuteScalar();
                            if (result != DBNull.Value)
                                used = Convert.ToDecimal(result);
                        }

                        decimal remaining = acc.allocated - used;

                        // 3. Update tblUserAccounts with new values
                        string updateQuery = "UPDATE tblUserAccounts SET userUsedAmount = @used, userRemainingAmount = @remaining WHERE userAccountID = @userAccountID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@used", used);
                            updateCmd.Parameters.AddWithValue("@remaining", remaining);
                            updateCmd.Parameters.AddWithValue("@userAccountID", acc.userAccountID);

                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            //MessageBox.Show("All user allocations updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        int numberofUsers;
        void checkingNumberOfRecords()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT COUNT(userID) as numberOfUsers FROM tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE())";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                numberofUsers = Convert.ToInt32(dr["numberOfUsers"]);
            }

            if (numberofUsers > 0)
            {
                usedBudgetOfSP();
                allocatedBudgetOfSP();

                int remainingOMSP;
                remainingOMSP = Program.totalAllocatedOMSP - Program.totalUsedOMSP;
                lblSPOM.Text = string.Format("{0:n}", double.Parse(remainingOMSP.ToString()));

                int remainingCOSP;
                remainingCOSP = Program.totalAllocatedCOSP - Program.totalUsedCOSP;
                lblSPCO.Text = string.Format("{0:n}", double.Parse(remainingCOSP.ToString()));
            }
            else
            {
                int remainingOMSP;
                remainingOMSP = 0;
                lblSPOM.Text = string.Format("{0:n}", double.Parse(remainingOMSP.ToString()));

                int remainingCOSP;
                remainingCOSP = 0;
                lblSPCO.Text = string.Format("{0:n}", double.Parse(remainingCOSP.ToString()));
            }
            
        }

        void usedBudgetOfSP()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT SUM(tblBudget.os) as usedOS, SUM(tblBudget.fol) AS usedFOL, SUM(tblBudget.rmte) AS usedRMTE, SUM(tblBudget.om) AS usedOM, SUM(tblBudget.co) AS usedCO FROM tblBudget WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE())";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            { 
                Program.totalUsedOMSP = Convert.ToInt32(dr["usedOM"]);
                Program.totalUsedCOSP = Convert.ToInt32(dr["usedCO"]);
            }
        }

        void allocatedBudgetOfSP()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT SUM(tblEndUsers.tb) AS allocatedTB, SUM(tblEndUsers.os) as allocatedOS, SUM(tblEndUsers.fol) AS allocatedFOL, SUM(tblEndUsers.rmte) AS allocatedRMTE, SUM(tblEndUsers.om) AS allocatedOM, SUM(tblEndUsers.co) AS allocatedCO FROM tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE())";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Program.totalAllocatedOMSP = Convert.ToInt32(dr["allocatedOM"]);
                Program.totalAllocatedCOSP = Convert.ToInt32(dr["allocatedCO"]);
              
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        void dateFromTo()
        {
            listviewPR.Items.Clear();
            string From = dateFROM.Value.ToString("yyyy-MM-dd");
            string TO = dateTO.Value.ToString("yyyy-MM-dd");


            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable where prDate Between '" + From + "' AND '" + TO + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                lv.SubItems.Add(dr["ctrlNumber"].ToString());
                lv.SubItems.Add(dr["prType"].ToString());
                lv.SubItems.Add(dr["prDept"].ToString());
                lv.SubItems.Add(dr["prEnduser"].ToString());
                lv.SubItems.Add(dr["prSource"].ToString());
                lv.SubItems.Add(dr["prDescription"].ToString());
                lv.SubItems.Add(dr["Cost"].ToString());
                lv.SubItems.Add(dr["prParticulars"].ToString());
                lv.SubItems.Add(dr["prRemarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["prStatus"].ToString());
                lv.SubItems.Add(dr["poControlNumber"].ToString());
                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                lv.SubItems.Add(dr["propCost"].ToString());
                listviewPR.Items.Add(lv);
            }
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
            listviewPR.Columns[11].Width = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dateFromTo();
        }
        int selection;
        

        private void PRList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Program.userStation);
            if (Program.userType == "superadmin")
            {
                if (PRList.SelectedIndex == 0)
                {
                    SelectALLDATA();
                }
                else if (PRList.SelectedIndex == 1)
                {
                    selection = 1;
                    SelectPendingDATA();
                }
                else if (PRList.SelectedIndex == 2)
                {
                    selection = 2;
                    SelectPaymentDATA();
                }
                else if (PRList.SelectedIndex == 3)
                {
                    selection = 3;
                    SelectAccomplishedDATA();
                }
            }
            else
            {
                if (PRList.SelectedIndex == 0)
                {
                    SelectAllDataOfCurrentYear();
                }
                else if (PRList.SelectedIndex == 1)
                {
                    selection = 1;
                    SelectPendingDATAofCurrentYear();
                }
                else if (PRList.SelectedIndex == 2)
                {
                    selection = 2;
                    SelectPaymentDATAofCurrentYear();
                }
                else if (PRList.SelectedIndex == 3)
                {
                    selection = 3;
                    SelectAccomplishedDATAofCurrentYear();
                }
            }

            
        }
        void SelectPendingDATA()
        {
            if(Program.userStation == "ALL")
            {
                SelectPendingDATAAllStation();
            }
            else
            {
                SelectPendingDATAByStation();
            }
        }

        void SelectPendingDATAAllStation()
        {
            pendingList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    pendingList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            pendingList.Columns[0].Width = 0;
            pendingList.Columns[11].Width = 0;
            pendingList.Columns[12].Width = 0;
        }

        void SelectPendingDATAByStation()
        {
            pendingList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status"; 
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    pendingList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            pendingList.Columns[0].Width = 0;
            pendingList.Columns[11].Width = 0;
            pendingList.Columns[12].Width = 0;
        }

        void SelectPendingDATAofCurrentYear()
        {
            if(Program.userStation == "ALL")
            {
                SelectPendingAllStationDATAofCurrentYear();
            }
            else
            {
                SelectPendingByStationDATAofCurrentYear();
            }
        }

        void SelectPendingAllStationDATAofCurrentYear()
        {
            pendingList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + " AND (year(prDate) = YEAR(GETDATE()) OR year(prDate) = YEAR(GETDATE())-1)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    pendingList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            pendingList.Columns[0].Width = 0;
            pendingList.Columns[11].Width = 0;
            pendingList.Columns[12].Width = 0;
        }

        void SelectPendingByStationDATAofCurrentYear()
        {
            try
            {
                pendingList.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status
                    AND (YEAR(m.prDate) = YEAR(GETDATE()) OR YEAR(m.prDate) = YEAR(GETDATE())-1)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);
                        cmd.Parameters.AddWithValue("@status", selection);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            pendingList.Items.Add(lv);
                        }
                    }
                }

                pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                pendingList.Columns[0].Width = 0;
                pendingList.Columns[11].Width = 0;
                pendingList.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void SelectPaymentDATA()
        {
            if(Program.userStation == "ALL")
            {
                SelectPaymentDATAAllStation();
            }
            else
            {
                SelectPaymentDATAByStation();
            }
        }


        void SelectPaymentDATAAllStation()
        {
            paymentList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    paymentList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            paymentList.Columns[0].Width = 0;
            paymentList.Columns[11].Width = 0;
            paymentList.Columns[12].Width = 0;
        }


        void SelectPaymentDATAByStation()
        {
            paymentList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status"; 
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    paymentList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            paymentList.Columns[0].Width = 0;
            paymentList.Columns[11].Width = 0;
            paymentList.Columns[12].Width = 0;
        }

        void SelectPaymentDATAofCurrentYear()
        {
            if(Program.userStation == "ALL")
            {
                SelectPaymentAllStationDATAofCurrentYear();
            }
            else
            {
                SelectPaymentByStationDATAofCurrentYear();
            }
        }

        void SelectPaymentAllStationDATAofCurrentYear()
        {
            paymentList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + " AND (year(prDate) = YEAR(GETDATE()) OR year(prDate) = YEAR(GETDATE())-1)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    paymentList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            paymentList.Columns[0].Width = 0;
            paymentList.Columns[11].Width = 0;
            paymentList.Columns[12].Width = 0;
        }

        void SelectPaymentByStationDATAofCurrentYear()
        {
            try
            {
                paymentList.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status
                    AND (YEAR(m.prDate) = YEAR(GETDATE()) AND YEAR(m.prDate) = YEAR(GETDATE())-1)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);
                        cmd.Parameters.AddWithValue("@status", selection);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            paymentList.Items.Add(lv);
                        }
                    }
                }

                paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                paymentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                paymentList.Columns[0].Width = 0;
                paymentList.Columns[11].Width = 0;
                paymentList.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void SelectAccomplishedDATA()
        {
            if(Program.userStation == "ALL")
            {
                SelectAccomplishedDATAAllStation();
            }
            else
            {
                SelectAccomplishedDATAByStation();
            }
        }

        void SelectAccomplishedDATAAllStation()
        {
            accomplishedList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    accomplishedList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            accomplishedList.Columns[0].Width = 0;
            accomplishedList.Columns[11].Width = 0;
            accomplishedList.Columns[12].Width = 0;
        }

        void SelectAccomplishedDATAByStation()
        {
            try
            {
                accomplishedList.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);
                        cmd.Parameters.AddWithValue("@status", selection);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            accomplishedList.Items.Add(lv);
                        }
                    }
                }

                accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                accomplishedList.Columns[0].Width = 0;
                accomplishedList.Columns[11].Width = 0;
                accomplishedList.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void SelectAccomplishedDATAofCurrentYear()
        {
            if(Program.userStation == "ALL")
            {
                SelectAccomplishedAllStationDATAofCurrentYear();
            }
            else
            {
                SelectAccomplishedByStationDATAofCurrentYear();
            }
        }

        void SelectAccomplishedAllStationDATAofCurrentYear()
        {
            accomplishedList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE prStatus =" + selection.ToString() + " AND (year(prDate) = YEAR(GETDATE()) OR year(prDate) = YEAR(GETDATE())-1)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                    lv.SubItems.Add(dr["ctrlNumber"].ToString());
                    lv.SubItems.Add(dr["prType"].ToString());
                    lv.SubItems.Add(dr["prDept"].ToString());
                    lv.SubItems.Add(dr["prEnduser"].ToString());
                    lv.SubItems.Add(dr["prSource"].ToString());
                    lv.SubItems.Add(dr["prDescription"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    lv.SubItems.Add(dr["poControlNumber"].ToString());
                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["propCost"].ToString());
                    accomplishedList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            accomplishedList.Columns[0].Width = 0;
            accomplishedList.Columns[11].Width = 0;
            accomplishedList.Columns[12].Width = 0;
        }

        void SelectAccomplishedByStationDATAofCurrentYear()
        {
            try
            {
                accomplishedList.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    m.*, 
                    FORMAT(m.prDate, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(m.prCost, 'N') AS Cost, 
                    FORMAT(m.proposedCost, 'N') AS propCost
                FROM qrMotherTable AS m
                INNER JOIN tblAccountUser AS a 
                    ON m.prEnduser = a.userName
                WHERE 
                    a.district = @station
                    AND m.prStatus = @status
                    AND (YEAR(m.prDate) = YEAR(GETDATE()) OR YEAR(m.prDate) = YEAR(GETDATE())-1)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);
                        cmd.Parameters.AddWithValue("@status", selection);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["prID"].ToString());
                            lv.SubItems.Add(dr["ctrlNumber"].ToString());
                            lv.SubItems.Add(dr["prType"].ToString());
                            lv.SubItems.Add(dr["prDept"].ToString());
                            lv.SubItems.Add(dr["prEnduser"].ToString());
                            lv.SubItems.Add(dr["prSource"].ToString());
                            lv.SubItems.Add(dr["prDescription"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["prParticulars"].ToString());
                            lv.SubItems.Add(dr["prRemarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["prStatus"].ToString());
                            lv.SubItems.Add(dr["poControlNumber"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["propCost"].ToString());
                            accomplishedList.Items.Add(lv);
                        }
                    }
                }

                accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                accomplishedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                accomplishedList.Columns[0].Width = 0;
                accomplishedList.Columns[11].Width = 0;
                accomplishedList.Columns[12].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdatePR_Click(object sender, EventArgs e)
        {
            editPR editPR= new editPR();
            editPR.ShowDialog();
        }

        private void accomplishedList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (accomplishedList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = accomplishedList.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;
                Program.pocontrol = selectedItem.SubItems[12].Text;
                Program.vouchercontrol = selectedItem.SubItems[13].Text;
            }

            string prstatus = Program.requeststatus.ToString();
            if (prstatus == "4")
            {
                btnUpdatePR.Enabled = false;
                btnCancelPR.Enabled = false;
            }
            else
            {
                btnUpdatePR.Enabled = true;
                btnCancelPR.Enabled = true;
            }

        }

        private void pendingList_MouseClick(object sender, MouseEventArgs e)
        {
            //Program.ctrl = pendingList.SelectedItems[0].ToString();
            //MessageBox.Show(Program.ctrl);
        }

        private void pendingList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (pendingList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = pendingList.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;
                Program.pocontrol = selectedItem.SubItems[12].Text;
                Program.vouchercontrol = selectedItem.SubItems[13].Text;
            }

            string prstatus = Program.requeststatus.ToString();
            if (prstatus == "4")
            {
                btnUpdatePR.Enabled = false;
                btnCancelPR.Enabled = false;
            }
            else
            {
                btnUpdatePR.Enabled = true;
                btnCancelPR.Enabled = true;
            }

        }

        string PRCtrlTemp;

        private void listviewPR_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listviewPR.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listviewPR.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;
                Program.pocontrol = selectedItem.SubItems[12].Text;
                Program.vouchercontrol = selectedItem.SubItems[13].Text;
                //Program.dConvertedCost = Convert.ToDecimal(selectedItem.SubItems[7].ToString());

            }
            //MessageBox.Show(Program.ctrl);
            string prstatus = Program.requeststatus.ToString();
            if (prstatus == "4")
            {
                btnUpdatePR.Enabled = false;
                btnCancelPR.Enabled = false;
                btnTrackPR.Enabled = false;
            }
            else
            {
                btnUpdatePR.Enabled = true;
                btnCancelPR.Enabled = true;
                btnTrackPR.Enabled = true;
            }



        }

        

        private void paymentList_SelectedIndexChanged(object sender, EventArgs e)
        {           

            if (paymentList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = paymentList.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;
                Program.pocontrol = selectedItem.SubItems[12].Text;
                Program.vouchercontrol = selectedItem.SubItems[13].Text;
            }

            string prstatus = Program.requeststatus.ToString();
            if (prstatus == "4")
            {
                btnUpdatePR.Enabled = false;
                btnCancelPR.Enabled = false;
                
            }
            else
            {
                btnUpdatePR.Enabled = true;
                btnCancelPR.Enabled = true;
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateAllUserAllocations();
            //MessageBox.Show(Program.userType);

            if (Program.userType == "superadmin")
            {
                PRList.SelectedIndex = 0;
                SelectALLDATA();
                checkingNumberOfRecords();
            }
            else
            {
                PRList.SelectedIndex = 0;
                SelectAllDataOfCurrentYear();
                checkingNumberOfRecords();
            }
            
        }

        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            cancelRequest();
        }

        void selectBudgetDataForAllocation()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define the query with a parameter
                String query = "SELECT * FROM tblBudget WHERE controlNumber = @controlNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter with proper type handling
                    cmd.Parameters.AddWithValue("@controlNumber", Program.ctrl);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Program.dConvertedCost = Convert.ToDecimal(dr["amount"]);
                            Program.dUserAccountsID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }

        void selectUserAccountDataForAllocation()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define the query with a parameter
                String query = "SELECT * FROM tblUserAccounts WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter with proper type handling
                    cmd.Parameters.AddWithValue("@userAccountID", Program.dUserAccountsID);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Program.dUserRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                            Program.dUserUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                        }
                    }
                }
            }
        }

        private void cancelBudget()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblBudget WHERE controlNumber = @controlNumber", con);
            con.Open();
            cmd.Parameters.AddWithValue("@controlNumber", Program.ctrl);
            SqlDataReader dr = cmd.ExecuteReader();
            //MessageBox.Show("!");
        }

        void updateAllocations()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();

                // Check if the userAccountID exists before updating
                string checkQuery = "SELECT COUNT(*) FROM tblUserAccounts WHERE userAccountID = @userAccountID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@userAccountID", Program.dUserAccountsID);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        MessageBox.Show("No matching userAccountID found. Update aborted.");
                        return;
                    }
                }

                // Update the table
                string updateQuery = "UPDATE tblUserAccounts SET userRemainingAmount = @userRemainingAmount, userUsedAmount = @userUsedAmount WHERE userAccountID = @userAccountID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@userAccountID", Program.dUserAccountsID);
                    cmd.Parameters.AddWithValue("@userRemainingAmount", Program.dUserRemainingAmount + Program.dConvertedCost);
                    cmd.Parameters.AddWithValue("@userUsedAmount", Program.dUserUsedAmount - Program.dConvertedCost);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Allocation Updated!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No rows affected.");
                    }
                }
            }
        }


        private void cancelRequest()
        {
            string prstatus = Program.requeststatus.ToString();
            if (prstatus == "1")
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to cancel this request?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    
                    

                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("UPDATE qrMotherTable SET prRemarks = @prRemarks, prStatus = '4' WHERE ctrlNumber = @ctrlNumber AND prStatus = '1'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ctrlNumber", Program.ctrl);
                    //cmd.Parameters.AddWithValue("@prType", txtPRType.Text);
                    cmd.Parameters.AddWithValue("@prRemarks", Program.remarks + "(Cancelled)");
                    SqlDataReader dr = cmd.ExecuteReader();

                    string activity = "Cancelled PR: PR ID: " + Program.ctrl + " Remarks: " + Program.remarks + "(Cancelled)";

                    AddUserLog(Program.userName, activity);

                    selectBudgetDataForAllocation();
                    selectUserAccountDataForAllocation();
                    //MessageBox.Show(Program.dUserAccountsID);
                    //MessageBox.Show(Program.dConvertedCost.ToString());
                    updateAllocations();
                    cancelBudget();
                    MessageBox.Show("Cancelled!");
                }
                
            }
            else
            {
                MessageBox.Show("Request can not be cancelled!");
            }
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            //endUser endUser = new endUser();
            //endUser.ShowDialog();
        }

        private void btnTrackBudget_Click(object sender, EventArgs e)
        {
            budgetTracking budget = new budgetTracking();
            budget.ShowDialog();
        }

        private void btnTrackPR_Click(object sender, EventArgs e)
        {
            PRTracking trackPR = new PRTracking();
            trackPR.ShowDialog();
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            

            if (Program.userType == "superadmin")
            {
                
                label9.Visible = true;
                label7.Visible = true;
                dateFROM.Visible = true;
                dateTO.Visible = true;
                btnOK.Visible = true;
                btnSettings.Visible = true;
                btnSettings.Enabled = true;
                btnTrackBudget.Enabled = false;
                btnTrackBudget.Visible = false;

                SelectALLDATA();
                SelectAccomplishedDATA();
                SelectPendingDATA();
                SelectPaymentDATA();
            }
            else
            {
                
                label9.Visible = false;
                label7.Visible = false;
                dateFROM.Visible = false;
                dateTO.Visible = false;
                btnOK.Visible = false;
                btnSettings.Visible = false;
                btnSettings.Enabled = false;
                btnTrackBudget.Enabled = false;
                btnTrackBudget.Visible = false;

                SelectAllDataOfCurrentYear();
                SelectAccomplishedDATAofCurrentYear();
                SelectPendingDATAofCurrentYear();
                SelectPaymentDATAofCurrentYear();
            }

            btnCancelPR.Enabled = false;
            
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            voucherForm vForm = new voucherForm();
            vForm.ShowDialog();

        }

        private void AddUserLog(string employeeName, string activity)
        {
            if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(activity))
            {
                MessageBox.Show("Employee name and activity cannot be empty.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();

                string query = @"INSERT INTO tblLogs
                         (logDate, userEmployeeName, activity)
                         VALUES
                         (@logDate, @userEmployeeName, @activity)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@logDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@userEmployeeName", employeeName.Trim());
                    cmd.Parameters.AddWithValue("@activity", activity.Trim());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void icnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Task.Run(() => backup()).Wait();
                MessageBox.Show("Backup completed successfully!");

                string activity = "Logged out";

                AddUserLog(Program.userName, activity);

                try
                {


                    this.Hide();
                    Application.Exit();
                    Application.Restart();

                }
                catch (Exception ex)
                {

                }


            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        void backup()
        {
            DateTime d = DateTime.Now;
            string dd = d.Month + "-" + d.Day;
            string dbname = "FMIS2025";

            string constring = "Data Source=localhost;Initial Catalog=FMIS2025;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();
                string str1 = "BACKUP DATABASE FMIS2025 TO DISK = 'D:\\FMIS2025.bak' WITH FORMAT";

                SqlCommand cmd2 = new SqlCommand(str1, con);
                cmd2.CommandTimeout = 300;  // Set timeout to 5 minutes

                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during backup: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void txtSearchCtrl_KeyUp(object sender, KeyEventArgs e)
        {
            //getFilteredRequests();
        }

        public void getFilteredRequestsofCurrentYear()
        {

            listviewPR.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE (ctrlNumber LIKE '%" + txtSearchCtrl.Text + "%' OR prEnduser LIKE '%" + txtSearchCtrl.Text + "%' OR prSource LIKE '%" + txtSearchCtrl.Text + "%' OR prDescription LIKE '%" + txtSearchCtrl.Text + "%' OR prCost LIKE '%" + txtSearchCtrl.Text + "%') AND year(prDate) = YEAR(GETDATE())";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                lv.SubItems.Add(dr["ctrlNumber"].ToString());
                lv.SubItems.Add(dr["prType"].ToString());
                lv.SubItems.Add(dr["prDept"].ToString());
                lv.SubItems.Add(dr["prEnduser"].ToString());
                lv.SubItems.Add(dr["prSource"].ToString());
                lv.SubItems.Add(dr["prDescription"].ToString());
                lv.SubItems.Add(dr["Cost"].ToString());
                lv.SubItems.Add(dr["prParticulars"].ToString());
                lv.SubItems.Add(dr["prRemarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["prStatus"].ToString());
                lv.SubItems.Add(dr["poControlNumber"].ToString());
                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                lv.SubItems.Add(dr["propCost"].ToString());
                listviewPR.Items.Add(lv);
            }

            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
            listviewPR.Columns[11].Width = 0;
            timer1.Stop();
        }


        public void getFilteredRequests()
        {

            listviewPR.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE, FORMAT (prCost, 'N') as Cost, FORMAT (proposedCost, 'N') as propCost from qrMotherTable WHERE (ctrlNumber LIKE '%" + txtSearchCtrl.Text + "%' OR prEnduser LIKE '%" + txtSearchCtrl.Text + "%' OR prSource LIKE '%" + txtSearchCtrl.Text + "%' OR prDescription LIKE '%" + txtSearchCtrl.Text + "%' OR prCost LIKE '%" + txtSearchCtrl.Text + "%')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["prID"].ToString());

                lv.SubItems.Add(dr["ctrlNumber"].ToString());
                lv.SubItems.Add(dr["prType"].ToString());
                lv.SubItems.Add(dr["prDept"].ToString());
                lv.SubItems.Add(dr["prEnduser"].ToString());
                lv.SubItems.Add(dr["prSource"].ToString());
                lv.SubItems.Add(dr["prDescription"].ToString());
                lv.SubItems.Add(dr["Cost"].ToString());
                lv.SubItems.Add(dr["prParticulars"].ToString());
                lv.SubItems.Add(dr["prRemarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["prStatus"].ToString());
                lv.SubItems.Add(dr["poControlNumber"].ToString());
                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                lv.SubItems.Add(dr["propCost"].ToString());
                listviewPR.Items.Add(lv);
            }

            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
            listviewPR.Columns[11].Width = 0;
            timer1.Stop();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnSPVGO_Click(object sender, EventArgs e)
        {
            SPVGOReportForm spVGOReportForm = new SPVGOReportForm();
            spVGOReportForm.ShowDialog();
        }

        private void txtSearchCtrl_TextChanged(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Program.userType == "superadmin")
            {
                getFilteredRequests();
            }
            else
            {
                getFilteredRequestsofCurrentYear();
            }
            
        }

        private void alphaGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listviewPR_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icnBorrowersSheet_Click(object sender, EventArgs e)
        {
            BorrowerSheetMenu borrowerSheetMenu = new BorrowerSheetMenu();
            borrowerSheetMenu.ShowDialog();
        }
    }
}
