BEGIN TRANSACTION;
ALTER TABLE [TB_JOGADORES] DROP CONSTRAINT [PK_TB_JOGADORES];

EXEC sp_rename N'[TB_JOGADORES]', N'TB_ESTADIOS', 'OBJECT';

ALTER TABLE [TB_ESTADIOS] ADD CONSTRAINT [PK_TB_ESTADIOS] PRIMARY KEY ([Id]);

CREATE TABLE [Estadio] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [Capacidade] int NOT NULL,
    CONSTRAINT [PK_Estadio] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[Estadio]'))
    SET IDENTITY_INSERT [Estadio] ON;
INSERT INTO [Estadio] ([Id], [Capacidade], [Cidade], [Nome])
VALUES (1, 46000, N'São Paulo', N'NeoQuímica Arena'),
(2, 45000, N'São Paulo', N'Allianz Parque'),
(3, 75000, N'Rio de Janeiro', N'Maracanã'),
(4, 47000, N'São Paulo', N'Morumbi'),
(5, 30000, N'São Paulo', N'Castelão'),
(6, 20000, N'São Paulo', N'Brinco de Ouro'),
(7, 50000, N'São Paulo', N'Camp Nou'),
(8, 60000, N'São Paulo', N'Allianz Arena'),
(9, 20000, N'São Paulo', N'Vila Belmiro'),
(10, 20000, N'São Paulo', N'Arena Barueri');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[Estadio]'))
    SET IDENTITY_INSERT [Estadio] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406111320_MigracaoEstadios', N'10.0.5');

COMMIT;
GO

