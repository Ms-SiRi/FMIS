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

        void SelectALLDATA()
        {
            listviewPR.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE from qrMotherTable";
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
                lv.SubItems.Add(dr["prCost"].ToString());
                lv.SubItems.Add(dr["prParticulars"].ToString());
                lv.SubItems.Add(dr["prRemarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["prStatus"].ToString());
                listviewPR.Items.Add(lv);

            }
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
            listviewPR.Columns[11].Width = 0;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SelectALLDATA();
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
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE from qrMotherTable where prDate Between '" + From + "' AND '" + TO + "'";
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
                lv.SubItems.Add(dr["prCost"].ToString());
                lv.SubItems.Add(dr["prParticulars"].ToString());
                lv.SubItems.Add(dr["prRemarks"].ToString());
                lv.SubItems.Add(dr["DATE"].ToString());
                lv.SubItems.Add(dr["prStatus"].ToString());
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
            if(PRList.SelectedIndex == 0)
            {
                SelectALLDATA();
            }
            else if(PRList.SelectedIndex == 1)
            {
                selection = 1;
                SelectPendingDATA();
            }
            else if(PRList.SelectedIndex == 2)
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
        void SelectPendingDATA()
        {
            pendingList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE from qrMotherTable WHERE prStatus ="+selection.ToString()+"";
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
                    lv.SubItems.Add(dr["prCost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
                    pendingList.Items.Add(lv);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            pendingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            pendingList.Columns[0].Width = 0;
            pendingList.Columns[11].Width = 0;
        }
        void SelectPaymentDATA()
        {
            paymentList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE from qrMotherTable WHERE prStatus =" + selection.ToString() + "";
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
                    lv.SubItems.Add(dr["prCost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
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
        }
        void SelectAccomplishedDATA()
        {
            accomplishedList.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select *, FORMAT (prDate, 'yyyy-MM-dd') as DATE from qrMotherTable WHERE prStatus =" + selection.ToString() + "";
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
                    lv.SubItems.Add(dr["prCost"].ToString());
                    lv.SubItems.Add(dr["prParticulars"].ToString());
                    lv.SubItems.Add(dr["prRemarks"].ToString());
                    lv.SubItems.Add(dr["DATE"].ToString());
                    lv.SubItems.Add(dr["prStatus"].ToString());
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

        private void listviewPR_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listviewPR.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listviewPR.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;

            }
            //MessageBox.Show(Program.ctrl);
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

        private void paymentList_SelectedIndexChanged(object sender, EventArgs e)
        {           

            if (paymentList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = paymentList.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;
                Program.remarks = selectedItem.SubItems[9].Text;
                Program.requeststatus = selectedItem.SubItems[11].Text;

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
            PRList.SelectedIndex = 0;
            SelectALLDATA();
        }

        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            cancelRequest();
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
            endUser endUser = new endUser();
            endUser.ShowDialog();
        }

        private void btnTrackBudget_Click(object sender, EventArgs e)
        {
            budgetTracking budget = new budgetTracking();
            budget.ShowDialog();
        }
    }
}
