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

        private void emptyFields()
        {
            if (txtuserName.Text == "" || cmbDepartment.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                saveUser();
            }
        }

        private void saveUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblEndUsers(Name,Department, tb, os, fol, rmte, om, co, year) VALUES(@Name, @Dept, @tb, @os, @fol, @rmte, @om, @co, @year)";

            con.Open();
            
            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@tb", txtTB.Text);
                cmd.Parameters.AddWithValue("@os", txtOS.Text);
                cmd.Parameters.AddWithValue("@fol", txtFOL.Text);
                cmd.Parameters.AddWithValue("@rmte", txtRMTE.Text);
                cmd.Parameters.AddWithValue("@om", txtOM.Text);
                cmd.Parameters.AddWithValue("@co", txtCO.Text);
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
            String query = "select * from tblEndUsers";
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
            String query = "select * from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN'";
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
            String query = "select * from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE'";
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
                lv.SubItems.Add(dr["year"].ToString());
                VGOList.Items.Add(lv);

            }
            VGOList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            VGOList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            VGOList.Columns[0].Width = 0;
        }

        private void endUser_Load(object sender, EventArgs e)
        {
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
            String query = "UPDATE tblEndUsers SET Name = @Name, Department = @Dept, tb = @tb, os = @os, fol = @fol, rmte = @rmte, om = @om, co = @co, year = @year WHERE userID = @ID";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", Program.userID);
                cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@tb", txtTB.Text);
                cmd.Parameters.AddWithValue("@os", txtOS.Text);
                cmd.Parameters.AddWithValue("@fol", txtFOL.Text);
                cmd.Parameters.AddWithValue("@rmte", txtRMTE.Text);
                cmd.Parameters.AddWithValue("@om", txtOM.Text);
                cmd.Parameters.AddWithValue("@co", txtCO.Text);
                cmd.Parameters.AddWithValue("@year", txtyear.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Updated!");
            dataClear();
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
                txtuserName.Text = selectedItem.SubItems[1].Text;
                cmbDepartment.Text = selectedItem.SubItems[2].Text;
                txtTB.Text = selectedItem.SubItems[3].Text;
                txtOS.Text = selectedItem.SubItems[4].Text;
                txtFOL.Text = selectedItem.SubItems[5].Text;
                txtRMTE.Text = selectedItem.SubItems[6].Text;
                txtOM.Text = selectedItem.SubItems[7].Text;
                txtCO.Text = selectedItem.SubItems[8].Text;
                txtyear.Text = selectedItem.SubItems[9].Text;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;

            }

        }

        private void lvAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvAllUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAllUsers.SelectedItems[0];


                Program.userID = selectedItem.SubItems[0].Text;
                Program.userID = selectedItem.SubItems[0].Text;
                txtuserName.Text = selectedItem.SubItems[1].Text;
                cmbDepartment.Text = selectedItem.SubItems[2].Text;
                txtTB.Text = selectedItem.SubItems[3].Text;
                txtOS.Text = selectedItem.SubItems[4].Text;
                txtFOL.Text = selectedItem.SubItems[5].Text;
                txtRMTE.Text = selectedItem.SubItems[6].Text;
                txtOM.Text = selectedItem.SubItems[7].Text;
                txtCO.Text = selectedItem.SubItems[8].Text;
                txtyear.Text = selectedItem.SubItems[9].Text;
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
                txtuserName.Text = selectedItem.SubItems[1].Text;
                cmbDepartment.Text = selectedItem.SubItems[2].Text;
                txtTB.Text = selectedItem.SubItems[3].Text;
                txtOS.Text = selectedItem.SubItems[4].Text;
                txtFOL.Text = selectedItem.SubItems[5].Text;
                txtRMTE.Text = selectedItem.SubItems[6].Text;
                txtOM.Text = selectedItem.SubItems[7].Text;
                txtCO.Text = selectedItem.SubItems[8].Text;
                txtyear.Text = selectedItem.SubItems[9].Text;
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

        private void dataClear()
        {
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtuserName.Clear();
            cmbDepartment.SelectedIndex = 0;
            txtTB.Clear();
            txtOS.Clear();
            txtFOL.Clear();
            txtRMTE.Clear();
            txtOM.Clear();
            txtCO.Clear();
            txtyear.Clear();

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
                txtuserName.Text = dr["Name"].ToString();
                cmbDepartment.Text = dr["Department"].ToString();
                txtyear.Text = dr["year"].ToString();
                txtTB.Text = dr["tb"].ToString();
                txtOS.Text = dr["os"].ToString();
                txtFOL.Text = dr["fol"].ToString();
                txtRMTE.Text = dr["rmte"].ToString();
                txtOM.Text = dr["om"].ToString();
                txtCO.Text = dr["co"].ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
            }

            else
            {
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                txtTB.Text = "";
                txtOS.Text = "";
                txtFOL.Text = "";
                txtRMTE.Text = "";
                txtOM.Text = "";
                txtCO.Text = "";

            }

        }

        private void txtyear_KeyUp(object sender, KeyEventArgs e)
        {
            existenceTrap();
        }
    }
}
