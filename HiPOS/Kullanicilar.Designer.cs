namespace HiPOS
{
    partial class frmKullanicilar
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
            this.ıconButton1 = new FontAwesome.Sharp.IconButton();
            this.MatCardYeniKullaniciEkle = new MaterialSkin.Controls.MaterialCard();
            this.PanelKullan2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnYeniGorevEkle = new FontAwesome.Sharp.IconButton();
            this.btnYeniKullaniciEkleKapa = new System.Windows.Forms.Button();
            this.cmbGorev = new System.Windows.Forms.ComboBox();
            this.lblGorev = new MaterialSkin.Controls.MaterialLabel();
            this.SwitchYetki = new MaterialSkin.Controls.MaterialSwitch();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.btnKullaniciOlustur = new MaterialSkin.Controls.MaterialButton();
            this.lblPinOlustur = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmailOlustur = new MaterialSkin.Controls.MaterialLabel();
            this.btnKullaniciGuncelle = new MaterialSkin.Controls.MaterialButton();
            this.lblTelefonOlustur = new MaterialSkin.Controls.MaterialLabel();
            this.btnKullaniciSil = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txtKullaniciPin = new MaterialSkin.Controls.MaterialTextBox();
            this.txtKullaniciTelefon = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.txtKullaniciPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtKullaniciAdSoyad = new MaterialSkin.Controls.MaterialTextBox();
            this.txtKullaniciEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.lblSifreOlustur = new MaterialSkin.Controls.MaterialLabel();
            this.matCardKullanicilar = new MaterialSkin.Controls.MaterialCard();
            this.PanelKullan1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGVKullanici = new System.Windows.Forms.DataGridView();
            this.duzenle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.radioBtnAktifCalisanlar = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioBtnButunCalisanlar = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblKullaniciID = new System.Windows.Forms.Label();
            this.matCardYeniGorev = new MaterialSkin.Controls.MaterialCard();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.YeniGBtn = new MaterialSkin.Controls.MaterialButton();
            this.GUpdateBtn = new MaterialSkin.Controls.MaterialButton();
            this.GDeleteBtn = new MaterialSkin.Controls.MaterialButton();
            this.TxtGorev = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbGorevEk = new System.Windows.Forms.ComboBox();
            this.lblGAdi = new MaterialSkin.Controls.MaterialLabel();
            this.btnYeniKulaniciEkle = new System.Windows.Forms.Button();
            this.materialCard1.SuspendLayout();
            this.MatCardYeniKullaniciEkle.SuspendLayout();
            this.PanelKullan2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.matCardKullanicilar.SuspendLayout();
            this.PanelKullan1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVKullanici)).BeginInit();
            this.matCardYeniGorev.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.ıconButton1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1386, 63);
            this.materialCard1.TabIndex = 7;
            // 
            // ıconButton1
            // 
            this.ıconButton1.FlatAppearance.BorderSize = 0;
            this.ıconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ıconButton1.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.ıconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ıconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton1.Location = new System.Drawing.Point(12, 12);
            this.ıconButton1.Name = "ıconButton1";
            this.ıconButton1.Size = new System.Drawing.Size(174, 46);
            this.ıconButton1.TabIndex = 2;
            this.ıconButton1.Text = "Kullanıcılar";
            this.ıconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ıconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton1.UseVisualStyleBackColor = true;
            // 
            // MatCardYeniKullaniciEkle
            // 
            this.MatCardYeniKullaniciEkle.AutoScroll = true;
            this.MatCardYeniKullaniciEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MatCardYeniKullaniciEkle.Controls.Add(this.PanelKullan2);
            this.MatCardYeniKullaniciEkle.Depth = 0;
            this.MatCardYeniKullaniciEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MatCardYeniKullaniciEkle.Location = new System.Drawing.Point(386, 91);
            this.MatCardYeniKullaniciEkle.Margin = new System.Windows.Forms.Padding(14);
            this.MatCardYeniKullaniciEkle.MouseState = MaterialSkin.MouseState.HOVER;
            this.MatCardYeniKullaniciEkle.Name = "MatCardYeniKullaniciEkle";
            this.MatCardYeniKullaniciEkle.Padding = new System.Windows.Forms.Padding(14);
            this.MatCardYeniKullaniciEkle.Size = new System.Drawing.Size(813, 624);
            this.MatCardYeniKullaniciEkle.TabIndex = 25;
            // 
            // PanelKullan2
            // 
            this.PanelKullan2.AutoScroll = true;
            this.PanelKullan2.ColumnCount = 1;
            this.PanelKullan2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelKullan2.Controls.Add(this.panel6, 0, 0);
            this.PanelKullan2.Controls.Add(this.tableLayoutPanel11, 0, 1);
            this.PanelKullan2.Location = new System.Drawing.Point(14, 14);
            this.PanelKullan2.Name = "PanelKullan2";
            this.PanelKullan2.RowCount = 2;
            this.PanelKullan2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.74468F));
            this.PanelKullan2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.25532F));
            this.PanelKullan2.Size = new System.Drawing.Size(800, 470);
            this.PanelKullan2.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnYeniGorevEkle);
            this.panel6.Controls.Add(this.btnYeniKullaniciEkleKapa);
            this.panel6.Controls.Add(this.cmbGorev);
            this.panel6.Controls.Add(this.lblGorev);
            this.panel6.Controls.Add(this.SwitchYetki);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(794, 161);
            this.panel6.TabIndex = 19;
            // 
            // btnYeniGorevEkle
            // 
            this.btnYeniGorevEkle.BackColor = System.Drawing.Color.White;
            this.btnYeniGorevEkle.FlatAppearance.BorderSize = 0;
            this.btnYeniGorevEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniGorevEkle.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnYeniGorevEkle.IconColor = System.Drawing.Color.Black;
            this.btnYeniGorevEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnYeniGorevEkle.IconSize = 24;
            this.btnYeniGorevEkle.Location = new System.Drawing.Point(569, 41);
            this.btnYeniGorevEkle.Name = "btnYeniGorevEkle";
            this.btnYeniGorevEkle.Size = new System.Drawing.Size(49, 35);
            this.btnYeniGorevEkle.TabIndex = 16;
            this.btnYeniGorevEkle.UseVisualStyleBackColor = false;
            this.btnYeniGorevEkle.Click += new System.EventHandler(this.btnYeniGorevEkle_Click);
            // 
            // btnYeniKullaniciEkleKapa
            // 
            this.btnYeniKullaniciEkleKapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniKullaniciEkleKapa.FlatAppearance.BorderSize = 0;
            this.btnYeniKullaniciEkleKapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKullaniciEkleKapa.Image = global::HiPOS.Properties.Resources.cross_circle;
            this.btnYeniKullaniciEkleKapa.Location = new System.Drawing.Point(716, 3);
            this.btnYeniKullaniciEkleKapa.Name = "btnYeniKullaniciEkleKapa";
            this.btnYeniKullaniciEkleKapa.Size = new System.Drawing.Size(75, 54);
            this.btnYeniKullaniciEkleKapa.TabIndex = 15;
            this.btnYeniKullaniciEkleKapa.UseVisualStyleBackColor = false;
            this.btnYeniKullaniciEkleKapa.Click += new System.EventHandler(this.btnYeniKullaniciEkleKapa_Click);
            // 
            // cmbGorev
            // 
            this.cmbGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cmbGorev.FormattingEnabled = true;
            this.cmbGorev.Location = new System.Drawing.Point(110, 43);
            this.cmbGorev.Name = "cmbGorev";
            this.cmbGorev.Size = new System.Drawing.Size(453, 33);
            this.cmbGorev.TabIndex = 14;
            this.cmbGorev.SelectedIndexChanged += new System.EventHandler(this.cmbGorev_SelectedIndexChanged);
            // 
            // lblGorev
            // 
            this.lblGorev.AutoSize = true;
            this.lblGorev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblGorev.Depth = 0;
            this.lblGorev.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGorev.ForeColor = System.Drawing.Color.Gray;
            this.lblGorev.Location = new System.Drawing.Point(113, 21);
            this.lblGorev.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGorev.Name = "lblGorev";
            this.lblGorev.Size = new System.Drawing.Size(49, 19);
            this.lblGorev.TabIndex = 6;
            this.lblGorev.Text = "Görev*";
            // 
            // SwitchYetki
            // 
            this.SwitchYetki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SwitchYetki.AutoSize = true;
            this.SwitchYetki.Depth = 0;
            this.SwitchYetki.Location = new System.Drawing.Point(531, 92);
            this.SwitchYetki.Margin = new System.Windows.Forms.Padding(0);
            this.SwitchYetki.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SwitchYetki.MouseState = MaterialSkin.MouseState.HOVER;
            this.SwitchYetki.Name = "SwitchYetki";
            this.SwitchYetki.Ripple = true;
            this.SwitchYetki.Size = new System.Drawing.Size(213, 37);
            this.SwitchYetki.TabIndex = 13;
            this.SwitchYetki.Text = "ManagerID Kullanıcısı";
            this.SwitchYetki.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.59477F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.45098F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.86928F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.08497F));
            this.tableLayoutPanel11.Controls.Add(this.btnKullaniciOlustur, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.lblPinOlustur, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.lblEmailOlustur, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.btnKullaniciGuncelle, 2, 3);
            this.tableLayoutPanel11.Controls.Add(this.lblTelefonOlustur, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.btnKullaniciSil, 3, 3);
            this.tableLayoutPanel11.Controls.Add(this.materialLabel6, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.txtKullaniciPin, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.txtKullaniciTelefon, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.txtKullaniciPassword, 3, 2);
            this.tableLayoutPanel11.Controls.Add(this.txtKullaniciAdSoyad, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.txtKullaniciEmail, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.lblSifreOlustur, 2, 2);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 170);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(794, 297);
            this.tableLayoutPanel11.TabIndex = 18;
            // 
            // btnKullaniciOlustur
            // 
            this.btnKullaniciOlustur.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKullaniciOlustur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKullaniciOlustur.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKullaniciOlustur.Depth = 0;
            this.btnKullaniciOlustur.HighEmphasis = true;
            this.btnKullaniciOlustur.Icon = null;
            this.btnKullaniciOlustur.Location = new System.Drawing.Point(183, 188);
            this.btnKullaniciOlustur.Margin = new System.Windows.Forms.Padding(20);
            this.btnKullaniciOlustur.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKullaniciOlustur.Name = "btnKullaniciOlustur";
            this.btnKullaniciOlustur.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKullaniciOlustur.Size = new System.Drawing.Size(64, 36);
            this.btnKullaniciOlustur.TabIndex = 12;
            this.btnKullaniciOlustur.Text = "Ekle";
            this.btnKullaniciOlustur.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKullaniciOlustur.UseAccentColor = false;
            this.btnKullaniciOlustur.UseVisualStyleBackColor = true;
            this.btnKullaniciOlustur.Click += new System.EventHandler(this.btnKullaniciOlustur_Click);
            // 
            // lblPinOlustur
            // 
            this.lblPinOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPinOlustur.AutoSize = true;
            this.lblPinOlustur.Depth = 0;
            this.lblPinOlustur.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPinOlustur.Location = new System.Drawing.Point(69, 149);
            this.lblPinOlustur.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPinOlustur.Name = "lblPinOlustur";
            this.lblPinOlustur.Size = new System.Drawing.Size(35, 19);
            this.lblPinOlustur.TabIndex = 11;
            this.lblPinOlustur.Text = " Pin*";
            // 
            // lblEmailOlustur
            // 
            this.lblEmailOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmailOlustur.AutoSize = true;
            this.lblEmailOlustur.Depth = 0;
            this.lblEmailOlustur.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEmailOlustur.Location = new System.Drawing.Point(429, 93);
            this.lblEmailOlustur.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmailOlustur.Name = "lblEmailOlustur";
            this.lblEmailOlustur.Size = new System.Drawing.Size(49, 19);
            this.lblEmailOlustur.TabIndex = 8;
            this.lblEmailOlustur.Text = " E-mail";
            // 
            // btnKullaniciGuncelle
            // 
            this.btnKullaniciGuncelle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKullaniciGuncelle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKullaniciGuncelle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKullaniciGuncelle.Depth = 0;
            this.btnKullaniciGuncelle.HighEmphasis = true;
            this.btnKullaniciGuncelle.Icon = null;
            this.btnKullaniciGuncelle.Location = new System.Drawing.Point(355, 188);
            this.btnKullaniciGuncelle.Margin = new System.Windows.Forms.Padding(20);
            this.btnKullaniciGuncelle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKullaniciGuncelle.Name = "btnKullaniciGuncelle";
            this.btnKullaniciGuncelle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKullaniciGuncelle.Size = new System.Drawing.Size(94, 36);
            this.btnKullaniciGuncelle.TabIndex = 15;
            this.btnKullaniciGuncelle.Text = "Güncelle";
            this.btnKullaniciGuncelle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKullaniciGuncelle.UseAccentColor = false;
            this.btnKullaniciGuncelle.UseVisualStyleBackColor = true;
            this.btnKullaniciGuncelle.Click += new System.EventHandler(this.btnKullaniciGuncelle_Click);
            // 
            // lblTelefonOlustur
            // 
            this.lblTelefonOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefonOlustur.AutoSize = true;
            this.lblTelefonOlustur.Depth = 0;
            this.lblTelefonOlustur.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTelefonOlustur.Location = new System.Drawing.Point(49, 93);
            this.lblTelefonOlustur.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTelefonOlustur.Name = "lblTelefonOlustur";
            this.lblTelefonOlustur.Size = new System.Drawing.Size(55, 19);
            this.lblTelefonOlustur.TabIndex = 9;
            this.lblTelefonOlustur.Text = "Telefon";
            // 
            // btnKullaniciSil
            // 
            this.btnKullaniciSil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKullaniciSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKullaniciSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKullaniciSil.Depth = 0;
            this.btnKullaniciSil.HighEmphasis = true;
            this.btnKullaniciSil.Icon = null;
            this.btnKullaniciSil.Location = new System.Drawing.Point(605, 188);
            this.btnKullaniciSil.Margin = new System.Windows.Forms.Padding(20);
            this.btnKullaniciSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKullaniciSil.Name = "btnKullaniciSil";
            this.btnKullaniciSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKullaniciSil.Size = new System.Drawing.Size(64, 36);
            this.btnKullaniciSil.TabIndex = 16;
            this.btnKullaniciSil.Text = "Sil";
            this.btnKullaniciSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKullaniciSil.UseAccentColor = false;
            this.btnKullaniciSil.UseVisualStyleBackColor = true;
            this.btnKullaniciSil.Click += new System.EventHandler(this.btnKullaniciSil_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(28, 37);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(76, 19);
            this.materialLabel6.TabIndex = 7;
            this.materialLabel6.Text = "Ad Soyad*";
            // 
            // txtKullaniciPin
            // 
            this.txtKullaniciPin.AnimateReadOnly = false;
            this.txtKullaniciPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciPin.Depth = 0;
            this.txtKullaniciPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKullaniciPin.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciPin.LeadingIcon = null;
            this.txtKullaniciPin.Location = new System.Drawing.Point(110, 115);
            this.txtKullaniciPin.MaxLength = 50;
            this.txtKullaniciPin.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciPin.Multiline = false;
            this.txtKullaniciPin.Name = "txtKullaniciPin";
            this.txtKullaniciPin.Size = new System.Drawing.Size(211, 50);
            this.txtKullaniciPin.TabIndex = 4;
            this.txtKullaniciPin.Text = "";
            this.txtKullaniciPin.TrailingIcon = null;
            // 
            // txtKullaniciTelefon
            // 
            this.txtKullaniciTelefon.AllowPromptAsInput = true;
            this.txtKullaniciTelefon.AnimateReadOnly = false;
            this.txtKullaniciTelefon.AsciiOnly = false;
            this.txtKullaniciTelefon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtKullaniciTelefon.BeepOnError = false;
            this.txtKullaniciTelefon.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtKullaniciTelefon.Depth = 0;
            this.txtKullaniciTelefon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKullaniciTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciTelefon.HidePromptOnLeave = false;
            this.txtKullaniciTelefon.HideSelection = true;
            this.txtKullaniciTelefon.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtKullaniciTelefon.LeadingIcon = null;
            this.txtKullaniciTelefon.Location = new System.Drawing.Point(110, 59);
            this.txtKullaniciTelefon.Mask = "";
            this.txtKullaniciTelefon.MaxLength = 32767;
            this.txtKullaniciTelefon.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciTelefon.Name = "txtKullaniciTelefon";
            this.txtKullaniciTelefon.PasswordChar = '\0';
            this.txtKullaniciTelefon.PrefixSuffixText = null;
            this.txtKullaniciTelefon.PromptChar = '_';
            this.txtKullaniciTelefon.ReadOnly = false;
            this.txtKullaniciTelefon.RejectInputOnFirstFailure = false;
            this.txtKullaniciTelefon.ResetOnPrompt = true;
            this.txtKullaniciTelefon.ResetOnSpace = true;
            this.txtKullaniciTelefon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKullaniciTelefon.SelectedText = "";
            this.txtKullaniciTelefon.SelectionLength = 0;
            this.txtKullaniciTelefon.SelectionStart = 0;
            this.txtKullaniciTelefon.ShortcutsEnabled = true;
            this.txtKullaniciTelefon.Size = new System.Drawing.Size(211, 48);
            this.txtKullaniciTelefon.SkipLiterals = true;
            this.txtKullaniciTelefon.TabIndex = 14;
            this.txtKullaniciTelefon.TabStop = false;
            this.txtKullaniciTelefon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKullaniciTelefon.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtKullaniciTelefon.TrailingIcon = null;
            this.txtKullaniciTelefon.UseSystemPasswordChar = false;
            this.txtKullaniciTelefon.ValidatingType = null;
            // 
            // txtKullaniciPassword
            // 
            this.txtKullaniciPassword.AnimateReadOnly = false;
            this.txtKullaniciPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciPassword.Depth = 0;
            this.txtKullaniciPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKullaniciPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciPassword.LeadingIcon = null;
            this.txtKullaniciPassword.Location = new System.Drawing.Point(484, 115);
            this.txtKullaniciPassword.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtKullaniciPassword.MaxLength = 50;
            this.txtKullaniciPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciPassword.Multiline = false;
            this.txtKullaniciPassword.Name = "txtKullaniciPassword";
            this.txtKullaniciPassword.Password = true;
            this.txtKullaniciPassword.Size = new System.Drawing.Size(260, 50);
            this.txtKullaniciPassword.TabIndex = 5;
            this.txtKullaniciPassword.Text = "";
            this.txtKullaniciPassword.TrailingIcon = null;
            // 
            // txtKullaniciAdSoyad
            // 
            this.txtKullaniciAdSoyad.AnimateReadOnly = false;
            this.txtKullaniciAdSoyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel11.SetColumnSpan(this.txtKullaniciAdSoyad, 3);
            this.txtKullaniciAdSoyad.Depth = 0;
            this.txtKullaniciAdSoyad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKullaniciAdSoyad.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciAdSoyad.LeadingIcon = null;
            this.txtKullaniciAdSoyad.Location = new System.Drawing.Point(110, 3);
            this.txtKullaniciAdSoyad.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtKullaniciAdSoyad.MaxLength = 50;
            this.txtKullaniciAdSoyad.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciAdSoyad.Multiline = false;
            this.txtKullaniciAdSoyad.Name = "txtKullaniciAdSoyad";
            this.txtKullaniciAdSoyad.Size = new System.Drawing.Size(634, 50);
            this.txtKullaniciAdSoyad.TabIndex = 17;
            this.txtKullaniciAdSoyad.Text = "";
            this.txtKullaniciAdSoyad.TrailingIcon = null;
            // 
            // txtKullaniciEmail
            // 
            this.txtKullaniciEmail.AnimateReadOnly = false;
            this.txtKullaniciEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciEmail.Depth = 0;
            this.txtKullaniciEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKullaniciEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciEmail.LeadingIcon = null;
            this.txtKullaniciEmail.Location = new System.Drawing.Point(484, 59);
            this.txtKullaniciEmail.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtKullaniciEmail.MaxLength = 50;
            this.txtKullaniciEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciEmail.Multiline = false;
            this.txtKullaniciEmail.Name = "txtKullaniciEmail";
            this.txtKullaniciEmail.Size = new System.Drawing.Size(260, 50);
            this.txtKullaniciEmail.TabIndex = 2;
            this.txtKullaniciEmail.Text = "";
            this.txtKullaniciEmail.TrailingIcon = null;
            // 
            // lblSifreOlustur
            // 
            this.lblSifreOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSifreOlustur.AutoSize = true;
            this.lblSifreOlustur.Depth = 0;
            this.lblSifreOlustur.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSifreOlustur.Location = new System.Drawing.Point(437, 149);
            this.lblSifreOlustur.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSifreOlustur.Name = "lblSifreOlustur";
            this.lblSifreOlustur.Size = new System.Drawing.Size(41, 19);
            this.lblSifreOlustur.TabIndex = 10;
            this.lblSifreOlustur.Text = "Şifre*";
            // 
            // matCardKullanicilar
            // 
            this.matCardKullanicilar.AutoScroll = true;
            this.matCardKullanicilar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.matCardKullanicilar.Controls.Add(this.PanelKullan1);
            this.matCardKullanicilar.Depth = 0;
            this.matCardKullanicilar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.matCardKullanicilar.Location = new System.Drawing.Point(158, 91);
            this.matCardKullanicilar.Margin = new System.Windows.Forms.Padding(14);
            this.matCardKullanicilar.MouseState = MaterialSkin.MouseState.HOVER;
            this.matCardKullanicilar.Name = "matCardKullanicilar";
            this.matCardKullanicilar.Padding = new System.Windows.Forms.Padding(14);
            this.matCardKullanicilar.Size = new System.Drawing.Size(186, 142);
            this.matCardKullanicilar.TabIndex = 26;
            // 
            // PanelKullan1
            // 
            this.PanelKullan1.ColumnCount = 2;
            this.PanelKullan1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelKullan1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelKullan1.Controls.Add(this.DGVKullanici, 0, 1);
            this.PanelKullan1.Controls.Add(this.radioBtnAktifCalisanlar, 1, 0);
            this.PanelKullan1.Controls.Add(this.radioBtnButunCalisanlar, 0, 0);
            this.PanelKullan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKullan1.Location = new System.Drawing.Point(14, 14);
            this.PanelKullan1.Name = "PanelKullan1";
            this.PanelKullan1.RowCount = 2;
            this.PanelKullan1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.725159F));
            this.PanelKullan1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.27484F));
            this.PanelKullan1.Size = new System.Drawing.Size(158, 114);
            this.PanelKullan1.TabIndex = 0;
            // 
            // DGVKullanici
            // 
            this.DGVKullanici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVKullanici.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVKullanici.BackgroundColor = System.Drawing.Color.White;
            this.DGVKullanici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVKullanici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.duzenle});
            this.PanelKullan1.SetColumnSpan(this.DGVKullanici, 2);
            this.DGVKullanici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVKullanici.Location = new System.Drawing.Point(10, 14);
            this.DGVKullanici.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.DGVKullanici.Name = "DGVKullanici";
            this.DGVKullanici.RowHeadersVisible = false;
            this.DGVKullanici.Size = new System.Drawing.Size(145, 97);
            this.DGVKullanici.TabIndex = 17;
            this.DGVKullanici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVKullanici_CellContentClick);
            this.DGVKullanici.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVKullanici_CellPainting);
            // 
            // duzenle
            // 
            this.duzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duzenle.HeaderText = "Düzenle";
            this.duzenle.Name = "duzenle";
            this.duzenle.Text = "Düzenle";
            this.duzenle.ToolTipText = "Seçili sıradaki kullanıcıyı düzenlemek veya silmek için tıklayın";
            // 
            // radioBtnAktifCalisanlar
            // 
            this.radioBtnAktifCalisanlar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioBtnAktifCalisanlar.AutoSize = true;
            this.radioBtnAktifCalisanlar.Depth = 0;
            this.radioBtnAktifCalisanlar.Location = new System.Drawing.Point(79, 0);
            this.radioBtnAktifCalisanlar.Margin = new System.Windows.Forms.Padding(0);
            this.radioBtnAktifCalisanlar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioBtnAktifCalisanlar.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioBtnAktifCalisanlar.Name = "radioBtnAktifCalisanlar";
            this.radioBtnAktifCalisanlar.Ripple = true;
            this.radioBtnAktifCalisanlar.Size = new System.Drawing.Size(79, 11);
            this.radioBtnAktifCalisanlar.TabIndex = 16;
            this.radioBtnAktifCalisanlar.TabStop = true;
            this.radioBtnAktifCalisanlar.Text = "Sadece Aktif Olanlar";
            this.radioBtnAktifCalisanlar.UseVisualStyleBackColor = true;
            this.radioBtnAktifCalisanlar.CheckedChanged += new System.EventHandler(this.radioBtnAktifCalisanlar_CheckedChanged);
            // 
            // radioBtnButunCalisanlar
            // 
            this.radioBtnButunCalisanlar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioBtnButunCalisanlar.AutoSize = true;
            this.radioBtnButunCalisanlar.Depth = 0;
            this.radioBtnButunCalisanlar.Location = new System.Drawing.Point(0, 0);
            this.radioBtnButunCalisanlar.Margin = new System.Windows.Forms.Padding(0);
            this.radioBtnButunCalisanlar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioBtnButunCalisanlar.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioBtnButunCalisanlar.Name = "radioBtnButunCalisanlar";
            this.radioBtnButunCalisanlar.Ripple = true;
            this.radioBtnButunCalisanlar.Size = new System.Drawing.Size(79, 11);
            this.radioBtnButunCalisanlar.TabIndex = 15;
            this.radioBtnButunCalisanlar.TabStop = true;
            this.radioBtnButunCalisanlar.Text = "Bütün Çalışanlar";
            this.radioBtnButunCalisanlar.UseVisualStyleBackColor = true;
            this.radioBtnButunCalisanlar.CheckedChanged += new System.EventHandler(this.radioBtnButunCalisanlar_CheckedChanged);
            // 
            // lblKullaniciID
            // 
            this.lblKullaniciID.AutoSize = true;
            this.lblKullaniciID.Location = new System.Drawing.Point(70, 121);
            this.lblKullaniciID.Name = "lblKullaniciID";
            this.lblKullaniciID.Size = new System.Drawing.Size(35, 13);
            this.lblKullaniciID.TabIndex = 28;
            this.lblKullaniciID.Text = "label1";
            this.lblKullaniciID.Visible = false;
            // 
            // matCardYeniGorev
            // 
            this.matCardYeniGorev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.matCardYeniGorev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matCardYeniGorev.Controls.Add(this.button1);
            this.matCardYeniGorev.Controls.Add(this.tableLayoutPanel1);
            this.matCardYeniGorev.Depth = 0;
            this.matCardYeniGorev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.matCardYeniGorev.Location = new System.Drawing.Point(111, 91);
            this.matCardYeniGorev.Margin = new System.Windows.Forms.Padding(14);
            this.matCardYeniGorev.MouseState = MaterialSkin.MouseState.HOVER;
            this.matCardYeniGorev.Name = "matCardYeniGorev";
            this.matCardYeniGorev.Padding = new System.Windows.Forms.Padding(14);
            this.matCardYeniGorev.Size = new System.Drawing.Size(27, 352);
            this.matCardYeniGorev.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::HiPOS.Properties.Resources.cross_circle;
            this.button1.Location = new System.Drawing.Point(-35, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 34);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.55656F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.44344F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Controls.Add(this.YeniGBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.GUpdateBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.GDeleteBtn, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtGorev, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbGorevEk, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGAdi, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.59813F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.40187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 293);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // YeniGBtn
            // 
            this.YeniGBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.YeniGBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.YeniGBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.YeniGBtn.Depth = 0;
            this.YeniGBtn.HighEmphasis = true;
            this.YeniGBtn.Icon = null;
            this.YeniGBtn.Location = new System.Drawing.Point(-88, 241);
            this.YeniGBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.YeniGBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.YeniGBtn.Name = "YeniGBtn";
            this.YeniGBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.YeniGBtn.Size = new System.Drawing.Size(1, 46);
            this.YeniGBtn.TabIndex = 24;
            this.YeniGBtn.Text = "Ekle";
            this.YeniGBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.YeniGBtn.UseAccentColor = false;
            this.YeniGBtn.UseVisualStyleBackColor = true;
            this.YeniGBtn.Click += new System.EventHandler(this.YeniGBtn_Click);
            // 
            // GUpdateBtn
            // 
            this.GUpdateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.GUpdateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GUpdateBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GUpdateBtn.Depth = 0;
            this.GUpdateBtn.HighEmphasis = true;
            this.GUpdateBtn.Icon = null;
            this.GUpdateBtn.Location = new System.Drawing.Point(-226, 241);
            this.GUpdateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GUpdateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GUpdateBtn.Name = "GUpdateBtn";
            this.GUpdateBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GUpdateBtn.Size = new System.Drawing.Size(94, 46);
            this.GUpdateBtn.TabIndex = 25;
            this.GUpdateBtn.Text = "Güncelle";
            this.GUpdateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GUpdateBtn.UseAccentColor = false;
            this.GUpdateBtn.UseVisualStyleBackColor = true;
            this.GUpdateBtn.Click += new System.EventHandler(this.GUpdateBtn_Click);
            // 
            // GDeleteBtn
            // 
            this.GDeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.GDeleteBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GDeleteBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GDeleteBtn.Depth = 0;
            this.GDeleteBtn.HighEmphasis = true;
            this.GDeleteBtn.Icon = null;
            this.GDeleteBtn.Location = new System.Drawing.Point(-87, 241);
            this.GDeleteBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GDeleteBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GDeleteBtn.Name = "GDeleteBtn";
            this.GDeleteBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GDeleteBtn.Size = new System.Drawing.Size(64, 46);
            this.GDeleteBtn.TabIndex = 26;
            this.GDeleteBtn.Text = "Sil";
            this.GDeleteBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GDeleteBtn.UseAccentColor = false;
            this.GDeleteBtn.UseVisualStyleBackColor = true;
            this.GDeleteBtn.Click += new System.EventHandler(this.GDeleteBtn_Click);
            // 
            // TxtGorev
            // 
            this.TxtGorev.AnimateReadOnly = false;
            this.TxtGorev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.TxtGorev, 3);
            this.TxtGorev.Depth = 0;
            this.TxtGorev.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtGorev.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TxtGorev.LeadingIcon = null;
            this.TxtGorev.Location = new System.Drawing.Point(-89, 117);
            this.TxtGorev.MaxLength = 50;
            this.TxtGorev.MouseState = MaterialSkin.MouseState.OUT;
            this.TxtGorev.Multiline = false;
            this.TxtGorev.Name = "TxtGorev";
            this.TxtGorev.Size = new System.Drawing.Size(88, 50);
            this.TxtGorev.TabIndex = 22;
            this.TxtGorev.Text = "";
            this.TxtGorev.TrailingIcon = null;
            // 
            // cmbGorevEk
            // 
            this.cmbGorevEk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbGorevEk, 3);
            this.cmbGorevEk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorevEk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cmbGorevEk.FormattingEnabled = true;
            this.cmbGorevEk.Location = new System.Drawing.Point(-89, 40);
            this.cmbGorevEk.Name = "cmbGorevEk";
            this.cmbGorevEk.Size = new System.Drawing.Size(88, 33);
            this.cmbGorevEk.TabIndex = 27;
            this.cmbGorevEk.SelectedIndexChanged += new System.EventHandler(this.cmbGorevEk_SelectedIndexChanged);
            // 
            // lblGAdi
            // 
            this.lblGAdi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGAdi.AutoSize = true;
            this.lblGAdi.Depth = 0;
            this.lblGAdi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGAdi.Location = new System.Drawing.Point(3, 47);
            this.lblGAdi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGAdi.Name = "lblGAdi";
            this.lblGAdi.Size = new System.Drawing.Size(1, 19);
            this.lblGAdi.TabIndex = 23;
            this.lblGAdi.Text = "Görev:";
            // 
            // btnYeniKulaniciEkle
            // 
            this.btnYeniKulaniciEkle.AccessibleDescription = "";
            this.btnYeniKulaniciEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniKulaniciEkle.FlatAppearance.BorderSize = 0;
            this.btnYeniKulaniciEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKulaniciEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnYeniKulaniciEkle.Image = global::HiPOS.Properties.Resources.plus;
            this.btnYeniKulaniciEkle.Location = new System.Drawing.Point(1179, 65);
            this.btnYeniKulaniciEkle.Name = "btnYeniKulaniciEkle";
            this.btnYeniKulaniciEkle.Size = new System.Drawing.Size(131, 51);
            this.btnYeniKulaniciEkle.TabIndex = 27;
            this.btnYeniKulaniciEkle.Text = " Ekle";
            this.btnYeniKulaniciEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYeniKulaniciEkle.UseVisualStyleBackColor = true;
            this.btnYeniKulaniciEkle.Click += new System.EventHandler(this.btnYeniKulaniciEkle_Click);
            // 
            // frmKullanicilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1386, 772);
            this.Controls.Add(this.matCardYeniGorev);
            this.Controls.Add(this.lblKullaniciID);
            this.Controls.Add(this.btnYeniKulaniciEkle);
            this.Controls.Add(this.MatCardYeniKullaniciEkle);
            this.Controls.Add(this.matCardKullanicilar);
            this.Controls.Add(this.materialCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKullanicilar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanicilar";
            this.Load += new System.EventHandler(this.Kullanicilar_Load);
            this.materialCard1.ResumeLayout(false);
            this.MatCardYeniKullaniciEkle.ResumeLayout(false);
            this.PanelKullan2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.matCardKullanicilar.ResumeLayout(false);
            this.PanelKullan1.ResumeLayout(false);
            this.PanelKullan1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVKullanici)).EndInit();
            this.matCardYeniGorev.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard MatCardYeniKullaniciEkle;
        private System.Windows.Forms.TableLayoutPanel PanelKullan2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnYeniKullaniciEkleKapa;
        private System.Windows.Forms.ComboBox cmbGorev;
        private MaterialSkin.Controls.MaterialLabel lblGorev;
        private MaterialSkin.Controls.MaterialSwitch SwitchYetki;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private MaterialSkin.Controls.MaterialButton btnKullaniciOlustur;
        private MaterialSkin.Controls.MaterialLabel lblPinOlustur;
        private MaterialSkin.Controls.MaterialLabel lblEmailOlustur;
        private MaterialSkin.Controls.MaterialButton btnKullaniciGuncelle;
        private MaterialSkin.Controls.MaterialLabel lblTelefonOlustur;
        private MaterialSkin.Controls.MaterialButton btnKullaniciSil;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciPin;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtKullaniciTelefon;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciPassword;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciAdSoyad;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciEmail;
        private MaterialSkin.Controls.MaterialLabel lblSifreOlustur;
        private MaterialSkin.Controls.MaterialCard matCardKullanicilar;
        private System.Windows.Forms.DataGridView DGVKullanici;
        private System.Windows.Forms.DataGridViewButtonColumn duzenle;
        private MaterialSkin.Controls.MaterialRadioButton radioBtnButunCalisanlar;
        private MaterialSkin.Controls.MaterialRadioButton radioBtnAktifCalisanlar;
        private System.Windows.Forms.Button btnYeniKulaniciEkle;
        private System.Windows.Forms.Label lblKullaniciID;
        private FontAwesome.Sharp.IconButton ıconButton1;
        private FontAwesome.Sharp.IconButton btnYeniGorevEkle;
        private MaterialSkin.Controls.MaterialCard matCardYeniGorev;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTextBox TxtGorev;
        private MaterialSkin.Controls.MaterialLabel lblGAdi;
        private MaterialSkin.Controls.MaterialButton YeniGBtn;
        private MaterialSkin.Controls.MaterialButton GUpdateBtn;
        private MaterialSkin.Controls.MaterialButton GDeleteBtn;
        private System.Windows.Forms.ComboBox cmbGorevEk;
        private System.Windows.Forms.TableLayoutPanel PanelKullan1;
    }
}