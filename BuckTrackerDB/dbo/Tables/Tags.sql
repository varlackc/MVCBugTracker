CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TagDescription] NVARCHAR(50) NULL, 
    [TagType] NCHAR(10) NULL, 
    [TimeStamp] DATETIME2 NULL
)
