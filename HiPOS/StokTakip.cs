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
    public partial class StokTakip : MaterialForm
    {
        public StokTakip()
        {
            InitializeComponent();
        }
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");




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

        private void btnStokEkle_Click(object sender, EventArgs e)
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
                    if (stokadlari.Rows[i]["UrunAd"].ToString()==cmbStokUrun.Text)
                    {
                        stokvarmi = 1;
                    }
                    
                }
                baglan.Close();

                if (stokvarmi==0)
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
                else if (stokvarmi==1)
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

        private void btnStokGuncelle_Click(object sender, EventArgs e)
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

        private void btnStokSil_Click(object sender, EventArgs e)
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

        private void StokTakip_Load(object sender, EventArgs e)
        {
            StokTakip frmx = new StokTakip();
            int w = this.Size.Width;
            int h = this.Size.Height;

            Responsive(frmx, w, h, MatCardStok, PanelStokTakip);
            CardBirimDuzen.Location = new Point(MatCardStok.Size.Width * 35 / 100, MatCardStok.Size.Height * 35 / 100);



            stokurunlistele();
            BirimListesiUpdate();

        }
        private void Responsive(Form frmx, int width, int height, MaterialCard MatCard, TableLayoutPanel panel)
        {

            Boyutlandir.Yenile(frmx, width, height, MatCard, panel);

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
                MatCardStok.Enabled = false;
            }
            else
            {
                CardBirimDuzen.Visible = false;
                MatCardStok.Enabled = true;

            }


        }

        private void BirimSwitch_Click(object sender, EventArgs e)
        {
            BirimDuzenle();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            BirimSwitch.Checked = false;
            BirimDuzenle();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            BirimSwitch.Checked = true;
            BirimDuzenle();

        }

        private void PanelStokTakip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BirimSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
