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
    public partial class frmKullanicilar : Form
    {
        public frmKullanicilar()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");

        private void Kullanicilar_Load(object sender, EventArgs e)
        {
            
            GorevCmbList();
            cmbGorevEkle();
            kullanicilistele();

            MatCardYeniKullaniciEkle.Visible = false;
            matCardYeniGorev.Visible = false;
            frmKullanicilar frmx = new frmKullanicilar();
            int w = this.Size.Width;
            int h = this.Size.Height;
            
            Responsive2(frmx, w, h, matCardKullanicilar, PanelKullan1);
            Responsive(frmx, w, h, MatCardYeniKullaniciEkle, PanelKullan2);
            int ww = MatCardYeniKullaniciEkle.Size.Width;
            int hh= MatCardYeniKullaniciEkle.Size.Height;
            Responsive3(MatCardYeniKullaniciEkle, ww, hh, matCardYeniGorev );
            


        }
        private void Responsive3(MaterialCard MatCard1, int width, int height, MaterialCard MatCard)
        {

            Boyutlandir.Kullanicilar(MatCard1, width, height, MatCard);

        }

        private void GorevCmbList()
        {
            SqlDataAdapter gorev = new SqlDataAdapter("Select JobID,JobType From Gorevlers", baglan);
            DataTable gorevekle = new DataTable();
            gorev.Fill(gorevekle);
            cmbGorev.DataSource = gorevekle;
            cmbGorev.ValueMember = gorevekle.Columns[0].ToString();
            cmbGorev.DisplayMember = gorevekle.Columns[1].ToString();
            
        }
        private void cmbGorevEkle()//xx
        {
            SqlDataAdapter gorev = new SqlDataAdapter("Select JobID,JobType From Gorevlers", baglan);
            DataTable gorevekle = new DataTable();
            gorev.Fill(gorevekle);
            cmbGorevEk.DataSource = gorevekle;
            cmbGorevEk.ValueMember = gorevekle.Columns[0].ToString();
            cmbGorevEk.DisplayMember = gorevekle.Columns[1].ToString();
            
        }

        
        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.YenileGenisYapidaOlanlar(frmx, width, height, MatCard, panel);

        }
        private void Responsive2(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.YenileGenisYapidaOlanlarFlowPanelli(frmx, width, height, MatCard, panel);

        }
        

        private void DGVKullanici_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.icons8_settings_64.Width / 4;
                var h = Properties.Resources.icons8_settings_64.Height / 4;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.icons8_settings_64, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void kullanicilistele()
        {

            btnKullaniciOlustur.Visible = false;
            baglan.Close();
            baglan.Open();
            SqlDataAdapter butunkullanicidatagetir = new SqlDataAdapter("Select KullaniciAdSoyad,Telefon,Email,Yetki,GorevAd,KullaniciPassword,KullaniciPin,KullaniciID From Kullanicilars where KullaniciDurum=" + "'False'", baglan);
            DataTable kullanicidt = new DataTable();
            butunkullanicidatagetir.Fill(kullanicidt);
            DGVKullanici.DataSource = kullanicidt;
        }


        private void btnKullaniciOlustur_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdSoyad.Text == "" || txtKullaniciPin.Text == "" || txtKullaniciPassword.Text == "" || cmbGorev.Text == "")
            {
                MessageBox.Show("Eksik Bilgi girilidi tekrar giriniz(görev,ad,pin,password)");
            }
            else
            {
                bool yetkivarmi;

                if (SwitchYetki.Checked)
                {
                    yetkivarmi = true;
                }
                else
                {
                    yetkivarmi = false;
                }
                baglan.Close();
                baglan.Open();
                SqlCommand kaydetkomut = new SqlCommand("Insert into [Kullanicilars] (KullaniciAdSoyad,Telefon,Email,Yetki,GorevAd,KullaniciPassword,KullaniciPin,KullaniciDurum) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglan);
                kaydetkomut.Parameters.AddWithValue("@p1", txtKullaniciAdSoyad.Text);
                kaydetkomut.Parameters.AddWithValue("@p2", txtKullaniciTelefon.Text);
                kaydetkomut.Parameters.AddWithValue("@p3", txtKullaniciEmail.Text);
                kaydetkomut.Parameters.AddWithValue("@p4", yetkivarmi);
                kaydetkomut.Parameters.AddWithValue("@p5", cmbGorev.Text);
                kaydetkomut.Parameters.AddWithValue("@p6", txtKullaniciPassword.Text);
                kaydetkomut.Parameters.AddWithValue("@p7", txtKullaniciPin.Text);
                kaydetkomut.Parameters.AddWithValue("@p8", false);

                kaydetkomut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Eklendi.");
                kullanicilistele();
                temizler();
            }
            

        }
        private void temizler()
        {
            txtKullaniciAdSoyad.Text = "";//burada
            txtKullaniciTelefon.Text = "";
            txtKullaniciEmail.Text = "";
            txtKullaniciPassword.Text = "";
            txtKullaniciPin.Text = "";
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdSoyad.Text== ""|| txtKullaniciPin.Text==""|| txtKullaniciPassword.Text==""|| cmbGorev.Text=="")
            {
                MessageBox.Show("Eksik Bilgi girilidi tekrar giriniz(görev,ad,pin,password)");
            }
            else
            {
                bool yetkivarmi;

                if (SwitchYetki.Checked)
                {
                    yetkivarmi = true;
                }
                else
                {
                    yetkivarmi = false;
                }
                try
                {
                    baglan.Close();
                    baglan.Open();
                    SqlCommand kullaniciguncellekomut = new SqlCommand("Update Kullanicilars Set KullaniciAdSoyad=@p1,Telefon=@p2,Email=@p3,Yetki=@p4,GorevAd=@p5,KullaniciPassword=@p6,KullaniciPin=@p7 where KullaniciID=" + lblKullaniciID.Text, baglan);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p1", txtKullaniciAdSoyad.Text);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p2", txtKullaniciTelefon.Text);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p3", txtKullaniciEmail.Text);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p4", yetkivarmi);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p5", cmbGorev.Text);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p6", txtKullaniciPassword.Text);
                    kullaniciguncellekomut.Parameters.AddWithValue("@p7", txtKullaniciPin.Text);
                    kullaniciguncellekomut.ExecuteNonQuery();

                    baglan.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Güncelleme işlemi için, işlem yapılmak istenilen kişinin solundaki sembole basınız.");

                }

                MessageBox.Show("Kayıt Güncellendi.");

                kullanicilistele();
                temizler();
            }
            
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            baglan.Close();
            baglan.Open();
            SqlCommand kullaniciguncellekomut = new SqlCommand("Update Kullanicilars Set KullaniciDurum=@p1,Aciklama=@p2 where KullaniciID=" + lblKullaniciID.Text, baglan);
            kullaniciguncellekomut.Parameters.AddWithValue("@p1", true);
            kullaniciguncellekomut.Parameters.AddWithValue("@p2", "Pasif");
            kullaniciguncellekomut.ExecuteNonQuery();
            baglan.Close();


            kullanicilistele();
            temizler();

        }

        private void btnYeniKulaniciEkle_Click(object sender, EventArgs e)
        {
            MatCardYeniKullaniciEkle.Visible = true;
            matCardKullanicilar.Enabled = false;
            btnKullaniciGuncelle.Visible = false;
            btnKullaniciSil.Visible = false;
            btnKullaniciOlustur.Visible = true;



        }

        private void btnYeniKullaniciEkleKapa_Click(object sender, EventArgs e)
        {
            txtKullaniciAdSoyad.Text = "";
            txtKullaniciTelefon.Text = "";
            txtKullaniciEmail.Text = "";
            cmbGorev.Text = "";
            txtKullaniciPassword.Text = "";
            txtKullaniciPin.Text = "";

            MatCardYeniKullaniciEkle.Visible = false;
            matCardKullanicilar.Enabled = true;
            btnKullaniciGuncelle.Visible = true;
            btnKullaniciSil.Visible = true;
            kullanicilistele();

        }


        private void radioBtnButunCalisanlar_CheckedChanged(object sender, EventArgs e)
        {


            SqlDataAdapter aktifkullanicidatagetir = new SqlDataAdapter("Select KullaniciAdSoyad,Telefon,Email,Yetki,GorevAd,KullaniciPassword,KullaniciPin,KullaniciID,KullaniciDurum,Aciklama From Kullanicilars", baglan);
            DataTable kullanicidt = new DataTable();
            aktifkullanicidatagetir.Fill(kullanicidt);
            DGVKullanici.DataSource = kullanicidt;
        }

        private void radioBtnAktifCalisanlar_CheckedChanged(object sender, EventArgs e)
        {
            kullanicilistele();
        }

        private void DGVKullanici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = DGVKullanici.SelectedCells[0].RowIndex;

                txtKullaniciAdSoyad.Text = DGVKullanici.Rows[secilen].Cells[1].Value.ToString();
                txtKullaniciTelefon.Text = DGVKullanici.Rows[secilen].Cells[2].Value.ToString();
                txtKullaniciEmail.Text = DGVKullanici.Rows[secilen].Cells[3].Value.ToString();
                if (Convert.ToBoolean(DGVKullanici.Rows[secilen].Cells[4].Value.ToString()) == true)
                {
                    SwitchYetki.CheckState = CheckState.Checked;

                }
                SwitchYetki.CheckState = CheckState.Unchecked;

                cmbGorev.Text = DGVKullanici.Rows[secilen].Cells[5].Value.ToString();
                txtKullaniciPassword.Text = DGVKullanici.Rows[secilen].Cells[6].Value.ToString();
                txtKullaniciPin.Text = DGVKullanici.Rows[secilen].Cells[7].Value.ToString();
                lblKullaniciID.Text = DGVKullanici.Rows[secilen].Cells[8].Value.ToString();

                MatCardYeniKullaniciEkle.Visible = true;
            }
            catch (Exception)
            {

            }
            
            
           
        }

        private void cmbGorev_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            

        }

        private void YeniGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtGorev.Text != "")

                {
                    baglan.Close();
                    baglan.Open();
                    SqlCommand KaydetG = new SqlCommand("Insert into Gorevlers (JobType) values (@p1) ", baglan);
                    KaydetG.Parameters.AddWithValue("@p1", TxtGorev.Text);
                    KaydetG.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(TxtGorev.Text + "  yeni kayıt olarak eklendi");
                    GorevCmbList();
                    cmbGorevEkle();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Tekrar Giriş yapmayı deneyiniz");
            }
           
        }

        private void GUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Close();
                baglan.Open();
                SqlCommand KaydetG = new SqlCommand("Update Gorevlers set JobType=@p1 where JobID=" + cmbGorevEk.SelectedValue.ToString(), baglan);
                KaydetG.Parameters.AddWithValue("@p1", TxtGorev.Text);
                KaydetG.ExecuteNonQuery();
                baglan.Close();
                GorevCmbList();
                cmbGorevEkle();
                MessageBox.Show(TxtGorev.Text + " Olarak Guncellendi");
                GorevCmbList();
                cmbGorevEkle();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Tekrar Giriş yapmayı deneyiniz");
            }
          
        }

        private void GDeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Close();
                baglan.Open();
                SqlCommand KaydetG = new SqlCommand("Delete from Gorevlers where JobID= " + cmbGorevEk.SelectedValue.ToString(), baglan);
                if (cmbGorevEk.SelectedValue.ToString() != "")
                {
                    KaydetG.Parameters.AddWithValue("@p1", TxtGorev.Text);
                    KaydetG.ExecuteNonQuery();
                    MessageBox.Show(cmbGorevEk.Text + " Kaydı Silindi");
                }
                cmbGorevEk.Text = "";
                baglan.Close();

                GorevCmbList();
                cmbGorevEkle();
            }
            catch (Exception)
            {
                if (cmbGorevEk.SelectedValue==null)
                {
                    MessageBox.Show("Silinecek kayır seçilmedi veya kayıt yok");

                }
                else
                {
                    MessageBox.Show("Hata! Tekrar Giriş yapmayı deneyiniz");
                }
               
            }

        }

        private void btnYeniGorevEkle_Click(object sender, EventArgs e)
        {
            matCardYeniGorev.Visible = true;
            MatCardYeniKullaniciEkle.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matCardYeniGorev.Visible = false;
            MatCardYeniKullaniciEkle.Enabled = true;


        }

        private void cmbGorevEk_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtGorev.Text = cmbGorevEk.Text;
        }
    }
}
