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
    public partial class frmMutfak : MaterialForm
    {
        public frmMutfak()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=" +
            ".;" +
            "Initial Catalog=GoPOS;Integrated Security=True");
        Boyutlandir boyut = new Boyutlandir();
        bool hazirmi = false;
        int sipnumara = 0;
        private void frmMutfak_Load(object sender, EventArgs e)
        {
            hazirlanacaksiplistele();

            boyut.mutfak(matCardHazirlamaSeviyesi,this, this.Width, this.Height);
            
        }

        private void hazirlanacaksiplistele()
        {
            baglan.Close();
            baglan.Open();
            SqlDataAdapter hazirlanacaksipgetir = new SqlDataAdapter("SELECT UrunAd, UrunAdet, SipDurum, Tarih, SipNo FROM  Siparislers where MutfakDurum='False' and SipDurum = 'True'",baglan);
            DataTable dthazirlanacak = new DataTable();
            hazirlanacaksipgetir.Fill(dthazirlanacak);
            sipcardolustur(dthazirlanacak);
        }

        private void sipcardolustur(DataTable veri)
        {

            baglan.Close();
            baglan.Open();
            SqlDataAdapter sipnoyagoresayi1 = new SqlDataAdapter("SELECT SipNo FROM Siparislers where MutfakDurum='False' and SipDurum='True' group by SipNo", baglan);
            DataTable dtsayi1 = new DataTable();
            sipnoyagoresayi1.Fill(dtsayi1);

            olusturucu(veri,dtsayi1);
         
        }

        private void olusturucu(DataTable veri, DataTable dtrakam)
        {

            if (dtrakam.Rows.Count<=0)
            {
               

                MessageBox.Show("Hazırlanacak Sipariş Bulunmamaktadır");
            }
            else
            {


                Point[] p = new Point[dtrakam.Rows.Count];
                string log = "sasfasggasg";

                DataTable[] dtsipicerik = new DataTable[dtrakam.Rows.Count];
                DataGridView[] dtmutfak = new DataGridView[dtrakam.Rows.Count];
                FlowLayoutPanel[] pan1 = new FlowLayoutPanel[dtrakam.Rows.Count];
                Button[] btnhazir = new Button[dtrakam.Rows.Count];
                Button[] btnTeslim = new Button[dtrakam.Rows.Count];
               



                for (int a = 0; a < dtrakam.Rows.Count; a++)
                {
                  

                    baglan.Close();
                    baglan.Open();
                    SqlDataAdapter sipnoyagoreicerik = new SqlDataAdapter("SELECT UrunID,UrunAd,UrunAdet,Tarih,TeslimHazirDurum FROM Siparislers where MutfakDurum='False' and SipNo=" + dtrakam.Rows[a]["SipNo"].ToString(),baglan);
                    dtsipicerik[a] = new DataTable();
                    sipnoyagoreicerik.Fill(dtsipicerik[a]);

                    if (dtsipicerik[a].Rows.Count<=0)
                    {

                    }
                    else
                    {
                        dtmutfak[a] = new DataGridView();
                        dtmutfak[a].BackgroundColor = Color.White;
                        dtmutfak[a].BorderStyle = BorderStyle.None;
                        dtmutfak[a].RowHeadersVisible = false;
                        dtmutfak[a].Width = 300;
                        dtmutfak[a].Height = 200;

                        dtmutfak[a].DataSource = dtsipicerik[a];

                        btnhazir[a] = new Button();
                        btnhazir[a].ForeColor = Color.Black;
                        btnhazir[a].Width = 50;
                        btnhazir[a].Height = 50;
                        btnhazir[a].Text = "Hazır";
                        btnhazir[a].TabIndex = Convert.ToInt16(dtrakam.Rows[a]["SipNo"].ToString());

                        btnTeslim[a] = new Button();
                        btnTeslim[a].ForeColor = Color.Black;
                        btnTeslim[a].Width = 50;
                        btnTeslim[a].Height = 50;
                        btnTeslim[a].Text = "Teslim";
                        btnTeslim[a].TabIndex = Convert.ToInt16(dtrakam.Rows[a]["SipNo"].ToString());

                        btnhazir[a].Click += FrmMutfak_Click;
                        btnTeslim[a].Click += FrmMutfak_Click1;

                        pan1[a] = new FlowLayoutPanel();

                        if (dtsipicerik[a].Rows[a]["TeslimHazirDurum"].ToString() == "True")
                        {
                            pan1[a].Controls.Add(btnTeslim[a]);
                            pan1[a].BackColor = Color.Green;
                        }
                        else
                        {
                            pan1[a].Controls.Add(btnhazir[a]);

                        }
                        pan1[a].Dock = DockStyle.Fill;

                        pan1[a].Controls.Add(dtmutfak[a]);

                     

                    }

                       


                }


                Panel[] pnlhazirsip = new Panel[dtrakam.Rows.Count];

                for (int i = 0; i < pnlhazirsip.GetLength(0); i++)
                {



                    pnlhazirsip[i] = new Panel();
                    pnlhazirsip[i].Width = 500;
                    pnlhazirsip[i].Height = 160;
                    pnlhazirsip[i].BackColor = Color.White;
                    pnlhazirsip[i].BorderStyle = BorderStyle.FixedSingle;
                    pnlhazirsip[i].Controls.Add(pan1[i]);



                    p[i] = new Point();
                    p[i].X = i * 83;

                    p[i].Y = 0;

                    log += p.ToString() + "\n";
                    pnlhazirsip[i].PointToClient(p[i]);
                    pnlhazirsip[i].Margin = new Padding(12, 12, 0, 0);
                    pnlhazirsip[i].Show();


                }

                FlowLayoutPanel pan = new FlowLayoutPanel();
                pan.Dock = DockStyle.Fill;
                pan.AutoScroll = true;
                pan.Controls.AddRange(pnlhazirsip);

                matCardHazirlamaSeviyesi.Controls.Add(pan);

            }

       
        }

        private void FrmMutfak_Click1(object sender, EventArgs e)
        {
            int sayi = ((Button)sender).TabIndex;

            baglan.Close();
            baglan.Open();
            SqlCommand mutfakdurumguncelle = new SqlCommand("Update Siparislers set MutfakDurum=@p2 where SipNo=" + sayi, baglan);
            mutfakdurumguncelle.Parameters.AddWithValue("@p2", true);
            mutfakdurumguncelle.ExecuteNonQuery();


            MessageBox.Show("Teslim Edildi ");

            frmAnaSayfa frm = new frmAnaSayfa();

            this.Hide();
            frmMutfak mutfak = new frmMutfak();
            mutfak.MdiParent = this.MdiParent;
            mutfak.Dock = DockStyle.Fill;

            mutfak.Show();
        }

        private void FrmMutfak_Click(object sender, EventArgs e)
        {
            int sayi =  ((Button)sender).TabIndex;

            baglan.Close();
            baglan.Open();
            SqlCommand mutfakdurumguncelle = new SqlCommand("Update Siparislers set TeslimHazirDurum=@p2 where SipNo="+ sayi,baglan);
            mutfakdurumguncelle.Parameters.AddWithValue("@p2", true);
            mutfakdurumguncelle.ExecuteNonQuery();


            MessageBox.Show("Ürünlerin hazır olduğu bilgisi gönderildi ");

            frmAnaSayfa frm = new frmAnaSayfa();

            this.Hide();
            frmMutfak mutfak = new frmMutfak();
            mutfak.MdiParent = this.MdiParent;
            mutfak.Dock = DockStyle.Fill;

            mutfak.Show();


        }



    }
}
