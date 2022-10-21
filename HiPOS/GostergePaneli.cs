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
    public partial class frmGostergePaneli : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");


        string BasTarih = DateTime.Today.ToString("yyyy-MM-dd");
        string SonTarih = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");

        public frmGostergePaneli()
        {
            InitializeComponent();
        }

        private void frmGostergePaneli_Load(object sender, EventArgs e)
        {
            dgvtukenenurunlerdoldur();
            kartezyengrafikdoldur();
            kartezyengrafikdoldurGunler();
            pastagrafikdoldur();
            cirohesaplama();
            siparishesaplama();
            cmburundoldur();

            ChrtKartezyenGun.Visible = false;
            SwitchChrt.Checked = true;
        }

        private void SwitchChrt_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchChrt.Checked == true)
            {
                ChrtKartezyenGun.Visible = false;
                chrtKartezyen.Visible = true;
                cmburungpsterge.Visible = true;
            }
            else
            {
                ChrtKartezyenGun.Visible = true;
                chrtKartezyen.Visible = false;
                cmburungpsterge.Visible = false;
            }
        }

        private void cmburundoldur()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter cmburundoldur = new SqlDataAdapter("Select UrunID,UrunAd From Urunlers", baglan);
            DataTable dtcmb = new DataTable();
            cmburundoldur.Fill(dtcmb);
            dtcmb.Rows.Add(new Object[] { 0, "Hepsi" });
            cmburungpsterge.DataSource = dtcmb;
            cmburungpsterge.DisplayMember = dtcmb.Columns[1].ToString();
            cmburungpsterge.ValueMember = dtcmb.Columns[0].ToString();
            cmburungpsterge.SelectedIndex = 0;

        }




        private void cmburungpsterge_SelectedIndexChanged(object sender, EventArgs e)
        {
            chrtKartezyen.Titles.RemoveAt(0);

            if (cmburungpsterge.Text == "Hepsi")
            {
                kartezyengrafikdoldurhepsi();
            }
            else
            {
                kartezyengrafikdoldur();

            }


        }

        private void siparishesaplama()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT SipNo FROM  dbo.Siparislers WHERE(TarihKasa BETWEEN '" + SonTarih.ToString() + "' AND '" + BasTarih.ToString() + "') GROUP BY SipNo", baglan);
            DataTable dt = new DataTable();
            grafikdoldur.Fill(dt);

            for (int i = 1; i < dt.Rows.Count + 1; i++)
            {
                lblSipTopMiktar.Text = i.ToString();
            }
        }

        private void cirohesaplama()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT  sum(SatirTutar) as Toplam FROM   Siparislers where TarihKasa between '" + SonTarih.ToString() + "' and '" + BasTarih.ToString() + "' ", baglan);
            DataTable dt = new DataTable();
            grafikdoldur.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblCiroTutari.Text = dt.Rows[i]["Toplam"].ToString();
            }

        }

        private void pastagrafikdoldur()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT  Kullanicilars.KullaniciAdSoyad,count(SipID) as Toplam FROM  Siparislers INNER JOIN Kullanicilars ON Siparislers.KullaniciID = Kullanicilars.KullaniciID where TarihKasa between  '" + SonTarih.ToString() + "' and '" + BasTarih.ToString() + "' group by Kullanicilars.KullaniciAdSoyad", baglan);
            DataTable dt = new DataTable();
            grafikdoldur.Fill(dt);

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt16(dt.Rows[i][1].ToString());


            }

            chrtPasta.Series[0].Points.DataBindXY(x, y);



        }

        private void kartezyengrafikdoldurGunler()
        {
            if (ChrtKartezyenGun.Titles.Count > 0)
            {
                ChrtKartezyenGun.Titles.RemoveAt(0);

            }



            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("Set Language Turkish SELECT COUNT(SipID) AS Toplam, DATENAME(WEEKDAY, TarihKasa) AS Gunler FROM dbo.Siparislers where TarihKasa Between '" + SonTarih.ToString() + "' and '" + BasTarih.ToString() + "'  GROUP BY DATENAME(WEEKDAY, TarihKasa) ", baglan);
            DataSet ds = new DataSet();
            grafikdoldur.Fill(ds);
            ChrtKartezyenGun.DataSource = ds;
            ChrtKartezyenGun.Series["Gün Bazında"].XValueMember = "Gunler";
            ChrtKartezyenGun.Series["Gün Bazında"].YValueMembers = "Toplam";
            ChrtKartezyenGun.Titles.Add("Siparişler");

            baglan.Close();
        }

        private void kartezyengrafikdoldurhepsi()
        {
            string urunad = cmburungpsterge.Text;

            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT count(SipID) as Toplam,TarihKasa FROM  Siparislers where TarihKasa Between '" + SonTarih.ToString() + "' and '" + BasTarih.ToString() + "' Group by TarihKasa", baglan);
            DataSet ds = new DataSet();
            grafikdoldur.Fill(ds);
            chrtKartezyen.DataSource = ds;
            chrtKartezyen.Series["Ürün Bazında"].XValueMember = "TarihKasa";
            chrtKartezyen.Series["Ürün Bazında"].YValueMembers = "Toplam";
            chrtKartezyen.Titles.Add("Siparişler");

            baglan.Close();

        }

        private void kartezyengrafikdoldur()
        {
            string urunad = cmburungpsterge.Text;

            baglan.Close();
            baglan.Open();
            SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT count(SipID) as Toplam,TarihKasa FROM  Siparislers where UrunAd='" + urunad + "' and TarihKasa Between '" + SonTarih.ToString() + "' and '" + BasTarih.ToString() + "' Group by TarihKasa", baglan);
            DataSet ds = new DataSet();
            grafikdoldur.Fill(ds);
            chrtKartezyen.DataSource = ds;
            chrtKartezyen.Series["Ürün Bazında"].XValueMember = "TarihKasa";
            chrtKartezyen.Series["Ürün Bazında"].YValueMembers = "Toplam";
            chrtKartezyen.Titles.Add("Siparişler");

            baglan.Close();

        }

        private void dgvtukenenurunlerdoldur()
        {
            baglan.Close();
            baglan.Open();
            //SqlDataAdapter grafikdoldur = new SqlDataAdapter("SELECT UrunAd From Stoklars where KritikStokMiktari

        }

        private void button1_Click(object sender, EventArgs e)//Özel
        {
            BasTarih = dtpSonTarih.Value.ToString("yyyy-MM-dd");
            SonTarih = dtpBasTarih.Value.ToString("yyyy-MM-dd");

            chrtKartezyen.Titles.RemoveAt(0);
            ChrtKartezyenGun.Titles.RemoveAt(0);
            kartezyengrafikdoldurGunler();
            kartezyengrafikdoldur();


            pastagrafikdoldur();
            cirohesaplama();
            siparishesaplama();


        }

        private void button2_Click(object sender, EventArgs e)//Son 24 saat
        {
            BasTarih = DateTime.Now.ToString("yyyy-MM-dd");
            SonTarih = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            chrtKartezyen.Titles.RemoveAt(0);
            ChrtKartezyenGun.Titles.RemoveAt(0);
            kartezyengrafikdoldurGunler();
            kartezyengrafikdoldur();
            pastagrafikdoldur();
            cirohesaplama();
            siparishesaplama();


        }

        private void button4_Click(object sender, EventArgs e) // Son bir hafta
        {
            BasTarih = DateTime.Now.ToString("yyyy-MM-dd");
            SonTarih = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");

            chrtKartezyen.Titles.RemoveAt(0);
            ChrtKartezyenGun.Titles.RemoveAt(0);
            kartezyengrafikdoldurGunler();
            kartezyengrafikdoldur();
            pastagrafikdoldur();
            cirohesaplama();
            siparishesaplama();

        }

        private void btnLast30days_Click(object sender, EventArgs e)
        {
            BasTarih = DateTime.Now.ToString("yyyy-MM-dd");
            SonTarih = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");

            chrtKartezyen.Titles.RemoveAt(0);
            ChrtKartezyenGun.Titles.RemoveAt(0);
            kartezyengrafikdoldurGunler();
            kartezyengrafikdoldur();
            pastagrafikdoldur();
            cirohesaplama();
            siparishesaplama();

        }


    }
}
