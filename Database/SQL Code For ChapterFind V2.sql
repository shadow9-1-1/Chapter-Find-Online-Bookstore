-- Create Categories Table
CREATE TABLE Categories (
    CategoryID VARCHAR(100) PRIMARY KEY,
    CategoryName VARCHAR(100),
	img TEXT
);

-- Create Authors Table
CREATE TABLE Authors (
    AuthorID VARCHAR(100) PRIMARY KEY,
    Name VARCHAR(100),
    TopCategoryID VARCHAR(100),
    Description TEXT,
	img TEXT,
    FOREIGN KEY (TopCategoryID) REFERENCES Categories(CategoryID)
);

-- Create Books Table
CREATE TABLE Books (
    BookID VARCHAR(100) PRIMARY KEY,
    Title VARCHAR(255),
    AuthorID VARCHAR(100),
    CategoryID VARCHAR(100),
    Price DECIMAL(10, 2),
	IsDiscount INT,
    Discount DECIMAL(5, 2),
    InStock INT,
    SDescription TEXT,
    Description TEXT,
    ReleaseDate INT,
    NuOfPage INT,
	Collection INT,
	img TEXT,
	Visabilty INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Create Customers Table
CREATE TABLE Customers (
    CustomerID VARCHAR(100) PRIMARY KEY,
	Username VARCHAR(100),
	Password VARCHAR(100),
    Name VARCHAR(100),
	Email VARCHAR(255),
    PhoneNumber VARCHAR(15),
);

-- Create Orders Table
CREATE TABLE Orders (
    OrderID VARCHAR(100) PRIMARY KEY,
    CustomerID VARCHAR(100),
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    Status VARCHAR(50),
    ShippingAddress VARCHAR(255),
    PhoneNumber VARCHAR(15),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create OrderDetails Table
CREATE TABLE OrderDetails (
    OrderID VARCHAR(100),
    BookID VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    PRIMARY KEY (OrderID, BookID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- Create Admin Table
CREATE TABLE Admin (
	Username VARCHAR(100) PRIMARY KEY,
    Password VARCHAR(100),
    Name VARCHAR(100),
    Email VARCHAR(255),
    PhoneNumber VARCHAR(15),
	Title VARCHAR(15)
    
);

-- Create Staff Table
CREATE TABLE Staff (
    Name VARCHAR(100),
    Email VARCHAR(255),
    PhoneNumber VARCHAR(15),
    Username VARCHAR(100) PRIMARY KEY,
    Password VARCHAR(100),
    AuthorityLevel INT
);

-- Create Cart Table
CREATE TABLE Cart (
    CustomerID VARCHAR(100),
    BookID VARCHAR(100),
    Quantity INT,
    PRIMARY KEY (CustomerID, BookID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
CREATE TABLE ShippingCost (
    City VARCHAR(100) PRIMARY KEY,
    Cost DECIMAL(10, 2)
);

CREATE TABLE CustomersAddress (
    CustomerID VARCHAR(100),
	City VARCHAR(100),
	Address VARCHAR(100),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (City) REFERENCES ShippingCost(City)
);




-- Insert Data into Categories Table
INSERT INTO Categories (CategoryID, CategoryName, img) VALUES
('1', 'Fiction', 'fiction.jpg'),
('2', 'Non-Fiction', 'nonfiction.jpg'),
('3', 'Science', 'science.jpg'),
('4', 'History', 'history.jpg');

-- Insert Data into Authors Table
INSERT INTO Authors (AuthorID, Name, TopCategoryID, Description, img) VALUES
('1', 'John Smith', '1', 'A bestselling fiction author.', 'john_smith.jpg'),
('2', 'Jane Doe', '2', 'An expert in non-fiction writing.', 'jane_doe.jpg'),
('3', 'Dr. Alan Grant', '3', 'A renowned scientist.', 'alan_grant.jpg'),
('4', 'Emily Johnson', '4', 'A history enthusiast and author.', 'emily_johnson.jpg');

-- Insert Data into Books Table
INSERT INTO Books (BookID, Title, AuthorID, CategoryID, Price, IsDiscount, Discount, InStock, SDescription, Description, ReleaseDate, NuOfPage, Collection, img) VALUES
('1', 'The Great Adventure', '1', '1', 19.99, 1, 5.00, 50, 'A thrilling fiction novel.', 'A detailed story of adventure and mystery.', 2023, 350, 0, 'great_adventure.jpg'),
('2', 'Learning Science', '3', '3', 25.99, 0, 0.00, 100, 'An introduction to modern science.', 'A comprehensive guide to basic science principles.', 2022, 200, 0, 'learning_science.jpg'),
('3', 'The History of the World', '4', '4', 30.00, 1, 10.00, 75, 'A deep dive into world history.', 'An extensive coverage of historical events.', 2021, 500, 0, 'history_world.jpg'),
('4', 'Adventure Chronicles: Volume 1', '1', '1', 29.99, 1, 7.00, 20, 'The first volume of an epic adventure series.', 'A captivating collection of adventure tales.', 2023, 400, 1, 'adventure_chronicles_v1.jpg'),
('5', 'Adventure Chronicles: Volume 2', '1', '1', 29.99, 1, 7.00, 20, 'The second volume of an epic adventure series.', 'Continuation of the thrilling adventure series.', 2024, 450, 1, 'adventure_chronicles_v2.jpg'),
('6', 'Science Explorer: Volume 1', '3', '3', 39.99, 0, 0.00, 15, 'A collection of the latest science discoveries.', 'Detailed explorations into various scientific fields.', 2022, 300, 1, 'science_explorer_v1.jpg'),
('7', 'World History Archives: Volume 1', '4', '4', 35.00, 1, 5.00, 25, 'The first in a series of historical archives.', 'An extensive collection of historical documents and analysis.', 2021, 600, 1, 'history_archives_v1.jpg');

-- Insert Data into Customers Table
INSERT INTO Customers (CustomerID, Username, Password, Name) VALUES
('1', 'john_doe', 'password123', 'John Doe'),
('2', 'jane_doe', 'pass456', 'Jane Doe');

-- Insert Data into Orders Table
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, Status, ShippingAddress, PhoneNumber) VALUES
('1', '1', '2024-09-01', 49.99, 'Shipped', '123 Main St, New York', '1234567890'),
('2', '2', '2024-09-02', 55.99, 'Processing', '456 Elm St, Los Angeles', '0987654321');

-- Insert Data into OrderDetails Table
INSERT INTO OrderDetails (OrderID, BookID, Quantity, UnitPrice) VALUES
('1', '1', 2, 19.99),
('1', '3', 1, 30.00),
('2', '2', 1, 25.99);

-- Insert Data into Admin Table
INSERT INTO Admin (Name, Email, PhoneNumber, Username, Password, Title) VALUES
('Admin User', 'admin@example.com', '1234567890', 'admin_user', 'adminpass','Admin Test');

-- Insert Data into Staff Table
INSERT INTO Staff (Name, Email, PhoneNumber, Username, Password, AuthorityLevel) VALUES
('Staff Member 1', 'staff1@example.com', '1111111111', 'staff_user1', 'staffpass1', 1),
('Staff Member 2', 'staff2@example.com', '2222222222', 'staff_user2', 'staffpass2', 2);

-- Insert Data into Cart Table
INSERT INTO Cart (CustomerID, BookID, Quantity) VALUES
('1', '1', 1),
('2', '2', 1);

-- Insert Data into ShippingCost Table
INSERT INTO ShippingCost (City, Cost) VALUES
('Cairo', 50.00),
('Alexandria', 70.00),
('Giza', 40.00),
('Sharm El-Sheikh', 100.00),
('Luxor', 90.00),
('Aswan', 95.00),
('Hurghada', 80.00);

-- Insert Data into CustomersAddress Table
INSERT INTO CustomersAddress (CustomerID, City, Address) VALUES
('1', 'Cairo', '123 Tahrir Square'),
('1', 'Alexandria', '45 Coastal Road'),
('2', 'Giza', '678 Pyramid Street'),
('2', 'Sharm El-Sheikh', '12 Resort Road');
