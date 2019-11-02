CREATE TABLE [dbo].[Bug]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY(1 ,1),
    [Description] NVARCHAR(100) NULL, 
    [TimeStamp] DATETIME2 NULL, 
    [Status] NCHAR(10) NULL, 
    [Details] NVARCHAR(50) NULL, 
    [PriorityLevel] NCHAR(10) NULL, 
    [BugProjectId] INT NOT NULL, 
    CONSTRAINT [FK_BugProjectId] FOREIGN KEY ([BugProjectId]) REFERENCES [Project]([Id])

)
