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
CREATE PROCEDURE F_ResetPass
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @NewPassword NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Admins WHERE Username = @Username AND Email = @Email)
    BEGIN
        UPDATE Admins
        SET [Password] = @NewPassword
        WHERE Username = @Username AND Email = @Email;

        PRINT 'Password updated successfully!';
    END
    ELSE
    BEGIN
        RAISERROR('Invalid username or email. Please try again.', 16, 1);
    END
END
GO
