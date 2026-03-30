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
            Application.Run(new Login());

              
        }

        //for logs
        //Account Users Form
        public static string auUserName;
        public static string auUserYear;
        public static string auUserAccountName;


        //for edit form load
        public static string ePRID;

        //For Borrower's Sheet
        public static string borrowerLabel;
        public static string borrowerStatus;
        public static string borrowerFrom;
        public static string borrowerTo;
        public static string borrowerAccountName;
        //public static string borrowerOldBalance;
        public static string borrowedAmount;
        public static string borrowerRemarks;

        public static string bYear;
        public static string lenderUserID = "0";
        public static string lenderAccountID = "0";
        public static string lenderUserAccountID = "0";
        public static decimal lenderAllocatedAmount = 0;
        public static decimal lenderRemainingAmount = 0;
        public static string borrowerUserID = "0";
        public static string borrowerAccountID = "0";
        public static string borrowerUserAccountID = "0";
        public static decimal borrowerAllocatedAmount = 0;
        public static decimal borrowerRemainingAmount = 0;

        public static string bsSavedCost = "0";
        public static float bsReturnCost = 0;
        public static decimal bsConvertedCost = 0;
        public static decimal bsAvailableAmount = 0;
        
        //public static string lenderAccountID = "0";
        //public static string lenderUserAccountID = "0";
        

        //For Report
        public static string rAccountUserID = "0";
        public static string rUserAccountID = "0";
        public static string rAccountID = "0";

        //For Dashboard Form
        public static decimal dConvertedCost;
        public static decimal dUserRemainingAmount;
        public static decimal dUserUsedAmount;
        public static string dUserAccountsID;


        //For Voucher Form
        public static decimal vConvertedCost;
        public static decimal vUserRemainingAmount;
        public static decimal vUserUsedAmount;
        public static string vUserAccountsID;
        public static string vVoucherStatus;

        //for AccountUser Form
        public static string AccountUserID;
        public static string UserAccountsID = "0";

        //for UserAccount Form
        public static string AccountID;
        public static string accountYear;

        //for Accounts Form
        public static string AccountsID;

        //for newPR Form
        public static string nAccountUserID = "0";
        public static string nAccountID ="0";
        public static string nUserAccountID = "0";
        public static decimal nUsedAmount ;
        public static decimal nRemainingAmount;
        public static decimal nAllocatedAmount;

        //for editPR Form
        public static string eAccountUserID = "0";
        public static string eAccountID = "0";
        public static string eUserAccountID = "0";
        public static decimal eUsedAmount;
        public static decimal eRemainingAmount;
        public static decimal eAllocatedAmount;

        //for newVoucher Form
        public static string nvAccountUserID = "0";
        public static string nvAccountID = "0";
        public static string nvUserAccountID = "0";
        public static decimal nvUsedAmount;
        public static decimal nvRemainingAmount;
        public static decimal nvAllocatedAmount;

        //for editVoucher Form
        public static string evAccountUserID = "0";
        public static string evAccountID = "0";
        public static string evUserAccountID = "0";
        public static decimal evUsedAmount;
        public static decimal evRemainingAmount;
        public static decimal evAllocatedAmount;

        //preload
        public static int preloadyear;

        //login
        public static string userType;
        public static string userName;
        public static string userStation;

        //for Login Accounts
        public static int laAccountID;


        public static String ConnString = "Data Source=DESKTOP-7UEUA2R;Initial Catalog=FMIS2025;User ID=admin;Password=P@SSWORD;";

        //public static String ConnString = "Data Source=DESKTOP-RHVI7S1;Initial Catalog=FMIS2025;User ID=admin;Password=P@SSWORD;";

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
        public static string username;
        public static string useryear;
        public static int totalUsedOMSP;
        public static int totalUsedCOSP;
        public static int totalAllocatedOMSP;
        public static int totalAllocatedCOSP;

        //for checking balance of PR
        public static decimal remainingOS;
        public static decimal remainingFOL;
        public static decimal remainingRMTE;
        public static decimal remainingOM;
        public static decimal remainingCO;
        public static decimal remainingTB;
        public static decimal remainingRepEx;
        public static decimal remainingOSME;
        public static decimal remainingPCS;        
        public static decimal remainingRMBOS;
        public static decimal remainingRMME;
        public static decimal remainingRMFF;
        public static decimal remainingRMOPPE;
        public static decimal remainingPPE;

        //for checkingbalance of Voucher
        public static decimal remainingTravExLoc;
        public static decimal remainingTravExFor;
        public static decimal remainingTrainingEx;
        public static decimal remainingTelEx;
        public static decimal remainingInternetSubEx;
        public static decimal remainingLSS;
        public static decimal remainingConsultancySer;
        public static decimal remainingOGS;
        public static decimal remainingFBP;
        public static decimal remainingAdvertisingEx;
        public static decimal remainingMDCO;
        public static decimal remainingSubsEx;
        public static decimal remainingJO;
        public static decimal remainingSWR;
        public static decimal remainingSWC;
        public static decimal remainingPERA;
        public static decimal remainingRepAllowance;
        public static decimal remainingTranspoAllowance;
        public static decimal remainingClothing;
        public static decimal remainingOT;
        public static decimal remainingYearEnd;
        public static decimal remainingCashGift;
        public static decimal remainingOBAM;
        public static decimal remainingOBAA;
        public static decimal remainingRetirement;
        public static decimal remainingPagibig;
        public static decimal remainingPhilhealth;
        public static decimal remainingECIP;
        public static decimal remainingTLB;
        public static decimal remainingOPBM;
        public static decimal remainingOPBL;
        public static decimal remainingOPBPEI;
        public static decimal remainingvFOL;
        public static decimal remainingCSTRE;
        public static decimal remainingQA;


        public static decimal convertedCost;
        public static float convertedFloatCost;

        public static int PRType;

        public static int i;

        public static decimal actualc;
        public static decimal totalc;

        public static string pocontrol;
        public static string vouchercontrol;
        public static int controltype = 0;
        public static string controltypevalue;

        //for voucher
        public static string vouchercontrolnumber;
        public static int voucherid;
    }
}
