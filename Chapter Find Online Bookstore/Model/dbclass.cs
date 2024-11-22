using System.Data.SqlClient;

namespace Chapter_Find_Online_Bookstore.Model
{
    public class dbclass
    {
        public SqlConnection con { get; set; }
        public dbclass()
        {


            string SQLcon = "Data Source=ahmed;Initial Catalog=ChapterFind;Integrated Security=True;";

            con = new SqlConnection(SQLcon);
        }
    }
}
