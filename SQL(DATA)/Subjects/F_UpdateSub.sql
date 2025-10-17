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
CREATE PROCEDURE F_UpdateSubject
    @SubjectID INT,
    @Code NVARCHAR(50),
    @Title NVARCHAR(200),
    @Teacher NVARCHAR(100),
    @Active BIT
AS
BEGIN
    UPDATE Subjects
    SET Code = @Code,
        Title = @Title,
        Teacher = @Teacher,
        Active = @Active
    WHERE SubjectID = @SubjectID;
END
GO
