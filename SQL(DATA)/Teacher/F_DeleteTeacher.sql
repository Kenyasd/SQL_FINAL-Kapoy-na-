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
CREATE PROCEDURE F_DeleteTeacher
    @TeacherID INT
AS
BEGIN
    -- Delete related entries first
    DELETE FROM TeacherSubjects WHERE TeacherID = @TeacherID;

    -- Then delete the teacher
    DELETE FROM Teachers WHERE TeacherID = @TeacherID;
END;
GO
