CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TagDescription] NVARCHAR(100), 
    [TagType] NCHAR(50), 
    [TimeStamp] DateTime2(7)
)
