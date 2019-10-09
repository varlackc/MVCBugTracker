CREATE TABLE [dbo].[Bug]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProjectId] INT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [TimeStamp] NVARCHAR(50) NULL, 
    [Status] NCHAR(10) NULL, 
    [CreatedByUserId] INT NULL, 
    [Details] NVARCHAR(50) NULL, 
    [PriorityLevel] NCHAR(10) NULL, 
    [UserAssignedId] INT NULL, 
    CONSTRAINT [FK_UserAssignedId] FOREIGN KEY ([UserAssignedId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [User]([Id])
)
