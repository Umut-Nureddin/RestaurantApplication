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
using HiPOS.Class;
using MaterialSkin;
using MaterialSkin.Controls;

namespace HiPOS
{
    public partial class Kasa : MaterialForm
    {
        public Kasa()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");




        private void Kasa_Load(object sender, EventArgs e)
        {
            Kasa frmx = new Kasa();
            int w = this.Size.Width;
            int h = this.Size.Height;
            Responsive(frmx, w, h, materialCard2, PanelKasaTop);
            //CmbDoldur();
        }
        
        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.YeniKasa(frmx, width, height, MatCard, panel);

        }

        private void Time(DateTime start, DateTime end)
        {
            baglan.Close();
            baglan.Open();
            DateTime bas = start;
            DateTime son = end;
            bas.ToString("yyyy-MM-dd ");
            son.ToString("yyyy-MM-dd ");

            SqlDataAdapter ZamanKomut = new SqlDataAdapter("Select TarihKasa, SUM(SiparisTutar) AS Toplam From Siparislers where TarihKasa between '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' GROUP BY TarihKasa  ", baglan);
            DataTable dt = new DataTable(); //Seçili tarihler arasında ki Sipariş tutarları Toplamı as Toplam
            ZamanKomut.Fill(dt);
            SqlDataAdapter ZamanKomutB = new SqlDataAdapter("Select (ZamanB) as Tarih, SUM(ToplamTutar) AS HarcananTutar ,Sum(CikanTutar) as iadeTutar From StokHareketleris where ZamanB between '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' GROUP BY ZamanB  ", baglan);
            DataTable dtB = new DataTable(); //Stok Hareketlerinde ki Girdi ve Çıktıların zaman göre toplamı
            ZamanKomutB.Fill(dtB);

            //SqlDataAdapter GelirGetirKredi = new SqlDataAdapter("SELECT Siparislers.TarihKasa, SUM(Odemelers.KrediKarti) AS KREDİ, SUM(Odemelers.Sodexo) AS SODEXO, SUM(Odemelers.Multinet) AS MULTİNET FROM Odemelers CROSS JOIN Siparislers WHERE(Siparislers.TarihKasa BETWEEN '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "') GROUP BY Siparislers.TarihKasa", baglan);
            //DataTable dtgelirKredi = new DataTable();
            //GelirGetirKredi.Fill(dtgelirKredi);

            SqlDataAdapter GelirGetirKredi = new SqlDataAdapter("SELECT Tarih, SUM(KrediKarti) AS KREDİ, SUM(Sodexo) AS SODEXO, SUM(Multinet) AS MULTİNET FROM Odemelers where Tarih BETWEEN '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' GROUP BY Tarih", baglan);
            DataTable dtgelirKredi = new DataTable();
            GelirGetirKredi.Fill(dtgelirKredi);


            SqlDataAdapter GelirGetirCash = new SqlDataAdapter("SELECT Tarih, SUM(Nakit) AS Nakit FROM Odemelers where Tarih BETWEEN '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' GROUP BY Tarih", baglan);
            DataTable dtGelirCash = new DataTable();
            GelirGetirCash.Fill(dtGelirCash);

            SqlDataAdapter Gider = new SqlDataAdapter("SELECT ZamanB, SUM(ToplamTutar) AS toplam FROM StokHareketleris where ZamanB between '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' Group by ZamanB", baglan);
            DataTable birinci = new DataTable();
            Gider.Fill(birinci);

            SqlDataAdapter Gideringeliri = new SqlDataAdapter("SELECT ZamanB, SUM(CikanMiktar) AS toplam FROM StokHareketleris where ZamanB between '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' Group by ZamanB", baglan);
            DataTable ikinci = new DataTable();
            Gider.Fill(ikinci);

            SqlDataAdapter GiderSon = new SqlDataAdapter("SELECT SUM(ToplamTutar) AS Harcanan, SUM(CikanTutar) AS İade, (sum(ToplamTutar) - sum(CikanTutar)) as Net FROM StokHareketleris where ZamanB between '" + bas.ToString("yyyy-MM-dd ") + "'and '" + son.ToString("yyyy-MM-dd ") + "' ", baglan);
            DataTable GiderTop = new DataTable();
            GiderSon.Fill(GiderTop);



            DGVGelir.DataSource = dt; // bütün tarihlerdeki toplam kazanvı gösteriri
            DGVGider.DataSource = dtB;
            DgvKasaGelirKart.DataSource = dtgelirKredi;
            DgvKasaGelirNakit.DataSource = dtGelirCash;
            DgvSpend.DataSource = GiderTop;
            baglan.Close();
        }

      

       

        private void TodayBtn_Click_1(object sender, EventArgs e)
        {


            DateTime startdate;
            DateTime enddate;

            startdate = DateTime.Today;
            enddate = DateTime.Today;
            Time(startdate, enddate);



        }

        private void LastSevenBtn_Click_1(object sender, EventArgs e)
        {

            DateTime startdate;
            DateTime enddate;

            startdate = DateTime.Today.AddDays(-7);
            enddate = DateTime.Today;
            Time(startdate, enddate);
        }

        private void BuAyBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {

            DateTime startdate;
            DateTime enddate;

            startdate = DateTimeStart.Value;
            enddate = DateTimeFin.Value;
            Time(startdate, enddate);
        }

        private void BtnKasaCredit_Click_1(object sender, EventArgs e)
        {

            DgvKasaGelirKart.Visible = true;
            DgvKasaGelirNakit.Visible = false;
            BtnKasaCredit.BackColor = Color.FromArgb(255, 224, 192);
            BtnKasaGelirNakit.BackColor = Color.White;
        }

        private void BtnKasaGelirNakit_Click_1(object sender, EventArgs e)
        {
            DgvKasaGelirKart.Visible = false;
            DgvKasaGelirNakit.Visible = true;
            BtnKasaCredit.BackColor = Color.White;
            BtnKasaGelirNakit.BackColor = Color.FromArgb(255, 224, 192);
        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelKasaTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
