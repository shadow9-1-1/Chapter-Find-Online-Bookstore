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
        public DataTable booksByCategories(string categoryID)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        b.BookID, 
        b.Title, 
        a.Name, 
        c.CategoryName, 
        b.Price, 
        b.IsDiscount, 
        b.Discount, 
        b.InStock, 
        b.SDescription, 
        b.Description, 
        b.ReleaseDate, 
        b.NuOfPage, 
        b.img,
        a.AuthorID,
        c.CategoryID    
    FROM Books b
    JOIN Authors a ON b.AuthorID = a.AuthorID
    JOIN Categories c ON b.CategoryID = c.CategoryID
    WHERE c.CategoryID = @CategoryID AND b.Collection = 0";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error)
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable CollectionByCategories(string categoryID)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        b.BookID, 
        b.Title, 
        a.Name, 
        c.CategoryName, 
        b.Price, 
        b.IsDiscount, 
        b.Discount, 
        b.InStock, 
        b.SDescription, 
        b.Description, 
        b.ReleaseDate, 
        b.NuOfPage, 
        b.img,
        a.AuthorID,
        c.CategoryID    
    FROM Books b
    JOIN Authors a ON b.AuthorID = a.AuthorID
    JOIN Categories c ON b.CategoryID = c.CategoryID
    WHERE c.CategoryID = @CategoryID AND b.Collection = 1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error)
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetCategoryByID(string categoryID)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT * 
    FROM Categories
    WHERE CategoryID = @CategoryID";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error)
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAuthorsByCategoryID(string categoryID)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        a.AuthorID, 
        a.Name, 
        a.Description, 
        a.img,
        c.CategoryName AS TopCategory
    FROM Authors a
    JOIN Categories c ON a.TopCategoryID = c.CategoryID
    WHERE c.CategoryID = @CategoryID";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error)
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
    }
}
