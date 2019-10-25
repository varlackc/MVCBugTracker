CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TagDescription] NVARCHAR(50), 
    [TagType] NCHAR(10), 
    [TimeStamp] DateTime2(7)
)
