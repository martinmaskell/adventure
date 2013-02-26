CREATE TABLE [LogicData].[Dependency] (
    [DependencyID]           INT              IDENTITY (1, 1) NOT NULL,
    [DependencyTypeID]       INT              NOT NULL,
    [DependencyElementID]    UNIQUEIDENTIFIER NOT NULL,
    [DependencyElementKey]   VARCHAR (50)     NOT NULL,
    [DependencyElementValue] VARCHAR (50)     NULL
);

