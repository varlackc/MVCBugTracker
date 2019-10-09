CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NCHAR(10) NULL
)
