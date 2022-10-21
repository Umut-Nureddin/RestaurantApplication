using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiPOS.Class
{
    public class _cmbMasaTransfer
    {
        //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-4SEOCDM\\TEW_SQLEXPRESS;Initial Catalog=GoPOS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=GoPOS;Integrated Security=True");



        public DataTable masasorgu(string sorgu)
        {
            string con="";
            con = sorgu;
            baglan.Close();

            baglan.Open();
            SqlCommand connectionstring = new SqlCommand(con,baglan);
            SqlDataAdapter masagetir = new SqlDataAdapter(connectionstring);
            DataTable dt = new DataTable();
            masagetir.Fill(dt);
            
            

            return dt;
        }
    }
}
