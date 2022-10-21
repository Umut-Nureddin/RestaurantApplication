using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiPOS
{
    public partial class frmAnaSayfa : MaterialForm
    {
        public frmAnaSayfa()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange400, Primary.BlueGrey900, Primary.DeepOrange700, Accent.DeepOrange400, TextShade.WHITE);
        }
        
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            
            string a = label1.Text.ToString();
            if (label1.Text.ToString()=="False")
            {
                btnGostergePaneli.Visible = false;
                btngostergeimage.Visible = false;
                btnTanimlamalar.Visible = false;
                btnTanimimage.Visible = false;
                btnKullanici.Visible = false;
                btnkullaniciimage.Visible = false;
                btnKasa.Visible = false;
                btnkasaimage.Visible = false;
                btnUrunOzellik.Visible = false;
                btndepoimage.Visible = false;
                Depooss.Visible = false;
                btnDepofrm.Visible = false;
                DepoHareket.Visible = false;
                btnSatinAlmafrm.Visible = false;
            }
            else
            {
                btnGostergePaneli.Visible = true;
                btngostergeimage.Visible = true;
                btnTanimlamalar.Visible = true;
                btnTanimimage.Visible = true;
                btnKullanici.Visible = true;
                btnkullaniciimage.Visible = true;
                btnKasa.Visible = true;
                btnkasaimage.Visible = true;
                btnUrunOzellik.Visible = true;
                btndepoimage.Visible = true;
                Depooss.Visible = true;
                btnDepofrm.Visible = true;
                DepoHareket.Visible = true;
                btnSatinAlmafrm.Visible = true;
            }


            frmMasalar frmamasa = new frmMasalar();
            frmamasa.MdiParent = this;
            frmamasa.Show();

            frmamasa.Dock = DockStyle.Fill;

            //--------------------------------------------------

            

        }

        private void btnTanimlamalar_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            frmTanimlamalar frmtanim = new frmTanimlamalar();
            frmtanim.MdiParent = this;
            frmtanim.Dock = DockStyle.Fill;

            frmtanim.Show();
            collapseNavkapa();


        }
        //*********************************************************************************************************
        //Responsivee
        private void butonrenklendirici(int tabindex)
        {
            btnanaimage.BackColor = Color.FromArgb(236, 240, 241);
            btngostergeimage.BackColor = Color.FromArgb(236, 240, 241);
            btnTanimimage.BackColor = Color.FromArgb(236, 240, 241);
            btnkullaniciimage.BackColor = Color.FromArgb(236, 240, 241);
            btnkasaimage.BackColor = Color.FromArgb(236, 240, 241);
            btndepoimage.BackColor = Color.FromArgb(236, 240, 241);
            btnDepofrm.BackColor = Color.FromArgb(236, 240, 241);
            btnSatinAlmafrm.BackColor = Color.FromArgb(236, 240, 241);
            btnMutfak.BackColor = Color.FromArgb(236, 240, 241);


            switch (tabindex)
            {
                case 0:
                    btnanaimage.BackColor = Color.FromArgb(255, 224, 192);
                    break;

                case 1:
                    btngostergeimage.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 2:
                    btnTanimimage.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 3:
                    btnkullaniciimage.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 4:
                    btnkasaimage.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 5:
                    btndepoimage.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 6:
                    btnDepofrm.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 7:
                    btnSatinAlmafrm.BackColor = Color.FromArgb(255, 224, 192);

                    break;

                case 8:
                    btnMutfak.BackColor = Color.FromArgb(255, 224, 192);

                    break;
            }
        }
        public void frmAnaSayfa_ResizeEnd(object sender, EventArgs e)
        {
            frmTanimlamalar frmtanim = new frmTanimlamalar();

            frmtanim.MatCardKategori.Width = frmtanim.Size.Width / 2 + 200;
            frmtanim.MatCardKategori.Height = frmtanim.Size.Height;
            frmtanim.MatCardKategori.Location = new Point(frmtanim.Size.Width / 4 - 50, frmtanim.Size.Height / 4 - 50);

            frmtanim.MatCardUrun.Width = frmtanim.Size.Width / 2 + 200;
            frmtanim.MatCardUrun.Height = frmtanim.Size.Height;
            frmtanim.MatCardUrun.Location = new Point(frmtanim.Size.Width / 4 - 50, frmtanim.Size.Height / 4 - 50);

            frmtanim.MatCardMasa.Width = frmtanim.Size.Width / 2 + 200;
            frmtanim.MatCardMasa.Height = frmtanim.Size.Height;
            frmtanim.MatCardMasa.Location = new Point(frmtanim.Size.Width / 4 - 50, frmtanim.Size.Height / 4 - 50);

            frmtanim.matCardRecete.Width = frmtanim.Size.Width / 2 + 200;
            frmtanim.matCardRecete.Height = frmtanim.Size.Height;
            frmtanim.matCardRecete.Location = new Point(frmtanim.Size.Width / 4 - 50, frmtanim.Size.Height / 4 - 50);
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {//l
            butonrenklendirici(((Button)sender).TabIndex);

            frmMasalar frmmasa = new frmMasalar();
            frmmasa.MdiParent = this;
            frmmasa.Dock = DockStyle.Fill;

            frmmasa.Show();
            collapseNavkapa();

        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            frmKullanicilar frmkul = new frmKullanicilar();
            frmkul.MdiParent = this;
            frmkul.Dock = DockStyle.Fill;

            frmkul.Show();
            collapseNavkapa();

        }

        private void btnGostergePaneli_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            frmGostergePaneli frmgos = new frmGostergePaneli();
            frmgos.MdiParent = this;
            frmgos.Dock = DockStyle.Fill;

            frmgos.Show();
            collapseNavkapa();

        }

        private void btnNavHareket_Click(object sender, EventArgs e)
        {
            Kapan();
            
        }

        private void Kapan()
        {
            if (flowPnlNavigator.Size.Width == 58)
            {
                collapseNavac();

            }
            else
            {
                collapseNavkapa();

            }
        }

        private void collapseNavkapa()
        {
          
            
         flowPnlNavigator.Width = 58;
            
        }

        private void collapseNavac()
        {
          flowPnlNavigator.Width = 203;
        }

        private void button2_Click_1(object sender, EventArgs e) // satın alma form gösterme
        {
            butonrenklendirici(((Button)sender).TabIndex);

            SatinAlma Satin = new SatinAlma();
            Satin.MdiParent = this;
            Satin.Dock = DockStyle.Fill;
            Satin.Show();
            collapseNavkapa();
        }

        private void StokTakipbtn_Click(object sender, EventArgs e)
        {//urun ozellikleri
            butonrenklendirici(((Button)sender).TabIndex);

            StokTakip Stok = new StokTakip();
            Stok.MdiParent = this;
            Stok.Dock = DockStyle.Fill;
            Stok.Show();
            collapseNavkapa();
        }

        private void button1_Click(object sender, EventArgs e) // Depo form gösterme
        {
            butonrenklendirici(((Button)sender).TabIndex);

            Depo dpo = new Depo();
            dpo.MdiParent = this;
            dpo.Dock = DockStyle.Fill;
            dpo.Show();
            collapseNavkapa();
        }

        private void btnkasaimage_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            Kasa Kasam = new Kasa();
            Kasam.MdiParent = this;
            Kasam.Dock = DockStyle.Fill;

            Kasam.Show();
            collapseNavkapa();
        }

        public void btnMutfak_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            frmMutfak mutfak = new frmMutfak();
            mutfak.MdiParent = this;
            mutfak.Dock = DockStyle.Fill;

            mutfak.Show();
            collapseNavkapa();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            Kasa Kasam = new Kasa();
            Kasam.MdiParent = this;
            Kasam.Dock = DockStyle.Fill;

            Kasam.Show();
            collapseNavkapa();

        }

        private void btnDepo_Click(object sender, EventArgs e)
        {
            //urum özellikleri
            butonrenklendirici(((Button)sender).TabIndex);

            StokTakip Stok = new StokTakip();
            Stok.MdiParent = this;
            Stok.Dock = DockStyle.Fill;
            Stok.Show();
            collapseNavkapa();
        }

        private void Depooss_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            Depo dpo = new Depo();
            dpo.MdiParent = this;
            dpo.Dock = DockStyle.Fill;
            dpo.Show();
            collapseNavkapa();
        }

        private void DepoHareket_Click(object sender, EventArgs e)
        {
            butonrenklendirici(((Button)sender).TabIndex);

            SatinAlma Satin = new SatinAlma();
            Satin.MdiParent = this;
            Satin.Dock = DockStyle.Fill;
            Satin.Show();
            collapseNavkapa();
        }

        private void button3_Click(object sender, EventArgs e)
        {// Mutfak butonu
            butonrenklendirici(((Button)sender).TabIndex);

            frmMutfak mutfak = new frmMutfak();
            mutfak.MdiParent = this;
            mutfak.Dock = DockStyle.Fill;

            mutfak.Show();
            collapseNavkapa();
        }
    }
}
