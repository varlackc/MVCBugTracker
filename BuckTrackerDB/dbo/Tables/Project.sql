CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1 ,1),
	[Name] Varchar(50),
	[Description] Varchar(50),
	[DeadLine] DateTime2(7)


)
