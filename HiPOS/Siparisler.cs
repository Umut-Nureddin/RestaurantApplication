using HiPOS.Class;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiPOS
{
    public partial class frmSiparisler : MaterialForm
    {


        //Butonları yuvarlaklaştırmak için.
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRgn

         (
            int nLeft,
            int nTop,
            int nRight,
            int nBottom,
            int nWidthEllipse,
            int nHeightEllipse

         );


        bool indirimgecerlimi = true;

        public frmSiparisler()
        {
            InitializeComponent();

        }

        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");
        //SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");



        private void frmSiparisler_Load(object sender, EventArgs e)
        {
            MatCardSip.Dock = DockStyle.Fill;

            frmMasalar frmmasa = new frmMasalar();

            siparisload(frmmasa.masaad, frmmasa.masaid);


            frmSiparisler frmx = new frmSiparisler();
            int w = this.Size.Width;
            int h = this.Size.Height;

            Responsive(frmx, w, h, matcardOdeme);



        }

        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard)
        {
            Boyutlandir.Siparis(frmx, width, height, MatCard);
        }

        public void siparisload(string Veri, int IDVeri)
        {
            if (DGVAdisyon.Rows.Count > 1)
            {
                ToplamBulucu();
            }

            lblOdemeSipNo.Text = lblSipNo.Text;
            lblMasaAd.Text = Veri;
            lblOdemeMasaAd.Text = lblMasaAd.Text;
            lblMasaAd.TabIndex = IDVeri;
            lblOdemeMasaAd.TabIndex = lblMasaAd.TabIndex;
            try
            {
                baglan.Close();
                baglan.Open();
                SqlDataAdapter kategoriadgetir = new SqlDataAdapter("Select KategoriID,KategoriAD From Kategoris", baglan);
                DataTable dt = new DataTable();
                kategoriadgetir.Fill(dt);



                if (dt.Rows.Count > 0)
                {
                    CreatBtn(dt);
                }
                baglan.Close();

                matcardOdeme.Visible = false;
            }
            catch (Exception)
            {

                MessageBox.Show("Önce kategori ve ürün girişi yapınız");
            }


        }


        private void CreatBtn(DataTable Veri)
        {

            Point[] p = new Point[Veri.Rows.Count];
            string log = "";



            Button[] btn = new Button[Veri.Rows.Count];
            for (int i = 0; i < btn.GetLength(0); i++)
            {

                if (Veri.Rows[i]["KategoriAD"].ToString().Length > 0)
                {
                    btn[i] = new Button();
                    btn[i].FlatStyle = FlatStyle.Flat;
                    btn[i].BackColor = System.Drawing.Color.FromArgb(211, 84, 0);
                    btn[i].ForeColor = Color.White;
                    btn[i].Font = new Font("Arial", 11, FontStyle.Bold);
                    btn[i].Height = 90;
                    btn[i].Width = 100;
                    btn[i].Region = Region.FromHrgn(CreateRoundRgn(0, 0, btn[i].Width, btn[i].Height, 15, 15));

                    btn[i].Text = Veri.Rows[i]["KategoriAD"].ToString();
                    p[i] = new Point();
                    p[i].X = i * 83;

                    p[i].Y = 0;

                    log += p.ToString() + "\n";
                    btn[i].PointToClient(p[i]);
                    btn[i].Margin = new Padding(12, 12, 0, 0);
                    btn[i].Show();
                    btn[i].Click += KategoriButtonClick; ;

                }

            }

            FlowLayoutPanel pan = new FlowLayoutPanel();
            pan.Dock = DockStyle.Fill;
            pan.AutoScroll = true;
            pan.Controls.AddRange(btn);

            MatCardSipKategoriler.Controls.Add(pan);

        }

        private void KategoriButtonClick(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            int a = 0;
            baglan.Close();
            baglan.Open();

            SqlDataAdapter urunadgetir = new SqlDataAdapter("SELECT Kategoris.KategoriAD, Urunlers.UrunAD,Urunlers.UrunID, Urunlers.UrunFiyat, Urunlers.UrunResmi FROM  Kategoris INNER JOIN Urunlers ON Kategoris.KategoriID = Urunlers.UrunKategoriID", baglan);
            DataTable dtt = new DataTable();
            urunadgetir.Fill(dtt);
            for (int i = 0; i < dtt.Rows.Count; i++)
            {


                if (((Button)sender).Text == dtt.Rows[i]["KategoriAD"].ToString())
                {

                    list.Add(i);

                    a++;

                }

            }
            createKategoribtn2(dtt, a, list);
        }

        private void createKategoribtn2(DataTable Veri, int a, List<int> Liste)
        {
            MatCardSipUrunler.Controls.Clear();



            Point[] p = new Point[Liste.Count];
            string log = "";



            Button[] btn = new Button[Liste.Count];
            for (int i = 0; i < Liste.Count; i++)
            {
                // BEN BURADA aynı zamanda oluşturulan butonun özelliklerinide ayarlamak istiyorum
                // Resiminide göstermemlazım sanırsam nasıl olucak ki 

                btn[i] = new Button();

                btn[i].Height = 130;
                btn[i].Width = 180;
                btn[i].Text = Veri.Rows[Liste[i]]["UrunAD"].ToString();
                btn[i].TabIndex = Convert.ToInt16(Veri.Rows[Liste[i]]["UrunID"].ToString());
                btn[i].Tag = Veri.Rows[Liste[i]]["UrunFiyat"].ToString();


                btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                btn[i].ForeColor = System.Drawing.Color.Black;
                btn[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn[i].BackColor = System.Drawing.Color.White;


                try
                {
                    PictureBox resimci = new PictureBox();
                    resimci.ImageLocation = Veri.Rows[Liste[i]]["UrunResmi"].ToString();
                    string resimyolu = resimci.ImageLocation;
                    Bitmap bitmap = new Bitmap(resimyolu.ToString());
                    btn[i].BackgroundImage = bitmap;
                    btn[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {


                }



                p[i] = new Point();
                p[i].X = i * 83;

                p[i].Y = 0;

                log += p.ToString() + "\n";
                btn[i].PointToClient(p[i]);
                btn[i].Margin = new Padding(5, 5, 0, 0);

                btn[i].Show();

                btn[i].Click += btnUrunclick;



            }

            FlowLayoutPanel pan1 = new FlowLayoutPanel();
            pan1.Dock = DockStyle.Fill;
            pan1.Controls.AddRange(btn);


            MatCardSipUrunler.Controls.Add(pan1);

        }

        private void btnUrunclick(object sender, EventArgs e)
        {
            frmMasalar frmmasa = new frmMasalar();



            string urunad = ((Button)sender).Text;



            baglan.Close();
            baglan.Open();

            SqlDataAdapter sipsatirgetir = new SqlDataAdapter("SELECT Urunlers.UrunAD, Urunlers.UrunFiyat FROM Kategoris INNER JOIN Urunlers ON Kategoris.KategoriID = Urunlers.UrunKategoriID", baglan);
            DataTable dturun = new DataTable();
            sipsatirgetir.Fill(dturun);


            int yenimiktar = 1;
            bool buldum = false;
            if (DGVAdisyon.Rows.Count > 1)
            {
                for (int i = 0; i < DGVAdisyon.Rows.Count - 1; i++)
                {

                    if (DGVAdisyon.Rows[i].Cells[1].Value.ToString() == ((Button)sender).Text.ToString())
                    {
                        buldum = true;
                        yenimiktar = Convert.ToInt32(DGVAdisyon.Rows[i].Cells[3].Value) + 1;
                        DGVAdisyon.Rows[i].Cells[3].Value = yenimiktar;
                        double at = Convert.ToDouble(((Button)sender).Tag);
                        double Ym = Convert.ToDouble(yenimiktar);

                        DGVAdisyon.Rows[i].Cells[4].Value = (Ym * at).ToString();



                    }
                    else
                    {

                    }

                }
                if (!buldum)
                {
                    DataGridViewRow row = (DataGridViewRow)DGVAdisyon.Rows[0].Clone();
                    row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Cells[2].Value = ((Button)sender).Tag;
                    row.Cells[1].Value = ((Button)sender).Text;
                    row.Cells[3].Value = yenimiktar;
                    row.Cells[4].Value = ((Button)sender).Tag;
                    row.Cells[5].Value = ((Button)sender).TabIndex;

                    DGVAdisyon.Rows.Add(row);
                }



            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)DGVAdisyon.Rows[0].Clone();
                row.Cells[2].Value = ((Button)sender).Tag;
                row.Cells[1].Value = ((Button)sender).Text;
                row.Cells[3].Value = yenimiktar;
                row.Cells[4].Value = ((Button)sender).Tag;
                row.Cells[5].Value = ((Button)sender).TabIndex;

                DGVAdisyon.Rows.Add(row);
            }
            ToplamBulucu();
        }

        public void ToplamBulucu()
        {
            decimal AsilToplam = 0;
            for (int i = 0; i < DGVAdisyon.Rows.Count; i++)
            {
                AsilToplam += Convert.ToDecimal(DGVAdisyon.Rows[i].Cells[4].Value);
            }
            txtTop.Text = AsilToplam.ToString();

            int kdvtutar = Convert.ToInt32(AsilToplam) * 8 / 100;
            txtVergi.Text = kdvtutar.ToString();

            int aratoplam = Convert.ToInt32(AsilToplam) - kdvtutar;
            txtaratop.Text = aratoplam.ToString();

            txtOdemeToplamTutar.Text = txtTop.Text;
        }

        private void BtnSipKaydet_Click(object sender, EventArgs e)
        {
            if (DGVAdisyon.Rows.Count > 1)
            {

                //bir daha yeni bişi eklenince tekrar visible off olamalı
                frmMasalar frmmasa = new frmMasalar();

                MessageBox.Show("Sipariş Kayıt Edildi");
                baglan.Close();
                // Anasayfadaki Masa Butonunun rengini kırmızıya çevirmek için kullandığım kod
                baglan.Open();
                SqlCommand Masadurumguncelle = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + lblMasaAd.TabIndex, baglan);
                Masadurumguncelle.Parameters.AddWithValue("@p1", true);
                Masadurumguncelle.ExecuteNonQuery();



                sipariskaydetmethod();
            }
            else
            {
                MessageBox.Show("Ürün Eklemediniz");
            }

        }



        private void sipariskaydetmethod()
        {

            frmMasalar frmmasa = new frmMasalar();


            int sonsiparisno = siparisnobul();
            int x = 0;

            baglan.Close();
            baglan.Open();

            DataTable siptable = siparislergetir();
            if (siptable.Rows.Count <= 0)
            {
                SqlCommand sonsipguncelle = new SqlCommand("Update SonSiparis set SipNo=" + lblSipNo.Text, baglan);
                sonsipguncelle.ExecuteNonQuery();
            }





            for (int a = 0; a < DGVAdisyon.Rows.Count - 1; a++)
            {
                for (int b = 0; b < siptable.Rows.Count; b++)
                {
                    if (DGVAdisyon.Rows[a].Cells[5].Value.ToString() == siptable.Rows[b]["UrunID"].ToString())
                    {
                        x = 1;
                    }
                }

                if (x == 0)
                {
                    decimal siptutar = Convert.ToDecimal(txtTop.Text.ToString());
                    decimal kdvtutar = Convert.ToDecimal(txtVergi.Text.ToString());
                    decimal aratutar = Convert.ToDecimal(txtaratop.Text.ToString());
                    SqlCommand sipkaydetkomut = new SqlCommand("Insert into [Siparislers] (MasaAD,UrunAd,Tarih,SiparisTutar,KDVTutar,AraTutar,MasaID,SipDurum,KullaniciID,SipNo,UrunFiyat,UrunAdet,UrunID,SatirTutar,TarihKasa,MutfakDurum,TeslimHazirDurum,SatirOdemeDurum) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)", baglan);
                    sipkaydetkomut.Parameters.AddWithValue("@p1", lblMasaAd.Text);
                    sipkaydetkomut.Parameters.AddWithValue("@p2", DGVAdisyon.Rows[a].Cells[1].Value.ToString());
                    sipkaydetkomut.Parameters.AddWithValue("@p3", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sipkaydetkomut.Parameters.AddWithValue("@p4", siptutar);
                    sipkaydetkomut.Parameters.AddWithValue("@p5", kdvtutar);
                    sipkaydetkomut.Parameters.AddWithValue("@p6", aratutar);
                    sipkaydetkomut.Parameters.AddWithValue("@p7", lblMasaAd.TabIndex);
                    sipkaydetkomut.Parameters.AddWithValue("@p8", true);
                    sipkaydetkomut.Parameters.AddWithValue("@p9", Convert.ToInt32(lblkullanici.TabIndex.ToString())); // kullancı ıd
                    sipkaydetkomut.Parameters.AddWithValue("@p10", Convert.ToInt32(lblSipNo.Text.ToString()));  // sip no
                    sipkaydetkomut.Parameters.AddWithValue("@p11", Convert.ToDecimal(DGVAdisyon.Rows[a].Cells[2].Value.ToString()));
                    sipkaydetkomut.Parameters.AddWithValue("@p12", Convert.ToInt32(DGVAdisyon.Rows[a].Cells[3].Value.ToString()));
                    sipkaydetkomut.Parameters.AddWithValue("@p13", Convert.ToInt32(DGVAdisyon.Rows[a].Cells[5].Value.ToString()));
                    sipkaydetkomut.Parameters.AddWithValue("@p14", Convert.ToDecimal(DGVAdisyon.Rows[a].Cells[4].Value.ToString()));
                    sipkaydetkomut.Parameters.AddWithValue("@p15", DateTime.Now);
                    sipkaydetkomut.Parameters.AddWithValue("@p16", false);
                    sipkaydetkomut.Parameters.AddWithValue("@p17", false);
                    sipkaydetkomut.Parameters.AddWithValue("@p18", false);

                    sipkaydetkomut.ExecuteNonQuery();



                }

                x = 0;
            }




            SqlDataAdapter sipsorgu = new SqlDataAdapter("Select SipNo,UrunID,UrunAd,MasaID,SipID From Siparislers where SipNo=" + lblSipNo.Text, baglan);
            DataTable sipidtable = new DataTable();
            sipsorgu.Fill(sipidtable);




            for (int i = 0; i < DGVAdisyon.Rows.Count - 1; i++)
            {
                DGVAdisyon.Rows[i].Cells[8].Value = sipidtable.Rows[i]["SipID"].ToString();
            }



            for (int i = 0; i < siptable.Rows.Count; i++)
            {


                if (lblMasaAd.TabIndex.ToString() == siptable.Rows[i]["MasaID"].ToString() && DGVAdisyon.Rows[i].Cells[5].Value.ToString() == siptable.Rows[i]["UrunID"].ToString())
                {
                    decimal siptutar = Convert.ToDecimal(txtTop.Text.ToString());
                    decimal kdvtutar = Convert.ToDecimal(txtVergi.Text.ToString());
                    decimal aratutar = Convert.ToDecimal(txtaratop.Text.ToString());
                    baglan.Close();
                    baglan.Open();
                    SqlCommand guncellekomut = new SqlCommand("Update Siparislers set MasaAD=@p1,UrunAd=@p2,Tarih=@p3,SiparisTutar=@p4,KDVTutar=@p5,AraTutar=@p6,MasaID=@p7,SipDurum=@p8,KullaniciID=@p9,SipNo=@p10,UrunFiyat=@p11,UrunAdet=@p12,UrunID=@p13,SatirTutar=@p14,TarihKasa=@p15 where SipID=" + DGVAdisyon.Rows[i].Cells[8].Value.ToString(), baglan);
                    guncellekomut.Parameters.AddWithValue("@p1", lblMasaAd.Text);
                    guncellekomut.Parameters.AddWithValue("@p2", DGVAdisyon.Rows[i].Cells[1].Value.ToString());
                    guncellekomut.Parameters.AddWithValue("@p3", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    guncellekomut.Parameters.AddWithValue("@p4", siptutar);
                    guncellekomut.Parameters.AddWithValue("@p5", kdvtutar);
                    guncellekomut.Parameters.AddWithValue("@p6", aratutar);
                    guncellekomut.Parameters.AddWithValue("@p7", lblMasaAd.TabIndex);
                    guncellekomut.Parameters.AddWithValue("@p8", true);
                    guncellekomut.Parameters.AddWithValue("@p9", Convert.ToInt32(lblkullanici.TabIndex.ToString())); // kullancı ıd
                    guncellekomut.Parameters.AddWithValue("@p10", Convert.ToInt32(lblSipNo.Text.ToString()));  // sip no
                    guncellekomut.Parameters.AddWithValue("@p11", Convert.ToDecimal(DGVAdisyon.Rows[i].Cells[2].Value.ToString()));
                    guncellekomut.Parameters.AddWithValue("@p12", Convert.ToInt32(DGVAdisyon.Rows[i].Cells[3].Value.ToString()));
                    guncellekomut.Parameters.AddWithValue("@p13", Convert.ToInt32(DGVAdisyon.Rows[i].Cells[5].Value.ToString()));
                    guncellekomut.Parameters.AddWithValue("@p14", Convert.ToDecimal(DGVAdisyon.Rows[i].Cells[4].Value.ToString()));
                    guncellekomut.Parameters.AddWithValue("@p15", DateTime.Now);


                    guncellekomut.ExecuteNonQuery();




                }



            }



            //MatCardAnaMasalar.Controls.Clear();
            frmmasa.MasaButonDiz();
        }



        private DataTable siparislergetir()
        {

            SqlDataAdapter sipsorgu = new SqlDataAdapter("Select SipNo,UrunID,UrunAd,MasaID,SipID From Siparislers where SipNo=" + lblSipNo.Text, baglan);
            DataTable siptable = new DataTable();
            sipsorgu.Fill(siptable);
            return siptable;
        }

        public int siparisnobul()
        {
            int numara = 0;
            baglan.Close();
            baglan.Open();
            SqlDataAdapter sipnobul = new SqlDataAdapter("Select SipNo from SonSiparis", baglan);
            DataTable dt = new DataTable();
            sipnobul.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                numara = Convert.ToInt32(dt.Rows[0]["SipNo"].ToString());
            }



            return numara;
        }

        private void BtnSipKapa_Click(object sender, EventArgs e)
        {
            odemeadisyonlistesi();
            sipariseDahaOnceOdemeYapildimi();

            radiobtnNakit.Select();
            matcardOdeme.Visible = true;
            MatCardSip.Enabled = false;
            // aynı reçete n ya sahip ürünler için depodan o reçete mitarlarını düşür

            baglan.Close();
            baglan.Open();

            SqlDataAdapter depoeksi = new SqlDataAdapter("Select UrunAD,StokMiktariNet,StokMiktariPaket From Depo", baglan);
            DataTable depotable = new DataTable();
            depoeksi.Fill(depotable);






        }



        private void masakapandi()
        {

        }

        private void sipariseDahaOnceOdemeYapildimi()
        {
            decimal toplamodenen = 0;

            baglan.Close();
            baglan.Open();

            SqlDataAdapter odemevarmi = new SqlDataAdapter("Select Nakit,KrediKarti,Sodexo,Multinet,İkram,İndirim,KalanTutar From Odemelers where SipNo=" + lblOdemeSipNo.Text.ToString(), baglan);
            DataTable odemevarmitablo = new DataTable();
            odemevarmi.Fill(odemevarmitablo);

            for (int i = 0; i < odemevarmitablo.Rows.Count; i++)
            {

                if (odemevarmitablo.Rows[i]["KalanTutar"].ToString() == "0")
                {
                    txtOdemeToplamTutar.Text = Convert.ToString(Convert.ToDecimal(txtTop.Text.ToString()));

                }
                else
                {
                    toplamodenen += Convert.ToDecimal(odemevarmitablo.Rows[i]["Nakit"].ToString()) + Convert.ToDecimal(odemevarmitablo.Rows[i]["KrediKarti"].ToString()) + Convert.ToDecimal(odemevarmitablo.Rows[i]["Sodexo"].ToString()) + Convert.ToDecimal(odemevarmitablo.Rows[i]["Multinet"].ToString()) + Convert.ToDecimal(odemevarmitablo.Rows[i]["İkram"].ToString()) + Convert.ToDecimal(odemevarmitablo.Rows[i]["İndirim"].ToString());

                    lblOdenmisTutarRakam.Text = toplamodenen.ToString();
                }

                txtOdemeToplamTutar.Text = Convert.ToString(Convert.ToDecimal(txtTop.Text.ToString()) - toplamodenen);
            }



        }

        private void btnHizliOde_Click(object sender, EventArgs e)
        {

            decimal nakit = 0;
            decimal kredikarti = 0;
            decimal sodexo = 0;
            decimal multinet = 0;

            Tetikle();
            string odemebicimi = "";
            bool odemesecildimi = true;

            if (radiobtnNakit.Checked)
            {
                odemebicimi = "Nakit";
                nakit = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());
            }
            if (radiobtnKK.Checked)
            {
                odemebicimi = "Kredi Kartı";
                kredikarti = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());

            }
            if (radiobtnSodexo.Checked)
            {
                odemebicimi = "Sodexo";
                sodexo = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());

            }
            if (radiobtnMulinet.Checked)
            {
                odemebicimi = "Multinet";
                multinet = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());

            }
            if (radiobtnMulinet.Checked == false && radiobtnSodexo.Checked == false && radiobtnKK.Checked == false && radiobtnNakit.Checked == false)
            {
                MessageBox.Show("Lütfen bir ödeme biçimi seçiniz...");
                odemesecildimi = false;

            }


            if (odemesecildimi)
            {
                baglan.Close();
                baglan.Open();
                SqlCommand odemebicimiguncelle = new SqlCommand("Update Siparislers Set OdemeBicimi=@p1 where SipNo=" + lblSipNo.Text, baglan);
                odemebicimiguncelle.Parameters.AddWithValue("@p1", odemebicimi);
                odemebicimiguncelle.ExecuteNonQuery();

                //************************************************************************************************************************************
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                // Masa Durumunu inaktif eden kod
                baglan.Close();
                baglan.Open();
                SqlCommand Masadurumguncelle = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + lblMasaAd.TabIndex, baglan);
                Masadurumguncelle.Parameters.AddWithValue("@p1", false);
                Masadurumguncelle.ExecuteNonQuery();
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                // Sipariş Durumunu inaktif eden kod
                baglan.Close();
                baglan.Open();

                //sipariş kontrolü yapılacak
                DataTable sipkontrol = siparislergetir();
                if (sipkontrol.Rows.Count > 0)
                {
                    SqlCommand sipkapatkomut = new SqlCommand("Update Siparislers Set SipDurum=@p1 where SipNO=" + lblSipNo.Text, baglan);
                    sipkapatkomut.Parameters.AddWithValue("@p1", false);
                    sipkapatkomut.ExecuteNonQuery();


                    baglan.Close();
                    baglan.Open();
                    SqlCommand odemekaydetkomut = new SqlCommand("Insert into [Odemelers] (SipNo,Nakit,KrediKarti,Sodexo,Multinet,SipTutar,KalanTutar,OdemeDurum,Tarih) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglan);
                    odemekaydetkomut.Parameters.AddWithValue("@p1", Convert.ToInt16(lblOdemeSipNo.Text.ToString()));
                    odemekaydetkomut.Parameters.AddWithValue("@p2", nakit);
                    odemekaydetkomut.Parameters.AddWithValue("@p3", kredikarti);
                    odemekaydetkomut.Parameters.AddWithValue("@p4", sodexo);
                    odemekaydetkomut.Parameters.AddWithValue("@p5", multinet);
                    odemekaydetkomut.Parameters.AddWithValue("@p6", Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString()));
                    odemekaydetkomut.Parameters.AddWithValue("@p7", 0);
                    odemekaydetkomut.Parameters.AddWithValue("@p8", true);
                    odemekaydetkomut.Parameters.AddWithValue("@p9", DateTime.Now);
                    odemekaydetkomut.ExecuteNonQuery();

                }

                fisyazdir();


                MessageBox.Show("Sipariş kapatıldı..");
                DGVAdisyon.Rows.Clear();

                txtaratop.Clear();
                txtTop.Clear();
                txtVergi.Clear();
                masaac();
            }


        }

        private void fisyazdir()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter raporgetir = new SqlDataAdapter("Select UrunAd,UrunFiyat,UrunAdet,SatirTutar From Siparislers where SipNo=" + lblOdemeSipNo.Text.ToString(), baglan);
            DataTable dtrapor = new DataTable();
            raporgetir.Fill(dtrapor);


            string toplamtutar = txtTop.Text.ToString();
            string aratutar = txtaratop.Text.ToString();
            string kdvtutar = txtVergi.Text.ToString();
            string saticiadi = lblKullaniciAD.Text.ToString();
            string SipNo = lblOdemeSipNo.Text.ToString();

            frnFis frm = new frnFis();
            frm.Show();
            frm.RepoViewFis.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSetSiparislers", dtrapor);
            frm.RepoViewFis.LocalReport.ReportPath = @"C:\Users\hp\Desktop\HighPos\3 Eylül-HPOS\HiPOS\_Fis.rdlc";
            frm.RepoViewFis.LocalReport.DataSources.Add(source);
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[]
         {
                   new Microsoft.Reporting.WinForms.ReportParameter("pAraTutar", aratutar.ToString() ),
                   new Microsoft.Reporting.WinForms.ReportParameter("pToplamTutar", toplamtutar.ToString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("pKDVTutar", kdvtutar.ToString() ),
                   new Microsoft.Reporting.WinForms.ReportParameter("pTarih", DateTime.Now.ToShortDateString() ),
                   new Microsoft.Reporting.WinForms.ReportParameter("pSaticiAdi", saticiadi.ToString() ),
                   new Microsoft.Reporting.WinForms.ReportParameter("pSipNo", SipNo.ToString() )
         };
            frm.RepoViewFis.LocalReport.SetParameters(parameters);
            frm.RepoViewFis.RefreshReport();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            DGVAdisyon.Rows.Clear();
            txtaratop.Clear();
            txtTop.Clear();
            txtVergi.Clear();
            masaac();
        }

        private void masaac()
        {
            frmMasalar frmmasa = new frmMasalar();
            frmmasa.MdiParent = this.MdiParent;
            frmmasa.Dock = DockStyle.Fill;
            this.Hide();
            frmmasa.Show();


            frmmasa.MatCardAnaMasalar.Controls.Clear();
            frmmasa.MasaButonDiz();
        }

        private void DGVAdisyon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            //if (e.ColumnIndex == 1)
            //{
            //    DGVAdisyonEk.Visible = true;


            //    btnİkram.Visible = true;
            //    btnİndirim.Visible = true;

            //    if (DGVAdisyonEk.Rows.Count > 1)
            //    {
            //        DGVAdisyonEk.Rows.RemoveAt(0);

            //        int secilen = DGVAdisyon.SelectedCells[0].RowIndex;
            //        DataGridViewRow row = (DataGridViewRow)DGVAdisyonEk.Rows[0].Clone();
            //        row.Cells[0].Value = DGVAdisyon.Rows[secilen].Cells[1].Value.ToString();
            //        row.Cells[1].Value = DGVAdisyon.Rows[secilen].Cells[2].Value.ToString();
            //        row.Cells[2].Value = 1;
            //        row.Cells[3].Value = DGVAdisyon.Rows[secilen].Cells[5].Value.ToString();
            //        DGVAdisyonEk.Rows.Add(row);

            //    }
            //    else
            //    {
            //        int secilen = DGVAdisyon.SelectedCells[0].RowIndex;
            //        DataGridViewRow row = (DataGridViewRow)DGVAdisyonEk.Rows[0].Clone();
            //        row.Cells[0].Value = DGVAdisyon.Rows[secilen].Cells[1].Value.ToString();
            //        row.Cells[1].Value = DGVAdisyon.Rows[secilen].Cells[2].Value.ToString();
            //        row.Cells[2].Value = 1;
            //        row.Cells[3].Value = "0" + DGVAdisyon.Rows[secilen].Cells[5].Value.ToString();

            //        DGVAdisyonEk.Rows.Add(row);
            //    }



            //}
            //else
            //{

            //    DGVAdisyonEk.Visible = false;

            //    btnİkram.Visible = false;
            //    btnİndirim.Visible = false;

            //}


            if (e.ColumnIndex == 6)
            {
                int secilen = DGVAdisyon.SelectedCells[0].RowIndex;

                DGVAdisyon.Rows[secilen].Cells[3].Value = Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) + 1;
                DGVAdisyon.Rows[secilen].Cells[4].Value = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[2].Value) * Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value);
                ToplamBulucu();

            }

            if (e.ColumnIndex == 7)
            {
                int secilen = DGVAdisyon.SelectedCells[0].RowIndex;

                if (DGVAdisyon.Rows[secilen].Cells[3].Value.ToString() == "1")
                {
                    MessageBox.Show("Seçili Ürünü Daha Fazla Azaltamazsınız. Ürünü Çıkarmayı Deneyebilirsiniz.");
                }
                else
                {
                    DGVAdisyon.Rows[secilen].Cells[3].Value = Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) - 1;

                    DGVAdisyon.Rows[secilen].Cells[4].Value = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[2].Value) * Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value);
                    ToplamBulucu();

                }
            }

            DGVAdisyonEk.Rows[0].Selected = true;

        }

        private void btnSipCikar_Click(object sender, EventArgs e)
        {


            try
            {
                int secilen = DGVAdisyon.SelectedCells[0].RowIndex;
                DGVAdisyon.Rows.RemoveAt(secilen);//trycatxh
                baglan.Close();
                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from Siparislers where SipNo=" + lblSipNo.Text, baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();



                if (DGVAdisyon.Rows.Count <= 1)
                {
                    baglan.Close();
                    // Anasayfadaki Masa Butonunun rengini beyaza çevirmek için kullandığım kod
                    baglan.Open();
                    SqlCommand Masadurumguncelle = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + lblMasaAd.TabIndex, baglan);
                    Masadurumguncelle.Parameters.AddWithValue("@p1", false);
                    Masadurumguncelle.ExecuteNonQuery();


                }
                else
                {
                    baglan.Close();
                    // Anasayfadaki Masa Butonunun rengini kırmızıya çevirmek için kullandığım kod
                    baglan.Open();
                    SqlCommand Masadurumguncelletrue = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + lblMasaAd.TabIndex, baglan);
                    Masadurumguncelletrue.Parameters.AddWithValue("@p1", true);
                    Masadurumguncelletrue.ExecuteNonQuery();
                }

                sipariskaydetmethod();

                ToplamBulucu();

            }
            catch (Exception)
            {
                MessageBox.Show("Çıkarılacak ürünü seçiniz..");

            }

        }



        private void btnİkram_Click(object sender, EventArgs e)
        {       // Sorun adisyondaki ürünler çıkırılsa bile ek adisyon kısmında hala kalıyorlar 
                //İkram tuşuna basarsan eğer olmayan ürünü ikram yapmaya çalıştığın için
                // NULL hatası alıyorsun geçici çözüm olarak try catch e alındı
                //try
                //{
                //    int secilen = DGVAdisyon.SelectedCells[0].RowIndex;

            //    if (DGVAdisyon.Rows[secilen].Cells[1].Value.ToString() != DGVAdisyonEk.Rows[0].Cells[0].Value.ToString())
            //    {
            //        MessageBox.Show("İkramEdilecek Ürün Yok");
            //    }
            //    else
            //    {
            //        DataGridViewRow row = (DataGridViewRow)DGVAdisyon.Rows[0].Clone();
            //        row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
            //        row.Cells[1].Value = "(İkram)" + DGVAdisyonEk.Rows[0].Cells[0].Value.ToString();
            //        row.Cells[2].Value = DGVAdisyonEk.Rows[0].Cells[1].Value.ToString();
            //        row.Cells[3].Value = DGVAdisyonEk.Rows[0].Cells[2].Value.ToString();
            //        row.Cells[4].Value = 0;
            //        row.Cells[5].Value = DGVAdisyonEk.Rows[0].Cells[3].Value.ToString();
            //        DGVAdisyon.Rows.Insert(secilen + 1, row);



            //        if (DGVAdisyon.Rows[secilen].Cells[1].Value.ToString() == DGVAdisyonEk.Rows[0].Cells[0].Value.ToString())
            //        {

            //            if (DGVAdisyon.Rows[secilen].Cells[3].Value.ToString() == DGVAdisyonEk.Rows[0].Cells[2].Value.ToString())
            //            {
            //                DGVAdisyon.Rows.RemoveAt(secilen);
            //                ToplamBulucu();

            //            }

            //            if (Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) > Convert.ToInt16(DGVAdisyonEk.Rows[0].Cells[2].Value.ToString()))
            //            {



            //                int kalanadet = Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) - Convert.ToInt16(DGVAdisyonEk.Rows[0].Cells[2].Value.ToString());

            //                DGVAdisyon.Rows[secilen].Cells[3].Value = kalanadet;

            //                decimal Ym = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString());
            //                decimal at = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[2].Value.ToString());
            //                DGVAdisyon.Rows[secilen].Cells[4].Value = (Ym * at).ToString();
            //                ToplamBulucu();

            //            }


            //        }
            //    }
            //}
            //catch (Exception)
            //{


            //}


            int secilen = DGVOdemelistesi.SelectedCells[0].RowIndex;


            if (Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) <= 0)
            {
                DGVOdemelistesi.Rows.RemoveAt(secilen);
            }
            else
            {


                DGVOdemelistesi.Rows[secilen].Cells[1].Value = Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) - 1;


                DataGridViewRow row = (DataGridViewRow)DGVHesaplistesi.Rows[0].Clone();
                row.Cells[0].Value = +1;
                row.Cells[1].Value = "İkram";
                row.Cells[2].Value = DGVOdemelistesi.Rows[secilen].Cells[3].Value.ToString();
                row.Cells[4].Value = "(İkram) " + DGVOdemelistesi.Rows[secilen].Cells[2].Value.ToString();
                row.Cells[5].Value = DGVOdemelistesi.Rows[secilen].Cells[4].Value.ToString();
                row.Cells[6].Value = 0;



                DGVHesaplistesi.Rows.Add(row);

                for (int i = 0; i < DGVHesaplistesi.Rows.Count - 1; i++)
                {
                    decimal tutar = Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString()) * Convert.ToInt16(DGVHesaplistesi.Rows[i].Cells[0].Value.ToString());

                    DGVHesaplistesi.Rows[i].Cells[2].Value = Convert.ToDecimal(tutar.ToString());

                }

            }


        }

        private void btnİndirim_Click(object sender, EventArgs e)
        {
            matCardİndirim.Width = MatCardSip.Size.Width / 3;
            matCardİndirim.Height = MatCardSip.Size.Height - 200;
            matCardİndirim.Location = new Point(MatCardSip.Size.Width / 4 + 150, MatCardSip.Size.Height / 4 - 100);

            matCardİndirim.Visible = true;
            matcardOdeme.Enabled = false;

            int secilen = DGVOdemelistesi.SelectedCells[0].RowIndex;

            lblİndirimYapılacakUrununFiyati.Text = DGVOdemelistesi.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnİndirimKapa_Click(object sender, EventArgs e)
        {
            matCardİndirim.Visible = false;
            matcardOdeme.Enabled = true;

            lblİndirimYapılacakUrununFiyati.Text = "";
        }

        private void btnİndirimUygula_Click(object sender, EventArgs e)
        {
            if (switchİndirimSekli.Checked == false)
            {
                decimal UF = Convert.ToDecimal(lblİndirimYapılacakUrununFiyati.Text.ToString());
                int IG = Convert.ToInt16(txtİndirimGirdisi.Text.ToString());

                txtİndirimCiktisi.Text = (UF - (UF / 100 * IG)).ToString();
            }
            else
            {
                decimal UF = Convert.ToDecimal(lblİndirimYapılacakUrununFiyati.Text.ToString());
                decimal IG = Convert.ToInt16(txtİndirimGirdisi.Text.ToString());

                txtİndirimCiktisi.Text = (UF - IG).ToString();
            }
        }

        private void btnİndirimOnayla_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int secilen = DGVAdisyon.SelectedCells[0].RowIndex;

            //    if (DGVAdisyon.Rows[secilen].Cells[1].Value.ToString() != DGVAdisyonEk.Rows[0].Cells[0].Value.ToString())
            //    {
            //        MessageBox.Show("İndirim Yapılacak Ürün Yok");
            //    }
            //    else
            //    {

            //        if (DGVAdisyon.Rows[secilen].Cells[1].Value.ToString() == DGVAdisyonEk.Rows[0].Cells[0].Value.ToString())
            //        {
            //            DataGridViewRow row = (DataGridViewRow)DGVAdisyon.Rows[0].Clone();
            //            //row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
            //            row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            //            row.DefaultCellStyle.ForeColor = Color.White;
            //            row.Cells[1].Value = "(İndirim)" + DGVAdisyonEk.Rows[0].Cells[0].Value.ToString();
            //            row.Cells[2].Value = txtİndirimCiktisi.Text.ToString();
            //            row.Cells[3].Value = DGVAdisyonEk.Rows[0].Cells[2].Value.ToString();
            //            row.Cells[4].Value = Convert.ToDecimal(row.Cells[2].Value) * Convert.ToInt16(row.Cells[3].Value);
            //            row.Cells[5].Value = DGVAdisyonEk.Rows[0].Cells[3].Value.ToString();
            //            DGVAdisyon.Rows.Insert(secilen + 1, row);


            //            if (DGVAdisyon.Rows[secilen].Cells[3].Value.ToString() == DGVAdisyonEk.Rows[0].Cells[2].Value.ToString())
            //            {
            //                DGVAdisyon.Rows.RemoveAt(secilen);
            //                ToplamBulucu();

            //            }
            //            else
            //            {
            //                if (Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) > Convert.ToInt16(DGVAdisyonEk.Rows[0].Cells[2].Value.ToString()))
            //                {



            //                    int kalanadet = Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString()) - Convert.ToInt16(DGVAdisyonEk.Rows[0].Cells[2].Value.ToString());

            //                    DGVAdisyon.Rows[secilen].Cells[3].Value = kalanadet;

            //                    decimal YM = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString());
            //                    decimal At = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[2].Value.ToString());
            //                    DGVAdisyon.Rows[secilen].Cells[4].Value = (YM * At).ToString();
            //                    ToplamBulucu();
            //                }
            //            }
            //        }

            //    }

            //    decimal Ym = Convert.ToDecimal(DGVAdisyon.Rows[secilen].Cells[2].Value.ToString());
            //    int at = Convert.ToInt16(DGVAdisyon.Rows[secilen].Cells[3].Value.ToString());

            //    DGVAdisyon.Rows[secilen].Cells[4].Value = (Ym * at).ToString();

            //    ToplamBulucu();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            int secilen = DGVOdemelistesi.SelectedCells[0].RowIndex;


            if (Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) <= 0)
            {
                DGVOdemelistesi.Rows.RemoveAt(secilen);
            }
            else
            {


                DGVOdemelistesi.Rows[secilen].Cells[1].Value = Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) - 1;


                DataGridViewRow row = (DataGridViewRow)DGVHesaplistesi.Rows[0].Clone();
                row.Cells[0].Value = +1;
                row.Cells[1].Value = "İndirim";
                row.Cells[2].Value = DGVOdemelistesi.Rows[secilen].Cells[3].Value.ToString();
                row.Cells[4].Value = "(İndirim) " + DGVOdemelistesi.Rows[secilen].Cells[2].Value.ToString();
                row.Cells[5].Value = DGVOdemelistesi.Rows[secilen].Cells[4].Value.ToString();
                row.Cells[6].Value = Convert.ToDecimal(txtİndirimCiktisi.Text.ToString());



                DGVHesaplistesi.Rows.Add(row);

                for (int i = 0; i < DGVHesaplistesi.Rows.Count - 1; i++)
                {
                    decimal tutar = Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString()) * Convert.ToInt16(DGVHesaplistesi.Rows[i].Cells[0].Value.ToString());

                    DGVHesaplistesi.Rows[i].Cells[2].Value = Convert.ToDecimal(tutar.ToString());

                }

            }

        }


        private void DGVAdisyon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.minus_small.Width;
                var h = Properties.Resources.minus_small.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.minus_small, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 6)
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

        private void btnSipOdemeKapa_Click(object sender, EventArgs e)
        {
            matcardOdeme.Visible = false;
            MatCardSip.Enabled = true;

            DGVHesaplistesi.Rows.Clear();

        }

        private void odemeadisyonlistesi()
        {



            SqlDataAdapter dgvodemelistesidoldur = new SqlDataAdapter("Select UrunAdet,UrunAd,UrunFiyat,SipID,SatirTutar From Siparislers where SipDurum='True' and SatirOdemeDurum='False' and SipNo=" + lblOdemeSipNo.Text, baglan);
            DataTable dtodemelist = new DataTable();
            dgvodemelistesidoldur.Fill(dtodemelist);
            DGVOdemelistesi.DataSource = dtodemelist;

            SqlDataAdapter dgvodemelistesidoldurhesap = new SqlDataAdapter("Select SUM(UrunAdet) as Toplam,SipID From SipHesap  Group By SipID", baglan);
            DataTable dtodemelisthesap = new DataTable();
            dgvodemelistesidoldurhesap.Fill(dtodemelisthesap);

            for (int i = 0; i < DGVOdemelistesi.Rows.Count - 1; i++)
            {


                for (int a = 0; a < dtodemelisthesap.Rows.Count; a++)
                {
                    if (DGVOdemelistesi.Rows[i].Cells[4].Value.ToString() == dtodemelisthesap.Rows[a][1].ToString() && dtodemelisthesap.Rows.Count > i)
                    {
                        DGVOdemelistesi.Rows[i].Cells[1].Value = Convert.ToInt16(DGVOdemelistesi.Rows[i].Cells[1].Value.ToString()) - Convert.ToInt16(dtodemelisthesap.Rows[a][0].ToString());
                    }
                }


                if (Convert.ToInt16(DGVOdemelistesi.Rows[i].Cells[1].Value.ToString()) <= 0)
                {
                    DGVOdemelistesi.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                }

            }

            DGVOdemelistesi.Columns[4].Visible = false;
            DGVOdemelistesi.Columns[5].Visible = false;
            DGVOdemelistesi.Columns[3].Visible = true;



        }

        private void btnHesMak1_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 1;
        }
        private void btnHesMak2_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 2;
        }
        private void btnHesMak3_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 3;
        }
        private void btnHesMak4_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 4;
        }
        private void btnHesMak5_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 5;
        }
        private void btnHesMak6_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 6;
        }
        private void btnHesMak7_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 7;
        }
        private void btnHesMak8_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 8;
        }
        private void btnHesMak9_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 9;
        }
        private void btnHesMak0_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text += 0;
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            txtHesapMak.Text = txtHesapMak.Text.Remove(txtHesapMak.Text.Length - 1);
        }

        private void btnTamami_Click(object sender, EventArgs e)
        {
            decimal toplam = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());
            txtHesapMak.Text = Convert.ToString(toplam);
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            decimal toplam = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());
            txtHesapMak.Text = Convert.ToString(toplam / 2);
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            decimal toplam = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString());
            txtHesapMak.Text = Convert.ToString(toplam / 3);
        }



        private void txtHesapMak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as MaterialTextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtToplamFiyatIndirim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
                indirimgecerlimi = true;
            }


        }

        private void DGVOdemelistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string odemebicimi = "";

            if (radiobtnNakit.Checked)
            {
                odemebicimi = "Nakit";
            }
            if (radiobtnKK.Checked)
            {
                odemebicimi = "Kredi Kartı";
            }
            if (radiobtnSodexo.Checked)
            {
                odemebicimi = "Sodexo";
            }
            if (radiobtnMulinet.Checked)
            {
                odemebicimi = "Multinet";
            }
            int secilen = DGVOdemelistesi.SelectedCells[0].RowIndex;


            if (Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) <= 0)
            {
                DGVOdemelistesi.Rows.RemoveAt(secilen);
            }
            else
            {


                DGVOdemelistesi.Rows[secilen].Cells[1].Value = Convert.ToInt16(DGVOdemelistesi.Rows[secilen].Cells[1].Value.ToString()) - 1;


                DataGridViewRow row = (DataGridViewRow)DGVHesaplistesi.Rows[0].Clone();
                row.Cells[0].Value = +1;
                row.Cells[1].Value = odemebicimi;
                row.Cells[2].Value = DGVOdemelistesi.Rows[secilen].Cells[3].Value.ToString();
                row.Cells[4].Value = DGVOdemelistesi.Rows[secilen].Cells[2].Value.ToString();
                row.Cells[5].Value = DGVOdemelistesi.Rows[secilen].Cells[4].Value.ToString();



                DGVHesaplistesi.Rows.Add(row);

                for (int i = 0; i < DGVHesaplistesi.Rows.Count - 1; i++)
                {
                    decimal tutar = Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString()) * Convert.ToInt16(DGVHesaplistesi.Rows[i].Cells[0].Value.ToString());

                    DGVHesaplistesi.Rows[i].Cells[2].Value = tutar.ToString();

                }

            }

        }

        private void ıconButton3_Click(object sender, EventArgs e)  // hesap makinesinden ücret girme
        {
            string odemebicimi = "";

            if (radiobtnNakit.Checked)
            {
                odemebicimi = "Nakit";
            }
            if (radiobtnKK.Checked)
            {
                odemebicimi = "Kredi Kartı";
            }
            if (radiobtnSodexo.Checked)
            {
                odemebicimi = "Sodexo";
            }
            if (radiobtnMulinet.Checked)
            {
                odemebicimi = "Multinet";
            }


            DataGridViewRow row = (DataGridViewRow)DGVHesaplistesi.Rows[0].Clone();
            row.Cells[0].Value = 1;
            row.Cells[1].Value = odemebicimi;
            row.Cells[2].Value = Convert.ToDecimal(txtHesapMak.Text.ToString());
            row.Cells[4].Value = "Ürün Seçilmedi";
            row.Cells[5].Value = 000;

            DGVHesaplistesi.Rows.Add(row);
        }

        private void DGVHesaplistesi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.undo.Width / 2;
                var h = Properties.Resources.undo.Height / 2;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.undo, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void DGVHesaplistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = DGVHesaplistesi.SelectedCells[0].RowIndex;

            if (DGVHesaplistesi.Rows[secim].Cells[0].Value.ToString() == "")
            {
                DGVHesaplistesi.Rows.RemoveAt(secim);
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)DGVOdemelistesi.Rows[0].Clone();

                row.Cells[1].Value = DGVHesaplistesi.Rows[secim].Cells[0].Value;
                row.Cells[2].Value = DGVHesaplistesi.Rows[secim].Cells[4].Value;
                row.Cells[3].Value = DGVHesaplistesi.Rows[secim].Cells[2].Value.ToString();

                DGVOdemelistesi.Rows.Add(row);

                DGVHesaplistesi.Rows.RemoveAt(secim);

            }
        }

        private void btnOdeveYazdir_Click(object sender, EventArgs e) // Seçileni Öde butonu
        {
            Tetikle();

            decimal odenecektoplamtutar = 0;
            decimal nakit = 0;
            decimal kredikarti = 0;
            decimal sodexo = 0;
            decimal multinet = 0;
            decimal İkram = 0;
            decimal İndirim = 0;

            for (int i = 0; i < DGVHesaplistesi.Rows.Count - 1; i++)
            {
                odenecektoplamtutar += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());


                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "Nakit")
                {
                    nakit += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "Kredi Kartı")
                {
                    kredikarti += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "Sodexo")
                {
                    sodexo += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "Multinet")
                {
                    multinet += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "İkram")
                {
                    İkram += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() == "İndirim")
                {
                    İndirim += Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString());
                }

            }

            decimal kalantutar = Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString()) - nakit - kredikarti - sodexo - multinet - İkram - İndirim;

            odemekaydetme();

            baglan.Close();
            baglan.Open();
            SqlCommand odemekaydetkomut = new SqlCommand("Insert into [Odemelers] (SipNo,Nakit,KrediKarti,Sodexo,Multinet,SipTutar,KalanTutar,OdemeDurum,Tarih,İkram,İndirim) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglan);
            odemekaydetkomut.Parameters.AddWithValue("@p1", Convert.ToInt16(lblOdemeSipNo.Text.ToString()));
            odemekaydetkomut.Parameters.AddWithValue("@p2", nakit);
            odemekaydetkomut.Parameters.AddWithValue("@p3", kredikarti);
            odemekaydetkomut.Parameters.AddWithValue("@p4", sodexo);
            odemekaydetkomut.Parameters.AddWithValue("@p5", multinet);
            odemekaydetkomut.Parameters.AddWithValue("@p6", Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString()));
            odemekaydetkomut.Parameters.AddWithValue("@p7", kalantutar);
            if (kalantutar == 0)
            {
                odemekaydetkomut.Parameters.AddWithValue("@p8", true);
            }
            else
            {
                odemekaydetkomut.Parameters.AddWithValue("@p8", false);

            }
            odemekaydetkomut.Parameters.AddWithValue("@p9", DateTime.Now);
            odemekaydetkomut.Parameters.AddWithValue("@p10", İkram);
            odemekaydetkomut.Parameters.AddWithValue("@p11", İndirim);




            odemekaydetkomut.ExecuteNonQuery();

            txtOdemeToplamTutar.Text = Convert.ToString(Convert.ToDecimal(txtOdemeToplamTutar.Text.ToString()) - odenecektoplamtutar);



            DGVHesaplistesi.Rows.Clear();

            sipariseDahaOnceOdemeYapildimi();

            odemedetaygetiren();

            if (kalantutar <= 0)
            {


                //************************************************************************************************************************************
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                // Masa Durumunu inaktif eden kod
                baglan.Close();
                baglan.Open();
                SqlCommand Masadurumguncelle = new SqlCommand("Update Masalars Set MasaDurum=@p1 where MasaID=" + lblMasaAd.TabIndex, baglan);
                Masadurumguncelle.Parameters.AddWithValue("@p1", false);
                Masadurumguncelle.ExecuteNonQuery();
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                //************************************************************************************************************************************
                // Sipariş Durumunu inaktif eden kod
                baglan.Close();
                baglan.Open();

                //sipariş kontrolü yapılacak
                DataTable sipkontrol = siparislergetir();
                if (sipkontrol.Rows.Count > 0)
                {
                    SqlCommand sipkapatkomut = new SqlCommand("Update Siparislers Set SipDurum=@p1 where SipNO=" + lblSipNo.Text, baglan);
                    sipkapatkomut.Parameters.AddWithValue("@p1", false);
                    sipkapatkomut.ExecuteNonQuery();
                }

                fisyazdir();

                MessageBox.Show("Sipariş kapatıldı..");
                DGVAdisyon.Rows.Clear();

                txtaratop.Clear();
                txtTop.Clear();
                txtVergi.Clear();
                masaac();
            }

        }

        private void odemekaydetme()
        {
            //for (int i = 0; i < DGVHesaplistesi.Rows.Count-1; i++)
            //{
            //    baglan.Close();
            //    baglan.Open();
            //    SqlDataAdapter urunadetgetir = new SqlDataAdapter("Select UrunAdet From Siparislers where SipID=" + DGVHesaplistesi.Rows[i].Cells[5].Value.ToString(), baglan);
            //    DataTable dturunadet = new DataTable();
            //    urunadetgetir.Fill(dturunadet);

            //    int urunmiktar = Convert.ToInt16(dturunadet.Rows[0][0].ToString());


            //    if ( urunmiktar > 1 )
            //    {
            //        baglan.Close();
            //        baglan.Open();
            //        SqlCommand adetazalt = new SqlCommand("Update Siparislers Set UrunAdet=@p1  where SipID=" + DGVHesaplistesi.Rows[i].Cells[5].Value.ToString(), baglan);
            //        adetazalt.Parameters.AddWithValue("@p1", urunmiktar-1);
            //        adetazalt.ExecuteNonQuery();

            //    }
            //    else
            //    {

            //        baglan.Close();
            //        baglan.Open();
            //        SqlCommand sipkapatkomut = new SqlCommand("Update Siparislers Set SatirOdemeDurum='True' where SipID=" + DGVHesaplistesi.Rows[i].Cells[5].Value.ToString(), baglan);
            //        sipkapatkomut.ExecuteNonQuery();
            //    }




            //}

            for (int i = 0; i < DGVHesaplistesi.Rows.Count - 1; i++)
            {

                baglan.Close();
                baglan.Open();

                SqlCommand hesapkaydet = new SqlCommand("Insert into [SipHesap] (UrunAd,UrunAdet,UrunFiyat,SipID,SipNo) Values (@p1,@p2,@p3,@p4,@p5)", baglan);

                hesapkaydet.Parameters.AddWithValue("@p1", DGVHesaplistesi.Rows[i].Cells[4].Value.ToString());
                hesapkaydet.Parameters.AddWithValue("@p2", Convert.ToInt16(DGVHesaplistesi.Rows[i].Cells[0].Value.ToString()));
                if (DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() != "İkram" && DGVHesaplistesi.Rows[i].Cells[1].Value.ToString() != "İndirim")
                {
                    hesapkaydet.Parameters.AddWithValue("@p3", Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[2].Value.ToString()));

                }
                else
                {
                    hesapkaydet.Parameters.AddWithValue("@p3", Convert.ToDecimal(DGVHesaplistesi.Rows[i].Cells[6].Value.ToString()));

                }
                hesapkaydet.Parameters.AddWithValue("@p4", Convert.ToInt16(DGVHesaplistesi.Rows[i].Cells[5].Value.ToString()));
                hesapkaydet.Parameters.AddWithValue("@p5", Convert.ToInt16(lblOdemeSipNo.Text.ToString()));

                hesapkaydet.ExecuteNonQuery();

            }

        }

        private void Tetikle()
        {
            int Id;
            decimal paket = 0;
            decimal Net = 0;
            baglan.Close();
            decimal sonuc = 0;
            string IDUrun = "";
            SqlDataAdapter NetBul = new SqlDataAdapter("SELECT Stoklars.PaketMiktar, Depo.StokMiktariPaket, Stoklars.UrunID FROM Depo INNER JOIN Stoklars ON Depo.UrunID = Stoklars.UrunID", baglan);
            DataTable Bulmal = new DataTable();
            NetBul.Fill(Bulmal);

            for (int k = 0; k < Bulmal.Rows.Count; k++)
            {
                IDUrun = Bulmal.Rows[k][2].ToString();
                sonuc = Convert.ToDecimal(Bulmal.Rows[k][0]) * Convert.ToDecimal(Bulmal.Rows[k][1]);
                string sonucs = Convert.ToString(sonuc);
                baglan.Open();
                SqlCommand NetHesap = new SqlCommand("Update Depo set StokMiktariNet=@p1 where UrunID=" + Bulmal.Rows[k][2].ToString(), baglan);
                NetHesap.Parameters.AddWithValue("@p1", sonuc);
                NetHesap.ExecuteNonQuery();
                baglan.Close();
            }
            // artık net miktarlar belli gerie net miktarlardan düşmek düşüldüğünde de paket miktarınıda degistirmek kaldı


            SqlDataAdapter MasaBul = new SqlDataAdapter("Select MasaID From Siparislers where SipNo=" + lblOdemeSipNo.Text.ToString(), baglan);
            DataTable MasaAD = new DataTable();
            MasaBul.Fill(MasaAD);

            string MasaID = MasaAD.Rows[0][0].ToString();

            //masa ad al masa durmunu bak 

            SqlDataAdapter MasaDurum = new SqlDataAdapter("Select SipDurum From Siparislers where SipNo=" + lblOdemeSipNo.Text.ToString(), baglan);
            DataTable MasaD = new DataTable();
            MasaDurum.Fill(MasaD);
            string Durumm = MasaD.Rows[0][0].ToString();

            if (Durumm == "True")
            {
                SqlDataAdapter Sipno = new SqlDataAdapter("Select UrunID,UrunAdet From Siparislers where SipNo=" + lblOdemeSipNo.Text.ToString(), baglan);
                DataTable Odenecek = new DataTable();
                Sipno.Fill(Odenecek);
                for (int i = 0; i < Odenecek.Rows.Count; i++)// odenmis urunlerin ıdleri
                {
                    SqlDataAdapter recete = new SqlDataAdapter("Select StokUrun,Birim,Miktar,StokUrunID from Recetelers where UrunID=" + Odenecek.Rows[i]["UrunID"].ToString(), baglan);
                    DataTable Urun = new DataTable();
                    recete.Fill(Urun);//o urun ıd için recete 
                    for (int u = 0; u < Urun.Rows.Count; u++)
                    {
                        decimal Azalt = Convert.ToDecimal(Urun.Rows[u][2].ToString());
                        SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Urun.Rows[u][3].ToString(), baglan);// teraya için paket miktar aldım
                        DataTable PakMikBulDt = new DataTable();
                        PakMikBul.Fill(PakMikBulDt);


                        decimal PakMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);
                        int kritik = Convert.ToInt32(PakMikBulDt.Rows[0]["KritikStokMiktari"]);

                        try
                        {
                            SqlDataAdapter UrunMikkk = new SqlDataAdapter("Select UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Urun.Rows[u][3].ToString(), baglan);
                            DataTable UrunOldMikt = new DataTable();
                            UrunMikkk.Fill(UrunOldMikt);//o urun ıd için depodaki miktar
                            if (UrunOldMikt.Rows.Count < 1)
                            {
                                MessageBox.Show(Urun.Rows[u][0].ToString() + "Ürünü depoya eklenmemiş ");

                            }
                            //MessageBox.Show(Urun.Rows[u][3].ToString());
                            paket = Convert.ToDecimal(UrunOldMikt.Rows[0][1].ToString());
                            Net = Convert.ToDecimal(UrunOldMikt.Rows[0][2].ToString());
                            Id = Convert.ToInt32(UrunOldMikt.Rows[0][3].ToString());

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("sorun");

                        }



                        //null olma ihtimalini düşünerek bişi yapmadın net miktarın çarpanları için

                        decimal SipAdet = Convert.ToDecimal(Odenecek.Rows[i][1].ToString());
                        Azalt = Azalt * SipAdet;
                        Net = Net - Azalt;

                        decimal Pak = Net / PakMiktar;

                        baglan.Open();
                        SqlCommand UrunAz = new SqlCommand("Update Depo set StokMiktariNet=@p1,StokMiktariPaket=@p2 where UrunID=" + Urun.Rows[u][3].ToString(), baglan);
                        UrunAz.Parameters.AddWithValue("@p1", Net);
                        UrunAz.Parameters.AddWithValue("@p2", Pak);
                        UrunAz.ExecuteNonQuery();
                        baglan.Close();
                        if (Net <= kritik)
                        {
                            MessageBox.Show("Yeni " + Urun.Rows[u][0].ToString() + " Siparişi veriniz Ürün  kritik seviyeye düştü!  ");
                        }

                    }



                }

            }

        }

        private void LabelToplamci_Click(object sender, EventArgs e)
        {

        }

        private void btnOdemeDetay_Click(object sender, EventArgs e)
        {
            odemedetaygetiren();
        }

        private void odemedetaygetiren()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter sipdetaygetir = new SqlDataAdapter("Select UrunAd,Sum(UrunAdet) as Ürünler,Sum(UrunFiyat) as Tutar From SipHesap where SipNo=" + Convert.ToInt16(lblOdemeSipNo.Text.ToString()) + "Group By UrunAd", baglan);
            DataTable dt = new DataTable();
            sipdetaygetir.Fill(dt);
            DGVOdemeDetay.DataSource = dt;
        }
    }

}
