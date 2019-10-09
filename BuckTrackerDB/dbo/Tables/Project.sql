CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [DeadLine] DATETIME2 NULL, 
    [BugId] INT NULL, 
    CONSTRAINT [FK_BugId] FOREIGN KEY ([BugId]) REFERENCES [Bug]([Id])
)
