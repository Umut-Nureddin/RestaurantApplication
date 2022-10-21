namespace HiPOS
{
    partial class frnFis
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
            this.RepoViewFis = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RepoViewFis
            // 
            this.RepoViewFis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepoViewFis.LocalReport.ReportEmbeddedResource = "HiPOS._Fis.rdlc";
            this.RepoViewFis.Location = new System.Drawing.Point(0, 0);
            this.RepoViewFis.Name = "RepoViewFis";
            this.RepoViewFis.ServerReport.BearerToken = null;
            this.RepoViewFis.Size = new System.Drawing.Size(800, 450);
            this.RepoViewFis.TabIndex = 0;
            // 
            // frnFis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RepoViewFis);
            this.Name = "frnFis";
            this.Text = "frnFis";
            this.Load += new System.EventHandler(this.frnFis_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer RepoViewFis;
    }
}