CREATE TABLE [LocationData].[Location] (
    [LocationID]          UNIQUEIDENTIFIER NOT NULL,
    [GameID]              UNIQUEIDENTIFIER NOT NULL,
    [LocationName]        VARCHAR (500)    NOT NULL,
    [LocationDescription] TEXT             NOT NULL
);

