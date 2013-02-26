ALTER TABLE [LogicData].[LocationCommandAction]
    ADD CONSTRAINT [FK_LocationCommandAction_Location] FOREIGN KEY ([LocationID]) REFERENCES [LocationData].[Location] ([LocationID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

