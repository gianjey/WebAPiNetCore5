CREATE TABLE [dbo].[Movie] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Genre]       NVARCHAR (255) NOT NULL,
    [Duration]    NVARCHAR (255) NOT NULL,
    [ReleaseDate] SMALLDATETIME  NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC)
);

