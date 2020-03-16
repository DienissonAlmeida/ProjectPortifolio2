CREATE TABLE [dbo].[Person] (
    [id]             INT        NOT NULL,
    [Name]           VARCHAR (100) NOT NULL,
    [DateOfBirth] DATE          NULL,
    [Cpf]            VARCHAR (14)  NULL,
    [Employee]    BIT           NULL,
    CONSTRAINT [pk_person] PRIMARY KEY CLUSTERED ([id] ASC)
);

