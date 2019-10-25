CREATE TABLE [dbo].[Tags] (
    [Id]             INT          IDENTITY(1,1) NOT NULL,
    [TagDescription] NVARCHAR (50) NULL,
    [TagType]        NCHAR (10)    NULL,
    [TimeStamp]      DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

