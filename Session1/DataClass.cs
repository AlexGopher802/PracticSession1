using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Session1
{
    public class DataClass
    {
        public SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=Session1_23;Integrated Security=True");

        public DataSet getData(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch { return ds; }
            finally { con.Close(); }
        }

        public void executeQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
        }
    }
}
