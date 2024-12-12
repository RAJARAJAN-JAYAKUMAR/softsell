
CREATE TABLE Rooms (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(50) NOT NULL,
    RoomType NVARCHAR(50) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL -- e.g., 'Available' or 'Occupied'
);
GO

-- Create Guests Table
CREATE TABLE Guests (
    GuestID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CheckInDate DATETIME NOT NULL,
    CheckOutDate DATETIME NULL,
    RoomID INT,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID) -- Linking to Rooms table
);
GO

-- Create Transactions Table
CREATE TABLE Transactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    GuestID INT,
    RoomID INT,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    PaymentStatus NVARCHAR(50) NOT NULL, -- e.g., 'Paid' or 'Pending'
    FOREIGN KEY (GuestID) REFERENCES Guests(GuestID), -- Linking to Guests table
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)  -- Linking to Rooms table
);
GO

-- Create Facilities Table
CREATE TABLE Facilities (
    FacilityID INT IDENTITY(1,1) PRIMARY KEY,
    FacilityName NVARCHAR(100) NOT NULL,
    Fee DECIMAL(18, 2) NOT NULL
);
GO

-- Create Payments Table
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    TransactionID INT,
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL, -- e.g., 'Credit', 'Debit', 'Cash'
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID) -- Linking to Transactions table
);
GO

INSERT INTO Rooms (RoomNumber, RoomType, Price, Status)
VALUES 
('101', 'Single', 100.00, 'Available'),
('102', 'Double', 150.00, 'Available'),
('103', 'Suite', 300.00, 'Occupied'),
('104', 'Single', 100.00, 'Available');

INSERT INTO Facilities (FacilityName, Fee)
VALUES 
('Gym', 20.00),
('Swimming Pool', 25.00),
('Spa', 50.00),
('Restaurant', 30.00);

INSERT INTO Guests (Name, CheckInDate, CheckOutDate, RoomID)
VALUES 
('John Doe', '2024-12-10', '2024-12-12', 1),
('Jane Smith', '2024-12-11', '2024-12-15', 2),
('Michael Brown', '2024-12-09', '2024-12-13', 3);

INSERT INTO Transactions (GuestID, RoomID, TotalAmount, PaymentStatus)
VALUES 
(1, 1, 200.00, 'Paid'),
(2, 2, 600.00, 'Pending'),
(3, 3, 1200.00, 'Paid');

INSERT INTO Payments (TransactionID, Amount, PaymentDate, PaymentMethod)
VALUES 
(1, 200.00, '2024-12-10', 'Credit'),
(3, 1200.00, '2024-12-09', 'Debit');

SELECT * FROM Rooms;
SELECT * FROM Facilities;
SELECT * FROM Guests;
SELECT * FROM Transactions;
SELECT * FROM Payments;
