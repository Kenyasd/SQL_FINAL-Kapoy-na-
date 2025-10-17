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
CREATE PROCEDURE F_AddSubject
    @SubjectCode NVARCHAR(50),
    @SubjectName NVARCHAR(150)
AS
BEGIN
    INSERT INTO Subjects (SubjectCode, SubjectName, Active)
    VALUES (@SubjectCode, @SubjectName, 1);
END
GO