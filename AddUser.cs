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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (this.Text == "Add User")
            {
                //dataClear();
                txtYear.Text = DateTime.Now.Year.ToString();
            }
            else if (this.Text == "Edit User")
            {
                SelectALLUSERSDATA();
            }
        }

        void SelectALLUSERSDATA()
        {
            
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "select * from tblAccountUser WHERE userID = " + Program.AccountUserID;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtName.Text = dr["userName"].ToString();
                cmbDept.Text = dr["userDept"].ToString();
                txtYear.Text = dr["userYear"].ToString();
                cmbDistrict.Text = dr["district"].ToString();
            }
            
        }

        private void icnSave_Click(object sender, EventArgs e)
        {
            emptyFields();
        }

        private void emptyFields()
        {
            if (txtName.Text == "" || cmbDept.Text == "" || cmbDistrict.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {                
                saveUser();
            }
        }

        void saveUser()
        {
            if (this.Text == "Add User")
            {
                addUser();
            }
            else if (this.Text == "Edit User")
            {
                editUser();
            }
        }
        private void editUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tbLAccountUser SET userName = @Name,userDept = @Dept, userYear = @Year, district = @district WHERE userID =" +Program.AccountUserID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDept.Text);                
                cmd.Parameters.AddWithValue("@year", txtYear.Text);
                cmd.Parameters.AddWithValue("@district", cmbDistrict.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Edited!");
            dataClear();
            this.Close();
        }

        private void addUser()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblAccountUser(userName,userDept, userYear, district) VALUES (@Name,@Dept,@year, @district)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Dept", cmbDept.Text);
                cmd.Parameters.AddWithValue("@year", txtYear.Text);
                cmd.Parameters.AddWithValue("@district", cmbDistrict.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved!");
            dataClear();
            this.Close();
        }

        void dataClear()
        {
            txtName.Clear();
            txtYear.Clear();
        }

    }
}
