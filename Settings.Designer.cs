namespace FMIS
{
    partial class Settings
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
            this.colorWithAlpha1 = new System.Windows.Forms.ColorWithAlpha();
            this.colorWithAlpha2 = new System.Windows.Forms.ColorWithAlpha();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.icnUsers = new FontAwesome.Sharp.IconButton();
            this.icnAccounts = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.icnUserLogs = new FontAwesome.Sharp.IconButton();
            this.icnLoginAccounts = new FontAwesome.Sharp.IconButton();
            this.alphaGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.alphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.alphaGradientPanel1.Name = "alphaGradientPanel1";
            this.alphaGradientPanel1.Rounded = false;
            this.alphaGradientPanel1.Size = new System.Drawing.Size(960, 141);
            this.alphaGradientPanel1.TabIndex = 9;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FMIS.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.icnUsers);
            this.groupBox1.Controls.Add(this.icnAccounts);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 232);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For Budget";
            // 
            // icnUsers
            // 
            this.icnUsers.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnUsers.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icnUsers.IconColor = System.Drawing.Color.Black;
            this.icnUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnUsers.Location = new System.Drawing.Point(210, 40);
            this.icnUsers.Margin = new System.Windows.Forms.Padding(2);
            this.icnUsers.Name = "icnUsers";
            this.icnUsers.Size = new System.Drawing.Size(179, 158);
            this.icnUsers.TabIndex = 11;
            this.icnUsers.Text = "USERS";
            this.icnUsers.UseVisualStyleBackColor = true;
            this.icnUsers.Click += new System.EventHandler(this.icnUsers_Click);
            // 
            // icnAccounts
            // 
            this.icnAccounts.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnAccounts.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icnAccounts.IconColor = System.Drawing.Color.Black;
            this.icnAccounts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnAccounts.Location = new System.Drawing.Point(12, 40);
            this.icnAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.icnAccounts.Name = "icnAccounts";
            this.icnAccounts.Size = new System.Drawing.Size(179, 158);
            this.icnAccounts.TabIndex = 10;
            this.icnAccounts.Text = "BUDGET ACCOUNTS";
            this.icnAccounts.UseVisualStyleBackColor = true;
            this.icnAccounts.Click += new System.EventHandler(this.icnAccounts_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.icnUserLogs);
            this.groupBox2.Controls.Add(this.icnLoginAccounts);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(518, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 232);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "For Login";
            // 
            // icnUserLogs
            // 
            this.icnUserLogs.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnUserLogs.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icnUserLogs.IconColor = System.Drawing.Color.Black;
            this.icnUserLogs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnUserLogs.Location = new System.Drawing.Point(210, 40);
            this.icnUserLogs.Margin = new System.Windows.Forms.Padding(2);
            this.icnUserLogs.Name = "icnUserLogs";
            this.icnUserLogs.Size = new System.Drawing.Size(179, 158);
            this.icnUserLogs.TabIndex = 11;
            this.icnUserLogs.Text = "USER\'S LOGS";
            this.icnUserLogs.UseVisualStyleBackColor = true;
            this.icnUserLogs.Click += new System.EventHandler(this.icnUserLogs_Click);
            // 
            // icnLoginAccounts
            // 
            this.icnLoginAccounts.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnLoginAccounts.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icnLoginAccounts.IconColor = System.Drawing.Color.Black;
            this.icnLoginAccounts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnLoginAccounts.Location = new System.Drawing.Point(12, 40);
            this.icnLoginAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.icnLoginAccounts.Name = "icnLoginAccounts";
            this.icnLoginAccounts.Size = new System.Drawing.Size(179, 158);
            this.icnLoginAccounts.TabIndex = 10;
            this.icnLoginAccounts.Text = "LOGIN ACCOUNTS";
            this.icnLoginAccounts.UseVisualStyleBackColor = true;
            this.icnLoginAccounts.Click += new System.EventHandler(this.icnLoginAccounts_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(960, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.alphaGradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.alphaGradientPanel1.ResumeLayout(false);
            this.alphaGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton icnAccounts;
        private FontAwesome.Sharp.IconButton icnUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FontAwesome.Sharp.IconButton icnUserLogs;
        private FontAwesome.Sharp.IconButton icnLoginAccounts;
    }
}