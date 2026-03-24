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
    public partial class UsersLogs : Form
    {
        public UsersLogs()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UsersLogs_Load(object sender, EventArgs e)
        {
            LoadUserLogs();
        }

        private void LoadUserLogs()
        {
            lvUserLogs.Items.Clear();

            string query = "SELECT logID, logDate, userEmployeeName, activity FROM tblLogs ORDER BY logID DESC";

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["logID"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["logDate"]).ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(reader["userEmployeeName"].ToString());
                    item.SubItems.Add(reader["activity"].ToString());

                    lvUserLogs.Items.Add(item);
                }
            }

            lvUserLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvUserLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvUserLogs.Columns[0].Width = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchLogs();
        }

        public void searchLogs()
        {
            lvUserLogs.Items.Clear();

            string query = @"SELECT * FROM tblLogs
                     WHERE CONVERT(varchar, logDate, 23) LIKE @search
                        OR userEmployeeName LIKE @search
                        OR activity LIKE @search
                     ORDER BY logDate DESC;";

            using (SqlConnection conn = new SqlConnection(Program.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["logID"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["logDate"]).ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(reader["userEmployeeName"].ToString());
                    item.SubItems.Add(reader["activity"].ToString());

                    lvUserLogs.Items.Add(item);
                }
            }

            lvUserLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvUserLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvUserLogs.Columns[0].Width = 0;
            //timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //searchLogs();
        }
    }
}
