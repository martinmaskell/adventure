CREATE TABLE [LogicData].[CommandActionResponse] (
    [CommandActionResponseID] INT            IDENTITY (1, 1) NOT NULL,
    [CommandActionID]         INT            NOT NULL,
    [SuccessReponseMessage]   VARCHAR (1000) NOT NULL,
    [FailResponseMessage]     VARCHAR (1000) NOT NULL
);

