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
using System.Xml.Linq;

namespace FMIS
{
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        String sPR = "No";
        String sVoucher = "No";

        private void Accounts_Load(object sender, EventArgs e)
        {
            txtAccountYear.Text = DateTime.Now.ToString("yyyy");
            selectAccounts();
        }

        void selectAccounts()
        {
            lvAccounts.Items.Clear();
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT * FROM tblAccounts ORDER BY accountYear DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["accountID"].ToString());

                lv.SubItems.Add(dr["accountName"].ToString());
                lv.SubItems.Add(dr["accountYear"].ToString());
                lv.SubItems.Add(dr["PR"].ToString());
                lv.SubItems.Add(dr["Voucher"].ToString());
                lvAccounts.Items.Add(lv);

            }
            lvAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvAccounts.Columns[0].Width = 0;
           
        }

        private void icnAdd_Click(object sender, EventArgs e)
        {
            if (txtAccountName.Text == "" || txtAccountYear.Text == "")
            {
                MessageBox.Show("Please fill out the empty fields!");
            }
            else
            {
                PR();
                Voucher();
                saveAccount();
            }
        }

        void saveAccount()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "Insert INTO tblAccounts(accountName,accountYear,PR,Voucher) VALUES (@accountName,@accountYear,@PR, @Voucher)";

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@accountName", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@accountYear", txtAccountYear.Text);
                cmd.Parameters.AddWithValue("@PR", sPR);
                cmd.Parameters.AddWithValue("@Voucher",sVoucher);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved!");
            selectAccounts();
            dataClear();
        }

        void dataClear()
        {
            txtAccountName.Clear();
            txtAccountYear.Text = DateTime.Now.ToString("yyyy");
            sPR = "No";
            sVoucher = "No";
            icnAdd.Enabled = true;
            icnEdit.Enabled = false;
        }

        private void icnRefresh_Click(object sender, EventArgs e)
        {
            selectAccounts();
            dataClear();
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAccounts.SelectedItems[0];
                Program.AccountsID = selectedItem.SubItems[0].Text;
                txtAccountName.Text = selectedItem.SubItems[1].Text;
                txtAccountYear.Text = selectedItem.SubItems[2].Text;

                if(selectedItem.SubItems[3].Text == "Yes")
                {
                    chkPR.Checked = true;
                }
                else
                {
                    chkPR.Checked = false;
                }

                if (selectedItem.SubItems[4].Text == "Yes")
                {
                    chkVoucher.Checked = true;
                }
                else
                {
                    chkVoucher.Checked = false;
                }

                icnEdit.Enabled = true;
                icnAdd.Enabled = false;

            }
        }

        private void icnEdit_Click(object sender, EventArgs e)
        {
            PR();
            Voucher();

            SqlConnection con = new SqlConnection(Program.ConnString);
            SqlCommand cmd;
            String query = "UPDATE tblAccounts SET accountName = @accountName, accountYear = @accountYear, PR = @PR, Voucher = @Voucher WHERE accountID =" + Program.AccountsID;

            con.Open();

            using (cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@accountName", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@accountYear", txtAccountYear.Text);
                cmd.Parameters.AddWithValue("@PR", sPR);
                cmd.Parameters.AddWithValue("@Voucher", sVoucher);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Edited!");
            selectAccounts();
            dataClear();
        }

        private void icnDelete_Click(object sender, EventArgs e)
        {
            deleteAccount();
        }

        void deleteAccount()
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("DELETE FROM tblAccounts WHERE accountID = @ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Program.AccountsID);
                SqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Deleted!");
                selectAccounts();
                dataClear();
            }
        }

        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        void PR()
        {
            if (chkPR.Checked)
            {
                sPR = "Yes";
            }
            else
            {
                sPR = "No";
            }
        }

        void Voucher()
        {
            if (chkVoucher.Checked)
            {
                sVoucher = "Yes";
            }
            else
            {
                sVoucher = "No";
            }
        }
    }
}
