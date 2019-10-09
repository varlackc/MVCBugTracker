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
    [UserAssignedId] INT NULL
)
