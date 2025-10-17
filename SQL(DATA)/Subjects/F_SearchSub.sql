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
CREATE PROCEDURE F_SearchSubject
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT s.SubjectID, s.SubjectCode, s.SubjectName, s.Active
    FROM Subjects s
    LEFT JOIN TeacherSubjects ts ON s.SubjectID = ts.SubjectID
    LEFT JOIN Teachers t ON ts.TeacherID = t.TeacherID
    WHERE s.SubjectCode LIKE '%' + @Keyword + '%'
       OR s.SubjectName LIKE '%' + @Keyword + '%'
       OR t.FirstName LIKE '%' + @Keyword + '%'
       OR t.LastName LIKE '%' + @Keyword + '%'
    ORDER BY s.SubjectID DESC;
END
GO
