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
CREATE PROCEDURE F_StudentsPerSubject
AS
BEGIN
    SELECT s.SubjectCode, s.SubjectName,
           st.StudentID, st.FirstName + ' ' + st.LastName AS StudentName
    FROM StudentSubjects ss
    JOIN Students st ON ss.StudentID = st.StudentID
    JOIN Subjects s ON ss.SubjectID = s.SubjectID
    WHERE st.Active = 1
    ORDER BY s.SubjectName, StudentName;
END;
GO
