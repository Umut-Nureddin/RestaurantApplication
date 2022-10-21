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
    public partial class SatinAlma : MaterialForm
    {
        public SatinAlma()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");




        private void StnAlEkleBtn_Click(object sender, EventArgs e)
        {
            SatinAlEkleButon();
        }



        private void SatinAlEkleButon()
        {
            try
            {
                //SatAlUrunCmb.ValueMember
                decimal OldStok = 0;
                decimal RealStok = 0;
                int ayrac = 0;
                baglan.Close();
                baglan.Open();


                SqlDataAdapter DepoBak = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
                DataTable DepoKontrol = new DataTable(); // DEPODAN BİLGİLER ÇEKİLDİ
                DepoBak.Fill(DepoKontrol);
                baglan.Close();
                if (DepoKontrol.Rows.Count < 1)
                {//DEPODA DAHA ÖNCE BİR ÜRÜN YOKSA
                    baglan.Open();
                    SqlCommand DepoInsert = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                    DepoInsert.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                    DepoInsert.Parameters.AddWithValue("@p2", Convert.ToDecimal(SatAlMiktxt.Text.ToString()));
                    DepoInsert.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                    DepoInsert.ExecuteNonQuery();
                    baglan.Close();

                }
                else
                {
                    for (int i = 0; i < DepoKontrol.Rows.Count; i++)
                    {
                        if (DepoKontrol.Rows[i]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString()) //Hata varmı bak Ad Yerine IDlerini karşılaştırsan güzel olur dedik ve degistirdik
                        {


                            OldStok = Convert.ToDecimal(DepoKontrol.Rows[i]["StokMiktariPaket"].ToString());
                            RealStok = OldStok + Convert.ToDecimal(SatAlMiktxt.Text.ToString());
                            baglan.Open();
                            SqlCommand StokG = new SqlCommand("Update Depo set StokMiktariPaket=@p1 where UrunID=" + DepoKontrol.Rows[i]["UrunID"].ToString(), baglan);
                            StokG.Parameters.AddWithValue("@p1", Convert.ToDecimal(RealStok.ToString()));
                            StokG.ExecuteNonQuery();
                            baglan.Close();
                            ayrac = 1;// depodan birden fazla ürün olabilir ama genede seçili ürün ilk kez ekleniyor
                                      //seçili ürün ilk kez eklenmiyorsa


                        }
                    }
                    if (ayrac == 0)
                    {

                        baglan.Open();

                        SqlCommand DepoSave = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                        DepoSave.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                        DepoSave.Parameters.AddWithValue("@p2", Convert.ToDecimal(SatAlMiktxt.Text.ToString()));
                        DepoSave.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                        DepoSave.ExecuteNonQuery();
                        baglan.Close();
                    }

                }
            }
            catch (Exception)
            {
                if (SatAlMiktxt.Text.ToString() == "")
                {
                    MessageBox.Show("Miktar Girmediniz Miktar Giriniz");

                }
                
            }
            // İÇİ BOŞSA  FALAN STOK TRY CATXH HAREKETLERİ KAYIR YERİ
            try
            {
                if (SatAlFiyattxt.Text.ToString() == "")
                {
                    MessageBox.Show(" Tutar girilmeden kayıt yapıldı");

                }
                baglan.Open();
                SqlCommand SatinAlma = new SqlCommand("Insert into [StokHareketleris] (UrunID,UrunAD,EklenenMiktar,KayitNotu,Zaman,ToplamTutar,ZamanB) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan);
                SatinAlma.Parameters.AddWithValue("@p1", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                SatinAlma.Parameters.AddWithValue("@p2", SatAlUrunCmb.Text);
                SatinAlma.Parameters.AddWithValue("@p3", Convert.ToDecimal(SatAlMiktxt.Text.ToString()));
                SatinAlma.Parameters.AddWithValue("@p5", DateTime.Now);
                SatinAlma.Parameters.AddWithValue("@p7", DateTime.Now);
                if (SatAlFiyattxt.Text.ToString() == "")
                {
                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(0));
                    SatAlNottxt.Text = "--!!Urun Tutarı Girilmedigi icin 0 girildi!!--  " + SatAlNottxt.Text;

                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);
                }
                else
                {
                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);

                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(SatAlFiyattxt.Text.ToString()));
                }
                SatinAlma.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();


            }
            catch (Exception)
            {
                MessageBox.Show("Eksik yada Yanlış bilgi girdiniz");

            }
        }

        private void StnAlDznlBtn_Click(object sender, EventArgs e)
        {


            //kopya
            // düzenle butonu
            baglan.Close();
            int a = DGVSatAl.SelectedCells[0].RowIndex;
            int HareketID = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int b = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int Uıd = Convert.ToInt32(DGVSatAl.Rows[a].Cells[1].Value.ToString());


            if (DGVSatAl.Rows[a].Cells[3].Value.ToString() == "")
            { // 4 varsa
                //çıkartma işlemi yaparken güncelleme Eski girilen kayır kadar arttır Eski kaydı Sil Yeni Düşmme Kaydı Oluştur
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[4].Value.ToString());
                decimal SonPaMil = ArtPaMil + PaMik;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();
                // yanlış kaydın depdaki etkisni yok ettik şimdi yeni kayıt yapıcak

                EksiBtn();

                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();



            }
            else
            {// 3 varsa
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);



                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);


                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[3].Value.ToString());
                decimal SonPaMil = PaMik - ArtPaMil;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();

                SatinAlEkleButon();
                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();

            }
        }

        private void StnAlDelete_Click(object sender, EventArgs e)
        {

            baglan.Close();
            int a = DGVSatAl.SelectedCells[0].RowIndex;
            int HareketID = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int b = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int Uıd = Convert.ToInt32(DGVSatAl.Rows[a].Cells[1].Value.ToString());


            if (DGVSatAl.Rows[a].Cells[3].Value.ToString() == "")
            { // 4 varsa
                //çıkartma işlemi yaparken güncelleme Eski girilen kayır kadar arttır Eski kaydı Sil Yeni Düşmme Kaydı Oluştur
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[4].Value.ToString());
                decimal SonPaMil = ArtPaMil + PaMik;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();
                // yanlış kaydın depdaki etkisni yok ettik şimdi yeni kayıt yapıcak



                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();



            }
            else
            {// 3 varsa
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);



                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);// burayada bak


                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[3].Value.ToString());
                decimal SonPaMil = PaMik - ArtPaMil;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();


                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();

            }

        }

        private void eksiurunbtn_Click(object sender, EventArgs e)
        {
            EksiBtn();
        }

        private void EksiBtn()
        {

            baglan.Open();
            SqlDataAdapter DepoBak = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
            DataTable DepoKontrol = new DataTable();
            DepoBak.Fill(DepoKontrol);
            baglan.Close();
            decimal a = 0;
            decimal OldStokk = 0;
            decimal RealStokk = 0;
            int ayracc = 0;
            baglan.Open();
            SqlDataAdapter DepoBakk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
            DataTable DepoKontroll = new DataTable();
            DepoBakk.Fill(DepoKontroll);
            baglan.Close();
            if (DepoKontroll.Rows.Count < 1)
            {
                a = -Convert.ToDecimal(SatAlMiktxt.Text.ToString());
                baglan.Open();
                SqlCommand DepoInsertt = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                DepoInsertt.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                DepoInsertt.Parameters.AddWithValue("@p2", a);
                DepoInsertt.Parameters.AddWithValue("@p3", Convert.ToDecimal(SatAlUrunCmb.SelectedValue.ToString()));


                DepoInsertt.ExecuteNonQuery();
                baglan.Close();
            }
            else
            {
                try
                {
                    for (int i = 0; i < DepoKontroll.Rows.Count; i++)
                    {
                        if (DepoKontroll.Rows[i]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                        {
                            OldStokk = Convert.ToDecimal(DepoKontroll.Rows[i]["StokMiktariPaket"].ToString());
                            RealStokk = OldStokk - Convert.ToDecimal(SatAlMiktxt.Text.ToString());
                            baglan.Open();
                            SqlCommand StokGg = new SqlCommand("Update Depo set StokMiktariPaket=@p1 where UrunID=" + DepoKontrol.Rows[i]["UrunID"].ToString(), baglan);
                            StokGg.Parameters.AddWithValue("@p1", Convert.ToDecimal(RealStokk.ToString()));
                            StokGg.ExecuteNonQuery();
                            baglan.Close();
                            ayracc = 1;
                        }
                    }
                    if (ayracc == 0)
                    {
                        baglan.Open();
                        a = -Convert.ToDecimal(SatAlMiktxt.Text.ToString());
                        SqlCommand DepoSavee = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                        DepoSavee.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                        DepoSavee.Parameters.AddWithValue("@p2", a);
                        DepoSavee.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                        DepoSavee.ExecuteNonQuery();
                        baglan.Close();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Eksik veya Hatalı giriş yapıldı");

                }


            }

            try
            {

                SatınAlma();

                baglan.Open();
                SqlCommand SatinAlma = new SqlCommand("Insert into [StokHareketleris] (UrunID,UrunAD,CikanMiktar,KayitNotu,Zaman,CikanTutar,ZamanB) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan);
                SatinAlma.Parameters.AddWithValue("@p1", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                SatinAlma.Parameters.AddWithValue("@p2", SatAlUrunCmb.Text);
                SatinAlma.Parameters.AddWithValue("@p3", Convert.ToDecimal(SatAlMiktxt.Text.ToString()));
                SatinAlma.Parameters.AddWithValue("@p5", DateTime.Now);
                SatinAlma.Parameters.AddWithValue("@p7", DateTime.Now);

                if (SatAlFiyattxt.Text.ToString() == "")
                {
                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(0));
                    SatAlNottxt.Text = "--!!Urun Tutarı Girilmedigi icin 0 girildi!!--   " + SatAlNottxt.Text;

                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);
                }
                else
                {
                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);

                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(SatAlFiyattxt.Text.ToString()));
                }

                SatinAlma.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();


            }
            catch (Exception)
            {
                MessageBox.Show("Eksik yada Yanlış bilgi girdiniz");

            }
        }

        private void DGVSatAl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HareketID = DGVSatAl.SelectedCells[0].RowIndex;
            SatAlUrunCmb.Text = DGVSatAl.Rows[HareketID].Cells[2].Value.ToString();
            SatAlMiktxt.Text = DGVSatAl.Rows[HareketID].Cells[3].Value.ToString();
            if (SatAlMiktxt.Text == "")
            {
                SatAlMiktxt.Text = DGVSatAl.Rows[HareketID].Cells[4].Value.ToString();

            }

            SatAlNottxt.Text = DGVSatAl.Rows[HareketID].Cells[5].Value.ToString();

            SatAlFiyattxt.Text = DGVSatAl.Rows[HareketID].Cells[7].Value.ToString();
        }
        private void SatınAlma()//kopya
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter SatinAlmaSorgu = new SqlDataAdapter("Select UrunID,UrunAd From Stoklars", baglan);
            DataTable dt = new DataTable();
            SatinAlmaSorgu.Fill(dt);
            baglan.Close();
            SatAlUrunCmb.DataSource = dt;
            SatAlUrunCmb.ValueMember = dt.Columns[0].ToString();
            SatAlUrunCmb.DisplayMember = dt.Columns[1].ToString();


            baglan.Close();

            baglan.Open();
            SqlDataAdapter SatinAlmaListele = new SqlDataAdapter("Select HareketID,UrunID,UrunAD,EklenenMiktar,CikanMiktar,KayitNotu,Zaman,ToplamTutar,CikanTutar from StokHareketleris ", baglan);
            DataTable SqlSatinalma = new DataTable();
            SatinAlmaListele.Fill(SqlSatinalma);
            DGVSatAl.DataSource = SqlSatinalma;
            baglan.Close();
        }



        private void StokTakibi_Load(object sender, EventArgs e)
        {
            SatinAlma frmx = new SatinAlma();
            int w = this.Size.Width;
            int h = this.Size.Height;

            Responsive(frmx, w, h, CardSAlma, PanelSatAl1, PanelSatAl2);


            SatınAlma();


        }

        private void Responsive(Form frmx, int w, int h, MaterialCard cardSAlma, TableLayoutPanel panel, TableLayoutPanel panel2)
        {
            Boyutlandir.SatAL(frmx, w, h, cardSAlma, panel, panel2);

        }

        private void SatAlFiyattxt_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;

            }
        }

        private void SatAlMiktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;

            }
        }

        public void materialSwitch1_CheckStateChanged(object sender, EventArgs e)
        {
            int variable = 0;
            if (PaketAdetSwitch.Checked)
            {
                variable = 1;
                AdetEkleBtn.Visible = true;
                AdetTBox.Visible = true;
                AdetLbl.Visible = true;
                StnAlDznlBtn2.Visible = true;
                StnAlDelete2.Visible = true;
                eksiurunbtn2.Visible=true;

                StnAlEkleBtn.Visible = false;
                SatAlMiktxt.Visible = false;
                materialLabel14.Visible = false;
                StnAlDznlBtn.Visible = false;
                StnAlDelete.Visible = false;
                eksiurunbtn.Visible = false;

            }
            else
            {   // variable sıfır
                AdetEkleBtn.Visible = false;
                AdetTBox.Visible = false;
                AdetLbl.Visible = false;
                StnAlDznlBtn2.Visible = false;
                StnAlDelete2.Visible = false;
                eksiurunbtn2.Visible = false;

                StnAlEkleBtn.Visible = true;
                SatAlMiktxt.Visible = true;
                materialLabel14.Visible = true;
                StnAlDznlBtn.Visible = true;
                StnAlDelete.Visible = true;
                eksiurunbtn.Visible = true;
            }
        }

        private void AdetEkleBtn_Click(object sender, EventArgs e)
        {
            decimal OldAmount = 0;
            decimal AmountToBeAdd = 0;
            decimal LastAmount = 0;
            decimal PaketKapasitesi = 0;
            decimal Net = 0;
            int Ayrac = 0;
            if (AdetTBox.Text.ToString()=="")
            {
                MessageBox.Show("Adet için miktar giriniz");
            }
            else
            {
                SqlDataAdapter PaketBilgisi = new SqlDataAdapter("Select UrunID,PaketMiktar from Stoklars", baglan);
                DataTable PaketData = new DataTable(); //BİR PAKET İÇİNDEKİ PAKET MİKTARI VE URUNID Sİ ÇEKİLDİ
                PaketBilgisi.Fill(PaketData);

                SqlDataAdapter DepoBak = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
                DataTable DepoKontrol = new DataTable(); // DEPODAN BİLGİLER ÇEKİLDİ 
                DepoBak.Fill(DepoKontrol);


                baglan.Close();
                if (DepoKontrol.Rows.Count < 1)
                {//DEPODA DAHA ÖNCE BİR ÜRÜN YOKSA
                    for (int k = 0; k < PaketData.Rows.Count; k++)
                    {
                        if (PaketData.Rows[k]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                        {
                            PaketKapasitesi = Convert.ToDecimal(PaketData.Rows[k]["PaketMiktar"].ToString());
                            //seçili ürün için kapasitemiktarını öğrendim 
                            Net = Convert.ToDecimal(AdetTBox.Text.ToString());
                            LastAmount = Net / PaketKapasitesi;
                            baglan.Open();
                            SqlCommand DepoInsert = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID,StokMiktariNet) Values (@p1,@p2,@p3,@p4)", baglan);
                            DepoInsert.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                            DepoInsert.Parameters.AddWithValue("@p4", Net);
                            DepoInsert.Parameters.AddWithValue("@p2", LastAmount);
                            DepoInsert.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                            DepoInsert.ExecuteNonQuery();
                            baglan.Close();
                            // adeti pakete dönüştürüp ekliycem
                            // paket miktarını addete dömnüştürp adeti güncelliycem
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < PaketData.Rows.Count; i++)
                    {
                        if (PaketData.Rows[i]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                        {
                            PaketKapasitesi = Convert.ToDecimal(PaketData.Rows[i]["PaketMiktar"].ToString());
                            //seçili ürün için kapasitemiktarını öğrendim 

                            for (int j = 0; j < DepoKontrol.Rows.Count; j++)
                            {
                                if (DepoKontrol.Rows[j]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                                // seçili ürünün depodaki değerini bulucam

                                {
                                    OldAmount = Convert.ToDecimal(DepoKontrol.Rows[j]["StokMiktariPaket"].ToString());
                                    AmountToBeAdd = Convert.ToDecimal(AdetTBox.Text.ToString()) / PaketKapasitesi;
                                    MessageBox.Show(AmountToBeAdd.ToString() + " Bu kadar paket eklenicektir");
                                    LastAmount = OldAmount + AmountToBeAdd;
                                    MessageBox.Show(LastAmount.ToString() + "Son paket tutari");
                                    Net = LastAmount * PaketKapasitesi;


                                    baglan.Close();
                                    baglan.Open();
                                    SqlCommand LastStocks = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + SatAlUrunCmb.SelectedValue.ToString(), baglan);
                                    LastStocks.Parameters.AddWithValue("@p1", LastAmount);
                                    LastStocks.Parameters.AddWithValue("@p2", Net);
                                    LastStocks.ExecuteNonQuery();

                                    baglan.Close();
                                    Ayrac = 1;
                                }
                            }
                        }
                    }
                }
                if (Ayrac == 0)
                {
                    // NEDEN BU ? ÇÜNKÜ DAHA ÖNCE EKLENMEMİŞ Bİ ÜRÜN YUKARIDAKİ LİSTELEMEDE BULUNAMACAĞI İÇİN 
                    for (int z = 0; z < PaketData.Rows.Count; z++)
                    {
                        if (PaketData.Rows[z]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                        {
                            PaketKapasitesi = Convert.ToDecimal(PaketData.Rows[z]["PaketMiktar"].ToString());
                            //seçili ürün için kapasitemiktarını öğrendim 
                            Net = Convert.ToDecimal(AdetTBox.Text.ToString());
                            LastAmount = Net / PaketKapasitesi;
                            baglan.Open();
                            SqlCommand DepoInsert = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID,StokMiktariNet) Values (@p1,@p2,@p3,@p4)", baglan);
                            DepoInsert.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                            DepoInsert.Parameters.AddWithValue("@p4", Net);
                            DepoInsert.Parameters.AddWithValue("@p2", LastAmount);
                            DepoInsert.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                            DepoInsert.ExecuteNonQuery();
                            baglan.Close();
                        }
                    }
                }

                // Satın alma hareketlerine eklenme kısmı 
                try
                {
                    if (SatAlFiyattxt.Text.ToString() == "")
                    {
                        MessageBox.Show(" Tutar girilmeden kayıt yapıldı");

                    }
                    baglan.Open();
                    SqlCommand SatinAlma = new SqlCommand("Insert into [StokHareketleris] (UrunID,UrunAD,EklenenMiktar,KayitNotu,Zaman,ToplamTutar,ZamanB) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan);
                    SatinAlma.Parameters.AddWithValue("@p1", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                    SatinAlma.Parameters.AddWithValue("@p2", SatAlUrunCmb.Text);
                    SatinAlma.Parameters.AddWithValue("@p3", Convert.ToDecimal(AdetTBox.Text.ToString()) / PaketKapasitesi);
                    SatinAlma.Parameters.AddWithValue("@p5", DateTime.Now);
                    SatinAlma.Parameters.AddWithValue("@p7", DateTime.Now);
                    if (SatAlFiyattxt.Text.ToString() == "")
                    {
                        SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(0));
                        SatAlNottxt.Text = "--!!Urun Tutarı Girilmedigi icin 0 girildi!!--  " + SatAlNottxt.Text;

                        SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);
                    }
                    else
                    {
                        SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);

                        SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(SatAlFiyattxt.Text.ToString()));
                    }
                    SatinAlma.ExecuteNonQuery();
                    baglan.Close();
                    SatınAlma();


                }
                catch (Exception)
                {
                    MessageBox.Show("Eksik yada Yanlış bilgi girdiniz");

                }

            }
            



        }

        private void StnAlDznlBtn2_Click(object sender, EventArgs e)
        {
            baglan.Close();
            int a = DGVSatAl.SelectedCells[0].RowIndex;
            int HareketID = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int b = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int Uıd = Convert.ToInt32(DGVSatAl.Rows[a].Cells[1].Value.ToString());


            if (DGVSatAl.Rows[a].Cells[3].Value.ToString() == "")
            { // 4 varsa
                //çıkartma işlemi yaparken güncelleme Eski girilen kayır kadar arttır Eski kaydı Sil Yeni Düşmme Kaydı Oluştur
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[4].Value.ToString());
                decimal SonPaMil = ArtPaMil + PaMik;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();
                // yanlış kaydın depdaki etkisni yok ettik şimdi yeni kayıt yapıcak

                EksiBtn();

                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();



            }
            else
            {// 3 varsa
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);



                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);


                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[3].Value.ToString());
                decimal SonPaMil = PaMik - ArtPaMil;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();

                SatinAlEkleButon();
                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();

            }

        }

        private void StnAlDelete2_Click(object sender, EventArgs e)
        {


            baglan.Close();
            int a = DGVSatAl.SelectedCells[0].RowIndex;
            int HareketID = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int b = Convert.ToInt32(DGVSatAl.Rows[a].Cells[0].Value.ToString());
            int Uıd = Convert.ToInt32(DGVSatAl.Rows[a].Cells[1].Value.ToString());


            if (DGVSatAl.Rows[a].Cells[3].Value.ToString() == "")
            { // 4 varsa
                //çıkartma işlemi yaparken güncelleme Eski girilen kayır kadar arttır Eski kaydı Sil Yeni Düşmme Kaydı Oluştur
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[4].Value.ToString());
                decimal SonPaMil = ArtPaMil + PaMik;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();
                // yanlış kaydın depdaki etkisni yok ettik şimdi yeni kayıt yapıcak



                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();



            }
            else
            {// 3 varsa
                baglan.Open();
                SqlDataAdapter DepoCekkk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo where UrunID=" + Uıd.ToString(), baglan);
                DataTable DepoCekDt = new DataTable();
                DepoCekkk.Fill(DepoCekDt);
                decimal PaMik = Convert.ToDecimal(DepoCekDt.Rows[0][2]);



                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + Uıd.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);


                decimal ArtPaMil = Convert.ToDecimal(DGVSatAl.Rows[a].Cells[3].Value.ToString());
                decimal SonPaMil = PaMik - ArtPaMil;
                decimal YeniNet = SonPaMil * PakiciMiktar;

                SqlCommand UpdateRise = new SqlCommand("Update Depo set StokMiktariPaket=@p1,StokMiktariNet=@p2  where UrunID=" + Uıd.ToString(), baglan);
                UpdateRise.Parameters.AddWithValue("@p1", SonPaMil);
                UpdateRise.Parameters.AddWithValue("@p2", YeniNet);
                UpdateRise.ExecuteNonQuery();
                baglan.Close();


                baglan.Open();
                SqlCommand silkomut = new SqlCommand("Delete from StokHareketleris where HareketID=" + b.ToString(), baglan);
                silkomut.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();

            }
        }

        private void eksiurunbtn2_Click(object sender, EventArgs e)
        {


            baglan.Open();
            SqlDataAdapter DepoBak = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
            DataTable DepoKontrol = new DataTable();
            DepoBak.Fill(DepoKontrol);
            baglan.Close();
            decimal a = 0;
            decimal OldStokk = 0;
            decimal RealStokk = 0;
            int ayracc = 0;
            baglan.Open();
            SqlDataAdapter DepoBakk = new SqlDataAdapter("Select DepoUrunID,UrunAD,StokMiktariPaket,StokMiktariNet,UrunID from Depo", baglan);
            DataTable DepoKontroll = new DataTable();
            DepoBakk.Fill(DepoKontroll);
            baglan.Close();
            if (DepoKontroll.Rows.Count < 1)
            {

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + SatAlUrunCmb.SelectedValue.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);
                


                decimal PakiciMiktar = Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);
                a = -Convert.ToDecimal(AdetTBox.Text.ToString());
                
                decimal Last = a/PakiciMiktar;
                //burası
                baglan.Open();
                SqlCommand DepoInsertt = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                DepoInsertt.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                DepoInsertt.Parameters.AddWithValue("@p2", Last);
                DepoInsertt.Parameters.AddWithValue("@p3", Convert.ToDecimal(SatAlUrunCmb.SelectedValue.ToString()));


                DepoInsertt.ExecuteNonQuery();
                baglan.Close();
            }
            else
            {
                try
                {
                    

                    for (int i = 0; i < DepoKontroll.Rows.Count; i++)
                    {
                        if (DepoKontroll.Rows[i]["UrunID"].ToString() == SatAlUrunCmb.SelectedValue.ToString())
                        {

                            SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + SatAlUrunCmb.SelectedValue.ToString(), baglan);// teraya için paket miktar aldım
                            DataTable PakMikBulDt = new DataTable();
                            PakMikBul.Fill(PakMikBulDt);

                            decimal artik = Convert.ToDecimal(AdetTBox.Text.ToString()) / Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                            OldStokk = Convert.ToDecimal(DepoKontroll.Rows[i]["StokMiktariPaket"].ToString());
                            RealStokk = OldStokk - artik;
                            baglan.Open();
                            SqlCommand StokGg = new SqlCommand("Update Depo set StokMiktariPaket=@p1 where UrunID=" + DepoKontrol.Rows[i]["UrunID"].ToString(), baglan);
                            StokGg.Parameters.AddWithValue("@p1", Convert.ToDecimal(RealStokk.ToString()));
                            StokGg.ExecuteNonQuery();
                            baglan.Close();
                            ayracc = 1;
                        }
                    }
                    if (ayracc == 0)
                    {

                        SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + SatAlUrunCmb.SelectedValue.ToString(), baglan);// teraya için paket miktar aldım
                        DataTable PakMikBulDt = new DataTable();
                        PakMikBul.Fill(PakMikBulDt);

                        decimal artik = Convert.ToDecimal(AdetTBox.Text.ToString()) / Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                        baglan.Open();
                        a = -Convert.ToDecimal(SatAlMiktxt.Text.ToString());
                        SqlCommand DepoSavee = new SqlCommand("Insert into [Depo] (UrunAD,StokMiktariPaket,UrunID) Values (@p1,@p2,@p3)", baglan);
                        DepoSavee.Parameters.AddWithValue("@p1", SatAlUrunCmb.Text);
                        DepoSavee.Parameters.AddWithValue("@p2", artik);
                        DepoSavee.Parameters.AddWithValue("@p3", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                        DepoSavee.ExecuteNonQuery();
                        baglan.Close();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Eksik veya Hatalı giriş yapıldı");

                }


            }
            //SeniSen

            try
            {

                SqlDataAdapter PakMikBul = new SqlDataAdapter("Select PaketMiktar,KritikStokMiktari from Stoklars where UrunID=" + SatAlUrunCmb.SelectedValue.ToString(), baglan);// teraya için paket miktar aldım
                DataTable PakMikBulDt = new DataTable();
                PakMikBul.Fill(PakMikBulDt);

                decimal artik = Convert.ToDecimal(AdetTBox.Text.ToString()) / Convert.ToDecimal(PakMikBulDt.Rows[0]["PaketMiktar"]);

                SatınAlma();

                baglan.Open();
                SqlCommand SatinAlma = new SqlCommand("Insert into [StokHareketleris] (UrunID,UrunAD,CikanMiktar,KayitNotu,Zaman,CikanTutar,ZamanB) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan);
                SatinAlma.Parameters.AddWithValue("@p1", Convert.ToInt32(SatAlUrunCmb.SelectedValue.ToString()));
                SatinAlma.Parameters.AddWithValue("@p2", SatAlUrunCmb.Text);
                SatinAlma.Parameters.AddWithValue("@p3", artik);
                SatinAlma.Parameters.AddWithValue("@p5", DateTime.Now);
                SatinAlma.Parameters.AddWithValue("@p7", DateTime.Now);

                if (SatAlFiyattxt.Text.ToString() == "")
                {
                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(0));
                    SatAlNottxt.Text = "--!!Urun Tutarı Girilmedigi icin 0 girildi!!--   " + SatAlNottxt.Text;

                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);
                }
                else
                {
                    SatinAlma.Parameters.AddWithValue("@p4", SatAlNottxt.Text);

                    SatinAlma.Parameters.AddWithValue("@p6", Convert.ToDecimal(SatAlFiyattxt.Text.ToString()));
                }

                SatinAlma.ExecuteNonQuery();
                baglan.Close();
                SatınAlma();


            }
            catch (Exception)
            {
                MessageBox.Show("Eksik yada Yanlış bilgi girdiniz");

            }
        }
    }
}

//yapılcak 
// Adetin içi boşsa Kayıt giremiyeceksin --- ----YApınca Sil-- on progress ı think :P
//Diğer butonlar için giriş yapılmadı 
