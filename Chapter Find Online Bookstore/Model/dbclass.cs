﻿using Microsoft.AspNetCore.Mvc;
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
    WHERE c.CategoryID = @CategoryID AND b.Collection = 0 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
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
    WHERE c.CategoryID = @CategoryID AND b.Collection = 1 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
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
        WHERE b.Collection = 0 AND Visabilty=1";
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
        WHERE b.Collection = 1 AND Visabilty=1";
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
                
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public DataTable GetBookByID(string bookID)
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
        WHERE b.BookID = @BookID AND b.Collection = 0 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", bookID);
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

        public DataTable Similarbooks(string authorID, string categoryID)
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
    WHERE (a.AuthorID = @AuthorID
    OR c.CategoryID = @CategoryID) AND b.Collection = 0 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
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
        public DataTable SimilarCollection(string authorID, string categoryID)
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
    WHERE (a.AuthorID = @AuthorID
    OR c.CategoryID = @CategoryID) AND b.Collection = 1 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
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

        public DataTable GetCollectionByID(string CollectiomID)
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
            c.CategoryID
        FROM Books b
        JOIN Authors a ON b.AuthorID = a.AuthorID
        JOIN Categories c ON b.CategoryID = c.CategoryID
        WHERE b.BookID = @BookID AND b.Collection = 1 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", CollectiomID);
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

        public DataTable GetAuthorByID(string authorID)
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
    LEFT JOIN Categories c ON a.TopCategoryID = c.CategoryID
    WHERE a.AuthorID = @AuthorID";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
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

        public DataTable GetBooksByAuthorID(string authorID)
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
    WHERE a.AuthorID = @AuthorID AND b.Collection = 0 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
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

        public DataTable GetCollectionByAuthorID(string authorID)
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
    WHERE a.AuthorID = @AuthorID AND b.Collection = 1 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
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
        public DataTable SearchBooks(string searchTerm)
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
        WHERE (b.Title LIKE @searchTerm  
        OR a.Name LIKE @searchTerm) AND b.Collection = 0 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); 
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
        public DataTable SearchCollection(string searchTerm)
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
        WHERE (b.Title LIKE @searchTerm  
        OR a.Name LIKE @searchTerm) AND b.Collection = 1 AND b.Visabilty=1";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); 
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

        public DataTable SearchAuthor(string authorName)
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
        LEFT JOIN Categories c ON a.TopCategoryID = c.CategoryID
        WHERE Name LIKE @searchTerm";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + authorName + "%"); 
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



        ////////////////////////////////////////////////////////////////////////
        ///

        public DataTable GetNewOrders()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT * 
        FROM Orders
        WHERE Status = @Status";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Status", "waiting to confirm");
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
        public DataTable GetNewOrdersWithDetails()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                O.OrderID,
                C.Name AS CustomerName,
                O.OrderDate,
                O.TotalAmount,
                O.Status,
                O.ShippingAddress,
                O.PhoneNumber,
                COUNT(OD.BookID) AS TotalBooksOrdered
            FROM 
                Orders O
            INNER JOIN 
                Customers C ON O.CustomerID = C.CustomerID
            INNER JOIN 
                OrderDetails OD ON O.OrderID = OD.OrderID
            WHERE 
                O.Status = @Status
            GROUP BY 
                O.OrderID, C.Name, O.OrderDate, O.TotalAmount, O.Status, O.ShippingAddress, O.PhoneNumber";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Status", "waiting to confirm");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllOrdersWithDetails()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                O.OrderID,
                C.Name AS CustomerName,
                O.OrderDate,
                O.TotalAmount,
                O.Status,
                O.ShippingAddress,
                O.PhoneNumber,
                COUNT(OD.BookID) AS TotalBooksOrdered
            FROM 
                Orders O
            INNER JOIN 
                Customers C ON O.CustomerID = C.CustomerID
            INNER JOIN 
                OrderDetails OD ON O.OrderID = OD.OrderID
            GROUP BY 
                O.OrderID, C.Name, O.OrderDate, O.TotalAmount, O.Status, O.ShippingAddress, O.PhoneNumber
            ORDER BY 
                O.OrderDate DESC"; 

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                C.CustomerID,
                C.Name AS CustomerName,
                C.Username,
                C.Email,
                C.PhoneNumber,
                COUNT(O.OrderID) AS TotalOrders,
                COUNT(DISTINCT A.City) AS AddressCount
            FROM 
                Customers C
            LEFT JOIN 
                Orders O ON C.CustomerID = O.CustomerID
            LEFT JOIN 
                CustomersAddress A ON C.CustomerID = A.CustomerID
            GROUP BY 
                C.CustomerID, C.Name, C.Username, C.Email, C.PhoneNumber";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllAdmins()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                Username,
                Name,
                Email,
                PhoneNumber,
                Title
            FROM 
                Admin";
         

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                CategoryID,
                CategoryName,
                img
            FROM 
                Categories";            

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllAuthors()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                A.AuthorID,
                A.Name AS AuthorName,
                A.Description,
                A.img AS AuthorImage,
                C.CategoryName AS TopCategory
            FROM 
                Authors A
            LEFT JOIN 
                Categories C ON A.TopCategoryID = C.CategoryID";
            

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                B.BookID,
                B.Title,
                A.Name AS AuthorName,
                C.CategoryName,
                B.Price,
                B.IsDiscount,
                B.Discount,
                B.InStock,
                B.SDescription,
                B.ReleaseDate,
                B.NuOfPage,
                B.img AS BookImage,
                B.Visabilty
            FROM 
                Books B
            LEFT JOIN 
                Authors A ON B.AuthorID = A.AuthorID
            LEFT JOIN 
                Categories C ON B.CategoryID = C.CategoryID
            Where B.Collection = 0";


            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllCollections()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                B.BookID,
                B.Title,
                A.Name AS AuthorName,
                C.CategoryName,
                B.Price,
                B.IsDiscount,
                B.Discount,
                B.InStock,
                B.SDescription,
                B.ReleaseDate,
                B.NuOfPage,
                B.img AS BookImage,
                B.Visabilty
            FROM 
                Books B
            LEFT JOIN 
                Authors A ON B.AuthorID = A.AuthorID
            LEFT JOIN 
                Categories C ON B.CategoryID = C.CategoryID
            Where B.Collection = 1";


            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetAllShippingCosts()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                City, 
                Cost 
            FROM 
                ShippingCost";
            

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public DataTable GetBooksAdmin()
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
            c.CategoryID,
            b.Visabilty
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
                
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable GetCollectionAdmin()
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
            c.CategoryID,
            b.Visabilty
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
                
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public bool UpdateBookVisibility(string bookID, int visibility)
        {
            bool success = false;

            // Define the query to update the Visibility field
            string query = @"
        UPDATE Books
        SET Visabilty = @Visibility
        WHERE BookID = @BookID and Collection = 0";

            try
            {
                con.Open();  // Open the database connection

                // Create a new SqlCommand object with the query
                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters to the SQL command to avoid SQL injection
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Visibility", visibility);

                // Execute the command and get the number of affected rows
                int rowsAffected = cmd.ExecuteNonQuery();

                // If rows were affected, the update was successful
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                // Handle the SQL exception (e.g., logging the error)
            }
            finally
            {
                // Close the connection whether the operation succeeded or failed
                con.Close();
            }

            return success;  // Return whether the update was successful
        }
        public bool UpdateCollectionVisibility(string bookID, int visibility)
        {
            bool success = false;

            // Define the query to update the Visibility field
            string query = @"
        UPDATE Books
        SET Visabilty = @Visibility
        WHERE BookID = @BookID and Collection = 1";

            try
            {
                con.Open();  // Open the database connection

                // Create a new SqlCommand object with the query
                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters to the SQL command to avoid SQL injection
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Visibility", visibility);

                // Execute the command and get the number of affected rows
                int rowsAffected = cmd.ExecuteNonQuery();

                // If rows were affected, the update was successful
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                // Handle the SQL exception (e.g., logging the error)
            }
            finally
            {
                // Close the connection whether the operation succeeded or failed
                con.Close();
            }

            return success;  // Return whether the update was successful
        }



        public bool AddBook(string bookID, string title, string authorID, string categoryID, decimal price, int isDiscount, decimal discount, int inStock, string sDescription, string description, int releaseDate, int nuOfPage, int collection, string img, int visability)
        {
            bool success = false;
            string query = @"
    INSERT INTO Books 
        (BookID, Title, AuthorID, CategoryID, Price, IsDiscount, Discount, InStock, SDescription, Description, ReleaseDate, NuOfPage, Collection, img, Visabilty) 
    VALUES 
        (@BookID, @Title, @AuthorID, @CategoryID, @Price, @IsDiscount, @Discount, @InStock, @SDescription, @Description, @ReleaseDate, @NuOfPage, @Collection, @img, @Visabilty)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsDiscount", isDiscount);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@InStock", inStock);
                cmd.Parameters.AddWithValue("@SDescription", sDescription);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@NuOfPage", nuOfPage);
                cmd.Parameters.AddWithValue("@Collection", collection);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.Parameters.AddWithValue("@Visabilty", visability);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                con.Close();
            }

            return success;
        }
        public bool AddCollection(string bookID, string title, string authorID, string categoryID, decimal price, int isDiscount, decimal discount, int inStock, string sDescription, string description, int releaseDate, int nuOfPage, int collection, string img, int visability)
        {
            bool success = false;
            string query = @"
    INSERT INTO Books 
        (BookID, Title, AuthorID, CategoryID, Price, IsDiscount, Discount, InStock, SDescription, Description, ReleaseDate, NuOfPage, Collection, img, Visabilty) 
    VALUES 
        (@BookID, @Title, @AuthorID, @CategoryID, @Price, @IsDiscount, @Discount, @InStock, @SDescription, @Description, @ReleaseDate, @NuOfPage, @Collection, @img, @Visabilty)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsDiscount", isDiscount);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@InStock", inStock);
                cmd.Parameters.AddWithValue("@SDescription", sDescription);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@NuOfPage", nuOfPage);
                cmd.Parameters.AddWithValue("@Collection", collection);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.Parameters.AddWithValue("@Visabilty", visability);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                con.Close();
            }

            return success;
        }
        public bool AddCategory(string categoryID, string categoryName, string img)
        {
            bool success = false;
            string query = @"
    INSERT INTO Categories 
        (CategoryID, CategoryName, img) 
    VALUES 
        (@CategoryID, @CategoryName, @img)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@img", img);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                con.Close();
            }

            return success;
        }
        public bool AddAuthors(string authorID, string name, string topCategoryID, string description, string img)
        {
            bool success = false;
            string query = @"
    INSERT INTO Authors 
        (AuthorID, Name, TopCategoryID, Description, img) 
    VALUES 
        (@AuthorID, @Name, @TopCategoryID, @Description, @img)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@TopCategoryID", topCategoryID);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@img", img);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                con.Close();
            }

            return success;
        }
        public bool AddShippingCost(string city, decimal cost)
        {
            string query = @"
            INSERT INTO ShippingCost (City, Cost) 
            VALUES (@City, @Cost)";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Cost", cost);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while adding the shipping cost: " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }


    }
}
