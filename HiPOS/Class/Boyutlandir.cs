using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiPOS.Class
{
    public class Boyutlandir
    { private void Yorumlar()
        { //public void size(object item, )
          //{


            //    item.Width = this.Size.Width * 7 / 10;
            //    item.Height = this.Size.Height * 92 / 100;
            //    item.Location = new Point(this.Size.Width * 15 / 100, this.Size.Height / 4);

            //    PanelTanim.Width = MatCardUrun.Width * 92 / 100;
            //    PanelTanim.Height = MatCardUrun.Height * 92 / 100;
            //}
            //internal static void Yenile(Form FormGelen, MaterialSkin.Controls.MaterialCard matcartGelen)
            //{
            //    //foreach (var item in FormGelen.Controls)
            //    //{
            //    //    if (item.ToString() == matcartGelen.ToString())

            //    //    {
            //            matcartGelen.Height =  ( FormGelen.Size.Height *90/100 );
            //            matcartGelen.Width = (FormGelen.Size.Width * 70 / 100);
            //    //    }

            //    //}
            //}





        }

        internal static void Yenile(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {
            matcartGelen.Height = height * 93 / 100;
            matcartGelen.Width = width * 93 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel.Height = matcartGelen.Height * 92 / 100;
            //return matcartGelen.Width;

        }

        internal static void YenileK(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {
            matcartGelen.Height = height * 65 / 100;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel.Height = matcartGelen.Height * 92 / 100;
            //return matcartGelen.Width;

        }

        internal static void Ddepo(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {
            matcartGelen.Height = height;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 5);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel.Height = matcartGelen.Height * 92 / 100;

            //return matcartGelen.Width;

        }

        internal static void YenileGenisYapidaOlanlar(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {
            matcartGelen.Height = height;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel.Height = matcartGelen.Height * 92 / 100;
            //return matcartGelen.Width;

        }
        internal static void YenileGenisYapidaOlanlarFlowPanelli(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {
            matcartGelen.Height = height;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel.Height = matcartGelen.Height * 92 / 100;
        }
        internal static void YeniKasa(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel)
        {   //birden fazla panel içeren
            matcartGelen.Height = height * 110 / 100;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location =  new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 95 / 100;
          

        }
        internal static void SatAL(Form frmx, int width, int height, MaterialCard matcartGelen, TableLayoutPanel panel, TableLayoutPanel panel2)
        {   //birden fazla panel içeren
            matcartGelen.Height = height;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
            panel.Width = matcartGelen.Width * 92 / 100;
            panel2.Width = matcartGelen.Width * 90 / 100;
        
        }
        internal static void Siparis(Form frmx, int width, int height, MaterialCard matcartGelen)
        {   //birden fazla panel içeren
            matcartGelen.Height = height * 11 / 10; ;
            matcartGelen.Width = width * 90 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);


        }
        internal static void Kullanicilar(MaterialCard matcartGelen1, int width, int height, MaterialCard matcartGelen)
        {   //birden fazla panel içeren
            matcartGelen.Height = height * 40 / 100;
            matcartGelen.Width = width * 54 / 100;
            matcartGelen.Location = new Point(matcartGelen1.Size.Width * 40 / 100, matcartGelen1.Size.Height /2);
            

        }

        public void mutfak(MaterialCard matcartGelen1,Form frmx, int width, int height)
        {   //birden fazla panel içeren
            matcartGelen1.Height = height;
            matcartGelen1.Width = width * 90 / 100;
            matcartGelen1.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);
        }

        internal static void Rezarvasyon(Form frmx, int width, int height, MaterialCard matcartGelen)
        {
            matcartGelen.Height = height * 80/ 100;
            matcartGelen.Width = width * 80 / 100;
            matcartGelen.Location = new Point(frmx.Size.Width * 6 / 100, frmx.Size.Height / 6);

        }
    }

}
