
namespace HiPOS
{
    partial class Login
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
            this.btnGiris = new MaterialSkin.Controls.MaterialButton();
            this.Keytext = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PinTxta = new System.Windows.Forms.TextBox();
            this.Sifretxta = new System.Windows.Forms.TextBox();
            this.PinLbl = new System.Windows.Forms.Label();
            this.SifreLbl = new System.Windows.Forms.Label();
            this.GirisBtn2 = new System.Windows.Forms.Button();
            this.KapaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGiris.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGiris.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGiris.Depth = 0;
            this.btnGiris.HighEmphasis = true;
            this.btnGiris.Icon = null;
            this.btnGiris.Location = new System.Drawing.Point(439, 373);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGiris.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGiris.Size = new System.Drawing.Size(64, 36);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGiris.UseAccentColor = false;
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // Keytext
            // 
            this.Keytext.AnimateReadOnly = false;
            this.Keytext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Keytext.Depth = 0;
            this.Keytext.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Keytext.LeadingIcon = null;
            this.Keytext.Location = new System.Drawing.Point(339, 320);
            this.Keytext.MaxLength = 50;
            this.Keytext.MouseState = MaterialSkin.MouseState.OUT;
            this.Keytext.Multiline = false;
            this.Keytext.Name = "Keytext";
            this.Keytext.Size = new System.Drawing.Size(271, 50);
            this.Keytext.TabIndex = 0;
            this.Keytext.Text = "";
            this.Keytext.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::HiPOS.Properties.Resources.HiPOS;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(934, 447);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PinTxta
            // 
            this.PinTxta.Location = new System.Drawing.Point(66, 212);
            this.PinTxta.Name = "PinTxta";
            this.PinTxta.Size = new System.Drawing.Size(186, 20);
            this.PinTxta.TabIndex = 13;
            // 
            // Sifretxta
            // 
            this.Sifretxta.Location = new System.Drawing.Point(66, 246);
            this.Sifretxta.Name = "Sifretxta";
            this.Sifretxta.PasswordChar = '*';
            this.Sifretxta.Size = new System.Drawing.Size(186, 20);
            this.Sifretxta.TabIndex = 14;
            // 
            // PinLbl
            // 
            this.PinLbl.AutoSize = true;
            this.PinLbl.BackColor = System.Drawing.Color.White;
            this.PinLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PinLbl.Location = new System.Drawing.Point(27, 212);
            this.PinLbl.Name = "PinLbl";
            this.PinLbl.Size = new System.Drawing.Size(33, 13);
            this.PinLbl.TabIndex = 15;
            this.PinLbl.Text = "Pin :";
            // 
            // SifreLbl
            // 
            this.SifreLbl.AutoSize = true;
            this.SifreLbl.BackColor = System.Drawing.Color.White;
            this.SifreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SifreLbl.Location = new System.Drawing.Point(28, 249);
            this.SifreLbl.Name = "SifreLbl";
            this.SifreLbl.Size = new System.Drawing.Size(37, 13);
            this.SifreLbl.TabIndex = 16;
            this.SifreLbl.Text = "Şifre:";
            // 
            // GirisBtn2
            // 
            this.GirisBtn2.Location = new System.Drawing.Point(177, 281);
            this.GirisBtn2.Name = "GirisBtn2";
            this.GirisBtn2.Size = new System.Drawing.Size(75, 23);
            this.GirisBtn2.TabIndex = 17;
            this.GirisBtn2.Text = "Giriş";
            this.GirisBtn2.UseVisualStyleBackColor = true;
            this.GirisBtn2.Click += new System.EventHandler(this.GirisBtn2_Click_1);
            // 
            // KapaBtn
            // 
            this.KapaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KapaBtn.FlatAppearance.BorderSize = 0;
            this.KapaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KapaBtn.Image = global::HiPOS.Properties.Resources.cross_circle;
            this.KapaBtn.Location = new System.Drawing.Point(861, 14);
            this.KapaBtn.Name = "KapaBtn";
            this.KapaBtn.Size = new System.Drawing.Size(55, 44);
            this.KapaBtn.TabIndex = 18;
            this.KapaBtn.UseVisualStyleBackColor = false;
            this.KapaBtn.Click += new System.EventHandler(this.KapaBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.KapaBtn);
            this.Controls.Add(this.GirisBtn2);
            this.Controls.Add(this.SifreLbl);
            this.Controls.Add(this.PinLbl);
            this.Controls.Add(this.Sifretxta);
            this.Controls.Add(this.PinTxta);
            this.Controls.Add(this.Keytext);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.pictureBox1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnGiris;
        private MaterialSkin.Controls.MaterialTextBox Keytext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PinTxta;
        private System.Windows.Forms.TextBox Sifretxta;
        private System.Windows.Forms.Label PinLbl;
        private System.Windows.Forms.Label SifreLbl;
        private System.Windows.Forms.Button GirisBtn2;
        private System.Windows.Forms.Button KapaBtn;
    }
}