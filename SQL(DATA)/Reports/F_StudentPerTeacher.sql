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
CREATE PROCEDURE F_StudentsPerTeacher
AS
BEGIN
    SELECT t.TeacherID, t.FirstName + ' ' + t.LastName AS TeacherName,
           s.SubjectName, st.StudentID, st.FirstName + ' ' + st.LastName AS StudentName
    FROM TeacherSubjects ts
    JOIN Teachers t ON ts.TeacherID = t.TeacherID
    JOIN Subjects s ON ts.SubjectID = s.SubjectID
    JOIN StudentSubjects ss ON s.SubjectID = ss.SubjectID
    JOIN Students st ON ss.StudentID = st.StudentID
    WHERE t.Active = 1 AND st.Active = 1
    ORDER BY TeacherName, SubjectName, StudentName;
END;
GO
