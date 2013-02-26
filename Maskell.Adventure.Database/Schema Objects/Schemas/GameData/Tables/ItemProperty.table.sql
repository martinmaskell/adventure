CREATE TABLE [GameData].[ItemProperty] (
    [ItemPropertyID]     INT              IDENTITY (1, 1) NOT NULL,
    [ItemID]             UNIQUEIDENTIFIER NOT NULL,
    [PropertyDataTypeID] INT              NOT NULL,
    [PropertyName]       VARCHAR (50)     NOT NULL,
    [PropertyValue]      VARCHAR (1000)   NOT NULL
);

