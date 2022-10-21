using MaterialSkin.Controls;
using MaterialSkin;
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
using System.Globalization;

namespace HiPOS
{
    public partial class Login : MaterialForm
    {
        SqlConnection baglan = new SqlConnection("Data Source =.; Initial Catalog = GoPOS; Integrated Security = True");
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey700, Primary.Amber100, Accent.Red200, TextShade.WHITE);

        }


        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        public void btnGiris_Click(object sender, EventArgs e)
        {
            Lisansli();
        }

        private void Lisansli()
        {


            string code;
            string Sifre = "Nediyonlankelle";
            int a = 0;
            SqlDataAdapter password = new SqlDataAdapter("Select ID,Bis,Ver from Bin", baglan);
            DataTable PasswordTable = new DataTable();
            password.Fill(PasswordTable);

            List<string> Pas = new List<string>();

            for (int say = 0; say < PasswordTable.Rows.Count; say++)
            {   // sql deki her degeri alıp sayıya dönüştürüp 
                code = PasswordTable.Rows[say][1].ToString();
                a = Convert.ToInt32(PasswordTable.Rows[say]["ID"].ToString());
                switch (code)
                {
                    case "qw12":
                        Sifre = "rGuOokzq";
                        break;

                    case "qww":
                        Sifre = "ssKcGhXk";
                        break;

                    case "cas":
                        Sifre = "A4iGojVS";
                        break;

                    case "ssd":
                        Sifre = "r68LIkGn";
                        break;

                    case "asq":
                        Sifre = "IHry0Gwu";
                        break;

                    case "aqw":
                        Sifre = "UqDoPweQ";
                        break;

                    case "23h":
                        Sifre = "An42KlSU";
                        break;

                    case "sssi":
                        Sifre = "F4DMuys2";
                        break;

                    case "asdsadj":
                        Sifre = "IxquDrgj";
                        break;

                    case "cank":
                        Sifre = "093Fi1xc";
                        break;


                    case "trel":
                        Sifre = "uqpjAVKN";
                        break;

                    case "m9jy3":
                        Sifre = "lRjl7yqJ";
                        break;

                    case "n":
                        Sifre = "RoFOEglh";
                        break;

                    case "o":
                        Sifre = "2AX1lQSI";
                        break;

                    case "p":
                        Sifre = "0vngiJbt";
                        break;

                    case "q":
                        Sifre = "Nk3rBVH6";
                        break;

                    case "rsss1":
                        Sifre = "29L3yQGo";
                        break;

                    case "ss1d":
                        Sifre = "8RELQj5s";
                        break;

                    case "t":
                        Sifre = "g3dqiw33";
                        break;

                    case "u222":
                        Sifre = "ikjn3vTo";
                        break;


                    case "v":
                        Sifre = "4Oj8KgET";
                        break;

                    case "w":
                        Sifre = "cEAtn0tq";
                        break;

                    case "xx":
                        Sifre = "p5Gdma7b";
                        break;

                    case "y":
                        Sifre = "abqOEoEq";
                        break;

                    case "z":
                        Sifre = "VbrzPpZS";
                        break;

                    case "aa":
                        Sifre = "jEsZ73Op";
                        break;

                    case "ab":
                        Sifre = "SWI3FBQv";
                        break;

                    case "ac":
                        Sifre = "cBuuYyn3";
                        break;

                    case "as2ssd":
                        Sifre = "ijiFaIH4";
                        break;

                    case "af":
                        Sifre = "jVNA2LQW";
                        break;


                    case "ag":
                        Sifre = "EvFnLzkl";
                        break;

                    case "ah3gf":
                        Sifre = "24e8qrgR";
                        break;

                    case "ai":
                        Sifre = "NHsU9LIn";
                        break;

                    case "aj":
                        Sifre = "0w8bGgmE";
                        break;

                    case "ak":
                        Sifre = "c2II58kc";
                        break;

                    case "ggal":
                        Sifre = "TItpaTLw";
                        break;

                    case "2awm":
                        Sifre = "skwHkalr";
                        break;

                    case "a2n":
                        Sifre = "VOGvG4wN";
                        break;

                    case "ao":
                        Sifre = "olcPFPwL";
                        break;

                    case "ap":
                        Sifre = "UXkICemA";
                        break;


                    case "aq":
                        Sifre = "P2NgDrvm";
                        break;

                    case "ar":
                        Sifre = "nn4NFoAj";
                        break;

                    case "12as":
                        Sifre = "BRDoxqr3";
                        break;

                    case "x23at":
                        Sifre = "6NeuBDjb";
                        break;

                    case "ax99u":
                        Sifre = "D2RutWMj";
                        break;

                    case "av":
                        Sifre = "sMnAHxJO";
                        break;

                    case "aw":
                        Sifre = "UrjU8t8f";
                        break;

                    case "a32x":
                        Sifre = "QAg630n4";
                        break;

                    case "ay":
                        Sifre = "duk4Qfex";
                        break;

                    case "a999z":
                        Sifre = "sIQOdWbq";
                        break;


                    case "ba":
                        Sifre = "U8kKDwoH";
                        break;

                    case "bb":
                        Sifre = "SCdg5tBm";
                        break;

                    case "bc":
                        Sifre = "Ki1IdqtG";
                        break;

                    case "bd":
                        Sifre = "IRXHQ4tm";
                        break;

                    case "bf":
                        Sifre = "tV8FOZYa";
                        break;

                    case "bg123":
                        Sifre = "VvamVnDb";
                        break;

                    case "bhh9gh8gh":
                        Sifre = "sJNjQ3Nh";
                        break;

                    case "bi":
                        Sifre = "wRIzPI6q";
                        break;

                    case "bj":
                        Sifre = "gihBnYB8";
                        break;

                    case "bk":
                        Sifre = "6g4bDN3T";
                        break;


                    case "bl":
                        Sifre = "5JxOblFk";
                        break;

                    case "poj3":
                        Sifre = "DktB3CzK";
                        break;

                    case "b11n":
                        Sifre = "DVesa9KY";
                        break;

                    case "bo":
                        Sifre = "C77vZQFs";
                        break;

                    case "bp":
                        Sifre = "fZJ6U9ON";
                        break;

                    case "bq":
                        Sifre = "KDGD1aTK";
                        break;

                    case "b30r":
                        Sifre = "T5t9QwL9";
                        break;

                    case "bs":
                        Sifre = "8IZHB7Lx";
                        break;

                    case "903":
                        Sifre = "pk8ZCp0H";
                        break;

                    case "bu":
                        Sifre = "nPe4WOr5";
                        break;


                    case "bv":
                        Sifre = "0YF4HHVy";
                        break;

                    case "12xcv3":
                        Sifre = "c376cDoM";
                        break;

                    case "bx":
                        Sifre = "hXlQKkYv";
                        break;

                    case "by":
                        Sifre = "E7036L8S";
                        break;

                    case "bz":
                        Sifre = "MAC3i34U";
                        break;

                    case "ca23":
                        Sifre = "AR6Jsi0f";
                        break;

                    case "99cb":
                        Sifre = "e48cizsA";
                        break;

                    case "cc":
                        Sifre = "xyhC6ITM";
                        break;

                    case "cd":
                        Sifre = "RWVxV3n4";
                        break;

                    default:
                        break;
                }
                if (Keytext.Text.ToString() == Sifre)
                {


                    string KayitTarih = DateTime.Now.ToString("dd/MM/yyyy");
                    //BURASI KAYIT AT SQL E
                    DateTime dateee = new DateTime();
                    dateee = DateTime.Now;
                    string dateTarihi = dateee.ToString("ddMMyyyy");
                    

                    baglan.Close();
                    baglan.Open();
                    SqlCommand LisTarih = new SqlCommand("Update Win set ValueText=@p1,ValueID=@p2 where ID=" + 1, baglan);
                    LisTarih.Parameters.AddWithValue("@p1", dateTarihi);
                    LisTarih.Parameters.AddWithValue("@p2", a);
                    LisTarih.ExecuteNonQuery();
                    baglan.Close();

                    baglan.Close();
                    baglan.Open();
                    SqlCommand Key = new SqlCommand("Update ToplamReceteSayisi set TopReceteSayisi = @p1 where ID=" + 1, baglan);
                    Key.Parameters.AddWithValue("@p1", 9999);
                    Key.ExecuteNonQuery();
                    baglan.Close();
                    btnGiris.Visible = false;
                    Keytext.Visible = false;
                    PinLbl.Visible = true;
                    PinTxta.Visible = true;
                    SifreLbl.Visible = true;
                    Sifretxta.Visible = true;
                    GirisBtn2.Visible = true;
                    // buraya sil ekle Sql den silincek key kısmı
                    




                    //---------------------------------------------------

                    SqlDataAdapter LisansTarihleri = new SqlDataAdapter("Select ValueText,ValueID from Win where ID=" + 1, baglan);
                    DataTable LisansTarihdt = new DataTable();
                    LisansTarihleri.Fill(LisansTarihdt);
                    int verID = Convert.ToInt32(LisansTarihdt.Rows[0][1].ToString());

                    SqlDataAdapter Versiyon = new SqlDataAdapter("Select Ver From Bin where ID=" + verID.ToString(), baglan);
                    DataTable VersitonDt = new DataTable();
                    Versiyon.Fill(VersitonDt);

                    string TarihStr = LisansTarihdt.Rows[0]["ValueText"].ToString();
                    
                    string time = TarihStr.ToString();
                    DateTime theTime = DateTime.ParseExact(time,
                                                        "ddMMyyyy",
                                                        CultureInfo.InvariantCulture,
                                                        DateTimeStyles.None);
                    string day = theTime.ToString("dd");
                    string ay = theTime.ToString("MM");
                    string yil = theTime.ToString("yyyy");


                    int Ayint = Convert.ToInt32(ay);
                    int Yilint = Convert.ToInt32(yil);
                    int Dayint = Convert.ToInt32(day);
                    int KacAy = 0;
                    try
                    {

                        KacAy = Convert.ToInt32(VersitonDt.Rows[0]["Ver"].ToString());


                    }
                    catch (Exception)
                    {


                    }

                    
                    if (KacAy == 1)
                    {

                        if (Ayint == 12)
                        {
                            ay = "01";
                            MessageBox.Show("Ay çalışltı ");
                            Yilint = Yilint + 1;
                            yil = Yilint.ToString();




                        }
                        else
                        {
                            MessageBox.Show("Ay çalıltı ");

                            Ayint = Ayint + 1;
                            ay = Ayint.ToString();
                            if (Ayint < 10)
                            {
                                ay = "0" + ay;
                            }
                        }
                    }
                    else if (KacAy == 2)
                    {
                        if (Ayint > 6)
                        {
                            MessageBox.Show("6 Ay çalıltı ");

                            Yilint = Yilint + 1;
                            yil = Yilint.ToString();

                            Ayint = Ayint + 6;
                            Ayint = Ayint % 12;
                            ay = Ayint.ToString();
                            if (Ayint < 10)
                            {
                                ay = "0" + ay;
                            }

                        }
                    }
                    else if (KacAy == 3)
                    {
                        MessageBox.Show("yil çalıltı ");

                        Yilint = Yilint + 1;
                        yil = Yilint.ToString();
                    }
                    else if (KacAy == 4)
                    {
                        if (Ayint == 2)
                        {
                            if (Dayint == 28)
                            {
                                Dayint = 1;
                                Ayint = Ayint + 1;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }

                                ay = Ayint.ToString();
                                if (Ayint < 10)
                                {
                                    ay = "0" + ay;
                                }
                            }
                            else
                            {
                                Dayint = Dayint + 1;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }

                            }


                        }
                        else if (Ayint == 1 || Ayint == 3 || Ayint == 5 || Ayint == 7 || Ayint == 8 || Ayint == 10 || Ayint == 12)
                        {
                            if (Dayint == 31)
                            {
                                Dayint = 1;
                                Ayint = Ayint + 1;
                                Ayint = Ayint % 12;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }
                                ay = Ayint.ToString();
                                if (Ayint < 10)
                                {
                                    ay = "0" + ay;
                                }
                            }
                            else
                            {
                                Dayint = Dayint + 1;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }
                                
                            }

                        }
                        else if (Ayint == 4 || Ayint == 6 || Ayint == 9 || Ayint == 11)
                        {

                            if (Dayint == 30)
                            {
                                Dayint = 1;
                                Ayint = Ayint + 1;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }
                                ay = Ayint.ToString();
                                if (Ayint<10)
                                {
                                    ay = "0" + ay;
                                }
                                string deneme = "0" + ay;
                                MessageBox.Show(deneme);
                                
                            }
                            else
                            {
                                Dayint = Dayint + 1;
                                day = Dayint.ToString();
                                if (Dayint < 10)
                                {
                                    day = "0" + day;
                                }
                                
                            }
                        }
                        


                    }

                    string time2 = day + ay + yil;
                    


                    DateTime theTimee = DateTime.ParseExact(time2,
                                                       "ddMMyyyy",
                                                       CultureInfo.InvariantCulture,
                                                       DateTimeStyles.None);
                    
                   
                    string theTime2yazi = theTimee.ToString("ddMMyyyy");

                    
                    
                    

                    baglan.Close();
                    baglan.Open();
                    SqlCommand KapanisTimeSql = new SqlCommand("Update Win set ValueText=@p1 where ID=" + 2, baglan);
                    KapanisTimeSql.Parameters.AddWithValue("@p1", theTime2yazi);
                    KapanisTimeSql.ExecuteNonQuery();
                    baglan.Close();



                    int Id4Del = -1;
                    SqlDataAdapter SelectDelKey = new SqlDataAdapter("Select ID,Bis,Ver from Bin", baglan);
                    DataTable KeyDelDt = new DataTable();
                    SelectDelKey.Fill(KeyDelDt);
                    for (int i = 0; i < KeyDelDt.Rows.Count; i++)
                    {
                        if (code.ToString() == KeyDelDt.Rows[i][1].ToString())
                        {

                            Id4Del = Convert.ToInt32(KeyDelDt.Rows[i][0].ToString());
                        }
                    }

                    baglan.Close();
                    baglan.Open();
                    SqlCommand DeleteKeyCom = new SqlCommand("Delete from Bin where ID=" + Id4Del.ToString(), baglan);
                    DeleteKeyCom.ExecuteNonQuery();
                    baglan.Close();

                }

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {


           



            SqlDataAdapter Key = new SqlDataAdapter("Select TopReceteSayisi from ToplamReceteSayisi", baglan);
            DataTable KeyDt = new DataTable();
            Key.Fill(KeyDt);

            if (KeyDt.Rows[0]["TopReceteSayisi"].ToString() == "9998")
            {
                btnGiris.Visible = true;
                Keytext.Visible = true;
                PinLbl.Visible = false;
                PinTxta.Visible = false;
                SifreLbl.Visible = false;
                Sifretxta.Visible = false;
                GirisBtn2.Visible = false;


            }
            else
            {
                btnGiris.Visible = false;
                Keytext.Visible = false;

                PinLbl.Visible = true;
                PinTxta.Visible = true;
                SifreLbl.Visible = true;
                Sifretxta.Visible = true;
                GirisBtn2.Visible = true;
            }
            LisansBitimi();// ya bura




        }

        private void LisansBitimi()
        {
            DateTime simdi = new DateTime();
            simdi = DateTime.Now;
            string simdiStrr=simdi.ToString("ddMMyyyy");
            

            baglan.Close();
            baglan.Open();
            SqlCommand TimeNowin = new SqlCommand("Update Win set ValueText = @p1 where ID=" + 1, baglan);
            TimeNowin.Parameters.AddWithValue("@p1", simdiStrr.ToString());
            TimeNowin.ExecuteNonQuery();
            baglan.Close();



            SqlDataAdapter TimenowSql = new SqlDataAdapter("Select ValueText,ValueID from Win where ID=" + 1, baglan);
            DataTable TimenowDt = new DataTable();
            TimenowSql.Fill(TimenowDt);


            string TimenowString = TimenowDt.Rows[0]["ValueText"].ToString();



            string simdiyazi = TimenowString;





            SqlDataAdapter LisansTarihleri = new SqlDataAdapter("Select ValueText,ValueID from Win where ID=" + 2, baglan);
            DataTable LisansTarihdt = new DataTable();
            LisansTarihleri.Fill(LisansTarihdt);
            

            string TarihStr = LisansTarihdt.Rows[0]["ValueText"].ToString();
           
           
            
                DateTime theTime = DateTime.ParseExact(TarihStr,
                                                "ddMMyyyy",
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None);
                string theTime2yazi = theTime.ToString("ddMMyyyy");
            
            


            


            if (theTime2yazi == simdiyazi || theTime < simdi)
            {
                baglan.Close();
                baglan.Open();
                SqlCommand Key = new SqlCommand("Update ToplamReceteSayisi set TopReceteSayisi = @p1 where ID=" + 1, baglan);
                Key.Parameters.AddWithValue("@p1", 9998);
                Key.ExecuteNonQuery();
                baglan.Close();

                baglan.Close();
                baglan.Open();
                SqlCommand Key2 = new SqlCommand("Update Win set ValueID = @p1 where ID=" + 1, baglan);
                Key2.Parameters.AddWithValue("@p1", 9998);
                Key2.ExecuteNonQuery();
                baglan.Close();
                //Delete eklenemdi


            }






            //}
            //catch (Exception)
            //{


            //}






        }

        private void GirisBtn2_Click_1(object sender, EventArgs e)
        {

            string pin;
            string sifre;
            SqlDataAdapter butunkullanicidatagetir = new SqlDataAdapter("Select KullaniciPassword,KullaniciPin,Yetki From Kullanicilars where KullaniciDurum=" + "'False'", baglan);
            DataTable kullanicidt = new DataTable();
            butunkullanicidatagetir.Fill(kullanicidt);
            for (int i = 0; i < kullanicidt.Rows.Count; i++)
            {
                pin = kullanicidt.Rows[i]["KullaniciPin"].ToString();
                sifre = kullanicidt.Rows[i]["KullaniciPassword"].ToString();
                if (PinTxta.Text.ToString() == pin && Sifretxta.Text.ToString() == sifre)
                {
                    frmAnaSayfa ana = new frmAnaSayfa();

                    ana.label1.Text = kullanicidt.Rows[i]["Yetki"].ToString();

                    this.Hide();
                    ana.Show();
                }
                
                    
                    

                
            }
            Sifretxta.Text = "";
            PinTxta.Text = "";

        }

        private void KapaBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}






