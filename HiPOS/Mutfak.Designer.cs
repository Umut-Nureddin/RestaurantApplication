namespace HiPOS
{
    partial class frmMutfak
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.matCardHazirlamaSeviyesi = new MaterialSkin.Controls.MaterialCard();
            this.btnMutfak = new FontAwesome.Sharp.IconButton();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnMutfak);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1408, 63);
            this.materialCard1.TabIndex = 7;
            // 
            // matCardHazirlamaSeviyesi
            // 
            this.matCardHazirlamaSeviyesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.matCardHazirlamaSeviyesi.Depth = 0;
            this.matCardHazirlamaSeviyesi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.matCardHazirlamaSeviyesi.Location = new System.Drawing.Point(90, 142);
            this.matCardHazirlamaSeviyesi.Margin = new System.Windows.Forms.Padding(14);
            this.matCardHazirlamaSeviyesi.MouseState = MaterialSkin.MouseState.HOVER;
            this.matCardHazirlamaSeviyesi.Name = "matCardHazirlamaSeviyesi";
            this.matCardHazirlamaSeviyesi.Padding = new System.Windows.Forms.Padding(14);
            this.matCardHazirlamaSeviyesi.Size = new System.Drawing.Size(1198, 476);
            this.matCardHazirlamaSeviyesi.TabIndex = 8;
            // 
            // btnMutfak
            // 
            this.btnMutfak.FlatAppearance.BorderSize = 0;
            this.btnMutfak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMutfak.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMutfak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnMutfak.IconChar = FontAwesome.Sharp.IconChar.KitchenSet;
            this.btnMutfak.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnMutfak.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMutfak.Location = new System.Drawing.Point(17, 12);
            this.btnMutfak.Name = "btnMutfak";
            this.btnMutfak.Size = new System.Drawing.Size(164, 46);
            this.btnMutfak.TabIndex = 2;
            this.btnMutfak.Text = "Mutfak";
            this.btnMutfak.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMutfak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMutfak.UseVisualStyleBackColor = true;
            // 
            // frmMutfak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 738);
            this.Controls.Add(this.matCardHazirlamaSeviyesi);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmMutfak";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "Mutfak";
            this.Load += new System.EventHandler(this.frmMutfak_Load);
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private FontAwesome.Sharp.IconButton btnMutfak;
        private MaterialSkin.Controls.MaterialCard matCardHazirlamaSeviyesi;
    }
}