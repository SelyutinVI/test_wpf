USE TestWPF;
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Users] (
    [id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Login] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Companyid] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Users_Companies_Companyid] FOREIGN KEY ([Companyid]) REFERENCES [Companies] ([id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Users_Companyid] ON [Users] ([Companyid]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200929100213_first', N'3.1.8');

GO

