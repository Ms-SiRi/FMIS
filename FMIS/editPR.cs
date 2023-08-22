using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FMIS
{
    public partial class editPR : Form
    {
        public editPR()
        {
            InitializeComponent();
            selectPR();
        }

        public void selectPR()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "Select * FROM qrMotherTable WHERE ctrlNumber = '" + Program.ctrl +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {
                txtCtrl.Text = dr["ctrlNumber"].ToString();
                comboType.Text = dr["prType"].ToString();
                comboDept.Text = dr["prDept"].ToString();
                comboUser.Text = dr["prEnduser"].ToString();
                comboSource.Text = dr["prSource"].ToString();
                txtdate.Text = dr["prDate"].ToString();
                txtDesc.Text = dr["prDescription"].ToString();
                txtCost.Text = dr["prCost"].ToString();
                txtParticulars.Text = dr["prParticulars"].ToString();
                txtRemarks.Text = dr["prRemarks"].ToString();



            }

        }

        private void txtSummaryLoc_TextChanged(object sender, EventArgs e)
        {
             
        }
    }


}
