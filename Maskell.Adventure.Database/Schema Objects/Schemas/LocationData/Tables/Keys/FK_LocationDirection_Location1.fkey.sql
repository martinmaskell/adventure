ALTER TABLE [LocationData].[LocationDirection]
    ADD CONSTRAINT [FK_LocationDirection_Location1] FOREIGN KEY ([TargetLocationID]) REFERENCES [LocationData].[Location] ([LocationID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

