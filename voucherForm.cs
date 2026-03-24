using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace FMIS
{
    public partial class voucherForm : Form
    {
        public voucherForm()
        {
            InitializeComponent();
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            AddVoucher addVoucher = new AddVoucher();
            addVoucher.ShowDialog();
        }

        private void voucherForm_Load(object sender, EventArgs e)
        {
            if(Program.userType == "superadmin")
            {
                SelectVoucherData();
                dateFROM.Enabled = true;
                dateTO.Enabled = true;
                btnOK.Enabled = true;
            }
            else
            {
                SelectVoucherDataOfCurrentYear();
                dateFROM.Enabled = false;
                dateTO.Enabled = false;
                btnOK.Enabled = false;
            }
            
        }

        void SelectVoucherData()
        {
            if(Program.userStation == "ALL")
            {
                SelectVoucherDataAllStation();
            }
            else
            {
                SelectVoucherDataByStation();
            }

        }

        void SelectVoucherDataAllStation()
        {
            try
            {
                lvListofVouchers.Items.Clear();
                SqlConnection con = new SqlConnection(Program.ConnString);
                String query = "select *, FORMAT (date, 'yyyy-MM-dd') as DATE, FORMAT (amount, 'N') as Cost from tblVoucher ORDER BY voucherControlNumber DESC";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    System.Windows.Forms.ListViewItem lv = new System.Windows.Forms.ListViewItem(dr["voucherID"].ToString());

                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["payee"].ToString());
                    lv.SubItems.Add(dr["department"].ToString());
                    lv.SubItems.Add(dr["endUser"].ToString());
                    lv.SubItems.Add(dr["source"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["remarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["status"].ToString());
                    lvListofVouchers.Items.Add(lv);

                }
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvListofVouchers.Columns[0].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SelectVoucherDataByStation()
        {
            try
            {
                lvListofVouchers.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    v.*, 
                    FORMAT(v.date, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(v.amount, 'N') AS Cost
                FROM tblVoucher AS v
                INNER JOIN tblAccountUser AS a
                    ON v.endUser = a.userName
                WHERE a.district = @station
                ORDER BY v.voucherControlNumber DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);

                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ListViewItem lv = new ListViewItem(dr["voucherID"].ToString());
                            lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                            lv.SubItems.Add(dr["payee"].ToString());
                            lv.SubItems.Add(dr["department"].ToString());
                            lv.SubItems.Add(dr["endUser"].ToString());
                            lv.SubItems.Add(dr["source"].ToString());
                            lv.SubItems.Add(dr["Cost"].ToString());
                            lv.SubItems.Add(dr["remarks"].ToString());
                            lv.SubItems.Add(dr["DATE"].ToString());
                            lv.SubItems.Add(dr["status"].ToString());

                            lvListofVouchers.Items.Add(lv);
                        }
                    }
                }

                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvListofVouchers.Columns[0].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void SelectVoucherDataOfCurrentYear()
        {
            if(Program.userStation == "ALL")
            {
                SelectVoucherDataOfCurrentYearAllStation();
            }
            else
            {
                SelectVoucherDataOfCurrentYearByStation();
            }

        }

        void SelectVoucherDataOfCurrentYearAllStation()
        {
            try
            {
                lvListofVouchers.Items.Clear();
                SqlConnection con = new SqlConnection(Program.ConnString);
                String query = "select *, FORMAT (date, 'yyyy-MM-dd') as DATE, FORMAT (amount, 'N') as Cost from tblVoucher WHERE (year(date) = YEAR(GETDATE()) OR year(date) = YEAR(GETDATE())-1) ORDER BY voucherControlNumber DESC";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    System.Windows.Forms.ListViewItem lv = new System.Windows.Forms.ListViewItem(dr["voucherID"].ToString());

                    lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                    lv.SubItems.Add(dr["payee"].ToString());
                    lv.SubItems.Add(dr["department"].ToString());
                    lv.SubItems.Add(dr["endUser"].ToString());
                    lv.SubItems.Add(dr["source"].ToString());
                    lv.SubItems.Add(dr["Cost"].ToString());
                    lv.SubItems.Add(dr["remarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["status"].ToString());
                    lvListofVouchers.Items.Add(lv);

                }
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvListofVouchers.Columns[0].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SelectVoucherDataOfCurrentYearByStation()
        {
            try
            {
                lvListofVouchers.Items.Clear();

                using (SqlConnection con = new SqlConnection(Program.ConnString))
                {
                    string query = @"
                SELECT 
                    v.*, 
                    FORMAT(v.date, 'yyyy-MM-dd') AS DATE, 
                    FORMAT(v.amount, 'N') AS Cost
                FROM tblVoucher AS v
                INNER JOIN tblAccountUser AS a
                    ON v.endUser = a.userName
                WHERE (YEAR(v.date) = YEAR(GETDATE()) OR YEAR(v.date) = YEAR(GETDATE())-1)
                  AND a.district = @station
                ORDER BY v.voucherControlNumber DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@station", Program.userStation);

                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListViewItem lv = new ListViewItem(dr["voucherID"].ToString());
                                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                                lv.SubItems.Add(dr["payee"].ToString());
                                lv.SubItems.Add(dr["department"].ToString());
                                lv.SubItems.Add(dr["endUser"].ToString());
                                lv.SubItems.Add(dr["source"].ToString());
                                lv.SubItems.Add(dr["Cost"].ToString());
                                lv.SubItems.Add(dr["remarks"].ToString());
                                lv.SubItems.Add(dr["DATE"].ToString());
                                lv.SubItems.Add(dr["status"].ToString());

                                lvListofVouchers.Items.Add(lv);
                            }
                        }
                    }
                }

                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvListofVouchers.Columns[0].Width = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lvListofVouchers_MouseClick(object sender, MouseEventArgs e)
        {
            icnEdit.Enabled = true;
            btnCancel.Enabled = true;
            btnTrack.Enabled = true;
        }

        private void lvListofVouchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListofVouchers.SelectedItems.Count > 0)
            {
                System.Windows.Forms.ListViewItem selectedItem = lvListofVouchers.SelectedItems[0];


                Program.voucherid = Convert.ToInt32(selectedItem.SubItems[0].Text);
                Program.vouchercontrolnumber = selectedItem.SubItems[1].Text;
                Program.vVoucherStatus = selectedItem.SubItems[9].Text;

                string status = selectedItem.SubItems[9].Text;

                if(selectedItem.SubItems[9].Text.Trim() == "Cancelled")
                {
                    btnCancel.Visible = false;
                    icnEdit.Visible = false;
                }
                else
                {
                    btnCancel.Visible = true;
                    icnEdit.Visible = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to cancel?", "Cancel voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                selectBudgetDataForAllocation();
                selectUserAccountDataForAllocation();
                //MessageBox.Show(Program.dUserAccountsID);
                //MessageBox.Show(Program.dConvertedCost.ToString());
                updateAllocations();
                cancelVoucher();
                cancelVoucherBudget();

                

            }            
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

        void selectBudgetDataForAllocation()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                // Define the query with a parameter
                String query = "SELECT * FROM tblBudget WHERE controlNumber = @controlNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter with proper type handling
                    cmd.Parameters.AddWithValue("@controlNumber", Program.vouchercontrolnumber);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Program.vConvertedCost = Convert.ToDecimal(dr["amount"]);
                            Program.vUserAccountsID = dr["userAccountID"].ToString();
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
                    cmd.Parameters.AddWithValue("@userAccountID", Program.vUserAccountsID);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Program.vUserRemainingAmount = Convert.ToDecimal(dr["userRemainingAmount"]);
                            Program.vUserUsedAmount = Convert.ToDecimal(dr["userUsedAmount"]);
                        }
                    }
                }
            }
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
                    checkCmd.Parameters.AddWithValue("@userAccountID", Program.vUserAccountsID);
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
                    cmd.Parameters.AddWithValue("@userAccountID", Program.vUserAccountsID);
                    cmd.Parameters.AddWithValue("@userRemainingAmount", Program.vUserRemainingAmount + Program.vConvertedCost);
                    cmd.Parameters.AddWithValue("@userUsedAmount", Program.vUserUsedAmount - Program.vConvertedCost);

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

        private void cancelVoucherBudget()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblBudget WHERE controlNumber = @controlNumber", con);
            con.Open();
            cmd.Parameters.AddWithValue("@controlNumber", Program.vouchercontrolnumber);
            SqlDataReader dr = cmd.ExecuteReader();
            //MessageBox.Show("!");
        }

        public void cancelVoucher()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String insertquery = "UPDATE tblVoucher SET status = 'Cancelled' WHERE voucherID = @ID;";
            SqlCommand cmd = new SqlCommand(insertquery, con);

            cmd.Parameters.AddWithValue("ID",Program.voucherid);

            con.Open();
            cmd.ExecuteReader();

            string activity = "Cancelled Voucher: Voucher ID: " + Program.vouchercontrolnumber;

            AddUserLog(Program.userName, activity);

            MessageBox.Show("Voucher Cancelled!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (Program.userType == "superadmin")
            {
                SelectVoucherData();
            }
            else
            {
                SelectVoucherDataOfCurrentYear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(Program.userType == "superadmin")
            {
                searchVoucher();
            }
            else
            {
                searchVoucherOfCurrentYear();
            }
        }
        public void searchVoucher()
        {

            lvListofVouchers.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblVoucher WHERE voucherControlNumber LIKE '%" + txtSearch.Text + "%' OR payee LIKE '%" + txtSearch.Text + "%' OR department LIKE '%" + txtSearch.Text + "%' OR endUser LIKE '%" + txtSearch.Text + "%' OR source LIKE '%" + txtSearch.Text + "%' OR amount LIKE '%" + txtSearch.Text + "%' OR remarks LIKE '%" + txtSearch.Text + "%' ORDER BY date desc;";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                System.Windows.Forms.ListViewItem lv = new System.Windows.Forms.ListViewItem(dr["voucherID"].ToString());

                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                lv.SubItems.Add(dr["payee"].ToString());
                lv.SubItems.Add(dr["department"].ToString());
                lv.SubItems.Add(dr["endUser"].ToString());
                lv.SubItems.Add(dr["source"].ToString());
                lv.SubItems.Add(dr["amount"].ToString());
                lv.SubItems.Add(dr["remarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["status"].ToString());
                lvListofVouchers.Items.Add(lv);
            }
            lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvListofVouchers.Columns[0].Width = 0;
        }


        public void searchVoucherOfCurrentYear()
        {

            lvListofVouchers.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblVoucher WHERE (voucherControlNumber LIKE '%" + txtSearch.Text + "%' OR payee LIKE '%" + txtSearch.Text + "%' OR department LIKE '%" + txtSearch.Text + "%' OR endUser LIKE '%" + txtSearch.Text + "%' OR source LIKE '%" + txtSearch.Text + "%' OR amount LIKE '%" + txtSearch.Text + "%' OR remarks LIKE '%" + txtSearch.Text + "%') AND year(date) = YEAR(GETDATE()) ORDER BY date desc;";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                System.Windows.Forms.ListViewItem lv = new System.Windows.Forms.ListViewItem(dr["voucherID"].ToString());

                lv.SubItems.Add(dr["voucherControlNumber"].ToString());
                lv.SubItems.Add(dr["payee"].ToString());
                lv.SubItems.Add(dr["department"].ToString());
                lv.SubItems.Add(dr["endUser"].ToString());
                lv.SubItems.Add(dr["source"].ToString());
                lv.SubItems.Add(dr["amount"].ToString());
                lv.SubItems.Add(dr["remarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["status"].ToString());
                lvListofVouchers.Items.Add(lv);
            }
            lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvListofVouchers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvListofVouchers.Columns[0].Width = 0;
        }

        private void voucherForm_Activated(object sender, EventArgs e)
        {
            if (Program.userType == "superadmin")
            {
                SelectVoucherData();
                dateFROM.Enabled = true;
                dateTO.Enabled = true;
                btnOK.Enabled = true;
            }
            else
            {
                SelectVoucherDataOfCurrentYear();
                dateFROM.Enabled = false;
                dateTO.Enabled = false;
                btnOK.Enabled = false;
            }

            icnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnTrack.Enabled = false;
        }

        private void icnEdit_Click(object sender, EventArgs e)
        {
            EditVoucher editVoucher = new EditVoucher();
            editVoucher.ShowDialog();
        }

        private void icnRefresh_Click(object sender, EventArgs e)
        {
            if (Program.userType == "superadmin")
            {
                SelectVoucherData();
            }
            else
            {
                SelectVoucherDataOfCurrentYear();
            }

            icnEdit.Enabled = false;
            btnTrack.Enabled=false;
            btnCancel.Enabled=false;
        }
    }
}
