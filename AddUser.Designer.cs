namespace FMIS
{
    partial class AddUser
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
            this.alphaGradientPanel1 = new System.Windows.Forms.AlphaGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.colorWithAlpha1 = new System.Windows.Forms.ColorWithAlpha();
            this.colorWithAlpha2 = new System.Windows.Forms.ColorWithAlpha();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpName = new System.Windows.Forms.GroupBox();
            this.grpDept = new System.Windows.Forms.GroupBox();
            this.grpYear = new System.Windows.Forms.GroupBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.icnSave = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.alphaGradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpName.SuspendLayout();
            this.grpDept.SuspendLayout();
            this.grpYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // alphaGradientPanel1
            // 
            this.alphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.alphaGradientPanel1.Border = true;
            this.alphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha1);
            this.alphaGradientPanel1.Colors.Add(this.colorWithAlpha2);
            this.alphaGradientPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.alphaGradientPanel1.Controls.Add(this.pictureBox1);
            this.alphaGradientPanel1.Controls.Add(this.label1);
            this.alphaGradientPanel1.CornerRadius = 20;
            this.alphaGradientPanel1.Corners = ((System.Windows.Forms.Corner)((((System.Windows.Forms.Corner.TopLeft | System.Windows.Forms.Corner.TopRight) 
            | System.Windows.Forms.Corner.BottomLeft) 
            | System.Windows.Forms.Corner.BottomRight)));
            this.alphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.alphaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.alphaGradientPanel1.Name = "alphaGradientPanel1";
            this.alphaGradientPanel1.Rounded = false;
            this.alphaGradientPanel1.Size = new System.Drawing.Size(514, 144);
            this.alphaGradientPanel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Accounts";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.icnSave);
            this.groupBox1.Controls.Add(this.grpYear);
            this.groupBox1.Controls.Add(this.grpDept);
            this.groupBox1.Controls.Add(this.grpName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 384);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.txtName);
            this.grpName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpName.Location = new System.Drawing.Point(47, 47);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(386, 73);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            this.grpName.Text = "Name";
            // 
            // grpDept
            // 
            this.grpDept.Controls.Add(this.cmbDept);
            this.grpDept.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDept.Location = new System.Drawing.Point(47, 139);
            this.grpDept.Name = "grpDept";
            this.grpDept.Size = new System.Drawing.Size(386, 73);
            this.grpDept.TabIndex = 1;
            this.grpDept.TabStop = false;
            this.grpDept.Text = "Department";
            // 
            // grpYear
            // 
            this.grpYear.Controls.Add(this.txtYear);
            this.grpYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpYear.Location = new System.Drawing.Point(47, 231);
            this.grpYear.Name = "grpYear";
            this.grpYear.Size = new System.Drawing.Size(386, 73);
            this.grpYear.TabIndex = 2;
            this.grpYear.TabStop = false;
            this.grpYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(28, 31);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(337, 28);
            this.txtYear.TabIndex = 0;
            // 
            // icnSave
            // 
            this.icnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.icnSave.IconColor = System.Drawing.Color.LimeGreen;
            this.icnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnSave.Location = new System.Drawing.Point(167, 325);
            this.icnSave.Name = "icnSave";
            this.icnSave.Size = new System.Drawing.Size(116, 47);
            this.icnSave.TabIndex = 3;
            this.icnSave.Text = "Save";
            this.icnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icnSave.UseVisualStyleBackColor = true;
            this.icnSave.Click += new System.EventHandler(this.icnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FMIS.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(28, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(337, 28);
            this.txtName.TabIndex = 0;
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Items.AddRange(new object[] {
            "VICE GOVERNOR\'S OFFICE",
            "SANGGUNIANG PANLALAWIGAN"});
            this.cmbDept.Location = new System.Drawing.Point(28, 30);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(337, 28);
            this.cmbDept.TabIndex = 0;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(514, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.alphaGradientPanel1);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.alphaGradientPanel1.ResumeLayout(false);
            this.alphaGradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.grpDept.ResumeLayout(false);
            this.grpYear.ResumeLayout(false);
            this.grpYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.GroupBox grpDept;
        public FontAwesome.Sharp.IconButton icnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbDept;
    }
}