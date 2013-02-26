CREATE TABLE [GameData].[Item] (
    [ItemID]          UNIQUEIDENTIFIER NOT NULL,
    [GameID]          UNIQUEIDENTIFIER NOT NULL,
    [ItemName]        NVARCHAR (500)   NOT NULL,
    [CommonName]      NVARCHAR (500)   NOT NULL,
    [ItemDescription] TEXT             NOT NULL
);

