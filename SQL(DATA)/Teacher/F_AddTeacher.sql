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
CREATE PROCEDURE F_AddT
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Gender NVARCHAR(10),
    @Department NVARCHAR(100),
    @Subject NVARCHAR(100)
AS
BEGIN
    INSERT INTO Teachers (FirstName, LastName, Gender, Department, Subject)
    VALUES (@FirstName, @LastName, @Gender, @Department, @Subject);
END
GO
