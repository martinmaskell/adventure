CREATE TABLE [GameData].[Game] (
    [GameID]          UNIQUEIDENTIFIER NOT NULL,
    [OwnerID]         INT              NOT NULL,
    [Title]           NVARCHAR (500)   NOT NULL,
    [Description]     TEXT             NOT NULL,
    [DateAdded]       DATETIME         NOT NULL,
    [StartLocationID] UNIQUEIDENTIFIER NULL
);

