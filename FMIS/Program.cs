using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMIS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());

              
        }
        public static String ConnString = "Data Source=localhost;Initial Catalog=FMIS;Integrated Security=True";
        public static string ctrl;
        public static string remarks;
        public static string requeststatus;
        public static string identifier;
        public static int filetypedeterminer;
        public static string sourcetypedeterminer;
        public static string determinedfiletype;
        public static string filetextbox;
        public static string contentdeterminer = "";
        public static string fnamedeterminer = "";
        public static string filelabel = "";
        public static int filestatus;
        public static int updatedeterminer = 0;
        public static string userID;
    }
}
