using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using login.Models;

namespace login.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=192.168.1.6;Initial Catalog=EA_testing;Integrated security=True");
        public int logincheck(ad_login ad)
        {
            SqlCommand cmd=new SqlCommand("dbo.login2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ad.id);
            cmd.Parameters.AddWithValue("@password", ad.password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@invalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oblogin);           
            con.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }

}