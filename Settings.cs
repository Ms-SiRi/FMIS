using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMIS
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void icnUsers_Click(object sender, EventArgs e)
        {
            AccountUsers accountUsers = new AccountUsers();
            accountUsers.Show();
        }

        private void icnAccounts_Click(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            accounts.Show();
        }

        private void icnLoginAccounts_Click(object sender, EventArgs e)
        {
            LoginAccounts loginAccounts = new LoginAccounts();
            loginAccounts.Show();
        }

        private void icnUserLogs_Click(object sender, EventArgs e)
        {
            UsersLogs usersLogs = new UsersLogs();
            usersLogs.Show();
        }
    }
}
