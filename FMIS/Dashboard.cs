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
                listviewPR.Items.Add(lv);

            }
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
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
                listviewPR.Items.Add(lv);
            }
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
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
                    pendingList.Items.Add(lv);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
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
                    paymentList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
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
                    accomplishedList.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewPR.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listviewPR.Columns[0].Width = 0;
        }

        private void btnUpdatePR_Click(object sender, EventArgs e)
        {
            editPR editPR= new editPR();
            editPR.ShowDialog();
        }

        private void accomplishedList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pendingList_MouseClick(object sender, MouseEventArgs e)
        {
            Program.ctrl = pendingList.SelectedItems[0].ToString();
        }

        private void pendingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            


    
            
        }

        private void listviewPR_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listviewPR.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listviewPR.SelectedItems[0];


                Program.ctrl = selectedItem.SubItems[1].Text;


            }
            //MessageBox.Show(Program.ctrl);

        }
    }
}
