namespace FMIS
{
    partial class BudgetTrackReportViewer
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
            this.budgetTrackViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.BudgetTrack1 = new FMIS.Report.BudgetTrack();
            this.SuspendLayout();
            // 
            // budgetTrackViewer
            // 
            this.budgetTrackViewer.ActiveViewIndex = 0;
            this.budgetTrackViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.budgetTrackViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.budgetTrackViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.budgetTrackViewer.Location = new System.Drawing.Point(0, 0);
            this.budgetTrackViewer.Name = "budgetTrackViewer";
            this.budgetTrackViewer.ReportSource = this.BudgetTrack1;
            this.budgetTrackViewer.Size = new System.Drawing.Size(1381, 733);
            this.budgetTrackViewer.TabIndex = 0;
            this.budgetTrackViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // BudgetTrackReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 733);
            this.Controls.Add(this.budgetTrackViewer);
            this.Name = "BudgetTrackReportViewer";
            this.Text = "BudgetTrackReportViewer";
            this.Load += new System.EventHandler(this.BudgetTrackReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer budgetTrackViewer;
        private Report.BudgetTrack BudgetTrack1;
    }
}