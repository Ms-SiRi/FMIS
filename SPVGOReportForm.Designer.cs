namespace FMIS
{
    partial class SPVGOReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkEnableDate = new System.Windows.Forms.CheckBox();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.icnPrintAllocations = new FontAwesome.Sharp.IconButton();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.icnPrint = new FontAwesome.Sharp.IconButton();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.alphaGradientPanel1 = new System.Windows.Forms.AlphaGradientPanel();
            this.colorWithAlpha1 = new System.Windows.Forms.ColorWithAlpha();
            this.colorWithAlpha2 = new System.Windows.Forms.ColorWithAlpha();
            this.tcReport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.budgetData = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.remainingBudget = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.usedBudget = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allocatedBudget = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.alphaGradientPanel2 = new System.Windows.Forms.AlphaGradientPanel();
            this.chkDept = new System.Windows.Forms.CheckBox();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpDate.SuspendLayout();
            this.alphaGradientPanel1.SuspendLayout();
            this.tcReport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.budgetData.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.alphaGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FMIS.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1186, 73);
            this.label1.TabIndex = 5;
            this.label1.Text = "Track Secretariat and VGO Budget";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.chkAccount);
            this.groupBox4.Controls.Add(this.chkUser);
            this.groupBox4.Controls.Add(this.chkDept);
            this.groupBox4.Controls.Add(this.chkEnableDate);
            this.groupBox4.Controls.Add(this.grpDate);
            this.groupBox4.Controls.Add(this.icnPrintAllocations);
            this.groupBox4.Controls.Add(this.cmbSource);
            this.groupBox4.Controls.Add(this.icnPrint);
            this.groupBox4.Controls.Add(this.comboDept);
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.cmbUser);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 177);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(1898, 133);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // chkEnableDate
            // 
            this.chkEnableDate.AutoSize = true;
            this.chkEnableDate.Location = new System.Drawing.Point(1288, 13);
            this.chkEnableDate.Name = "chkEnableDate";
            this.chkEnableDate.Size = new System.Drawing.Size(119, 26);
            this.chkEnableDate.TabIndex = 25;
            this.chkEnableDate.Text = "with Date";
            this.chkEnableDate.UseVisualStyleBackColor = true;
            this.chkEnableDate.CheckedChanged += new System.EventHandler(this.chkEnableDate_CheckedChanged);
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.dtTo);
            this.grpDate.Controls.Add(this.dtFrom);
            this.grpDate.Controls.Add(this.label3);
            this.grpDate.Controls.Add(this.label2);
            this.grpDate.Enabled = false;
            this.grpDate.Location = new System.Drawing.Point(1288, 37);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(324, 83);
            this.grpDate.TabIndex = 26;
            this.grpDate.TabStop = false;
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(90, 48);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 29);
            this.dtTo.TabIndex = 3;
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(90, 16);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 29);
            this.dtFrom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "From:";
            // 
            // icnPrintAllocations
            // 
            this.icnPrintAllocations.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnPrintAllocations.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.icnPrintAllocations.IconColor = System.Drawing.Color.Red;
            this.icnPrintAllocations.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnPrintAllocations.IconSize = 30;
            this.icnPrintAllocations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnPrintAllocations.Location = new System.Drawing.Point(1633, 77);
            this.icnPrintAllocations.Margin = new System.Windows.Forms.Padding(2);
            this.icnPrintAllocations.Name = "icnPrintAllocations";
            this.icnPrintAllocations.Size = new System.Drawing.Size(214, 40);
            this.icnPrintAllocations.TabIndex = 24;
            this.icnPrintAllocations.Text = "Print Allocations";
            this.icnPrintAllocations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnPrintAllocations.UseVisualStyleBackColor = true;
            this.icnPrintAllocations.Click += new System.EventHandler(this.icnPrintAllocations_Click);
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "Office Supplies",
            "Fuel, Oil, Lubricants",
            "R/M-Trans. Equipment",
            "Other MOOE",
            "Capital Outlay",
            "Representation Expenses",
            "Other Supplies and Material Expenses",
            "Postage and Courier Services",
            "R/M-Buildings and Other Structures",
            "R/M-Machinery and Equipment",
            "R/M-Furniture and Fixtures",
            "R/M-Other PPE",
            "Printing and Publication Expenses",
            "Advertising Expenses",
            "Traveling Expenses - Local",
            "Training Expenses",
            "Telephone Expenses",
            "Internet Subscription Expenses",
            "Consultancy Services",
            "Membership Dues and Contribution to Organization",
            "Other General Services",
            "Traveling Expenses -Foreign",
            "Legal Services",
            "Fidelity Bond Premium",
            "Subscription Expenses",
            "Other MOE - Job Order",
            "Salaries and Wages - Regular ",
            "Salaries and Wages - Casual/Contractual",
            "Personal Economic Relief Allowance (PERA)",
            "Representation Allowance (RA)",
            "Transportation Allowance (TA)",
            "Clothing/Uniform Allowance",
            "Overtime and Night Pay",
            "Year End Bonus ",
            "Cash Gift",
            "Other Bonuses & Allowances (Mid Year Bonus)",
            "Other Bonuses & Allowances (Anniversary Bonus)",
            "Retirement and Life Insurance Premium",
            "Pag-ibig Contributions",
            "Philhealth Contributions",
            "Employees Compensation Insurance Premiums",
            "Terminal Leave Benefits",
            "Other Personnel Benefits - Monetization",
            "Other Personnel Benefits - Loyalty Pay",
            "Other Personnel Benefits - PEI",
            "Cable, Satelite, Telegraph and Radio Expenses",
            "Quarter\'s Allowance"});
            this.cmbSource.Location = new System.Drawing.Point(848, 63);
            this.cmbSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(423, 30);
            this.cmbSource.TabIndex = 23;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // icnPrint
            // 
            this.icnPrint.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.icnPrint.IconColor = System.Drawing.Color.Red;
            this.icnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnPrint.IconSize = 30;
            this.icnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnPrint.Location = new System.Drawing.Point(1633, 34);
            this.icnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.icnPrint.Name = "icnPrint";
            this.icnPrint.Size = new System.Drawing.Size(214, 40);
            this.icnPrint.TabIndex = 22;
            this.icnPrint.Text = "Show Breakdown";
            this.icnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnPrint.UseVisualStyleBackColor = true;
            this.icnPrint.Click += new System.EventHandler(this.icnPrint_Click);
            // 
            // comboDept
            // 
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Items.AddRange(new object[] {
            "SANGGUNIANG PANLALAWIGAN",
            "VICE GOVERNOR\'S OFFICE"});
            this.comboDept.Location = new System.Drawing.Point(45, 63);
            this.comboDept.Margin = new System.Windows.Forms.Padding(2);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(234, 30);
            this.comboDept.TabIndex = 20;
            this.comboDept.SelectedIndexChanged += new System.EventHandler(this.comboDept_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(315, 63);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(2);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(234, 30);
            this.cmbYear.TabIndex = 19;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(582, 63);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(234, 30);
            this.cmbUser.TabIndex = 18;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // alphaGradientPanel1
            // 
            this.alphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.alphaGradientPanel1.Border = true;
            this.alphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha1);
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha2);
            this.alphaGradientPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.alphaGradientPanel1.Controls.Add(this.tcReport);
            this.alphaGradientPanel1.Controls.Add(this.groupBox4);
            this.alphaGradientPanel1.Controls.Add(this.alphaGradientPanel2);
            this.alphaGradientPanel1.CornerRadius = 20;
            this.alphaGradientPanel1.Corners = ((System.Windows.Forms.Corner)((((System.Windows.Forms.Corner.TopLeft | System.Windows.Forms.Corner.TopRight) 
            | System.Windows.Forms.Corner.BottomLeft) 
            | System.Windows.Forms.Corner.BottomRight)));
            this.alphaGradientPanel1.Gradient = true;
            this.alphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.alphaGradientPanel1.GradientOffset = 1F;
            this.alphaGradientPanel1.GradientSize = new System.Drawing.Size(0, 0);
            this.alphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.alphaGradientPanel1.Grayscale = false;
            this.alphaGradientPanel1.Image = null;
            this.alphaGradientPanel1.ImageAlpha = 75;
            this.alphaGradientPanel1.ImagePadding = new System.Windows.Forms.Padding(5);
            this.alphaGradientPanel1.ImagePosition = System.Windows.Forms.ImagePosition.BottomRight;
            this.alphaGradientPanel1.ImageSize = new System.Drawing.Size(48, 48);
            this.alphaGradientPanel1.Location = new System.Drawing.Point(2, 2);
            this.alphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.alphaGradientPanel1.Name = "alphaGradientPanel1";
            this.alphaGradientPanel1.Rounded = false;
            this.alphaGradientPanel1.Size = new System.Drawing.Size(1898, 1029);
            this.alphaGradientPanel1.TabIndex = 8;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha1.Parent = this.alphaGradientPanel1;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.SkyBlue;
            this.colorWithAlpha2.Parent = this.alphaGradientPanel1;
            // 
            // tcReport
            // 
            this.tcReport.Controls.Add(this.tabPage1);
            this.tcReport.Controls.Add(this.tabPage3);
            this.tcReport.Controls.Add(this.tabPage2);
            this.tcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcReport.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcReport.Location = new System.Drawing.Point(0, 310);
            this.tcReport.Name = "tcReport";
            this.tcReport.SelectedIndex = 0;
            this.tcReport.Size = new System.Drawing.Size(1898, 719);
            this.tcReport.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.budgetData);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1890, 681);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "INDIVIDUAL REPORT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1884, 568);
            this.panel1.TabIndex = 7;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1884, 568);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // budgetData
            // 
            this.budgetData.BackColor = System.Drawing.Color.Pink;
            this.budgetData.Controls.Add(this.groupBox3);
            this.budgetData.Controls.Add(this.groupBox2);
            this.budgetData.Controls.Add(this.groupBox1);
            this.budgetData.Dock = System.Windows.Forms.DockStyle.Top;
            this.budgetData.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetData.Location = new System.Drawing.Point(3, 3);
            this.budgetData.Margin = new System.Windows.Forms.Padding(2);
            this.budgetData.Name = "budgetData";
            this.budgetData.Padding = new System.Windows.Forms.Padding(2);
            this.budgetData.Size = new System.Drawing.Size(1884, 107);
            this.budgetData.TabIndex = 33;
            this.budgetData.TabStop = false;
            this.budgetData.Text = "Budget Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.remainingBudget);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1015, 28);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(455, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "REMAINING BUDGET";
            // 
            // remainingBudget
            // 
            this.remainingBudget.AutoSize = true;
            this.remainingBudget.Location = new System.Drawing.Point(112, 31);
            this.remainingBudget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.remainingBudget.Name = "remainingBudget";
            this.remainingBudget.Size = new System.Drawing.Size(26, 25);
            this.remainingBudget.TabIndex = 3;
            this.remainingBudget.Text = "0";
            this.remainingBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.usedBudget);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(555, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(365, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "USED BUDGET";
            // 
            // usedBudget
            // 
            this.usedBudget.AutoSize = true;
            this.usedBudget.Location = new System.Drawing.Point(69, 31);
            this.usedBudget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usedBudget.Name = "usedBudget";
            this.usedBudget.Size = new System.Drawing.Size(26, 25);
            this.usedBudget.TabIndex = 4;
            this.usedBudget.Text = "0";
            this.usedBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allocatedBudget);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(111, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(365, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOTAL ALLOCATED BUDGET";
            // 
            // allocatedBudget
            // 
            this.allocatedBudget.AutoSize = true;
            this.allocatedBudget.Location = new System.Drawing.Point(40, 31);
            this.allocatedBudget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.allocatedBudget.Name = "allocatedBudget";
            this.allocatedBudget.Size = new System.Drawing.Size(26, 25);
            this.allocatedBudget.TabIndex = 5;
            this.allocatedBudget.Text = "0";
            this.allocatedBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crystalReportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1890, 681);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LUMP REPORT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer2.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(1884, 675);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crystalReportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1890, 681);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "DEPARTMENT REPORT";
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer3.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.Size = new System.Drawing.Size(1890, 681);
            this.crystalReportViewer3.TabIndex = 2;
            this.crystalReportViewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // alphaGradientPanel2
            // 
            this.alphaGradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.alphaGradientPanel2.Border = true;
            this.alphaGradientPanel2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.alphaGradientPanel2.ContentPadding = new System.Windows.Forms.Padding(0);
            this.alphaGradientPanel2.Controls.Add(this.pictureBox1);
            this.alphaGradientPanel2.Controls.Add(this.label1);
            this.alphaGradientPanel2.CornerRadius = 20;
            this.alphaGradientPanel2.Corners = ((System.Windows.Forms.Corner)((((System.Windows.Forms.Corner.TopLeft | System.Windows.Forms.Corner.TopRight) 
            | System.Windows.Forms.Corner.BottomLeft) 
            | System.Windows.Forms.Corner.BottomRight)));
            this.alphaGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.alphaGradientPanel2.Gradient = true;
            this.alphaGradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.alphaGradientPanel2.GradientOffset = 1F;
            this.alphaGradientPanel2.GradientSize = new System.Drawing.Size(0, 0);
            this.alphaGradientPanel2.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.alphaGradientPanel2.Grayscale = false;
            this.alphaGradientPanel2.Image = null;
            this.alphaGradientPanel2.ImageAlpha = 75;
            this.alphaGradientPanel2.ImagePadding = new System.Windows.Forms.Padding(5);
            this.alphaGradientPanel2.ImagePosition = System.Windows.Forms.ImagePosition.BottomRight;
            this.alphaGradientPanel2.ImageSize = new System.Drawing.Size(48, 48);
            this.alphaGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.alphaGradientPanel2.Name = "alphaGradientPanel2";
            this.alphaGradientPanel2.Rounded = true;
            this.alphaGradientPanel2.Size = new System.Drawing.Size(1898, 177);
            this.alphaGradientPanel2.TabIndex = 34;
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.Location = new System.Drawing.Point(45, 27);
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size(169, 26);
            this.chkDept.TabIndex = 27;
            this.chkDept.Text = "by Department";
            this.chkDept.UseVisualStyleBackColor = true;
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Location = new System.Drawing.Point(582, 27);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(101, 26);
            this.chkUser.TabIndex = 28;
            this.chkUser.Text = "by User";
            this.chkUser.UseVisualStyleBackColor = true;
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Location = new System.Drawing.Point(848, 27);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(130, 26);
            this.chkAccount.TabIndex = 29;
            this.chkAccount.Text = "by Account";
            this.chkAccount.UseVisualStyleBackColor = true;
            // 
            // SPVGOReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1902, 1032);
            this.Controls.Add(this.alphaGradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SPVGOReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPVGOReportForm";
            this.Activated += new System.EventHandler(this.SPVGOReportForm_Activated);
            this.Load += new System.EventHandler(this.SPVGOReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.alphaGradientPanel1.ResumeLayout(false);
            this.tcReport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.budgetData.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.alphaGradientPanel2.ResumeLayout(false);
            this.alphaGradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private FontAwesome.Sharp.IconButton icnPrint;
        private FontAwesome.Sharp.IconButton icnSearch;
        private System.Windows.Forms.ComboBox comboDept;
        public System.Windows.Forms.ComboBox cmbYear;
        public System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        public System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.GroupBox budgetData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label remainingBudget;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label usedBudget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label allocatedBudget;
        private FontAwesome.Sharp.IconButton icnPrintAllocations;
        private System.Windows.Forms.CheckBox chkEnableDate;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel2;
        private System.Windows.Forms.TabControl tcReport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private System.Windows.Forms.TabPage tabPage3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.CheckBox chkUser;
        private System.Windows.Forms.CheckBox chkDept;
    }
}