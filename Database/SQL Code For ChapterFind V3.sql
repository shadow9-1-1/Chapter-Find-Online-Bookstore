

-- Create AspNetRoles table
CREATE TABLE AspNetRoles (
    Id NVARCHAR(450) NOT NULL PRIMARY KEY,
    Name NVARCHAR(256) NULL,
    NormalizedName NVARCHAR(256) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL
);

-- Create AspNetUsers table
CREATE TABLE AspNetUsers (
    Id NVARCHAR(450) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    Address NVARCHAR(MAX) NOT NULL,
    City NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    UserName NVARCHAR(256) NULL,
    NormalizedUserName NVARCHAR(256) NULL,
    Email NVARCHAR(256) NULL,
    NormalizedEmail NVARCHAR(256) NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash NVARCHAR(MAX) NULL,
    SecurityStamp NVARCHAR(MAX) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL,
    PhoneNumber NVARCHAR(MAX) NULL,
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL,
    LockoutEnd DATETIMEOFFSET NULL,
    LockoutEnabled BIT NOT NULL,
    AccessFailedCount INT NOT NULL
);

-- Create AspNetRoleClaims table
CREATE TABLE AspNetRoleClaims (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RoleId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
);

-- Create AspNetUserClaims table
CREATE TABLE AspNetUserClaims (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UserId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Create AspNetUserLogins table
CREATE TABLE AspNetUserLogins (
    LoginProvider NVARCHAR(450) NOT NULL,
    ProviderKey NVARCHAR(450) NOT NULL,
    ProviderDisplayName NVARCHAR(MAX) NULL,
    UserId NVARCHAR(450) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Create AspNetUserRoles table
CREATE TABLE AspNetUserRoles (
    UserId NVARCHAR(450) NOT NULL,
    RoleId NVARCHAR(450) NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE,
    CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Create AspNetUserTokens table
CREATE TABLE AspNetUserTokens (
    UserId NVARCHAR(450) NOT NULL,
    LoginProvider NVARCHAR(450) NOT NULL,
    Name NVARCHAR(450) NOT NULL,
    Value NVARCHAR(MAX) NULL,
    PRIMARY KEY (UserId, LoginProvider, Name),
    CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Create indexes
CREATE INDEX IX_AspNetRoleClaims_RoleId ON AspNetRoleClaims (RoleId);
CREATE UNIQUE INDEX RoleNameIndex ON AspNetRoles (NormalizedName) WHERE NormalizedName IS NOT NULL;
CREATE INDEX IX_AspNetUserClaims_UserId ON AspNetUserClaims (UserId);
CREATE INDEX IX_AspNetUserLogins_UserId ON AspNetUserLogins (UserId);
CREATE INDEX IX_AspNetUserRoles_RoleId ON AspNetUserRoles (RoleId);
CREATE INDEX EmailIndex ON AspNetUsers (NormalizedEmail);
CREATE UNIQUE INDEX UserNameIndex ON AspNetUsers (NormalizedUserName) WHERE NormalizedUserName IS NOT NULL;




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


-- Create Orders Table
CREATE TABLE Orders (
    OrderID VARCHAR(100) PRIMARY KEY,
    CustomerID NVARCHAR(450),
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    Status VARCHAR(50),
    ShippingAddress VARCHAR(255),
    PhoneNumber VARCHAR(15),
    FOREIGN KEY (CustomerID) REFERENCES AspNetUsers(ID)
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


-- Create Cart Table
CREATE TABLE Cart (
    CustomerID NVARCHAR(450),
    BookID VARCHAR(100),
    Quantity INT,
    PRIMARY KEY (CustomerID, BookID),
    FOREIGN KEY (CustomerID) REFERENCES AspNetUsers(ID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
CREATE TABLE ShippingCost (
    City VARCHAR(100) PRIMARY KEY,
    Cost DECIMAL(10, 2)
);

CREATE TABLE CustomersAddress (
    CustomerID NVARCHAR(450),
	City VARCHAR(100),
	Address VARCHAR(100),
	FOREIGN KEY (CustomerID) REFERENCES AspNetUsers(ID),
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
INSERT INTO Books (BookID, Title, AuthorID, CategoryID, Price, IsDiscount, Discount, InStock, SDescription, Description, ReleaseDate, NuOfPage, Collection, img, Visabilty) VALUES
('1', 'The Great Adventure', '1', '1', 19.99, 1, 5.00, 50, 'A thrilling fiction novel.', 'A detailed story of adventure and mystery.', 2023, 350, 0, 'great_adventure.jpg',1),
('2', 'Learning Science', '3', '3', 25.99, 0, 0.00, 100, 'An introduction to modern science.', 'A comprehensive guide to basic science principles.', 2022, 200, 0, 'learning_science.jpg',1),
('3', 'The History of the World', '4', '4', 30.00, 1, 10.00, 75, 'A deep dive into world history.', 'An extensive coverage of historical events.', 2021, 500, 0, 'history_world.jpg',1),
('4', 'Adventure Chronicles: Volume 1', '1', '1', 29.99, 1, 7.00, 20, 'The first volume of an epic adventure series.', 'A captivating collection of adventure tales.', 2023, 10, 1, 'adventure_chronicles_v1.jpg',1),
('5', 'Adventure Chronicles: Volume 2', '1', '1', 29.99, 1, 7.00, 20, 'The second volume of an epic adventure series.', 'Continuation of the thrilling adventure series.', 2024, 9, 1, 'adventure_chronicles_v2.jpg',1),
('6', 'Science Explorer: Volume 1', '3', '3', 39.99, 0, 0.00, 15, 'A collection of the latest science discoveries.', 'Detailed explorations into various scientific fields.', 2022, 3, 1, 'science_explorer_v1.jpg',1),
('7', 'World History Archives: Volume 1', '4', '4', 35.00, 1, 5.00, 25, 'The first in a series of historical archives.', 'An extensive collection of historical documents and analysis.', 2021, 6, 1, 'history_archives_v1.jpg',1);



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
INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES
('02ad55ad-6c39-45f3-a428-a340277e35dc', 'customers', 'customers'),
('45b97dc4-0529-42ff-8a78-56cc41f77055', 'admin', 'admin');




-- Insert the admin user
DECLARE @AdminUserId NVARCHAR(450) = NEWID();

INSERT INTO AspNetUsers (
    Id, FirstName, LastName, Address, City, CreatedAt,
    UserName, NormalizedUserName, Email, NormalizedEmail,
    EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp,
    PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled,
    LockoutEnd, LockoutEnabled, AccessFailedCount
)
VALUES (
    @AdminUserId, 'Admin', 'User', '123 Admin St.', 'Admin City', GETDATE(),
    'admin', 'ADMIN', 'admin@example.com', 'ADMIN@EXAMPLE.COM',
    1, 'HashedPasswordHere', NEWID(), NEWID(),
    NULL, 0, 0,
    NULL, 1, 0
);

-- Assign the admin user to the admin role
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (@AdminUserId, '45b97dc4-0529-42ff-8a78-56cc41f77055');