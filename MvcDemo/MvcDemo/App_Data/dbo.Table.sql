CREATE TABLE [dbo].[MovieDBs] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (100) NOT NULL,
    [Director] NVARCHAR (100) NOT NULL,
    [Date]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

