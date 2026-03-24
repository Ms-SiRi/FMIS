using FMIS.bin.Debug;
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
    public partial class BorrowerSheetMenu : Form
    {
        public BorrowerSheetMenu()
        {
            InitializeComponent();
        }

        private void icnBorrow_Click(object sender, EventArgs e)
        {
            Program.borrowerLabel = "Borrow Funds";
            Program.borrowerStatus = "BORROW";

            BorrowersSheet borrowersSheet = new BorrowersSheet();
            borrowersSheet.ShowDialog();
        }

        private void icnReturn_Click(object sender, EventArgs e)
        {
            Program.borrowerLabel = "Return Funds";
            Program.borrowerStatus = "RETURN";

            BorrowersSheet borrowersSheet = new BorrowersSheet();
            borrowersSheet.ShowDialog();
        }

        private void icnPrint_Click(object sender, EventArgs e)
        {
            BorrowersLog borrowersLog = new BorrowersLog();
            borrowersLog.ShowDialog();
        }

        private void icnTransfer_Click(object sender, EventArgs e)
        {
            Program.borrowerLabel = "Transfer Funds";
            Program.borrowerStatus = "TRANSFER";

            BorrowersSheet borrowersSheet = new BorrowersSheet();
            borrowersSheet.ShowDialog();
        }
    }
}
