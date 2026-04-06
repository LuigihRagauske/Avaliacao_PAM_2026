IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_JOGADORES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [NumeroCamisa] int NOT NULL,
    [Posicao] nvarchar(max) NOT NULL,
    [SelecaoId] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_TB_JOGADORES] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'NumeroCamisa', N'Posicao', N'SelecaoId', N'Status') AND [object_id] = OBJECT_ID(N'[TB_JOGADORES]'))
    SET IDENTITY_INSERT [TB_JOGADORES] ON;
INSERT INTO [TB_JOGADORES] ([Id], [Nome], [NumeroCamisa], [Posicao], [SelecaoId], [Status])
VALUES (1, N'Tevez', 10, N'Meio-Campo', 0, 1),
(2, N'Cassio', 12, N'Goleiro', 0, 1),
(3, N'Ronaldo', 9, N'Atacante', 0, 1),
(4, N'Fagner', 23, N'Lateral Direito', 0, 1),
(5, N'Gil', 4, N'Zagueiro', 0, 1),
(6, N'Renato Augusto', 8, N'Meio-Campo', 0, 1),
(7, N'Paulinho', 15, N'Meio-Campo', 0, 1),
(8, N'Yuri Alberto', 9, N'Atacante', 0, 1),
(9, N'Roger Guedes', 10, N'Atacante', 0, 1),
(10, N'Fabio Santos', 6, N'Lateral Esquerdo', 0, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'NumeroCamisa', N'Posicao', N'SelecaoId', N'Status') AND [object_id] = OBJECT_ID(N'[TB_JOGADORES]'))
    SET IDENTITY_INSERT [TB_JOGADORES] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260323115739_InitialCreate', N'10.0.5');

COMMIT;
GO

