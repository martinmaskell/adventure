ALTER TABLE [LogicData].[LocationCommandAction]
    ADD CONSTRAINT [DF_LocationCommandAction_LocationID] DEFAULT (newsequentialid()) FOR [LocationID];

