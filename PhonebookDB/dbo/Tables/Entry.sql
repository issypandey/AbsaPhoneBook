CREATE TABLE [dbo].[Entry] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NULL,
    [PhoneNumber]   VARCHAR(50)          NULL,
    [CreatedBy]     VARCHAR (50) NULL,
    [CreatedByDate] DATETIME     NULL,
    [PhoneBookId]   INT          NULL,
    CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED ([Id] ASC)
);

