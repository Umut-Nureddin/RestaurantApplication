using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiPOS.Class
{
    public class Odeme
    {




        public static void War(string b)
        {
            SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");


            baglan.Open();
            SqlCommand SipSav=new SqlCommand("Update Sipp set   SippNo=@p1 where=1", baglan);
            SipSav.Parameters.AddWithValue("@p1", b.ToString());
            SipSav.ExecuteNonQuery();
            baglan.Close();

            
        }

        
        public static void Start()
        {
           

        }

        
    }
}
