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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109215009_initialcreate')
BEGIN
    CREATE TABLE [Restaurants] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(80) NOT NULL,
        [Location] nvarchar(255) NOT NULL,
        [Cuisine] int NOT NULL,
        CONSTRAINT [PK_Restaurants] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109215009_initialcreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230109215009_initialcreate', N'7.0.1');
END;
GO

COMMIT;
GO

