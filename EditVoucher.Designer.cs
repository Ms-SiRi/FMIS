namespace FMIS
{
    partial class EditVoucher
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
            this.icnVoucherSave = new FontAwesome.Sharp.IconButton();
            this.icnVoucherPrint = new FontAwesome.Sharp.IconButton();
            this.qrVoucherPic = new System.Windows.Forms.PictureBox();
            this.comboSource = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAttachObR = new FontAwesome.Sharp.IconButton();
            this.txtObRLoc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.icnVoucherGenerate = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorWithAlpha2 = new System.Windows.Forms.ColorWithAlpha();
            this.alphaGradientPanel1 = new System.Windows.Forms.AlphaGradientPanel();
            this.colorWithAlpha1 = new System.Windows.Forms.ColorWithAlpha();
            this.voucherSP = new System.Windows.Forms.Label();
            this.voucherDate = new System.Windows.Forms.Label();
            this.voucherCtrl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbVoucher = new System.Windows.Forms.GroupBox();
            this.icnCancel = new FontAwesome.Sharp.IconButton();
            this.icnOpen = new FontAwesome.Sharp.IconButton();
            this.txtVoucherCtrl = new System.Windows.Forms.TextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.txtUsers = new System.Windows.Forms.ComboBox();
            this.txtUserYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qrVoucherPic)).BeginInit();
            this.alphaGradientPanel1.SuspendLayout();
            this.gbVoucher.SuspendLayout();
            this.SuspendLayout();
            // 
            // icnVoucherSave
            // 
            this.icnVoucherSave.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnVoucherSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.icnVoucherSave.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.icnVoucherSave.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.icnVoucherSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnVoucherSave.IconSize = 35;
            this.icnVoucherSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnVoucherSave.Location = new System.Drawing.Point(170, 100);
            this.icnVoucherSave.Margin = new System.Windows.Forms.Padding(2);
            this.icnVoucherSave.Name = "icnVoucherSave";
            this.icnVoucherSave.Size = new System.Drawing.Size(130, 34);
            this.icnVoucherSave.TabIndex = 6;
            this.icnVoucherSave.Text = "Update";
            this.icnVoucherSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnVoucherSave.UseVisualStyleBackColor = true;
            this.icnVoucherSave.Click += new System.EventHandler(this.icnVoucherSave_Click);
            // 
            // icnVoucherPrint
            // 
            this.icnVoucherPrint.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnVoucherPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.icnVoucherPrint.IconColor = System.Drawing.Color.Black;
            this.icnVoucherPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnVoucherPrint.IconSize = 35;
            this.icnVoucherPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnVoucherPrint.Location = new System.Drawing.Point(170, 61);
            this.icnVoucherPrint.Margin = new System.Windows.Forms.Padding(2);
            this.icnVoucherPrint.Name = "icnVoucherPrint";
            this.icnVoucherPrint.Size = new System.Drawing.Size(130, 34);
            this.icnVoucherPrint.TabIndex = 2;
            this.icnVoucherPrint.Text = "Print QR";
            this.icnVoucherPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnVoucherPrint.UseVisualStyleBackColor = true;
            this.icnVoucherPrint.Click += new System.EventHandler(this.icnVoucherPrint_Click);
            // 
            // qrVoucherPic
            // 
            this.qrVoucherPic.Location = new System.Drawing.Point(42, 35);
            this.qrVoucherPic.Margin = new System.Windows.Forms.Padding(2);
            this.qrVoucherPic.Name = "qrVoucherPic";
            this.qrVoucherPic.Size = new System.Drawing.Size(101, 101);
            this.qrVoucherPic.TabIndex = 0;
            this.qrVoucherPic.TabStop = false;
            // 
            // comboSource
            // 
            this.comboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSource.Enabled = false;
            this.comboSource.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSource.FormattingEnabled = true;
            this.comboSource.Location = new System.Drawing.Point(142, 254);
            this.comboSource.Margin = new System.Windows.Forms.Padding(2);
            this.comboSource.Name = "comboSource";
            this.comboSource.Size = new System.Drawing.Size(263, 25);
            this.comboSource.TabIndex = 89;
            this.comboSource.SelectedIndexChanged += new System.EventHandler(this.comboSource_SelectedIndexChanged);
            this.comboSource.TextChanged += new System.EventHandler(this.comboSource_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 88;
            this.label6.Text = "Source:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(142, 282);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(263, 24);
            this.txtAmount.TabIndex = 87;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 86;
            this.label2.Text = "Amount:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAttachObR
            // 
            this.btnAttachObR.Enabled = false;
            this.btnAttachObR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachObR.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            this.btnAttachObR.IconColor = System.Drawing.Color.Black;
            this.btnAttachObR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAttachObR.IconSize = 25;
            this.btnAttachObR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachObR.Location = new System.Drawing.Point(1017, 80);
            this.btnAttachObR.Margin = new System.Windows.Forms.Padding(2);
            this.btnAttachObR.Name = "btnAttachObR";
            this.btnAttachObR.Size = new System.Drawing.Size(94, 27);
            this.btnAttachObR.TabIndex = 85;
            this.btnAttachObR.Text = "Attach File";
            this.btnAttachObR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttachObR.UseVisualStyleBackColor = true;
            this.btnAttachObR.Click += new System.EventHandler(this.btnAttachObR_Click);
            // 
            // txtObRLoc
            // 
            this.txtObRLoc.Enabled = false;
            this.txtObRLoc.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObRLoc.Location = new System.Drawing.Point(891, 82);
            this.txtObRLoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtObRLoc.Name = "txtObRLoc";
            this.txtObRLoc.Size = new System.Drawing.Size(122, 24);
            this.txtObRLoc.TabIndex = 83;
            this.txtObRLoc.TextChanged += new System.EventHandler(this.txtObRLoc_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(696, 89);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 17);
            this.label14.TabIndex = 84;
            this.label14.Text = "Obligation Request File:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtParticulars
            // 
            this.txtParticulars.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParticulars.Enabled = false;
            this.txtParticulars.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticulars.Location = new System.Drawing.Point(9, 330);
            this.txtParticulars.Margin = new System.Windows.Forms.Padding(2);
            this.txtParticulars.Multiline = true;
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.Size = new System.Drawing.Size(397, 47);
            this.txtParticulars.TabIndex = 82;
            this.txtParticulars.TextChanged += new System.EventHandler(this.txtParticulars_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 312);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 17);
            this.label9.TabIndex = 81;
            this.label9.Text = "Particulars/Remarks:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // icnVoucherGenerate
            // 
            this.icnVoucherGenerate.Enabled = false;
            this.icnVoucherGenerate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnVoucherGenerate.IconChar = FontAwesome.Sharp.IconChar.Qrcode;
            this.icnVoucherGenerate.IconColor = System.Drawing.Color.Black;
            this.icnVoucherGenerate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnVoucherGenerate.IconSize = 35;
            this.icnVoucherGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnVoucherGenerate.Location = new System.Drawing.Point(170, 22);
            this.icnVoucherGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.icnVoucherGenerate.Name = "icnVoucherGenerate";
            this.icnVoucherGenerate.Size = new System.Drawing.Size(130, 34);
            this.icnVoucherGenerate.TabIndex = 1;
            this.icnVoucherGenerate.Text = "Generate QR";
            this.icnVoucherGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnVoucherGenerate.UseVisualStyleBackColor = true;
            this.icnVoucherGenerate.Click += new System.EventHandler(this.icnVoucherGenerate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 79;
            this.label5.Text = "End User:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboDept
            // 
            this.comboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDept.Enabled = false;
            this.comboDept.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Items.AddRange(new object[] {
            "Sangguniang Panlalawigan",
            "Vice Governor\'s Office"});
            this.comboDept.Location = new System.Drawing.Point(142, 194);
            this.comboDept.Margin = new System.Windows.Forms.Padding(2);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(263, 25);
            this.comboDept.TabIndex = 78;
            this.comboDept.SelectedIndexChanged += new System.EventHandler(this.comboDept_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Department:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPayee
            // 
            this.txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayee.Enabled = false;
            this.txtPayee.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayee.Location = new System.Drawing.Point(9, 128);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(2);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(397, 24);
            this.txtPayee.TabIndex = 76;
            this.txtPayee.TextChanged += new System.EventHandler(this.txtPayee_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Enabled = false;
            this.label26.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 75);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(175, 17);
            this.label26.TabIndex = 71;
            this.label26.Text = "D.V. Control Number:";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit Voucher";
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 0;
            this.colorWithAlpha2.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha2.Parent = this.alphaGradientPanel1;
            // 
            // alphaGradientPanel1
            // 
            this.alphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.alphaGradientPanel1.Border = true;
            this.alphaGradientPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha1);
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha2);
            this.alphaGradientPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.alphaGradientPanel1.Controls.Add(this.label1);
            this.alphaGradientPanel1.CornerRadius = 20;
            this.alphaGradientPanel1.Corners = ((System.Windows.Forms.Corner)((((System.Windows.Forms.Corner.TopLeft | System.Windows.Forms.Corner.TopRight) 
            | System.Windows.Forms.Corner.BottomLeft) 
            | System.Windows.Forms.Corner.BottomRight)));
            this.alphaGradientPanel1.Gradient = true;
            this.alphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.alphaGradientPanel1.GradientOffset = 1F;
            this.alphaGradientPanel1.GradientSize = new System.Drawing.Size(0, 0);
            this.alphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.alphaGradientPanel1.Grayscale = false;
            this.alphaGradientPanel1.Image = null;
            this.alphaGradientPanel1.ImageAlpha = 75;
            this.alphaGradientPanel1.ImagePadding = new System.Windows.Forms.Padding(5);
            this.alphaGradientPanel1.ImagePosition = System.Windows.Forms.ImagePosition.BottomRight;
            this.alphaGradientPanel1.ImageSize = new System.Drawing.Size(48, 48);
            this.alphaGradientPanel1.Location = new System.Drawing.Point(2, 1);
            this.alphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.alphaGradientPanel1.Name = "alphaGradientPanel1";
            this.alphaGradientPanel1.Rounded = false;
            this.alphaGradientPanel1.Size = new System.Drawing.Size(784, 59);
            this.alphaGradientPanel1.TabIndex = 70;
            this.alphaGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.alphaGradientPanel1_Paint);
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.Color.DeepSkyBlue;
            this.colorWithAlpha1.Parent = this.alphaGradientPanel1;
            // 
            // voucherSP
            // 
            this.voucherSP.AutoSize = true;
            this.voucherSP.Location = new System.Drawing.Point(58, 172);
            this.voucherSP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.voucherSP.Name = "voucherSP";
            this.voucherSP.Size = new System.Drawing.Size(69, 17);
            this.voucherSP.TabIndex = 5;
            this.voucherSP.Text = "SP-VGO";
            this.voucherSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voucherDate
            // 
            this.voucherDate.AutoSize = true;
            this.voucherDate.Location = new System.Drawing.Point(38, 140);
            this.voucherDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.voucherDate.Name = "voucherDate";
            this.voucherDate.Size = new System.Drawing.Size(50, 17);
            this.voucherDate.TabIndex = 4;
            this.voucherDate.Text = "DATE";
            this.voucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voucherCtrl
            // 
            this.voucherCtrl.AutoSize = true;
            this.voucherCtrl.Location = new System.Drawing.Point(18, 156);
            this.voucherCtrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.voucherCtrl.Name = "voucherCtrl";
            this.voucherCtrl.Size = new System.Drawing.Size(156, 17);
            this.voucherCtrl.TabIndex = 3;
            this.voucherCtrl.Text = "CONTROL NUMBER";
            this.voucherCtrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 75;
            this.label8.Text = "Payee:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // gbVoucher
            // 
            this.gbVoucher.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gbVoucher.Controls.Add(this.icnCancel);
            this.gbVoucher.Controls.Add(this.icnOpen);
            this.gbVoucher.Controls.Add(this.icnVoucherSave);
            this.gbVoucher.Controls.Add(this.voucherSP);
            this.gbVoucher.Controls.Add(this.voucherDate);
            this.gbVoucher.Controls.Add(this.voucherCtrl);
            this.gbVoucher.Controls.Add(this.icnVoucherPrint);
            this.gbVoucher.Controls.Add(this.icnVoucherGenerate);
            this.gbVoucher.Controls.Add(this.qrVoucherPic);
            this.gbVoucher.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVoucher.Location = new System.Drawing.Point(9, 385);
            this.gbVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.gbVoucher.Name = "gbVoucher";
            this.gbVoucher.Padding = new System.Windows.Forms.Padding(2);
            this.gbVoucher.Size = new System.Drawing.Size(396, 224);
            this.gbVoucher.TabIndex = 69;
            this.gbVoucher.TabStop = false;
            this.gbVoucher.Text = "Generate Disbursement Voucher QR";
            this.gbVoucher.Enter += new System.EventHandler(this.gbVoucher_Enter);
            // 
            // icnCancel
            // 
            this.icnCancel.ForeColor = System.Drawing.Color.Crimson;
            this.icnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
            this.icnCancel.IconColor = System.Drawing.Color.Crimson;
            this.icnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnCancel.IconSize = 35;
            this.icnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnCancel.Location = new System.Drawing.Point(170, 178);
            this.icnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.icnCancel.Name = "icnCancel";
            this.icnCancel.Size = new System.Drawing.Size(130, 34);
            this.icnCancel.TabIndex = 87;
            this.icnCancel.Text = "Close     ";
            this.icnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnCancel.UseVisualStyleBackColor = true;
            this.icnCancel.Click += new System.EventHandler(this.icnCancel_Click);
            // 
            // icnOpen
            // 
            this.icnOpen.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.icnOpen.IconChar = FontAwesome.Sharp.IconChar.File;
            this.icnOpen.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.icnOpen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnOpen.IconSize = 35;
            this.icnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnOpen.Location = new System.Drawing.Point(170, 140);
            this.icnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.icnOpen.Name = "icnOpen";
            this.icnOpen.Size = new System.Drawing.Size(130, 34);
            this.icnOpen.TabIndex = 7;
            this.icnOpen.Text = "Open File";
            this.icnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnOpen.UseVisualStyleBackColor = true;
            this.icnOpen.Click += new System.EventHandler(this.icnOpen_Click);
            // 
            // txtVoucherCtrl
            // 
            this.txtVoucherCtrl.Enabled = false;
            this.txtVoucherCtrl.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherCtrl.Location = new System.Drawing.Point(178, 73);
            this.txtVoucherCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtVoucherCtrl.Name = "txtVoucherCtrl";
            this.txtVoucherCtrl.Size = new System.Drawing.Size(185, 24);
            this.txtVoucherCtrl.TabIndex = 91;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(699, 110);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(16, 16);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(411, 467);
            this.webBrowser.TabIndex = 92;
            // 
            // txtUsers
            // 
            this.txtUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUsers.Enabled = false;
            this.txtUsers.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsers.FormattingEnabled = true;
            this.txtUsers.Items.AddRange(new object[] {
            "Sangguniang Panlalawigan",
            "Vice Governor\'s Office"});
            this.txtUsers.Location = new System.Drawing.Point(143, 223);
            this.txtUsers.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsers.Name = "txtUsers";
            this.txtUsers.Size = new System.Drawing.Size(262, 25);
            this.txtUsers.TabIndex = 94;
            this.txtUsers.SelectedIndexChanged += new System.EventHandler(this.txtUsers_SelectedIndexChanged);
            // 
            // txtUserYear
            // 
            this.txtUserYear.Enabled = false;
            this.txtUserYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserYear.Location = new System.Drawing.Point(143, 166);
            this.txtUserYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserYear.Name = "txtUserYear";
            this.txtUserYear.Size = new System.Drawing.Size(263, 24);
            this.txtUserYear.TabIndex = 96;
            this.txtUserYear.Text = "2025";
            this.txtUserYear.TextChanged += new System.EventHandler(this.txtUserYear_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 95;
            this.label3.Text = "Year:";
            // 
            // EditVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(414, 629);
            this.ControlBox = false;
            this.Controls.Add(this.txtUserYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsers);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.txtVoucherCtrl);
            this.Controls.Add(this.comboSource);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAttachObR);
            this.Controls.Add(this.txtObRLoc);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtParticulars);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboDept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.alphaGradientPanel1);
            this.Controls.Add(this.gbVoucher);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrVoucherPic)).EndInit();
            this.alphaGradientPanel1.ResumeLayout(false);
            this.alphaGradientPanel1.PerformLayout();
            this.gbVoucher.ResumeLayout(false);
            this.gbVoucher.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton icnVoucherSave;
        private FontAwesome.Sharp.IconButton icnVoucherPrint;
        private System.Windows.Forms.PictureBox qrVoucherPic;
        private System.Windows.Forms.ComboBox comboSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnAttachObR;
        private System.Windows.Forms.TextBox txtObRLoc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtParticulars;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton icnVoucherGenerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.Label voucherSP;
        private System.Windows.Forms.Label voucherDate;
        private System.Windows.Forms.Label voucherCtrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbVoucher;
        private System.Windows.Forms.TextBox txtVoucherCtrl;
        public System.Windows.Forms.WebBrowser webBrowser;
        private FontAwesome.Sharp.IconButton icnOpen;
        private FontAwesome.Sharp.IconButton icnCancel;
        private System.Windows.Forms.ComboBox txtUsers;
        private System.Windows.Forms.TextBox txtUserYear;
        private System.Windows.Forms.Label label3;
    }
}