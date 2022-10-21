using HiPOS.Class;
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
    public partial class frmTanimlamalar : Form
    {

        int recetesay = 0;


        public frmTanimlamalar()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");


        private void frmTanimlamalar_Load(object sender, EventArgs e)
        {

            CardBirimDuzen.Visible = false;
            MatCardStok.Visible = false;

            MatCardMasa.Visible = false;
            MatCardUrun.Visible = false;
            MatCardKategori.Visible = false;
            matCardRecete.Visible = false;
            frmTanimlamalar frmx = new frmTanimlamalar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            // responsiveleri buraya ekleme sebebim nedenini bilmedigim şekilde kategri kısmı başta yamuk başlıyor 
            // ikini tıklayışta düzeliyor bunu önlemek için buraya ekledim
            ResponsiveK(frmx, w, h, MatCardKategori, PanelKatego);
            Responsive(frmx, w, h, MatCardUrun, PanelTanim);
            Responsive(frmx, w, h, MatCardMasa, PanelMasa);


            StokTakip frmxx = new StokTakip();
            int wx = this.Size.Width;
            int hx = this.Size.Height;

            Responsivex(frmxx, wx, hx, MatCardStok, PanelStokTakip);
            CardBirimDuzen.Location = new Point(MatCardStok.Size.Width * 35 / 100, MatCardStok.Size.Height * 35 / 100);



            stokurunlistele();
            BirimListesiUpdate();



        }
        //*******************************************************************************************************************************
        //Kategori
        private void Responsivex(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.Yenile(frmx, width, height, MatCard, panel);

        }

        private void stokurunlistele()
        {


            baglan.Close();

            baglan.Open();
            SqlDataAdapter stokurunsorgu = new SqlDataAdapter("SELECT UrunID, UrunAD FROM  Urunlers where StokDurum = 'True'", baglan);
            DataTable dt = new DataTable();
            stokurunsorgu.Fill(dt);
            //lalalla


            cmbStokUrun.DataSource = dt;
            cmbStokUrun.ValueMember = dt.Columns[0].ToString();
            cmbStokUrun.DisplayMember = dt.Columns[1].ToString();

            baglan.Close();


            baglan.Open();
            SqlDataAdapter LVstokurunsorgu = new SqlDataAdapter("Select UrunID,UrunAD,Birim,(PaketMiktar) as AdetBasiMiktar,KritikStokMiktari From Stoklars", baglan);
            DataTable LVdt = new DataTable();
            LVstokurunsorgu.Fill(LVdt);
            DGVStok.DataSource = LVdt;
            DGVStok.Columns[0].Visible = false;
            baglan.Close();
        }

        private void cmbStokUrun_Click(object sender, EventArgs e)
        {
            stokurunlistele();
        }

       

       

        private void DGVStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvSec();

        }

        private void DgvSec()
        {
            int secilen = DGVStok.SelectedCells[0].RowIndex;

            cmbStokUrun.Text = DGVStok.Rows[secilen].Cells[1].Value.ToString();
            cmbBirim.Text = DGVStok.Rows[secilen].Cells[2].Value.ToString();
            txtAdetBasi.Text = DGVStok.Rows[secilen].Cells[3].Value.ToString();
            txtKritikStokMiktari.Text = DGVStok.Rows[secilen].Cells[4].Value.ToString();
            lblUrunID.Text = DGVStok.Rows[secilen].Cells[0].Value.ToString();
        }

        
        private void YeniBirimBtn_Click(object sender, EventArgs e)
        {
            baglan.Close();
            baglan.Open();

            if (YeniBirimtxt.Text != "")
            {
                SqlCommand KayitBirim = new SqlCommand("Insert into [Birims] (BirimCins) Values (@p1)", baglan);
                KayitBirim.Parameters.AddWithValue("@p1", YeniBirimtxt.Text);
                KayitBirim.ExecuteNonQuery();
                baglan.Close();
                BirimListesiUpdate();
                MessageBox.Show("Yeni Birim Eklendi");
            }
            else
            {
                MessageBox.Show("Birim boş girilemez");

            }


        }
        private void BirimListesiUpdate()
        {
            baglan.Open();
            SqlDataAdapter BirimSec = new SqlDataAdapter("Select BirimID,BirimCins from Birims", baglan);
            DataTable birimdizi = new DataTable();
            BirimSec.Fill(birimdizi);
            if (birimdizi.Rows.Count > 0) // degeryoksa hataverdigi için eklendi
            {

                cmbBirim.DataSource = birimdizi;
                cmbBirim.ValueMember = "BirimID";
                cmbBirim.DisplayMember = "BirimCins";
                CmbBirimD.DataSource = birimdizi;
                CmbBirimD.ValueMember = "BirimID";
                CmbBirimD.DisplayMember = "BirimCins";
            }



            baglan.Close();

        }

        private void BirimGnclBtn_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand BrmUp = new SqlCommand("Update [Birims] Set BirimCins=@p1 where BirimID=" + CmbBirimD.SelectedValue.ToString(), baglan);
            BrmUp.Parameters.AddWithValue("@p1", YeniBirimtxt.Text);
            BrmUp.ExecuteNonQuery();
            baglan.Close();
            BirimListesiUpdate();
            MessageBox.Show("Seçili Birim Güncellendi");

        }

        private void cmbBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            YeniBirimtxt.Text = CmbBirimD.Text;
        }

        private void BirimDelBtn_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand BrmDel = new SqlCommand("Delete From Birims where BirimID=" + CmbBirimD.SelectedValue.ToString(), baglan);
            BrmDel.ExecuteNonQuery();
            baglan.Close();
            BirimListesiUpdate();
            MessageBox.Show("Seçili Birim Silindi");
        }
        private void BirimDuzenle()
        {
            if (BirimSwitch.Checked)
            {
                CardBirimDuzen.Visible = true;
            }
            else
            {
                CardBirimDuzen.Visible = false;

            }


        }

       

       

       

        private void PanelStokTakip_Paint(object sender, PaintEventArgs e)
        {

        }

        //****************************************************************************************************************************************

        private void btnKategoriDuzenle_Click(object sender, EventArgs e)
        {
            MatCardMasa.Visible = false;
            MatCardUrun.Visible = false;

            MatCardKategori.Visible = true;
            frmTanimlamalar frmx = new frmTanimlamalar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            ResponsiveK(frmx, w, h, MatCardKategori, PanelKatego);
            listeleKTGR();
        }

        private void btnKaydetKTGR_Click(object sender, EventArgs e)
        {


            try
            {
                if (txtKategoriEkleCikarGuncelle.Text.Length > 1)
                {
                    baglan.Open();
                    SqlCommand kaydetkomut = new SqlCommand("Insert into [Kategoris] (KategoriAD) Values (@p1)", baglan);
                    kaydetkomut.Parameters.AddWithValue("@p1", txtKategoriEkleCikarGuncelle.Text);
                    kaydetkomut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kayıt Eklendi.");


                }
                else
                {
                    MessageBox.Show("Girdiğiniz kelime çok kısa");

                }


            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Eklenemedi");
            }
            listeleKTGR();
        }

        private void listeleKTGR()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter seckomut = new SqlDataAdapter("Select KategoriID,KategoriAD From Kategoris", baglan);
            DataTable dt = new DataTable();
            seckomut.Fill(dt);
            cmbKTGR.DataSource = dt;
            cmbKTGR.ValueMember = dt.Columns[0].ToString();
            cmbKTGR.DisplayMember = dt.Columns[1].ToString();

            baglan.Close();
        }

        private void btnGuncelleKTGR_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand guncellekomut = new SqlCommand("Update Kategoris set KategoriAD=@umut1 where KategoriID=" + cmbKTGR.SelectedValue.ToString(), baglan);
                //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Addwithvalue komutu ile sql komutunun içinde atamış olduğumuz parametreye değer veriyoruz
                guncellekomut.Parameters.AddWithValue("@umut1", txtKategoriEkleCikarGuncelle.Text);
                guncellekomut.ExecuteNonQuery();
                baglan.Close();
                listeleKTGR();

            }
            catch (Exception)
            {
                if (cmbKTGR.SelectedValue == null)
                {
                    MessageBox.Show("Kategori güncellemesi için önce katagori girişi yapılmalı");
                }

            }

        }

        private void KategoriSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from Kategoris where KategoriID=" + cmbKTGR.SelectedValue.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                listeleKTGR();
            }
            catch (Exception)
            {
                if (cmbKTGR.SelectedValue == null)
                {
                    MessageBox.Show("Kategori silebilmek için önce katagori girişi yapılmalı");
                }

            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            txtKategoriEkleCikarGuncelle.Text = cmbKTGR.Text;



        }
        //*******************************************************************************************************************************
        //Masa

        private void btnMasaDuzenle_Click(object sender, EventArgs e)
        {
            MatCardUrun.Visible = false;
            MatCardKategori.Visible = false;

            MatCardMasa.Visible = true;
            frmTanimlamalar frmx = new frmTanimlamalar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            Responsive(frmx, w, h, MatCardMasa, PanelMasa);




            listeleMasa();
        }

        private void listeleMasa()
        {
            baglan.Close();

            baglan.Open();
            SqlDataAdapter masasorgu = new SqlDataAdapter("Select MasaID,MasaAD,MasaDurum From Masalars", baglan);
            DataTable dt = new DataTable();
            masasorgu.Fill(dt);
            DGVMasaListesi.DataSource = dt;
            DGVMasaListesi.Columns[0].HeaderText = "ID";
            DGVMasaListesi.Columns[1].HeaderText = "Masa Adı";
            DGVMasaListesi.Columns[2].HeaderText = "Durum";
            baglan.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Close();

            baglan.Open();
            try
            {
                SqlCommand masakaydetsorgu = new SqlCommand("Insert into Masalars (MasaAD,MasaDurum) Values (@p1,@p2)", baglan);
                masakaydetsorgu.Parameters.AddWithValue("@p1", txtMasaAd.Text);
                masakaydetsorgu.Parameters.AddWithValue("@p2", false);
                masakaydetsorgu.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Yeni Masa Eklendi..");
            }
            catch (Exception)
            {
                MessageBox.Show("Yeni Masa Eklenemedi..");

            }
            listeleMasa();
            txtMasaAd.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Close();

            baglan.Open();
            try
            {
                SqlCommand masaguncellesorgu = new SqlCommand("Update Masalars set MasaAD=@p1,MasaDurum=@p2 where MasaID=" + lblmasaid.Text, baglan);
                masaguncellesorgu.Parameters.AddWithValue("@p1", txtMasaAd.Text);
                masaguncellesorgu.Parameters.AddWithValue("@p2", false);
                masaguncellesorgu.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Masa Güncellendi..");
            }
            catch (Exception)
            {
                MessageBox.Show("Masa Güncellenemedi..");

            }
            listeleMasa();
            txtMasaAd.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Close();

            baglan.Open();
            try
            {
                SqlCommand masasilsorgu = new SqlCommand("Delete From Masalars where MasaID=" + lblmasaid.Text, baglan);

                masasilsorgu.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show(lblmasaid.Text.ToString() + " Masası Silindi..");//xxxx
            }
            catch (Exception)
            {
                MessageBox.Show("Masa Silinemedi..");

            }
            listeleMasa();
            txtMasaAd.Text = "";
        }

        private void DGVMasaListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = DGVMasaListesi.SelectedCells[0].RowIndex;
            txtMasaAd.Text = DGVMasaListesi.Rows[secilen].Cells[1].Value.ToString();
            lblmasaid.Text = DGVMasaListesi.Rows[secilen].Cells[0].Value.ToString();
        }

        //*******************************************************************************************************************************
        //Ürün

        private void btnUrunduzenle_Click(object sender, EventArgs e)
        {
            MatCardMasa.Visible = false;
            MatCardKategori.Visible = false;
            MatCardUrun.Visible = true;
            frmTanimlamalar frmx = new frmTanimlamalar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            Responsive(frmx, w, h, MatCardUrun, PanelTanim);


            listele();
            listeleUrun();
            baglan.Close();
        }

        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.Yenile(frmx, width, height, MatCard, panel);

        }
        private void ResponsiveK(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.YenileK(frmx, width, height, MatCard, panel);

        }

        private void listeleUrun()
        {
            baglan.Close();

            baglan.Open();
            SqlDataAdapter seckomut = new SqlDataAdapter("Select KategoriID,KategoriAD From Kategoris", baglan);
            DataTable dtt = new DataTable();
            seckomut.Fill(dtt);
            if (dtt.Rows.Count > 0)
            {
                baglan.Close();

                baglan.Open();
                SqlDataAdapter urunsorgu = new SqlDataAdapter("Select UrunID,UrunAD,UrunFiyat,UrunResmi From Urunlers where UrunKategoriID=" + CMBKategori.SelectedValue.ToString(), baglan);
                DataTable dt = new DataTable();
                urunsorgu.Fill(dt);
                GridViewUrun.DataSource = dt;
                baglan.Close();
            }

        }
        private void CMBKategori_DropDownClosed(object sender, EventArgs e)
        {
            listeleUrun();
        }
        public void listele()
        {
            baglan.Close();

            baglan.Open();
            SqlDataAdapter seckomut = new SqlDataAdapter("Select KategoriID,KategoriAD From Kategoris", baglan);
            DataTable dt = new DataTable();
            seckomut.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                CMBKategori.DataSource = dt;
                CMBKategori.ValueMember = dt.Columns[0].ToString();
                CMBKategori.DisplayMember = dt.Columns[1].ToString();
                baglan.Close();
            }

        }

        private void GridViewUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            int secilen = GridViewUrun.SelectedCells[0].RowIndex;
            txtUrunAdi.Text = GridViewUrun.Rows[secilen].Cells[1].Value.ToString();
            txtUrunFiyati.Text = GridViewUrun.Rows[secilen].Cells[2].Value.ToString();
            txtresimuzanti.Text = GridViewUrun.Rows[secilen].Cells[3].Value.ToString();
            pictureBoxUrunResmi.ImageLocation = txtresimuzanti.Text;
            lblUrunID.Text = GridViewUrun.Rows[secilen].Cells[0].Value.ToString();
            //nuraya
            baglan.Close();
            baglan.Open();
            SqlDataAdapter urunsorgu = new SqlDataAdapter("Select StokDurum From Urunlers where UrunID=" + lblUrunID.Text.ToString(), baglan);
            DataTable dt = new DataTable();
            urunsorgu.Fill(dt);// hata bakılacak
            baglan.Close();
            if (dt.Rows[0]["StokDurum"].ToString() == "True")
            {
                btnSwitchUrunStoktutan.Checked = true;
            }
            else
            {
                btnSwitchUrunStoktutan.Checked = false;

            }


        }

        private void bntUrunGuncelle_Click(object sender, EventArgs e)
        {
            bool urunstokvarmi;
            if (btnSwitchUrunStoktutan.Checked)
            {
                urunstokvarmi = true;
            }
            else
            {
                urunstokvarmi = false;

            }
            try
            {
                baglan.Close();

                baglan.Open();
                SqlCommand guncellekomut = new SqlCommand("Update Urunlers set UrunAD=@p1,UrunFiyat=@p2,UrunResmi=@p3,StokDurum=@p4 where UrunID=" + lblUrunID.Text, baglan);
                //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Addwithvalue komutu ile sql komutunun içinde atamış olduğumuz parametreye değer veriyoruz
                guncellekomut.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
                guncellekomut.Parameters.AddWithValue("@p2", Convert.ToDecimal(txtUrunFiyati.Text));
                guncellekomut.Parameters.AddWithValue("@p3", txtresimuzanti.Text);
                guncellekomut.Parameters.AddWithValue("@p4", urunstokvarmi);
                guncellekomut.ExecuteNonQuery();
                baglan.Close();
                listele();
                listeleUrun();
            }
            catch (Exception)
            {
                if (CMBKategori.SelectedValue == null)
                {
                    MessageBox.Show("Guncelleme işlemi yapabilmek için önce katagori Ekleyiniz");
                }
                else
                {
                    MessageBox.Show("Kayıt Guncellenemedi");

                }
            }

        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Close();

                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from Urunlers where UrunID=" + lblUrunID.Text, baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                listele();
                listeleUrun();
            }
            catch (Exception)
            {
                if (CMBKategori.SelectedValue == null)
                {
                    MessageBox.Show("Silme işlemi yapabilmek için önce katagori Ekleyiniz");
                }
                else
                {
                    MessageBox.Show("Kayıt Silinemedi");

                }



            }

        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {


            bool urunstokvarmi;
            if (btnSwitchUrunStoktutan.Checked)
            {
                urunstokvarmi = true;
            }
            else
            {
                urunstokvarmi = false;

            }

            try
            {
                if (txtUrunAdi.Text.Length > 1)
                {

                    baglan.Close();

                    baglan.Open();
                    SqlCommand kaydetkomut = new SqlCommand("Insert into [Urunlers] (UrunAD,UrunKategoriID,UrunFiyat,UrunResmi,StokDurum) Values (@p1,@p2,@p3,@p4,@p5)", baglan);
                    kaydetkomut.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
                    kaydetkomut.Parameters.AddWithValue("@p2", Convert.ToInt16(CMBKategori.SelectedValue.ToString()));
                    kaydetkomut.Parameters.AddWithValue("@p3", Convert.ToDecimal(txtUrunFiyati.Text.ToString()));

                    kaydetkomut.Parameters.AddWithValue("@p4", txtresimuzanti.Text);
                    kaydetkomut.Parameters.AddWithValue("@p5", urunstokvarmi);

                    kaydetkomut.ExecuteNonQuery();
                    baglan.Close();


                    MessageBox.Show("Kayıt Eklendi.");
                }
                else
                {
                    MessageBox.Show("Girdiğiniz kelime çok kısa");

                }
            }
            catch (Exception)
            {
                if (CMBKategori.SelectedValue == null)
                {
                    MessageBox.Show("Önce Katagori Ekleyiniz");
                }
                else
                {
                    MessageBox.Show("Kayıt Eklenemedi ki");

                }
            }

            listele();
            listeleUrun();
        }


        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtresimuzanti.Text = openFileDialog1.FileName;
            pictureBoxUrunResmi.ImageLocation = txtresimuzanti.Text;
        }

        private void btnReceteEkle_Click(object sender, EventArgs e)
        {
            btnReceteUrunEkle.Text = "Ekle";
            try
            {
                int secilen = GridViewUrun.SelectedCells[0].RowIndex;
                lblreceteEklenecekUrunAd.Text = GridViewUrun.Rows[secilen].Cells[1].Value.ToString();
                lblreceteeklenecekurunID.Text = GridViewUrun.Rows[secilen].Cells[0].Value.ToString();
                baglan.Close();
                baglan.Open();
                SqlDataAdapter receteseckomut = new SqlDataAdapter("Select StokUrun,Birim,Miktar,ReceteID From Recetelers where UrunID=" + lblreceteeklenecekurunID.Text, baglan);
                DataTable dtrecete = new DataTable();
                receteseckomut.Fill(dtrecete);
                if (dtrecete.Rows.Count > 0)
                {
                    DGVRecetevarolan.DataSource = dtrecete;
                }
                else
                {
                    MessageBox.Show("Bu ürüne daha önce reçete eklenmemiş");
                }
                try
                {
                    baglan.Close();
                    baglan.Open();
                    SqlDataAdapter seckomut = new SqlDataAdapter("  SELECT UrunAd,UrunID,Birim  FROM Stoklars ", baglan);
                    DataTable dt = new DataTable();
                    seckomut.Fill(dt);


                    StokUrun.DataSource = dt;
                    StokUrun.ValueMember = dt.Columns[1].ToString();
                    StokUrun.DisplayMember = dt.Columns[0].ToString();
                    CmbBirimrec.DataSource = dt;
                    CmbBirimrec.ValueMember = dt.Columns[1].ToString();
                    CmbBirimrec.DisplayMember = dt.Columns[2].ToString();


                }
                catch (Exception)
                {

                    MessageBox.Show("Önce Stok Ürün Özellikleri bölümüne ürünü giriniz ");
                }
                recetesay++;
            }
            catch (Exception)
            {
                MessageBox.Show("Önce ürün eklenmeli");
            }

            matCardRecete.Width = this.Size.Width / 2 + 200;
            matCardRecete.Height = this.Size.Height / 2 + 200;
            matCardRecete.Location = new Point(this.Size.Width / 4 - 150, this.Size.Height / 4 - 50);
            MatCardUrun.Enabled = false;
            matCardRecete.Visible = true;
        }

        private void DGVRecete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = DGVRecete.SelectedCells[0].RowIndex;

            //MessageBox.Show(DGVRecete.Rows[secilen].Cells[0].Value.ToString());
            baglan.Close();

            baglan.Open();
            SqlCommand kaydetkomut = new SqlCommand("Insert into [Recetelers] (UrunID,StokUrun,Birim,Miktar,ReceteNo,StokUrunID) Values (@p1,@p2,@p3,@p4,@p5,@p6)", baglan);

            kaydetkomut.Parameters.AddWithValue("@p1", lblreceteeklenecekurunID.Text);
            kaydetkomut.Parameters.AddWithValue("@p2", Convert.ToString((DGVRecete.Rows[secilen].Cells["StokUrun"] as DataGridViewComboBoxCell).FormattedValue.ToString()));
            kaydetkomut.Parameters.AddWithValue("@p3", Convert.ToString((DGVRecete.Rows[secilen].Cells["CmbBirimrec"] as DataGridViewComboBoxCell).FormattedValue.ToString()));
            kaydetkomut.Parameters.AddWithValue("@p4", Convert.ToDecimal(DGVRecete.Rows[secilen].Cells[2].Value.ToString()));//degisti
            kaydetkomut.Parameters.AddWithValue("@p5", recetesay);
            kaydetkomut.Parameters.AddWithValue("@p6", DGVRecete.Rows[secilen].Cells[0].Value.ToString());

            kaydetkomut.ExecuteNonQuery();//
            baglan.Close();


            baglan.Close();
            baglan.Open();
            SqlDataAdapter receteseckomut = new SqlDataAdapter("Select StokUrun,Birim,Miktar,ReceteID From Recetelers where UrunID=" + lblreceteeklenecekurunID.Text, baglan);
            DataTable dtrecete = new DataTable();
            receteseckomut.Fill(dtrecete);
            if (dtrecete.Rows.Count > 0)
            {
                DGVRecetevarolan.DataSource = dtrecete;
                DGVRecetevarolan.Columns[2].ReadOnly = true;
                DGVRecetevarolan.Columns[3].ReadOnly = true;
                DGVRecetevarolan.Columns[5].ReadOnly = true;
            }
        }

        //****************************************************************************************************************************
        //****************************************************************************************************************************
        //****************************************************************************************************************************
        // DGV nin içindeki ekle butonuna artı simgesi eklemek için

        private void DGVRecete_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 3)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.plus.Width / 2;
                var h = Properties.Resources.plus.Height / 2;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.plus, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void matcardrecetekapatici_Click(object sender, EventArgs e)
        {
            MatCardUrun.Enabled = true;
            matCardRecete.Visible = false;
            DGVRecetevarolan.DataSource = null;
            DGVRecetevarolan.Rows.Clear();
        }

        //-------------------------------------------------------------------------------------------
        // Reçete

        private void DGVRecetevarolan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = DGVRecetevarolan.SelectedCells[0].RowIndex;


            if (e.ColumnIndex == DGVRecetevarolan.Columns[0].Index)
            {
                if (DialogResult.Yes == MessageBox.Show(" Bu satırı silmek mi istiyorsunuz?", "", MessageBoxButtons.YesNo))
                {
                    baglan.Close();

                    baglan.Open();
                    SqlCommand recetesilkomut = new SqlCommand("Delete from [Recetelers] where ReceteID=" + DGVRecetevarolan.Rows[secilen].Cells[5].Value.ToString(), baglan);
                    recetesilkomut.ExecuteNonQuery();
                    baglan.Close();
                    //delete it!          
                }
            }
            else if (e.ColumnIndex == DGVRecetevarolan.Columns[1].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Bu satırı düzenlemek mi istiyorsunuz?", "", MessageBoxButtons.YesNo))
                {
                    baglan.Close();

                    baglan.Open();
                    SqlCommand kaydetkomut = new SqlCommand("Update Recetelers set StokUrun=@p1,Birim=@p2,Miktar=@p3 where ReceteID=" + DGVRecetevarolan.Rows[secilen].Cells[5].Value.ToString(), baglan);

                    kaydetkomut.Parameters.AddWithValue("@p1", DGVRecetevarolan.Rows[secilen].Cells[2].Value.ToString());
                    kaydetkomut.Parameters.AddWithValue("@p2", DGVRecetevarolan.Rows[secilen].Cells[3].Value.ToString());
                    kaydetkomut.Parameters.AddWithValue("@p3", DGVRecetevarolan.Rows[secilen].Cells[4].Value.ToString());


                    kaydetkomut.ExecuteNonQuery();
                    baglan.Close();
                    //edit it!          
                }
            }

            baglan.Close();
            baglan.Open();
            SqlDataAdapter receteseckomut = new SqlDataAdapter("Select StokUrun,Birim,Miktar,ReceteID From Recetelers where UrunID=" + lblreceteeklenecekurunID.Text, baglan);
            DataTable dtrecete = new DataTable();
            receteseckomut.Fill(dtrecete);
            if (dtrecete.Rows.Count > 0)
            {
                DGVRecetevarolan.DataSource = dtrecete;

            }

        }

        private void DGVRecetevarolan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.minus_small.Width;
                var h = Properties.Resources.minus_small.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.minus_small, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.icons8_settings_64.Width / 3;
                var h = Properties.Resources.icons8_settings_64.Height / 3;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.icons8_settings_64, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnSwitchUrunStoktutan_CheckedChanged(object sender, EventArgs e)
        {

            if (btnSwitchUrunStoktutan.Checked)
            {
            }
            else
            {

            }

        }

        private void BirimEkleeBtn_Click(object sender, EventArgs e)
        {
            //döb
            BirimSwitch.Checked = true;
            BirimDuzenle();
        }

        private void btnStokEkle_Click_1(object sender, EventArgs e)
        {


            int selectedValue = Convert.ToInt32(cmbStokUrun.SelectedValue);
            try
            {
                baglan.Close();
                int stokvarmi = 0;
                baglan.Open();
                SqlDataAdapter stoksec = new SqlDataAdapter("Select UrunAD from Stoklars", baglan);
                DataTable stokadlari = new DataTable();
                stoksec.Fill(stokadlari);
                for (int i = 0; i < stokadlari.Rows.Count; i++)
                {
                    if (stokadlari.Rows[i]["UrunAd"].ToString() == cmbStokUrun.Text)
                    {
                        stokvarmi = 1;
                    }

                }
                baglan.Close();

                if (stokvarmi == 0)
                {
                    baglan.Open();
                    SqlCommand kaydetkomut = new SqlCommand("Insert into [Stoklars] (UrunAD,Birim,PaketMiktar,KritikStokMiktari,UrunID) Values (@p1,@p2,@p3,@p4,@p5)", baglan);
                    kaydetkomut.Parameters.AddWithValue("@p1", cmbStokUrun.Text);
                    kaydetkomut.Parameters.AddWithValue("@p2", cmbBirim.Text);
                    kaydetkomut.Parameters.AddWithValue("@p3", Convert.ToDecimal(txtAdetBasi.Text.ToString()));
                    kaydetkomut.Parameters.AddWithValue("@p4", Convert.ToInt32(txtKritikStokMiktari.Text.ToString()));
                    kaydetkomut.Parameters.AddWithValue("@p5", selectedValue);
                    kaydetkomut.ExecuteNonQuery();
                    baglan.Close();
                    stokurunlistele();

                    MessageBox.Show("Yeni ürün bilgileri Eklendi.");
                }
                else if (stokvarmi == 1)
                {
                    MessageBox.Show("Bu Ürün zaten daha önce eklenmiş Değişiklik  için Tablodan seçim yaparak" +
                        " GÜNCELLE işlemini kullanınız ");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Eksik yada yanlış giriş yapıldı.");


            }
        }

        private void btnStokGuncelle_Click_1(object sender, EventArgs e)
        {

            int secilen = DGVStok.SelectedCells[0].RowIndex;
            try
            {
                baglan.Close();
                baglan.Open();
                SqlCommand stokguncellekomut = new SqlCommand("Update [Stoklars] Set Birim=@p2,PaketMiktar=@p3,KritikStokMiktari=@p4 where UrunID=" + DGVStok.Rows[secilen].Cells[0].Value.ToString(), baglan);
                stokguncellekomut.Parameters.AddWithValue("@p2", cmbBirim.Text);
                stokguncellekomut.Parameters.AddWithValue("@p3", Convert.ToDecimal(txtAdetBasi.Text.ToString()));
                stokguncellekomut.Parameters.AddWithValue("@p4", Convert.ToInt32(txtKritikStokMiktari.Text.ToString()));
                stokguncellekomut.ExecuteNonQuery();
                baglan.Close();
                stokurunlistele();
                MessageBox.Show("Ürün Özellikleri Güncellendi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik yada yanlış giriş yapıldı.");


            }
        }

        private void btnStokSil_Click_1(object sender, EventArgs e)
        {

            int secilen = DGVStok.SelectedCells[0].RowIndex;
            try
            {
                baglan.Open();
                SqlCommand stoksilkomut = new SqlCommand("Delete From Stoklars where UrunID=" + DGVStok.Rows[secilen].Cells[0].Value.ToString(), baglan);
                stoksilkomut.ExecuteNonQuery();
                baglan.Close();
                stokurunlistele();
                MessageBox.Show("Stok Silindi.");

            }
            catch (Exception)
            {

                MessageBox.Show("Eksik yada yanlış giriş yapıldı.");
            }

        }

        private void BirimSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BirimSwitch_Click_1(object sender, EventArgs e)
        {
            BirimDuzenle();
        }

        private void BtnKapat_Click_1(object sender, EventArgs e)
        {
            BirimSwitch.Checked = false;
            BirimDuzenle();
        }

        private void BirimDelBtn_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand BrmDel = new SqlCommand("Delete From Birims where BirimID=" + CmbBirimD.SelectedValue.ToString(), baglan);
            BrmDel.ExecuteNonQuery();
            baglan.Close();
            BirimListesiUpdate();
            MessageBox.Show("Seçili Birim Silindi");
        }

        private void BirimGnclBtn_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand BrmUp = new SqlCommand("Update [Birims] Set BirimCins=@p1 where BirimID=" + CmbBirimD.SelectedValue.ToString(), baglan);
            BrmUp.Parameters.AddWithValue("@p1", YeniBirimtxt.Text);
            BrmUp.ExecuteNonQuery();
            baglan.Close();
            BirimListesiUpdate();
            MessageBox.Show("Seçili Birim Güncellendi");
        }

        private void YeniBirimBtn_Click_1(object sender, EventArgs e)
        {
            baglan.Close();
            baglan.Open();

            if (YeniBirimtxt.Text != "")
            {
                SqlCommand KayitBirim = new SqlCommand("Insert into [Birims] (BirimCins) Values (@p1)", baglan);
                KayitBirim.Parameters.AddWithValue("@p1", YeniBirimtxt.Text);
                KayitBirim.ExecuteNonQuery();
                baglan.Close();
                BirimListesiUpdate();
                MessageBox.Show("Yeni Birim Eklendi");
            }
            else
            {
                MessageBox.Show("Birim boş girilemez");

            }
        }

        private void cmbBirim_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            YeniBirimtxt.Text = CmbBirimD.Text;
        }

        private void cmbStokUrun_Click_1(object sender, EventArgs e)
        {
            stokurunlistele();
        }

        private void DGVStok_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DgvSec();
        }

        private void buttonKapatPanel_Click(object sender, EventArgs e)
        {
            MatCardStok.Visible = false;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            MatCardStok.Visible=true;
        }
    }
}
