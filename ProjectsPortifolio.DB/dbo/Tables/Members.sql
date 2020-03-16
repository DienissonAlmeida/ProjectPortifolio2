CREATE TABLE [dbo].[Members] (
    [idprojeto] INT NOT NULL,
    [idpessoa]  INT NOT NULL,
    CONSTRAINT [pk_project_members] PRIMARY KEY CLUSTERED ([idprojeto] ASC),
    CONSTRAINT [fk_person] FOREIGN KEY ([idpessoa]) REFERENCES [dbo].[Person] ([id]),
    CONSTRAINT [fk_person_members] FOREIGN KEY ([idpessoa]) REFERENCES [dbo].[Project] ([id])
);

