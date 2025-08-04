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
CREATE TABLE [Cliente] (
    [Id] INT NOT NULL IDENTITY,
    [DataNascimento] DATETIME NULL,
    [Nome] VARCHAR(100) NOT NULL,
    [DataCriacao] DATETIME NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);

CREATE TABLE [Livro] (
    [Id] INT NOT NULL IDENTITY,
    [Editora] VARCHAR(100) NOT NULL,
    [Nome] VARCHAR(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Livro] PRIMARY KEY ([Id])
);

CREATE TABLE [Pedido] (
    [Id] INT NOT NULL IDENTITY,
    [ClientId] INT NOT NULL,
    [LivroId] INT NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedido_Cliente_Id] FOREIGN KEY ([Id]) REFERENCES [Cliente] ([Id]),
    CONSTRAINT [FK_Pedido_Livro_Id] FOREIGN KEY ([Id]) REFERENCES [Livro] ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250804154019_First-Migration', N'9.0.7');

COMMIT;
GO

