CREATE TABLE [LogicData].[CommandAction] (
    [CommandActionID] INT              IDENTITY (1, 1) NOT NULL,
    [CommandID]       INT              NOT NULL,
    [ActionGroupID]   INT              NOT NULL,
    [GameID]          UNIQUEIDENTIFIER NULL
);

