IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [tblGenders] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(10) NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblGenders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tblLeagues] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(10) NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblLeagues] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tblRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tblMembers] (
    [Id] int NOT NULL IDENTITY,
    [FederationNr] VARCHAR(10) NOT NULL,
    [FirstName] VARCHAR(25) NOT NULL,
    [LastName] VARCHAR(35) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [GenderId] int NOT NULL,
    [Address] VARCHAR(70) NOT NULL,
    [Number] VARCHAR(6) NOT NULL,
    [Addition] VARCHAR(2) NULL,
    [Zipcode] VARCHAR(6) NOT NULL,
    [City] VARCHAR(30) NOT NULL,
    [PhoneNr] VARCHAR(15) NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblMembers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tblMembers_tblGenders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [tblGenders] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tblGames] (
    [Id] int NOT NULL IDENTITY,
    [GameNumber] VARCHAR(10) NOT NULL,
    [MemberId] int NOT NULL,
    [LeagueId] int NOT NULL,
    [Date] DATE NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblGames] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tblGames_tblLeagues_LeagueId] FOREIGN KEY ([LeagueId]) REFERENCES [tblLeagues] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tblGames_tblMembers_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [tblMembers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tblMemberFines] (
    [Id] int NOT NULL IDENTITY,
    [FineNumber] INT NOT NULL,
    [MemberId] int NOT NULL,
    [Amount] DECIMAL(7, 2) NOT NULL,
    [handOutDate] DATE NOT NULL,
    [PaymentDate] DATE NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblMemberFines] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tblMemberFines_tblMembers_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [tblMembers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tblMemberRoles] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [MemberId] int NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tblMemberRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tblMemberRoles_tblMembers_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [tblMembers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tblMemberRoles_tblRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [tblRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tblGameResults] (
    [Id] int NOT NULL IDENTITY,
    [GameId] int NOT NULL,
    [INT] int NOT NULL,
    [ScoreTeamMember] INT NOT NULL,
    [ScoreOpponent] INT NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_tblGameResults] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tblGameResults_tblGames_GameId] FOREIGN KEY ([GameId]) REFERENCES [tblGames] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_tblGameResults_GameId] ON [tblGameResults] ([GameId]);

GO

CREATE UNIQUE INDEX [IX_tblGameResults_INT_GameId] ON [tblGameResults] ([INT], [GameId]);

GO

CREATE UNIQUE INDEX [IX_tblGames_GameNumber] ON [tblGames] ([GameNumber]);

GO

CREATE INDEX [IX_tblGames_LeagueId] ON [tblGames] ([LeagueId]);

GO

CREATE INDEX [IX_tblGames_MemberId] ON [tblGames] ([MemberId]);

GO

CREATE UNIQUE INDEX [IX_tblGenders_Name] ON [tblGenders] ([Name]);

GO

CREATE UNIQUE INDEX [IX_tblLeagues_Name] ON [tblLeagues] ([Name]);

GO

CREATE UNIQUE INDEX [IX_tblMemberFines_FineNumber] ON [tblMemberFines] ([FineNumber]);

GO

CREATE INDEX [IX_tblMemberFines_MemberId] ON [tblMemberFines] ([MemberId]);

GO

CREATE INDEX [IX_tblMemberRoles_RoleId] ON [tblMemberRoles] ([RoleId]);

GO

CREATE UNIQUE INDEX [IX_tblMemberRoles_MemberId_RoleId_StartDate_EndDate] ON [tblMemberRoles] ([MemberId], [RoleId], [StartDate], [EndDate]);

GO

CREATE UNIQUE INDEX [IX_tblMembers_FederationNr] ON [tblMembers] ([FederationNr]);

GO

CREATE INDEX [IX_tblMembers_GenderId] ON [tblMembers] ([GenderId]);

GO

CREATE UNIQUE INDEX [IX_tblRoles_Name] ON [tblRoles] ([Name]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201002194900_init', N'3.1.9');

GO

EXEC sp_rename N'[tblGameResults].[INT]', N'SetNr', N'COLUMN';

GO

EXEC sp_rename N'[tblGameResults].[IX_tblGameResults_INT_GameId]', N'IX_tblGameResults_SetNr_GameId', N'INDEX';

GO

DROP INDEX [IX_tblGameResults_SetNr_GameId] ON [tblGameResults];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tblGameResults]') AND [c].[name] = N'SetNr');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [tblGameResults] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [tblGameResults] ALTER COLUMN [SetNr] INT NOT NULL;
CREATE UNIQUE INDEX [IX_tblGameResults_SetNr_GameId] ON [tblGameResults] ([SetNr], [GameId]);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[tbkGenders]'))
    SET IDENTITY_INSERT [tbkGenders] ON;
INSERT INTO [tbkGenders] ([Name])
VALUES (N'Male');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[tbkGenders]'))
    SET IDENTITY_INSERT [tbkGenders] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[tbkGenders]'))
    SET IDENTITY_INSERT [tbkGenders] ON;
INSERT INTO [tbkGenders] ([Name])
VALUES (N'Female');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[tbkGenders]'))
    SET IDENTITY_INSERT [tbkGenders] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201010144949_fix', N'3.1.9');

GO

