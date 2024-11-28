using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Chapter_Find_Online_Bookstore.Model
{
    public class dbclass
    {
        [BindProperty]
        public string AUsername { get; set; }
        public string Ausername1(string Ausername)
        {
            AUsername = Ausername;
            return AUsername;
        }
        [BindProperty]
        public string Username { get; set; }
        public string username1(string username)
        {
            Username = username;
            return Username;
        }

        public string UserID { get; set; }
        public string userIDinput(string id)
        {
            UserID = id;
            return UserID;
        }


        public string OUsername { get; set; }
        public string Ousername1(string username)
        {
            OUsername = username;
            return OUsername;
        }

        public SqlConnection con { get; set; }
        public dbclass()
        {


            string SQLcon = "Data Source=AHMED;Initial Catalog=ChapterFind;Integrated Security=True;";

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
        public DataTable GetBooks()
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
        WHERE b.Collection = 0";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
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

        public DataTable GetCollection()
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
        WHERE b.Collection = 1";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
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

        public DataTable GetAuthors()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            a.AuthorID, 
            a.Name, 
            a.Description, 
            a.img AS AuthorImage, 
            c.CategoryName AS TopCategoryName
        FROM Authors a
        LEFT JOIN Categories c ON a.TopCategoryID = c.CategoryID";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
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
