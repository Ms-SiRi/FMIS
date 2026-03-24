namespace FMIS
{
    partial class BorrowerSheetMenu
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
            this.icnPrint = new FontAwesome.Sharp.IconButton();
            this.icnReturn = new FontAwesome.Sharp.IconButton();
            this.icnBorrow = new FontAwesome.Sharp.IconButton();
            this.icnTransfer = new FontAwesome.Sharp.IconButton();
            this.alphaGradientPanel1.SuspendLayout();
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
            this.alphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.alphaGradientPanel1.Name = "alphaGradientPanel1";
            this.alphaGradientPanel1.Rounded = false;
            this.alphaGradientPanel1.Size = new System.Drawing.Size(913, 141);
            this.alphaGradientPanel1.TabIndex = 12;
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
            this.label1.Location = new System.Drawing.Point(153, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Borrower\'s Sheet ";
            // 
            // icnPrint
            // 
            this.icnPrint.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnPrint.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.icnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.icnPrint.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.icnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnPrint.IconSize = 120;
            this.icnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnPrint.Location = new System.Drawing.Point(676, 191);
            this.icnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.icnPrint.Name = "icnPrint";
            this.icnPrint.Size = new System.Drawing.Size(164, 135);
            this.icnPrint.TabIndex = 15;
            this.icnPrint.Text = "PRINT";
            this.icnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnPrint.UseVisualStyleBackColor = true;
            this.icnPrint.Click += new System.EventHandler(this.icnPrint_Click);
            // 
            // icnReturn
            // 
            this.icnReturn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.icnReturn.IconChar = FontAwesome.Sharp.IconChar.ReplyAll;
            this.icnReturn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.icnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnReturn.IconSize = 120;
            this.icnReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnReturn.Location = new System.Drawing.Point(468, 191);
            this.icnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.icnReturn.Name = "icnReturn";
            this.icnReturn.Size = new System.Drawing.Size(164, 135);
            this.icnReturn.TabIndex = 16;
            this.icnReturn.Text = "RETURN";
            this.icnReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnReturn.UseVisualStyleBackColor = true;
            this.icnReturn.Click += new System.EventHandler(this.icnReturn_Click);
            // 
            // icnBorrow
            // 
            this.icnBorrow.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnBorrow.ForeColor = System.Drawing.Color.Red;
            this.icnBorrow.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.icnBorrow.IconColor = System.Drawing.Color.Red;
            this.icnBorrow.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBorrow.IconSize = 120;
            this.icnBorrow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnBorrow.Location = new System.Drawing.Point(51, 191);
            this.icnBorrow.Margin = new System.Windows.Forms.Padding(2);
            this.icnBorrow.Name = "icnBorrow";
            this.icnBorrow.Size = new System.Drawing.Size(164, 135);
            this.icnBorrow.TabIndex = 17;
            this.icnBorrow.Text = "BORROW";
            this.icnBorrow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnBorrow.UseVisualStyleBackColor = true;
            this.icnBorrow.Click += new System.EventHandler(this.icnBorrow_Click);
            // 
            // icnTransfer
            // 
            this.icnTransfer.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icnTransfer.ForeColor = System.Drawing.Color.Maroon;
            this.icnTransfer.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.icnTransfer.IconColor = System.Drawing.Color.Maroon;
            this.icnTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnTransfer.IconSize = 120;
            this.icnTransfer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnTransfer.Location = new System.Drawing.Point(257, 191);
            this.icnTransfer.Margin = new System.Windows.Forms.Padding(2);
            this.icnTransfer.Name = "icnTransfer";
            this.icnTransfer.Size = new System.Drawing.Size(164, 135);
            this.icnTransfer.TabIndex = 18;
            this.icnTransfer.Text = "TRANSFER";
            this.icnTransfer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnTransfer.UseVisualStyleBackColor = true;
            this.icnTransfer.Click += new System.EventHandler(this.icnTransfer_Click);
            // 
            // BorrowerSheetMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(913, 364);
            this.Controls.Add(this.icnTransfer);
            this.Controls.Add(this.icnBorrow);
            this.Controls.Add(this.icnReturn);
            this.Controls.Add(this.icnPrint);
            this.Controls.Add(this.alphaGradientPanel1);
            this.Name = "BorrowerSheetMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BorrowerSheetMenu";
            this.alphaGradientPanel1.ResumeLayout(false);
            this.alphaGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.AlphaGradientPanel alphaGradientPanel1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton icnPrint;
        private FontAwesome.Sharp.IconButton icnReturn;
        private FontAwesome.Sharp.IconButton icnBorrow;
        private FontAwesome.Sharp.IconButton icnTransfer;
    }
}