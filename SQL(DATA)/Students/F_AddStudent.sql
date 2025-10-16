-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE F_AddS
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Age INT,
    @Address NVARCHAR(200),
    @Phone NVARCHAR(50),
    @Email NVARCHAR(100),
    @Username NVARCHAR(50),
    @Password NVARCHAR(100),
    @Gender NVARCHAR(10),
    @TermLevel NVARCHAR(50),
    @Department NVARCHAR(100),
    @Course NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Students WHERE Username = @Username)
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END

    INSERT INTO Students
    (FirstName, LastName, Age, Address, Phone, Email, Username, [Password],
     Gender, TermLevel, Department, Course)
    VALUES
    (@FirstName, @LastName, @Age, @Address, @Phone, @Email, @Username, @Password,
     @Gender, @TermLevel, @Department, @Course);
END
GO
