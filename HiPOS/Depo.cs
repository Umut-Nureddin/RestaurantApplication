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
    public partial class Depo : Form
    {
        public Depo()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");



        private void Depo_Load(object sender, EventArgs e)
        {
            Depo frmx = new Depo();
            int w = this.Size.Width;
            int h = this.Size.Height;
            Responsive(frmx, w, h, materialCard1, PanelDepo);
           
            depo();

        }
        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.Ddepo(frmx, width, height, MatCard, panel);

        }


        private void depo()
        {


            //degiscek
            baglan.Open();
            SqlDataAdapter stokurunsorgu = new SqlDataAdapter("SELECT  Depo.UrunAD, (Depo.StokMiktariPaket) as Paket_Miktar,(Stoklars.KritikStokMiktari) as MinPaketMiktar, (Depo.StokMiktariPaket*Stoklars.PaketMiktar) as NetMiktar, Stoklars.Birim FROM Depo INNER JOIN Stoklars ON Depo.UrunID = Stoklars.UrunID", baglan);
            DataTable dt = new DataTable();
            stokurunsorgu.Fill(dt);
            DgvDepo.DataSource = dt;
            DgvDepo.Columns[0].HeaderText = "Ürün Adı";
            DgvDepo.Columns[1].HeaderText = "Kalan Paket-Kasa miktarı";
            DgvDepo.Columns[2].HeaderText = "Paket için kritik miktar";
            DgvDepo.Columns[3].HeaderText = "Kalan Ürün Adedi-Gramı";

            baglan.Close();
        }
    }
}
