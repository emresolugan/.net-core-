using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace deneme.Models
{
    public class DatesAccessLayer
    {
        string connectionString = "Server=DESKTOP-M5287V9;Database=project;Trusted_Connection=True;";
        //To View all employees details   
        public IEnumerable<Dates> GetDate()
        {
            List<Dates> dates = new List<Dates>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetDate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Dates datess = new Dates();
                    datess.Date = Convert.ToDateTime(rdr["Date"]);
                    dates.Add(datess);
                }

     
                con.Close();

            }

            return dates;
        }

        public void AddDate(Dates date)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddDate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", date.Date);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        }
    }
}
