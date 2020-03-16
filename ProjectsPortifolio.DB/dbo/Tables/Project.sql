CREATE TABLE [dbo].[Project] (
    [id]              INT         NOT NULL,
    [Name]            VARCHAR (200)  NOT NULL,
    [StartDate]       DATE           NULL,
    [EndDateForecast] DATE           NULL,
    [EndDate]         DATE           NULL,
    [Description]     VARCHAR (5000) NULL,
    [StatusProject]   INT   NULL,
    [TotalBudget]     DECIMAL     NULL,
    [DegreRisk]       INT   NULL,
    [PersonId]       INT         NOT NULL,
    CONSTRAINT [pk_project] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_manager] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([id])
);



