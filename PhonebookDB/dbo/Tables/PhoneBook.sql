CREATE TABLE [dbo].[PhoneBook] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NULL,
    [CreatedBy]     VARCHAR (50) NULL,
    [CreatedByDate] DATETIME     NULL,
    [Entries]       INT          NULL,
    CONSTRAINT [PK_PhoneBook] PRIMARY KEY CLUSTERED ([Id] ASC)
);

