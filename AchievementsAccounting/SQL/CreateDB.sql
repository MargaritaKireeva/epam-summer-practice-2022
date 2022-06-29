CREATE DATABASE AchievementsAccountingDB
COLLATE Cyrillic_General_100_CI_AI
GO

USE AchievementsAccountingDB

CREATE TABLE [Users] (
  [ID] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Users] PRIMARY KEY,
  [Name] nvarchar(50) NOT NULL,
  [Birthday] date,
  [Description] nvarchar(255)
);

CREATE TABLE [Accounts] (
  [UserID] int NOT NULL,
  [UserLogin] nvarchar(30) NOT NULL,
  [UserPassword] nvarchar(15) NOT NULL,
  [UserRole] nvarchar(20) NOT NULL,
  CONSTRAINT [FK_Accounts.UserID]
    FOREIGN KEY ([UserID])
      REFERENCES [Users]([ID])
);

CREATE TABLE [Achievements] (
  [ID] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Achievements] PRIMARY KEY,
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(255) NOT NULL
);

CREATE TABLE [AchievementUserConnection] (
  [UserID] int NOT NULL,
  [AchievementID] int NOT NULL,
  CONSTRAINT [FK_AchievementUserConnection.UserID]
    FOREIGN KEY ([UserID])
      REFERENCES [Users]([ID]),
  CONSTRAINT [FK_AchievementUserConnection.AchievementID]
    FOREIGN KEY ([AchievementID])
      REFERENCES [Achievements]([ID])
);

ALTER TABLE [Accounts]
ADD UNIQUE(UserLogin);

ALTER TABLE Users
ALTER COLUMN Birthday date NOT NULL;
