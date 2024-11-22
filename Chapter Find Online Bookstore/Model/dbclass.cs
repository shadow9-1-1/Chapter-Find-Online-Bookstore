using System.Data;
using System.Data.SqlClient;

namespace Chapter_Find_Online_Bookstore.Model
{
    public class dbclass
    {
        public SqlConnection con { get; set; }
        public dbclass()
        {


            string SQLcon = "Data Source=DESKTOP-I2LRPKV\\SQLEXPRESS;Initial Catalog=ChapterFind;Integrated Security=True;";

            con = new SqlConnection(SQLcon);
        }

        /*-------------------------Show Table Query----------------------*/
        public DataTable ShowTable(string Tname)
        {
            DataTable dt = new DataTable();
            string query = "select* from " + Tname;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }
    }
}
