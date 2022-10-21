using HiPOS.Class;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiPOS
{
    public partial class frmMasalar : MaterialForm
    {
        Font Normal = new Font("Segoe UI", 10, FontStyle.Bold);

        public int masaid;
        public string masaad;
        bool sifreonaylandimi;
        bool aciksiparisvarmi;
        public int Sipno;

        frmSiparisler frmsip = new frmSiparisler();

        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");

        public frmMasalar()
        {
            InitializeComponent();
        }


        _cmbMasaTransfer classdt = new _cmbMasaTransfer();
        _doldur doldur = new _doldur();



        private void frmMasalar_Load(object sender, EventArgs e)
        {

            MatCardAnaMasalar.Dock = DockStyle.Fill;

            MasaButonDiz();

            timerCanliSaat.Start();

        }

        private void timerCanliSaat_Tick(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToLongDateString();
            txtSaat.Text = DateTime.Now.ToString(" hh:mm:ss tt");

        }

        public void MasaButonDiz()
        {

            baglan.Close();

            baglan.Open();
            SqlDataAdapter Masaadgetir = new SqlDataAdapter("Select MasaID,MasaAD,MasaDurum From Masalars", baglan);
            DataTable dt = new DataTable();
            Masaadgetir.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                CreatMasaBtn(dt);
            }
            baglan.Close();

        }

        private void CreatMasaBtn(DataTable Veri)
        {



            Point[] p = new Point[Veri.Rows.Count];
            string log = "";



            Button[] btn = new Button[Veri.Rows.Count];
            for (int i = 0; i < btn.GetLength(0); i++)
            {

                if (Veri.Rows[i]["MasaAD"].ToString().Length > 0)
                {
                    btn[i] = new Button();
                    btn[i].Height = 150;
                    btn[i].Width = 150;

                    btn[i].Font = new Font("Poppins", 11, FontStyle.Regular);



                    btn[i].Text = Veri.Rows[i]["MasaAD"].ToString();
                    btn[i].TabIndex = Convert.ToInt16(Veri.Rows[i]["MasaID"].ToString());
                    btn[i].Tag = Veri.Rows[i]["MasaDurum"].ToString();

                    if (btn[i].Tag.ToString() == "False")
                    {
                        btn[i].BackColor = Color.White;
                    }
                    else
                    {
                        btn[i].BackColor = Color.FromArgb(231, 76, 60);

                    }




                    p[i] = new Point();
                    p[i].X = i * 83;

                    p[i].Y = 0;

                    log += p.ToString() + "\n";
                    btn[i].PointToClient(p[i]);
                    btn[i].Margin = new Padding(24, 12, 0, 12);
                    btn[i].Show();
                    btn[i].Click += MasaButtonClick;

                }

            }

            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

            FlowLayoutPanel pan = new FlowLayoutPanel();
            pan.Width = Convert.ToInt16(screenWidth) - 100;
            pan.Height = Convert.ToInt16(screenHeight) - 200;
            pan.AutoScroll = true;

            pan.Controls.AddRange(btn);

            MatCardAnaMasalar.Controls.Add(pan);
            MatCardAnaMasalar.AutoScroll = true;
            MatCardAnaMasalar.Dock = DockStyle.Fill;
        }

        private void MasaButtonClick(object sender, EventArgs e)
        {
            MatCardAnaMasalar.Enabled = false;
            MatCardMasaClickKullaniciSorgu.Visible = true;

            MatCardMasaClickKullaniciSorgu.Width = this.Size.Width * 35 / 100;
            MatCardMasaClickKullaniciSorgu.Height = this.Size.Height * 35 / 100;
            MatCardMasaClickKullaniciSorgu.Location = new Point(this.Size.Width / 4 + 175, this.Size.Height / 4);
            SifrePanel.Width = MatCardMasaClickKullaniciSorgu.Width * 8 / 10;
            SifrePanel.Height = MatCardMasaClickKullaniciSorgu.Height * 8 / 10;
            masaad = ((Button)sender).Text;
            masaid = ((Button)sender).TabIndex;

        }


        private void btnMasaClickOnay_Click(object sender, EventArgs e)
        {


            baglan.Close();

            baglan.Open();
            SqlDataAdapter sifreonay = new SqlDataAdapter("Select KullaniciAdSoyad,KullaniciPassword,KullaniciPin,KullaniciID From Kullanicilars", baglan);
            DataTable dt = new DataTable();
            sifreonay.Fill(dt);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (txtMasaClickPin.Text == dt.Rows[i]["KullaniciPin"].ToString() && txtMasaClickSifre.Text == dt.Rows[i]["KullaniciPassword"].ToString())
                {
                    sifreonaylandimi = true;

                    frmSiparisler frmsip = new frmSiparisler();
                    frmsip.MdiParent = this.MdiParent;
                    frmsip.Dock = DockStyle.Fill;
                    this.Hide();
                    frmsip.Show();

                    if (aciksiparisvarmi == false)
                    {

                        Sipno = frmsip.siparisnobul();
                        Sipno++;
                        frmsip.lblSipNo.Text = Sipno.ToString();
                    }



                    baglan.Close();
                    baglan.Open();
                    SqlDataAdapter aciksiparisvarmisorgu = new SqlDataAdapter("Select SipID,Tarih,SiparisTutar,KDVTutar,AraTutar,SipDurum,MasaID,UrunAd,UrunFiyat,UrunAdet,SipNo,UrunID From Siparislers", baglan);
                    DataTable acikdt = new DataTable();
                    aciksiparisvarmisorgu.Fill(acikdt);




                    frmsip.lblkullanici.TabIndex = Convert.ToInt32(dt.Rows[i]["KullaniciID"].ToString());
                    frmsip.lblKullaniciAD.Text = dt.Rows[i]["KullaniciAdSoyad"].ToString();
                    aciksiparisvarmi = false;

                    for (int j = 0; j < acikdt.Rows.Count; j++)
                    {
                        if (Convert.ToBoolean(acikdt.Rows[j]["SipDurum"].ToString()) == true && masaid == Convert.ToInt16(acikdt.Rows[j]["MasaID"].ToString()))
                        {
                            DataGridViewRow row = (DataGridViewRow)frmsip.DGVAdisyon.Rows[0].Clone();
                            row.Cells[2].Value = acikdt.Rows[j]["UrunFiyat"].ToString();
                            row.Cells[1].Value = acikdt.Rows[j]["UrunAd"].ToString();
                            row.Cells[3].Value = acikdt.Rows[j]["UrunAdet"].ToString();
                            row.Cells[4].Value = Convert.ToDecimal(acikdt.Rows[j]["UrunAdet"].ToString()) * Convert.ToDecimal(acikdt.Rows[j]["UrunFiyat"].ToString());
                            row.Cells[5].Value = acikdt.Rows[j]["UrunID"].ToString();
                            row.Cells[8].Value = acikdt.Rows[j]["SipID"].ToString();

                            frmsip.DGVAdisyon.Rows.Add(row);

                            frmsip.lblSipID.Text = acikdt.Rows[j]["SipID"].ToString();
                            frmsip.lblSipNo.Text = acikdt.Rows[j]["SipNo"].ToString();




                            aciksiparisvarmi = true;
                        }
                    }
                    ToplamBulucu();

                    //------------------------------------------------------------------------------------------------------------------------


                    frmsip.siparisload(masaad, masaid);

                    break;
                }

                else
                {
                    sifreonaylandimi = false;
                }

            }



            if (sifreonaylandimi)
            {

            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız...");

            }


            MatCardMasaClickKullaniciSorgu.Visible = false;
            MatCardAnaMasalar.Enabled = true;




        }



        public void ToplamBulucu()
        {
            decimal AsilToplam = 0;
            for (int i = 0; i < frmsip.DGVAdisyon.Rows.Count; i++)
            {
                AsilToplam += Convert.ToDecimal(frmsip.DGVAdisyon.Rows[i].Cells[4].Value);
            }
            frmsip.txtTop.Text = AsilToplam.ToString();

            int kdvtutar = Convert.ToInt32(AsilToplam) * 8 / 100;
            frmsip.txtVergi.Text = kdvtutar.ToString();

            int aratoplam = Convert.ToInt32(AsilToplam) - kdvtutar;
            frmsip.txtaratop.Text = aratoplam.ToString();
        }

        private void btnMasaClickVazgec_Click(object sender, EventArgs e)
        {
            MatCardMasaClickKullaniciSorgu.Visible = false;
            sifreonaylandimi = false;
            MatCardAnaMasalar.Enabled = true;
        }

        private void btnMasaTransfer_Click(object sender, EventArgs e)
        {



            matcardMasaTransfer.Width = this.Size.Width * 80 / 100;
            matcardMasaTransfer.Height = this.Size.Height * 50 / 100;
            matcardMasaTransfer.Location = new Point(this.Size.Width * 5 / 100, this.Size.Height * 20 / 100);

            MatCardAnaMasalar.Enabled = false;
            matcardMasaTransfer.Visible = true;

            string con1 = "SELECT MasaID, MasaAd FROM Masalars where MasaDurum = 'True'";
            string con2 = "SELECT MasaID, MasaAd FROM Masalars where MasaDurum = 'False'";

            DataTable dt1 = new DataTable();
            dt1 = classdt.masasorgu(con1);
            cmbKirmiziMasalar.DataSource = dt1;
            cmbKirmiziMasalar.ValueMember = "MasaID";
            cmbKirmiziMasalar.DisplayMember = "MasaAd";



            DataTable dt2 = new DataTable();
            dt2 = classdt.masasorgu(con2);
            cmbBeyazMasalar.DataSource = dt2;
            cmbBeyazMasalar.ValueMember = "MasaID";
            cmbBeyazMasalar.DisplayMember = "MasaAd";




        }

        private void btnSipOdemeKapa_Click(object sender, EventArgs e)
        {
            matcardMasaTransfer.Visible = false;
            MatCardAnaMasalar.Enabled = true;


        }

        private void btnMasaTransferUygula_Click(object sender, EventArgs e)
        {

            // Transfer edilecek masanın sipnosunu öğrendiğim kod
            baglan.Close();
            baglan.Open();
            SqlDataAdapter masatransfersipnosorgu = new SqlDataAdapter("SELECT SipNo FROM  Siparislers where SipDurum ='True' and MasaID=" + cmbKirmiziMasalar.SelectedValue, baglan);
            DataTable sipno = new DataTable();
            masatransfersipnosorgu.Fill(sipno);
            cmbmasaidgetiren.DataSource = sipno;
            cmbmasaidgetiren.DisplayMember = "SipNo";

            // Siarişin madaid ve masa adını değişitirdiğim kod
            baglan.Close();
            baglan.Open();
            SqlCommand masatransfer = new SqlCommand("Update Siparislers set MasaID=@p1,MasaAd=@p2 where SipNo=" + cmbmasaidgetiren.Text, baglan);
            masatransfer.Parameters.AddWithValue("@p1", cmbBeyazMasalar.SelectedValue);
            masatransfer.Parameters.AddWithValue("@p2", cmbBeyazMasalar.Text);
            masatransfer.ExecuteNonQuery();


            // Masa Durum Güncellediğim kod
            baglan.Close();
            baglan.Open();
            SqlCommand Masadurumguncelle = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + cmbBeyazMasalar.SelectedValue, baglan);//Kırmızı
            Masadurumguncelle.Parameters.AddWithValue("@p1", true);
            Masadurumguncelle.ExecuteNonQuery();

            baglan.Close();
            baglan.Open();
            SqlCommand Masadurumguncelle1 = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + cmbKirmiziMasalar.SelectedValue, baglan);//Beyaz
            Masadurumguncelle1.Parameters.AddWithValue("@p1", false);
            Masadurumguncelle1.ExecuteNonQuery();

            frmMasalar frm = new frmMasalar();

            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            this.Hide();
            frm.Show();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            ıconButton3.BackColor = Color.FromArgb(211, 84, 0);
            ıconButton4.BackColor = Color.White;
            ıconButton3.ForeColor = Color.White;
            ıconButton4.ForeColor = Color.FromArgb(211, 84, 0);



            matcardRezOLustur.Visible = false;
            matcardRezBul.Dock = DockStyle.Fill;
            matcardRezBul.Visible = true;
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {

            matcardRezervasyon.Width = this.Size.Width / 2;
            matcardRezervasyon.Height = this.Size.Height / 2;
            matcardRezervasyon.Location = new Point(this.Size.Width / 4, this.Size.Height / 4);

            matcardRezervasyon.Visible = true;
            MatCardAnaMasalar.Enabled = false;

            matcardRezOLustur.Dock = DockStyle.Fill;

            frmMasalar frmx = new frmMasalar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            Responsive(frmx, w, h, matcardRezervasyon);

            
           

            //  Masa dolduran kod

            string masacon = "Select MasaID, MasaAd FROM Masalars";
            DataTable dt1 = new DataTable();
            dt1 = doldur.masasorgu(masacon);
            cmbRezMasaOlustur.DataSource = dt1;
            cmbRezMasaOlustur.ValueMember = "MasaID";
            cmbRezMasaOlustur.DisplayMember = "MasaAd";

            cmbMasaBul.DataSource = dt1;
            cmbMasaBul.ValueMember = "MasaID";
            cmbMasaBul.DisplayMember = "MasaAd";

            // Saat dolduran kod
            string saatcon = "Select SaatID,Saatler FROM Saatler";
            DataTable dt2 = new DataTable();
            dt2 = doldur.masasorgu(saatcon);
            cmbSaatOlustur.DataSource = dt2;
            cmbSaatOlustur.ValueMember = "SaatID";
            cmbSaatOlustur.DisplayMember = "Saatler";

            cmbSaatBul.DataSource = dt2;
            cmbSaatBul.ValueMember = "SaatID";
            cmbSaatBul.DisplayMember = "Saatler";


            rezlistele();
        }

        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard)
        {
            Boyutlandir.Rezarvasyon(frmx, width, height, MatCard);
        }

        private void btnRezEkranKapa_Click(object sender, EventArgs e)
        {
            matcardRezervasyon.Visible = false;
            MatCardAnaMasalar.Enabled = true;
        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            ıconButton4.BackColor = Color.FromArgb(211, 84, 0);
            ıconButton3.BackColor = Color.White;
            ıconButton4.ForeColor = Color.White;
            ıconButton3.ForeColor = Color.FromArgb(211, 84, 0);



            matcardRezBul.Visible = false;
            matcardRezOLustur.Dock = DockStyle.Fill;
            matcardRezOLustur.Visible = true;
        }

        private void rezlistele()
        {

            // Datagrid dolduran kod

            string rezcon = "Select MasaID,MasaAd,MusteriAd,Telefon,BasTarih,Saat,RezervasyonID FROM Rezervasyonlar";
            DataTable dt1 = new DataTable();
            dt1 = doldur.masasorgu(rezcon);
            DGVRezBul.DataSource = dt1;
        }

        private void btnRezEkle_Click(object sender, EventArgs e)
        {
            
            bool randevuvar = false;

            // Ravdevu varsa ekletmeyen kod
                   string rezcon = "Select MasaID,MasaAd,MusteriAd,Telefon,BasTarih,Saat FROM Rezervasyonlar";
            DataTable dtrez = new DataTable();
            dtrez = doldur.masasorgu(rezcon);

            for (int i = 0; i < dtrez.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dtrez.Rows[i]["BasTarih"].ToString());

                if (dtpOlusturTarih.Value.ToString("yyyy-MM-dd") == tarih.ToString("yyyy-MM-dd"))
                {
                    if (cmbSaatOlustur.Text == dtrez.Rows[i]["Saat"].ToString())
                    {
                        if (cmbRezMasaOlustur.Text==dtrez.Rows[i]["MasaAd"].ToString())
                        {
                            MessageBox.Show("Halihazırda randevu olan bir zamana randevu ekleyemezsiniz");
                            randevuvar = true;
                        }
                        
                    }
                }
            }

            if (randevuvar == false)
            {
                baglan.Close();
                baglan.Open();
                SqlCommand rezeklesorgu = new SqlCommand("  INSERT INTO [dbo].[Rezervasyonlar] ([MasaID],[MusteriAd],[Telefon],[BasTarih],[Saat],[MasaAd]) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", baglan);
                rezeklesorgu.Parameters.AddWithValue("@p1", cmbRezMasaOlustur.SelectedValue);
                rezeklesorgu.Parameters.AddWithValue("@p2", txtMusteriAdOlustur.Text.ToString());
                rezeklesorgu.Parameters.AddWithValue("@p3", txtTelefonOlustur.Text.ToString());
                rezeklesorgu.Parameters.AddWithValue("@p4", dtpOlusturTarih.Value.ToString("yyyy-MM-dd"));
                rezeklesorgu.Parameters.AddWithValue("@p5", cmbSaatOlustur.Text.ToString());
                rezeklesorgu.Parameters.AddWithValue("@p6", cmbRezMasaOlustur.Text.ToString());
                rezeklesorgu.ExecuteNonQuery();
                MessageBox.Show("Rezervasyon Eklendi");

            }




            rezlistele();

        }

        private void btnRezSil_Click(object sender, EventArgs e)
        {


            baglan.Close();
            baglan.Open();
            SqlCommand rezsizsorgu = new SqlCommand(" Delete From Rezervasyonlar where RezervasyonID=" + lblRezID.Text, baglan);
            rezsizsorgu.ExecuteNonQuery();
            rezlistele();
        }

        private void btnRezGuncelle_Click(object sender, EventArgs e)
        {
            bool randevuvar = false;
            SqlDataAdapter control = new SqlDataAdapter("Select MasaID,MasaAd,MusteriAd,Telefon,BasTarih,Saat FROM Rezervasyonlar", baglan);
            DataTable bak = new DataTable();
            control.Fill(bak);

            for (int i = 0; i < bak.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(bak.Rows[i]["BasTarih"].ToString());

                if (dtpBulTarih.Value.ToString("yyyy-MM-dd") == tarih.ToString("yyyy-MM-dd"))
                {
                    if (cmbSaatBul.Text == bak.Rows[i]["Saat"].ToString())
                    {
                        if (cmbMasaBul.Text== bak.Rows[i]["MasaAd"].ToString())
                        {
                            MessageBox.Show("Halihazırda randevu olan bir zamana randevu ekleyemezsiniz");
                            randevuvar = true;
                        }
                        
                    }
                }
            }
            if (randevuvar == false)
            {
                baglan.Close();
            baglan.Open();
            SqlCommand rezeklesorgu = new SqlCommand(" Update [dbo].[Rezervasyonlar] Set MasaID=@p1,MusteriAd=@p2,Telefon=@p3,BasTarih=@p4,Saat=@p5,MasaAd=@p6 where RezervasyonID=" + lblRezID.Text, baglan);
            rezeklesorgu.Parameters.AddWithValue("@p1", cmbMasaBul.SelectedValue);
            rezeklesorgu.Parameters.AddWithValue("@p2", txtMusteriBul.Text.ToString());
            rezeklesorgu.Parameters.AddWithValue("@p3", txtTelefonBul.Text.ToString());
            rezeklesorgu.Parameters.AddWithValue("@p4", dtpBulTarih.Value.ToString("yyyy-MM-dd"));
            rezeklesorgu.Parameters.AddWithValue("@p5", cmbSaatBul.Text.ToString());
            rezeklesorgu.Parameters.AddWithValue("@p6", cmbMasaBul.Text.ToString());
            rezeklesorgu.ExecuteNonQuery();
            MessageBox.Show("Rezervasyon Guncellendi");
            }

            rezlistele();
        }

        private void DGVRezBul_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = DGVRezBul.SelectedCells[0].RowIndex;

                txtMusteriBul.Text = DGVRezBul.Rows[secilen].Cells[2].Value.ToString();
                cmbMasaBul.SelectedValue = DGVRezBul.Rows[secilen].Cells[0].Value.ToString();
                cmbMasaBul.Text = DGVRezBul.Rows[secilen].Cells[1].Value.ToString();
                txtTelefonBul.Text = DGVRezBul.Rows[secilen].Cells[3].Value.ToString();
                dtpBulTarih.Text = DGVRezBul.Rows[secilen].Cells[4].Value.ToString();
                cmbSaatBul.Text = DGVRezBul.Rows[secilen].Cells[5].Value.ToString();

                lblRezID.Text = DGVRezBul.Rows[secilen].Cells[6].Value.ToString();

            }
            catch (Exception)
            {

                
            }
            
        }


    }
}



