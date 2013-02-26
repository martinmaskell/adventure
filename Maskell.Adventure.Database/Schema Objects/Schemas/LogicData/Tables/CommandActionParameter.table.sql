CREATE TABLE [LogicData].[CommandActionParameter] (
    [CommandActionParameterID]    INT              NOT NULL,
    [CommandActionID]             INT              NOT NULL,
    [ParameterID]                 UNIQUEIDENTIFIER NOT NULL,
    [CommandActionParameterOrder] INT              NOT NULL
);

