using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiPOS.Class
{
    public class _doldur
    {

        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");


        public DataTable masasorgu(string sorgu)
        {
            string con = "";
            con = sorgu;
            baglan.Close();

            baglan.Open();
            SqlCommand connectionstring = new SqlCommand(con, baglan);
            SqlDataAdapter getir = new SqlDataAdapter(connectionstring);
            DataTable dt = new DataTable();
            getir.Fill(dt);



            return dt;
        }
    }
}
