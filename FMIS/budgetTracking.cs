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
            
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblEndUsers WHERE Name = '"+cmbUser.Text+ "' AND year = '"+cmbYear.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {          

                lblTB.Text = dr["tb"].ToString();
                lblOS.Text = dr["os"].ToString();
                lblFOL.Text = dr["fol"].ToString();
                lblRMTE.Text = dr["rmte"].ToString();
                lblOM.Text = dr["om"].ToString();
                lblCO.Text = dr["co"].ToString();

            }
            

        }

        void budgetData()
        {
            SelectALLDATA();
            lvBudget.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM qrMotherTable INNER JOIN tblBudget ON qrMotherTable.ctrlNumber = tblBudget.controlNumber WHERE Name = '"+cmbUser.Text+ "' AND year = '"+cmbYear.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["ctrlNumber"].ToString());

                lv.SubItems.Add(dr["Name"].ToString());
                lv.SubItems.Add(dr["Department"].ToString());
                lv.SubItems.Add(dr["prDescription"].ToString());
                lv.SubItems.Add(dr["os"].ToString());
                lv.SubItems.Add(dr["fol"].ToString());
                lv.SubItems.Add(dr["rmte"].ToString());
                lv.SubItems.Add(dr["om"].ToString());
                lv.SubItems.Add(dr["co"].ToString());
                lv.SubItems.Add(dr["year"].ToString());
                string date = DateTime.Parse(dr["date"].ToString()).ToShortDateString();
                lv.SubItems.Add(date);
                lvBudget.Items.Add(lv);

                

            }

            lvBudget.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvBudget.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvBudget.Columns[0].Width = 0;
            lvBudget.Columns[1].Width = 0;
            lvBudget.Columns[2].Width = 0;
        }



        private void endUser_Load(object sender, EventArgs e)
        {
            comboDept.SelectedIndex = 0;
            SelectALLDATA();
            budgetData();
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
                SqlCommand cmd = new SqlCommand("select * from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN'", con2);
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
                SqlCommand cmd = new SqlCommand("select * from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE'", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
                cmbYear.DataSource = table;
                cmbYear.DisplayMember = "year";
            }

        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUsers();
            
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblyear.Text = cmbYear.Text;
        }

        private void icnSearch_Click(object sender, EventArgs e)
        {
            SelectALLDATA();
            budgetData();
        }
    }
}
