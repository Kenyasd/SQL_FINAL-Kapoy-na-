CREATE DATABASE FINAL_DB;
USE FINAL_DB;

-- 1️⃣ Create the Admin table
CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    Address NVARCHAR(200),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    ProfilePic NVARCHAR(200) NULL
);
Drop Procedure F_ResetPass