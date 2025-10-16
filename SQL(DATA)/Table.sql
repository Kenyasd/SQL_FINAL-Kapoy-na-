CREATE DATABASE FINAL_DB;
USE FINAL_DB;

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
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50), 
    Age INT,
    Address NVARCHAR(200),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Username NVARCHAR(50),
    Gender NVARCHAR(10),
    [Password] NVARCHAR(100),
    TermLevel NVARCHAR(50),
    Course NVARCHAR(100),
    Department NVARCHAR(100),  
    Teacher NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    DateCreated DATETIME DEFAULT GETDATE()
);
CREATE TABLE Teachers (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Department NVARCHAR(100),   
    Subject NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    DateCreated DATETIME DEFAULT GETDATE()
);
CREATE TABLE Logs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    ActionType NVARCHAR(20),
    Description NVARCHAR(255),
    DateLogged DATETIME DEFAULT GETDATE()
);
Drop Procedure F_CountActS;
DROP PROCEDURE IF EXISTS F_SearchS;
EXEC sp_rename 'Students.IsActive', 'Active', 'COLUMN';