using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.ReportDefModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using ReportDocument = CrystalDecisions.CrystalReports.Engine.ReportDocument;
using Grpc.Core;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FMIS
{
    public partial class SPVGOReportForm : Form
    {
        public SPVGOReportForm()
        {
            InitializeComponent();
            sourceTypeDeterminer();

        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Program.userType == "superadmin")
            //{
            //    getUsers();
            //}
            //else
            //{
            //    getUsersofCurrentYear();
            //}

            //getUsers();

            string dept = "";

            if (comboDept.SelectedIndex == 0)
                dept = "SANGGUNIANG PANLALAWIGAN";
            else if (comboDept.SelectedIndex == 1)
                dept = "VICE GOVERNOR'S OFFICE";
            else
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT userYear FROM tblAccountUser WHERE userDept = @dept ORDER BY userYear DESC", con);
                cmd.Parameters.AddWithValue("@dept", dept);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table2 = new DataTable();
                da.Fill(table2);

                // ❌ Avoid firing SelectedIndexChanged event while binding
                cmbYear.SelectedIndexChanged -= cmbYear_SelectedIndexChanged;

                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "userYear";
                cmbYear.ValueMember = "userYear";
                cmbYear.SelectedIndex = -1; // no auto-selection

                // ✅ Re-subscribe after binding
                cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;

                cmbUser.DataSource = null; // clear user list
            }
        }

        private void getUsers()
        {
            //FOR FMIS 2024 VERSION


            //if (comboDept.SelectedIndex == 0)
            //{
            //    string dept = comboDept.Text;
            //    SqlConnection con = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND Name NOT LIKE 'BM %'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable table = new DataTable();
            //    da.Fill(table);
            //    cmbUser.DataSource = table;
            //    cmbUser.DisplayMember = "Name";

            //    SqlConnection con2 = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' ORDER BY year DESC", con2);
            //    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //    DataTable table2 = new DataTable();
            //    da2.Fill(table2);
            //    cmbYear.DataSource = table2;
            //    cmbYear.DisplayMember = "year";
            //}

            //if (comboDept.SelectedIndex == 1)
            //{
            //    string dept = comboDept.Text;
            //    SqlConnection con = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND Name NOT LIKE 'BM %'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable table = new DataTable();
            //    da.Fill(table);
            //    cmbUser.DataSource = table;
            //    cmbUser.DisplayMember = "Name";

            //    SqlConnection con2 = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' ORDER BY year DESC", con2);
            //    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //    DataTable table2 = new DataTable();
            //    da2.Fill(table2);
            //    cmbYear.DataSource = table2;
            //    cmbYear.DisplayMember = "year";

            //}

            //FOR FMIS 2025 VERSION----

            //if (comboDept.SelectedIndex == 0)
            //{
            //    string dept = comboDept.Text;
            //    SqlConnection con = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable table = new DataTable();
            //    da.Fill(table);
            //    cmbUser.DataSource = table;
            //    cmbUser.DisplayMember = "Name";

            //    SqlConnection con2 = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' ORDER BY year DESC", con2);
            //    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //    DataTable table2 = new DataTable();
            //    da2.Fill(table2);
            //    cmbYear.DataSource = table2;
            //    cmbYear.DisplayMember = "year";
            //}

            //if (comboDept.SelectedIndex == 1)
            //{
            //    string dept = comboDept.Text;
            //    SqlConnection con = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable table = new DataTable();
            //    da.Fill(table);
            //    cmbUser.DataSource = table;
            //    cmbUser.DisplayMember = "Name";

            //    SqlConnection con2 = new SqlConnection(Program.ConnString);
            //    SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' ORDER BY year DESC", con2);
            //    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //    DataTable table2 = new DataTable();
            //    da2.Fill(table2);
            //    cmbYear.DataSource = table2;
            //    cmbYear.DisplayMember = "year";

            //}

            // If department is SANGGUNIANG PANLALAWIGAN
            //if (comboDept.SelectedIndex == 0)
            //{
            //    // Load years for SANGGUNIANG PANLALAWIGAN
            //    using (SqlConnection con2 = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT year FROM tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' ORDER BY year DESC", con2);
            //        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //        DataTable table2 = new DataTable();
            //        da2.Fill(table2);
            //        cmbYear.DataSource = table2;
            //        cmbYear.DisplayMember = "year";
            //    }

            //    // Load users for SANGGUNIANG PANLALAWIGAN
            //    int selectedYear = int.Parse(cmbYear.Text);
            //    using (SqlConnection con = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = @dept AND userYear = @year", con);
            //        cmd.Parameters.AddWithValue("@dept", "SANGGUNIANG PANLALAWIGAN");
            //        cmd.Parameters.AddWithValue("@year", selectedYear);

            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable table = new DataTable();
            //        da.Fill(table);
            //        cmbUser.DataSource = table;
            //        cmbUser.DisplayMember = "userName";
            //    }
            //}

            //// If department is VICE GOVERNOR'S OFFICE
            //if (comboDept.SelectedIndex == 1)
            //{
            //    // Load years for VICE GOVERNOR'S OFFICE
            //    using (SqlConnection con2 = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT year FROM tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' ORDER BY year DESC", con2);
            //        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //        DataTable table2 = new DataTable();
            //        da2.Fill(table2);
            //        cmbYear.DataSource = table2;
            //        cmbYear.DisplayMember = "year";
            //    }

            //    // Load users for VICE GOVERNOR'S OFFICE
            //    int selectedYear = int.Parse(cmbYear.Text);
            //    using (SqlConnection con = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = @dept AND userYear = @year", con);
            //        cmd.Parameters.AddWithValue("@dept", "VICE GOVERNOR'S OFFICE");
            //        cmd.Parameters.AddWithValue("@year", selectedYear);

            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable table = new DataTable();
            //        da.Fill(table);
            //        cmbUser.DataSource = table;
            //        cmbUser.DisplayMember = "userName";
            //    }
            //}

        }

        private void getUsersofCurrentYear()
        {
            if (comboDept.SelectedIndex == 0)
            {
                string dept = comboDept.Text;
                SqlConnection con = new SqlConnection(Program.ConnString);
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE()) AND Name NOT LIKE 'BM %'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'SANGGUNIANG PANLALAWIGAN' AND year = YEAR(GETDATE()) ORDER BY year DESC ", con2);
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
                SqlCommand cmd = new SqlCommand("select DISTINCT(Name) from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND year = YEAR(GETDATE()) AND Name NOT LIKE 'BM %'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cmbUser.DataSource = table;
                cmbUser.DisplayMember = "Name";

                SqlConnection con2 = new SqlConnection(Program.ConnString);
                SqlCommand cmd2 = new SqlCommand("select DISTINCT year from tblEndUsers WHERE Department = 'VICE GOVERNOR''S OFFICE' AND year = YEAR(GETDATE()) ORDER BY year DESC", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                cmbYear.DataSource = table2;
                cmbYear.DisplayMember = "year";
                //cmbYear.DataSource = table;
                //cmbYear.DisplayMember = "year";
            }

        }

        private void SPVGOReportForm_Load(object sender, EventArgs e)
        {
            //if (Program.userType == "superadmin")
            //{
            //    cmbYear.Enabled = true;
            //}
            //else
            //{
            //    cmbYear.Enabled = false;
            //}

            cmbSource.SelectedIndex = 0;
            comboDept.SelectedIndex = 0;
            sourceTypeDeterminer();
        }

        private void CleanTempDirectory(string tempPath)
        {
            DateTime thresholdDate = DateTime.Now.AddDays(-7);

            var tempFiles = Directory.EnumerateFiles(tempPath)
                .Where(file => File.GetLastWriteTime(file) < thresholdDate);

            foreach (var file in tempFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it accordingly
                    Console.WriteLine($"Failed to delete file: {file}. Exception: {ex.Message}");
                }
            }

            var tempDirs = Directory.EnumerateDirectories(tempPath)
                .Where(dir => Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0);

            foreach (var dir in tempDirs)
            {
                try
                {
                    Directory.Delete(dir);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it accordingly
                    Console.WriteLine($"Failed to delete directory: {dir}. Exception: {ex.Message}");
                }
            }
        }

        private void icnPrint_Click(object sender, EventArgs e)
        {
            //for individual
            if (chkUser.Checked && chkAccount.Checked)
            {
                if (chkEnableDate.Checked)
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudgetByDate();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showBreakdownReportByDate();//
                }
                else
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudget();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showBreakdownReport();
                }
            }

            //for department
            if (chkDept.Checked)
            {
                if (chkEnableDate.Checked)
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudgetByDate();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showBreakdownReportByDepartmentAndDate();
                }
                else
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudget();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showBreakdownReportByDepartment();
                }
            }

            //for lump
            if (chkUser.Checked == false)
            {
                if (chkEnableDate.Checked)
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudgetByDate();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showDetailedLumpWithDate();
                }
                else
                {
                    sourceTypeDeterminer();
                    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
                    totalUsedBudget();
                    totalAllocatedBudget();
                    totalRemainingBudget();
                    showDetailedLump();
                }
            }

            //<----------------FOR WHOLE----------------------->

            //if (chkEnableDate.Checked)
            //{
            //    sourceTypeDeterminer();
            //    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
            //    totalUsedBudgetByDate();
            //    totalAllocatedBudget();
            //    totalRemainingBudget();
            //    showBreakdownReportByDate();
            //    showBreakdownReportByDepartmentAndDate();
            //    showDetailedLumpWithDate();
            //}
            //else {
            //    sourceTypeDeterminer();
            //    sourcetype = "tblBudget." + Program.sourcetypedeterminer;
            //    totalUsedBudget();
            //    totalAllocatedBudget();
            //    totalRemainingBudget();
            //    showBreakdownReport();
            //    showBreakdownReportByDepartment();
            //    showDetailedLump();
            //}

            //<-------------END-------------------->
            
            //// Define the custom Temp directory
            //string customTempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CustomTemp");

            //// Ensure the custom Temp directory exists
            //Directory.CreateDirectory(customTempDir);

            //// Set the TEMP and TMP environment variables to the custom directory
            //Environment.SetEnvironmentVariable("TEMP", customTempDir);
            //Environment.SetEnvironmentVariable("TMP", customTempDir);

            //// Clean the custom Temp directory (optional but recommended)
            //CleanTempDirectory(customTempDir);

            //// Get the relative path from the config file
            //string reportFileName = ConfigurationManager.AppSettings["ReportPath"];

            //// Combine the base directory and the relative path
            //string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

            //// Check if the file exists to avoid runtime errors
            //if (!File.Exists(reportPath))
            //{
            //    throw new FileNotFoundException("The report file was not found at: " + reportPath);
            //}


            //SqlConnection con = new SqlConnection(Program.ConnString);
            //con.Open();

            //try
            //{

            //    SqlCommand cmd = new SqlCommand("SELECT *, FORMAT(date, 'MM/dd/yyyy') as FormattedDate FROM tblBudget WHERE Name = '" + cmbUser.Text + "' AND year = '" + cmbYear.Text + "' AND source = '" + cmbSource.Text + "' AND controlNumber NOT LIKE '%Extra%' ORDER BY date DESC", con);

            //    SqlCommand cmd = new SqlCommand("SELECT * FROM tblBudget INNER JOIN qrMotherTable ON qrMotherTable.ctrlNumber = tblBudget.controlNumber INNER JOIN tblEndUsers ON tblBudget.Name = tblEndUsers.Name WHERE qrMotherTable.prEnduser = '" + Program.username+"' AND YEAR(prDate) = '"+Program.useryear+ "' AND prStatus !='4'", con);
            //    SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    adap.Fill(dt);

            //    if (dt.Rows.Count > 0)
            //    {
            //        string apppath = Application.StartupPath;
            //        string reportpath = "~/SPVGOReport.rpt";
            //        string fullpath = Path.Combine(apppath, reportpath);
            //        ReportDocument rdd = new ReportDocument();
            //        rdd.Load(Application.StartupPath + "\\SPVGOReport.rpt");
            //        rdd.Load(fullpath);
            //        rdd.SetDataSource(dt);
            //        crystalReportViewer1.ReportSource = rdd;

            //    }
            //    else
            //    {
            //        MessageBox.Show("No Records Found!");
            //    }
            //}  
            //catch
            //{

            //}

            //WORKING BUT NO tblVoucher
            //    SqlConnection con = new SqlConnection(Program.ConnString);
            //    con.Open();

            //    try
            //    {
            //        string query = @"
            //SELECT 
            //    tblBudget.*, 
            //    FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
            //FROM tblBudget
            //INNER JOIN qrMotherTable ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
            //WHERE 
            //    tblBudget.Name = @Name AND 
            //    tblBudget.year = @Year AND 
            //    tblBudget.source = @Source AND 
            //    tblBudget.controlNumber NOT LIKE '%Extra%' AND
            //    qrMotherTable.prStatus != '4'
            //ORDER BY tblBudget.date DESC";

            //        SqlCommand cmd = new SqlCommand(query, con);

            //        // Add parameters
            //        cmd.Parameters.AddWithValue("@Name", cmbUser.Text);
            //        cmd.Parameters.AddWithValue("@Year", cmbYear.Text);
            //        cmd.Parameters.AddWithValue("@Source", cmbSource.Text);

            //        SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        adap.Fill(dt);

            //        if (dt.Rows.Count > 0)
            //        {
            //            ReportDocument rdd = new ReportDocument();
            //            rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport.rpt"));
            //            rdd.SetDataSource(dt);
            //            crystalReportViewer1.ReportSource = rdd;
            //        }
            //        else
            //        {
            //            MessageBox.Show("No Records Found!");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: " + ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }

            
        }

        void showBreakdownReport()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
        SELECT 
            tblBudget.*, 
            FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
        FROM tblBudget
        LEFT JOIN qrMotherTable 
            ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
        LEFT JOIN tblVoucher 
            ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
        WHERE 
            tblBudget.Name = @Name AND 
            tblBudget.year = @Year AND 
            tblBudget.source = @Source AND 
            tblBudget.controlNumber NOT LIKE '%Extra%' AND
            (
                (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
            )
        ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", cmbUser.Text);
                cmd.Parameters.AddWithValue("@Year", cmbYear.Text);
                cmd.Parameters.AddWithValue("@Source", cmbSource.Text);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rdd;
                    //crystalReportViewer1.Zoom(1);
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        void showDetailedLump()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
                SELECT 
                    tblBudget.*, 
                    FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
                FROM tblBudget
                LEFT JOIN qrMotherTable 
                    ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
                LEFT JOIN tblVoucher 
                    ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
                WHERE 
                    tblBudget.department = @Department AND
                    tblBudget.year = @CurrentYear AND
                    tblBudget.controlNumber NOT LIKE '%Extra%' AND
                    (
                        (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                        (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
                    )
                ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                // Department selected
                cmd.Parameters.AddWithValue("@Department", comboDept.Text);

                // Current year filter
                int currentYear = Convert.ToInt32(cmbYear.Text);
                cmd.Parameters.AddWithValue("@CurrentYear", currentYear);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport - DetailedLump.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer3.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        void showBreakdownReportByDepartment()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
        SELECT 
            tblBudget.*, 
            FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
        FROM tblBudget
        LEFT JOIN qrMotherTable 
            ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
        LEFT JOIN tblVoucher 
            ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
        WHERE 
            tblBudget.department = @Department AND 
            tblBudget.year = @Year AND 
            tblBudget.source = @Source AND 
            tblBudget.controlNumber NOT LIKE '%Extra%' AND
            (
                (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
            )
        ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Department", comboDept.Text);
                cmd.Parameters.AddWithValue("@Year", cmbYear.Text);
                cmd.Parameters.AddWithValue("@Source", cmbSource.Text);

                // ❌ Removed DateFrom and DateTo

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport - Lump.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer2.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void showDetailedLumpWithDate()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
        SELECT 
            tblBudget.*, 
            FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
        FROM tblBudget
        LEFT JOIN qrMotherTable 
            ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
        LEFT JOIN tblVoucher 
            ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
        WHERE 
            tblBudget.department = @Department AND 
            tblBudget.controlNumber NOT LIKE '%Extra%' AND
            tblBudget.date >= @DateFrom AND
            tblBudget.date < @DateTo AND
            (
                (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
            )
        ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Department", comboDept.Text);
                cmd.Parameters.AddWithValue("@DateFrom", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@DateTo", dtTo.Value.Date.AddDays(1));

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport - DetailedLumpWithDate.rpt"));
                    rdd.SetDataSource(dt);

                    // ✅ PASS PARAMETERS TO CRYSTAL REPORT
                    rdd.SetParameterValue("FromDate", dtFrom.Value.Date);
                    rdd.SetParameterValue("ToDate", dtTo.Value.Date);

                    crystalReportViewer3.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void showBreakdownReportByDepartmentAndDate()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
        SELECT 
            tblBudget.*, 
            FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
        FROM tblBudget
        LEFT JOIN qrMotherTable 
            ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
        LEFT JOIN tblVoucher 
            ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
        WHERE 
            tblBudget.department = @Department AND 
            tblBudget.year = @Year AND 
            tblBudget.source = @Source AND 
            tblBudget.controlNumber NOT LIKE '%Extra%' AND
            tblBudget.date >= @DateFrom AND
            tblBudget.date < @DateTo AND
            (
                (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
            )
        ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                // ✅ Replace Name with Department
                cmd.Parameters.AddWithValue("@Department", comboDept.Text);

                cmd.Parameters.AddWithValue("@Year", cmbYear.Text);
                cmd.Parameters.AddWithValue("@Source", cmbSource.Text);

                cmd.Parameters.AddWithValue("@DateFrom", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@DateTo", dtTo.Value.Date.AddDays(1));

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport - Lump.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer2.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void showBreakdownReportByDate()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"
                SELECT 
                    tblBudget.*, 
                    FORMAT(tblBudget.date, 'MM/dd/yyyy') AS FormattedDate 
                FROM tblBudget
                LEFT JOIN qrMotherTable 
                    ON tblBudget.controlNumber = qrMotherTable.ctrlNumber
                LEFT JOIN tblVoucher 
                    ON tblBudget.controlNumber = tblVoucher.voucherControlNumber
                WHERE 
                    tblBudget.Name = @Name AND 
                    tblBudget.year = @Year AND 
                    tblBudget.source = @Source AND 
                    tblBudget.controlNumber NOT LIKE '%Extra%' AND
                    tblBudget.date >= @DateFrom AND
                    tblBudget.date < @DateTo AND
                    (
                        (qrMotherTable.prStatus IS NOT NULL AND qrMotherTable.prStatus != '4') OR
                        (tblVoucher.status IS NOT NULL AND tblVoucher.status != 'Cancelled')
                    )
                ORDER BY tblBudget.date DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", cmbUser.Text);
                cmd.Parameters.AddWithValue("@Year", cmbYear.Text);
                cmd.Parameters.AddWithValue("@Source", cmbSource.Text);

                // ✅ Added date parameters (same logic as before)
                cmd.Parameters.AddWithValue("@DateFrom", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@DateTo", dtTo.Value.Date.AddDays(1));

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "SPVGOReport.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void totalRemainingBudget()
        {
            double allocated, used, remaining;
            allocated = Convert.ToDouble(allocatedBudget.Text);
            used = Convert.ToDouble(usedBudget.Text);

            remaining = allocated - used;

            remainingBudget.Text = string.Format("{0:n}", double.Parse(remaining.ToString()));
        }

        public void totalAllocatedBudget()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAllocatedAmount FROM tblUserAccounts WHERE userAccountID = @userAccountID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userAccountID", Program.rUserAccountID);

                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["userAllocatedAmount"] != DBNull.Value)
                                {
                                    double amount = Convert.ToDouble(dr["userAllocatedAmount"]);
                                    allocatedBudget.Text = string.Format("{0:n}", amount);
                                }
                                else
                                {
                                    allocatedBudget.Text = "0.00";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (optional: log error, show message, etc.)
                        allocatedBudget.Text = "0.00";
                    }
                }
            }
        }
        string userAccountID;
        string sourcetype;
        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUserID();
            getAccountID();
            getUserAccountID();
            sourceTypeDeterminer();
            sourcetype = "tblBudget." + Program.sourcetypedeterminer;
            totalUsedBudget();
            totalAllocatedBudget();
            totalRemainingBudget();
        }

        void getAccountID()
        {
            if (cmbYear.SelectedValue == null || !int.TryParse(cmbYear.SelectedValue.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT accountID FROM tblAccounts WHERE accountName = @accountName AND accountYear = @accountYear";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@accountName", cmbSource.Text.Trim());
                    cmd.Parameters.AddWithValue("@accountYear", cmbYear.Text.Trim());

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.rAccountID = dr["accountID"].ToString();
                        }
                    }
                }
            }
        }

        void getUserAccountID()
        {
            if (cmbYear.SelectedValue == null || !int.TryParse(cmbYear.SelectedValue.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userAccountID FROM tblUserAccounts WHERE userID = @userID AND accountID = @accountID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userID", Program.rAccountUserID);
                    cmd.Parameters.AddWithValue("@accountID", Program.rAccountID);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.rUserAccountID = dr["userAccountID"].ToString();
                        }
                    }
                }
            }
        }


        void totalUsedBudget()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            String query = "SELECT SUM(amount) as usedBudget FROM tblBudget WHERE tblBudget.userAccountID = " + Program.rUserAccountID;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                object result = dr["usedBudget"];
                if (result != DBNull.Value)
                {
                    double budget = Convert.ToDouble(result);
                    usedBudget.Text = string.Format("{0:n}", budget);
                }
                else
                {
                    usedBudget.Text = "0"; // or another default value
                }

            }
        }

        void totalUsedBudgetByDate()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"
        SELECT SUM(amount) as usedBudget 
        FROM tblBudget 
        WHERE userAccountID = @UserAccountID 
        AND date >= @DateFrom 
        AND date < @DateTo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountID", Program.rUserAccountID);
                    cmd.Parameters.AddWithValue("@DateFrom", dtFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@DateTo", dtTo.Value.Date.AddDays(1));

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        double budget = Convert.ToDouble(result);
                        usedBudget.Text = string.Format("{0:n}", budget);
                    }
                    else
                    {
                        usedBudget.Text = "0";
                    }
                }
            }
        }

        //void totalUsedBudget()
        //{
        //    SqlConnection con = new SqlConnection(Program.ConnString);
        //    String query = "SELECT SUM("+sourcetype+") as usedBudget FROM tblBudget WHERE tblBudget.Name = '" + cmbUser.Text + "' AND tblBudget.year = '" + cmbYear.Text + "'";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        object result = dr["usedBudget"];
        //        if (result != DBNull.Value)
        //        {
        //            double budget = Convert.ToDouble(result);
        //            usedBudget.Text = string.Format("{0:n}", budget);
        //        }
        //        else
        //        {
        //            usedBudget.Text = "0"; // or another default value
        //        }

        //    }
        //}

        public void sourceTypeDeterminer()
        {
            {
                if (cmbSource.SelectedIndex == 0)
                {
                    Program.sourcetypedeterminer = "os";
                }
                if (cmbSource.SelectedIndex == 1)
                {
                    Program.sourcetypedeterminer = "fol";
                }
                if (cmbSource.SelectedIndex == 2)
                {
                    Program.sourcetypedeterminer = "rmte";
                }
                if (cmbSource.SelectedIndex == 3)
                {
                    Program.sourcetypedeterminer = "om";
                }
                if (cmbSource.SelectedIndex == 4)
                {
                    Program.sourcetypedeterminer = "co";
                }
                if (cmbSource.SelectedIndex == 5)
                {
                    Program.sourcetypedeterminer = "repex";
                }
                if (cmbSource.SelectedIndex == 6)
                {
                    Program.sourcetypedeterminer = "osme";
                }
                if (cmbSource.SelectedIndex == 7)
                {
                    Program.sourcetypedeterminer = "pcs";
                }
                if (cmbSource.SelectedIndex == 8)
                {
                    Program.sourcetypedeterminer = "rmbos";
                }
                if (cmbSource.SelectedIndex == 9)
                {
                    Program.sourcetypedeterminer = "rmme";
                }
                if (cmbSource.SelectedIndex == 10)
                {
                    Program.sourcetypedeterminer = "rmff";
                }
                if (cmbSource.SelectedIndex == 11)
                {
                    Program.sourcetypedeterminer = "rmoppe";
                }
                if (cmbSource.SelectedIndex == 12)
                {
                    Program.sourcetypedeterminer = "ppe";
                }
                if (cmbSource.SelectedIndex == 13)
                {
                    Program.sourcetypedeterminer = "advertisingex";
                }
                if (cmbSource.SelectedIndex == 14)
                {
                    Program.sourcetypedeterminer = "travexloc";
                }
                if (cmbSource.SelectedIndex == 15)
                {
                    Program.sourcetypedeterminer = "trainingex";
                }
                if (cmbSource.SelectedIndex == 16)
                {
                    Program.sourcetypedeterminer = "telex";
                }
                if (cmbSource.SelectedIndex == 17)
                {
                    Program.sourcetypedeterminer = "internetsubex";
                }
                if (cmbSource.SelectedIndex == 18)
                {
                    Program.sourcetypedeterminer = "consultancyser";
                }
                if (cmbSource.SelectedIndex == 19)
                {
                    Program.sourcetypedeterminer = "mdco";
                }
                if (cmbSource.SelectedIndex == 20)
                {
                    Program.sourcetypedeterminer = "ogs";
                }
                if (cmbSource.SelectedIndex == 21)
                {
                    Program.sourcetypedeterminer = "travexfor";
                }
                if (cmbSource.SelectedIndex == 22)
                {
                    Program.sourcetypedeterminer = "lss";
                }
                if (cmbSource.SelectedIndex == 23)
                {
                    Program.sourcetypedeterminer = "fbp";
                }
                if (cmbSource.SelectedIndex == 24)
                {
                    Program.sourcetypedeterminer = "subsex";
                }
                if (cmbSource.SelectedIndex == 25)
                {
                    Program.sourcetypedeterminer = "jo";
                }
                if (cmbSource.SelectedIndex == 26)
                {
                    Program.sourcetypedeterminer = "swr";
                }
                if (cmbSource.SelectedIndex == 27)
                {
                    Program.sourcetypedeterminer = "swc";
                }
                if (cmbSource.SelectedIndex == 28)
                {
                    Program.sourcetypedeterminer = "pera";
                }
                if (cmbSource.SelectedIndex == 29)
                {
                    Program.sourcetypedeterminer = "repallowance";
                }
                if (cmbSource.SelectedIndex == 30)
                {
                    Program.sourcetypedeterminer = "transpoallowance";
                }
                if (cmbSource.SelectedIndex == 31)
                {
                    Program.sourcetypedeterminer = "clothing";
                }
                if (cmbSource.SelectedIndex == 32)
                {
                    Program.sourcetypedeterminer = "ot";
                }
                if (cmbSource.SelectedIndex == 33)
                {
                    Program.sourcetypedeterminer = "yearend";
                }
                if (cmbSource.SelectedIndex == 34)
                {
                    Program.sourcetypedeterminer = "cashgift";
                }
                if (cmbSource.SelectedIndex == 35)
                {
                    Program.sourcetypedeterminer = "obam";
                }
                if (cmbSource.SelectedIndex == 36)
                {
                    Program.sourcetypedeterminer = "obaa";
                }
                if (cmbSource.SelectedIndex == 37)
                {
                    Program.sourcetypedeterminer = "retirement";
                }
                if (cmbSource.SelectedIndex == 38)
                {
                    Program.sourcetypedeterminer = "pagibig";
                }
                if (cmbSource.SelectedIndex == 39)
                {
                    Program.sourcetypedeterminer = "philhealth";
                }
                if (cmbSource.SelectedIndex == 40)
                {
                    Program.sourcetypedeterminer = "ecip";
                }
                if (cmbSource.SelectedIndex == 41)
                {
                    Program.sourcetypedeterminer = "tlb";
                }
                if (cmbSource.SelectedIndex == 42)
                {
                    Program.sourcetypedeterminer = "opbm";
                }
                if (cmbSource.SelectedIndex == 43)
                {
                    Program.sourcetypedeterminer = "opbl";
                }
                if (cmbSource.SelectedIndex == 44)
                {
                    Program.sourcetypedeterminer = "opbpei";
                }
                if (cmbSource.SelectedIndex == 45)
                {
                    Program.sourcetypedeterminer = "cstre";
                }
                if (cmbSource.SelectedIndex == 46)
                {
                    Program.sourcetypedeterminer = "qa";
                }
            }
        }

        private void SPVGOReportForm_Activated(object sender, EventArgs e)
        {
            sourceTypeDeterminer();
            sourcetype = "tblBudget." + Program.sourcetypedeterminer;
            totalUsedBudget();
            totalAllocatedBudget();
            totalRemainingBudget();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceTypeDeterminer();
            sourcetype = "tblBudget." + Program.sourcetypedeterminer;
            totalUsedBudget();
            totalAllocatedBudget();
            totalRemainingBudget();

            getUserID();
            getAccounts();
            getAccountID();
            getUserAccountID();
        }

        private void getAccounts()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = @"SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, 
                                u.userDept, a.accountName, a.PR, a.Voucher, 
                                ua.userAllocatedAmount, ua.userRemainingAmount, 
                                ua.userUsedAmount, u.userYear 
                         FROM tblUserAccounts ua 
                         INNER JOIN tblAccounts a ON ua.accountID = a.accountID 
                         INNER JOIN tblAccountUser u ON ua.userID = u.userID 
                         WHERE ua.userID = @UserID 
                         ORDER BY accountName ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Program.rAccountUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    cmbSource.DataSource = table;
                    cmbSource.DisplayMember = "accountName";
                }
            }
        }

        void getUserID()
        {
            if (cmbYear.SelectedValue == null || !int.TryParse(cmbYear.SelectedValue.ToString(), out int selectedYear))
                return;

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                string query = "SELECT userID FROM tblAccountUser WHERE userYear = @year AND userName = @userName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", cmbUser.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", selectedYear);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Program.rAccountUserID = dr["userID"].ToString();
                        }
                    }
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Make sure year is selected
            //if (cmbYear.SelectedValue == null || comboDept.SelectedIndex < 0)
            //    return;

            //if (!int.TryParse(cmbYear.SelectedValue.ToString(), out int selectedYear))
            //    return; // silently ignore if invalid


            //// For SANGGUNIANG PANLALAWIGAN
            //if (comboDept.SelectedIndex == 0)
            //{
            //    using (SqlConnection con = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = @dept AND userYear = @year", con);
            //        cmd.Parameters.AddWithValue("@dept", "SANGGUNIANG PANLALAWIGAN");
            //        cmd.Parameters.AddWithValue("@year", selectedYear);

            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable table = new DataTable();
            //        da.Fill(table);
            //        cmbUser.DataSource = table;
            //        cmbUser.DisplayMember = "userName";
            //    }
            //}

            //// For VICE GOVERNOR'S OFFICE
            //if (comboDept.SelectedIndex == 1)
            //{
            //    using (SqlConnection con = new SqlConnection(Program.ConnString))
            //    {
            //        SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = @dept AND userYear = @year", con);
            //        cmd.Parameters.AddWithValue("@dept", "VICE GOVERNOR'S OFFICE");
            //        cmd.Parameters.AddWithValue("@year", selectedYear);

            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable table = new DataTable();
            //        da.Fill(table);
            //        cmbUser.DataSource = table;
            //        cmbUser.DisplayMember = "userName";
            //    }
            //}


            getUsersByStation();

        }

        private void getUsersByStation()
        {
            // Make sure year is selected
            if (cmbYear.SelectedValue == null || comboDept.SelectedIndex < 0)
                return;

            if (!int.TryParse(cmbYear.SelectedValue.ToString(), out int selectedYear))
                return; // silently ignore if invalid

            if (Program.userStation == "ALL")
            {
                if (comboDept.SelectedIndex == 0)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+selectedYear+"' AND (status IS NULL OR status <> 'INACTIVE');", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    cmbUser.DataSource = table;
                    cmbUser.DisplayMember = "userName";
                }

                if (comboDept.SelectedIndex == 1)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '"+selectedYear+"' AND (status IS NULL OR status <> 'INACTIVE');", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    cmbUser.DataSource = table;
                    cmbUser.DisplayMember = "userName";
                }
            }

            else
            {
                if (comboDept.SelectedIndex == 0)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblAccountUser WHERE userDept = 'SANGGUNIANG PANLALAWIGAN' AND userYear = '"+selectedYear+"' AND (status IS NULL OR status <> 'INACTIVE') AND district = '" + Program.userStation + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    cmbUser.DataSource = table;
                    cmbUser.DisplayMember = "userName";
                }

                if (comboDept.SelectedIndex == 1)
                {
                    string dept = comboDept.Text;
                    SqlConnection con = new SqlConnection(Program.ConnString);
                    SqlCommand cmd = new SqlCommand("select * from tblAccountUser WHERE userDept = 'VICE GOVERNOR''S OFFICE' AND userYear = '"+selectedYear+"' AND (status IS NULL OR status <> 'INACTIVE') AND district = '" + Program.userStation + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    cmbUser.DataSource = table;
                    cmbUser.DisplayMember = "userName";
                }
            }


        }

        private void icnPrintAllocations_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Zoom(1);
            if (chkEnableDate.Checked)
            {
                printAllocationByDate();
                printAllocationByDate_ByDepartmentWithDate();
            }
            else
            {
                printAllocation();
                printAllocationByDepartment();
            }
        }
        void printAllocationByDate_ByDepartmentWithDate()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;
            string department = comboDept.Text;
            int year = fromDate.Year; // dynamic year based on selected date

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();

                try
                {
                    string query = @"
                    SELECT 
                        u.userDept,
                        a.accountName,
                        SUM(ua.userAllocatedAmount) AS userAllocatedAmount,

                        -- Previous transactions (same year only)
                        ISNULL(SUM(CASE 
                            WHEN b.date < @fromDate 
                                 AND YEAR(b.date) = @year
                            THEN b.amount ELSE 0 END), 0) AS PreviousUsedAmount,

                        -- Transactions within range (same year only)
                        ISNULL(SUM(CASE 
                            WHEN b.date >= @fromDate 
                                 AND b.date <= @toDate
                                 AND YEAR(b.date) = @year
                            THEN b.amount ELSE 0 END), 0) AS UsedAmountInRange,

                        -- Remaining
                        (SUM(ua.userAllocatedAmount)
                            - ISNULL(SUM(CASE 
                                WHEN b.date < @fromDate 
                                     AND YEAR(b.date) = @year
                                THEN b.amount ELSE 0 END), 0)
                            - ISNULL(SUM(CASE 
                                WHEN b.date >= @fromDate 
                                     AND b.date <= @toDate
                                     AND YEAR(b.date) = @year
                                THEN b.amount ELSE 0 END), 0)
                        ) AS RemainingAmountInRange

                    FROM tblUserAccounts ua
                    INNER JOIN tblAccounts a ON ua.accountID = a.accountID
                    INNER JOIN tblAccountUser u ON ua.userID = u.userID
                    LEFT JOIN tblBudget b 
                        ON ua.userAccountID = b.userAccountID

                    WHERE u.userDept = @department
                    AND a.accountYear = @year
                    AND u.userYear = @year

                    GROUP BY u.userDept, a.accountName
                    ORDER BY a.accountName ASC
                    ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    cmd.Parameters.AddWithValue("@year", year);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument rdd = new ReportDocument();
                        rdd.Load(Path.Combine(Application.StartupPath, "BudgetAllocation - LumpWithDate.rpt"));
                        rdd.SetDataSource(dt);

                        // Format dates
                        string fromDateText = fromDate.ToString("MMMM dd, yyyy");
                        string toDateText = toDate.ToString("MMMM dd, yyyy");

                        rdd.SetParameterValue("FromDate", fromDateText);
                        rdd.SetParameterValue("ToDate", toDateText);
                        //rdd.SetParameterValue("Department", department);
                        //rdd.SetParameterValue("Year", year); // optional

                        crystalReportViewer2.ReportSource = rdd;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        

        void printAllocationByDate()
        {
            DateTime fromDate = dtFrom.Value.Date; // From date picker
            DateTime toDate = dtTo.Value.Date;     // To date picker

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();

                try
                {
                    string query = @"
            SELECT 
                ua.userAccountID,
                ua.accountID,
                ua.userID,
                u.userName,
                u.userDept,
                a.accountName,
                ua.userAllocatedAmount,

                -- Sum of previous transactions (before the range)
                ISNULL(SUM(CASE WHEN b.date < @fromDate THEN b.amount ELSE 0 END), 0) AS PreviousUsedAmount,

                -- Sum of transactions within the range
                ISNULL(SUM(CASE WHEN b.date >= @fromDate AND b.date <= @toDate THEN b.amount ELSE 0 END), 0) AS UsedAmountInRange,

                -- Remaining amount after deducting previous transactions
                (ua.userAllocatedAmount 
                    - ISNULL(SUM(CASE WHEN b.date < @fromDate THEN b.amount ELSE 0 END), 0)
                    - ISNULL(SUM(CASE WHEN b.date >= @fromDate AND b.date <= @toDate THEN b.amount ELSE 0 END), 0)
                ) AS RemainingAmountInRange

            FROM tblUserAccounts ua
            INNER JOIN tblAccounts a ON ua.accountID = a.accountID
            INNER JOIN tblAccountUser u ON ua.userID = u.userID
            LEFT JOIN tblBudget b 
                ON ua.userAccountID = b.userAccountID
            WHERE ua.userID = @userID
            GROUP BY ua.userAccountID, ua.accountID, ua.userID, u.userName, u.userDept, a.accountName, ua.userAllocatedAmount
            ORDER BY a.accountName ASC
            ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userID", Program.rAccountUserID);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument rdd = new ReportDocument();
                        rdd.Load(Path.Combine(Application.StartupPath, "BudgetAllocation - Copy.rpt"));
                        rdd.SetDataSource(dt);

                        // Set Crystal Report parameters
                        if (rdd.ParameterFields["FromDate"] != null)
                            rdd.SetParameterValue("FromDate", fromDate);
                        if (rdd.ParameterFields["ToDate"] != null)
                            rdd.SetParameterValue("ToDate", toDate);

                        crystalReportViewer1.ReportSource = rdd;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        void printAllocationByDepartment()
        {
            string department = comboDept.Text;
            int year = Convert.ToInt32(cmbYear.Text); // or get dynamically if needed

            using (SqlConnection con = new SqlConnection(Program.ConnString))
            {
                con.Open();

                try
                {
                    string query = @"
                    SELECT 
                        u.userDept,
                        a.accountName,
                        SUM(ua.userAllocatedAmount) AS userAllocatedAmount,

                        -- Total used
                        ISNULL(SUM(b.amount), 0) AS userUsedAmount,

                        -- Remaining
                        (SUM(ua.userAllocatedAmount) - ISNULL(SUM(b.amount), 0)) AS userRemainingAmount

                    FROM tblUserAccounts ua
                    INNER JOIN tblAccounts a ON ua.accountID = a.accountID
                    INNER JOIN tblAccountUser u ON ua.userID = u.userID
                    LEFT JOIN tblBudget b 
                        ON ua.userAccountID = b.userAccountID

                    WHERE u.userDept = @department
                    AND a.accountYear = @year
                    AND u.userYear = @year

                    GROUP BY u.userDept, a.accountName
                    ORDER BY a.accountName ASC
                    ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@year", year);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument rdd = new ReportDocument();
                        rdd.Load(Path.Combine(Application.StartupPath, "BudgetAllocation - Lump.rpt"));
                        rdd.SetDataSource(dt);

                        //rdd.SetParameterValue("Department", department);
                        //rdd.SetParameterValue("Year", year); // optional

                        crystalReportViewer2.ReportSource = rdd;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        void printAllocation()
        {
            SqlConnection con = new SqlConnection(Program.ConnString);
            con.Open();

            try
            {
                string query = @"SELECT ua.userAccountID, ua.accountID, ua.userID, u.userName, u.userDept, a.accountName, ua.userAllocatedAmount, ua.userRemainingAmount, ua.userUsedAmount, u.userYear FROM tblUserAccounts ua INNER JOIN tblAccounts a ON ua.accountID = a.accountID INNER JOIN tblAccountUser u ON ua.userID = u.userID WHERE ua.userID = @userAccountID ORDER BY a.accountName ASC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@userAccountID", Program.rAccountUserID);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ReportDocument rdd = new ReportDocument();
                    rdd.Load(Path.Combine(Application.StartupPath, "BudgetAllocation.rpt"));
                    rdd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rdd;
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void chkEnableDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDate.Checked == true)
            {
                grpDate.Enabled = true;
            }
            else
            {
                grpDate.Enabled = false;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
