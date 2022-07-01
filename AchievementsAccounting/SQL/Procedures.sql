USE AchievementsAccountingDB

CREATE PROCEDURE InsertUser
@ID INT OUTPUT,
@Name nvarchar(50),
@Birthday date,
@Description nvarchar(255)
AS 
INSERT INTO Users
VALUES(@Name, @Birthday, @Description)
SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID
GO

CREATE PROCEDURE DeleteUser
@ID INT
AS 
IF (EXISTS (SELECT * FROM Accounts WHERE UserID = @ID))
  DELETE FROM Accounts
  WHERE UserID = @ID
IF (EXISTS (SELECT * FROM AchievementUserConnection WHERE UserID = @ID))
  DELETE FROM AchievementUserConnection
  WHERE UserID = @ID
DELETE FROM Users 
WHERE ID = @ID
GO

CREATE PROCEDURE UpdateUser
@ID INT,
@Name nvarchar(50),
@Birthday date,
@Description nvarchar(255)
AS
UPDATE Users
SET Name = @Name, Birthday = @Birthday, [Description] = @Description
WHERE ID = @ID
GO

CREATE PROCEDURE GetAllUsers
AS 
SELECT ID, Name, Birthday FROM Users
GO

CREATE PROCEDURE GetUserDescription
@ID INT
AS 
SELECT [Description] FROM Users
WHERE ID = @ID
GO

CREATE PROCEDURE InsertAchievement
@ID INT OUTPUT,
@Name nvarchar(50),
@Description nvarchar(255)
AS 
INSERT INTO Achievements
VALUES(@Name, @Description)
GO

CREATE PROCEDURE DeleteAchievement
@ID INT
AS 
IF (EXISTS (SELECT * FROM AchievementUserConnection WHERE AchievementID = @ID))
  DELETE FROM AchievementUserConnection
  WHERE AchievementID = @ID
DELETE FROM Achievements 
WHERE ID = @ID
GO

CREATE PROCEDURE UpdateAchievement
@ID INT,
@Name nvarchar(50),
@Description nvarchar(255)
AS
UPDATE Achievements
SET Name = @Name, [Description] = @Description
WHERE ID = @ID
GO

CREATE PROCEDURE GetAllAchievements
AS 
SELECT * FROM Achievements
GO

CREATE PROCEDURE InsertAchievementUserConnection
@UserID INT,
@AchievementID INT
AS 
INSERT INTO AchievementUserConnection
VALUES(@UserID, @AchievementID)
GO

CREATE PROCEDURE DeleteAchievementUserConnection
@UserID INT,
@AchievementID INT
AS 
DELETE FROM AchievementUserConnection 
WHERE UserID = @UserID AND AchievementID = @AchievementID
GO

--CREATE PROCEDURE UpdateAchievementUserConnection
--@UserID INT,
--@OldAchievementID INT,
--@NewAchievementID INT
--AS
--UPDATE AchievementUserConnection
--SET UserID = @UserID, AchievementID = @AchievementID
--WHERE UserID = @UserID AND AchievementID = @OldAchievementID
--GO

CREATE PROCEDURE GetAllAchievementsByUser
@UserID INT
AS 
SELECT ach.ID, ach.Name, ach.[Description]
FROM AchievementUserConnection AS achUser
INNER JOIN Achievements AS ach ON ach.ID = achUser.AchievementID
WHERE achUser.UserID = @UserID
GO

CREATE PROCEDURE InsertAccount
@UserID INT,
@UserLogin nvarchar(30),
@UserPassword nvarchar(15),
@UserRole nvarchar(20)
AS 
IF (EXISTS(SELECT * FROM Accounts WHERE UserLogin = @UserLogin))
RAISERROR('ѕользователь с таким логином уже существует!', 16, 1)
ELSE
INSERT INTO Accounts
VALUES(@UserID, @UserLogin, @UserPassword, @UserRole)
GO

CREATE PROCEDURE DeleteAccount
@UserID INT
AS 
IF (EXISTS (SELECT * FROM AchievementUserConnection WHERE UserID = @UserID))
  DELETE FROM AchievementUserConnection
  WHERE UserID = @UserID
DELETE FROM Accounts 
WHERE UserID = @UserID
GO

CREATE PROCEDURE UpdateAccount
@UserID INT,
@UserLogin nvarchar(30),
@UserPassword nvarchar(15),
@UserRole nvarchar(20)
AS
UPDATE Accounts
SET UserLogin = @UserLogin, UserPassword = @UserPassword, UserRole = @UserRole
WHERE UserID = @UserID
GO

CREATE PROCEDURE GetAllAccounts
AS 
SELECT * FROM Accounts
GO

CREATE PROCEDURE GetUserByID
@UserID INT
AS 
SELECT * FROM Users
WHERE ID = @UserID
GO

CREATE PROCEDURE SearchAccountForAuth
@UserLogin nvarchar(30),
@UserPassword nvarchar(15)
AS
SELECT * FROM Accounts
WHERE UserLogin = @UserLogin AND UserPassword = @UserPassword
GO

CREATE PROCEDURE SearchAchievementByDescription
@Description varchar(255)
AS
SELECT * FROM Achievements WHERE [Description] LIKE '%' + @Description + '%'
OR Name LIKE '%' + @Description + '%'
GO