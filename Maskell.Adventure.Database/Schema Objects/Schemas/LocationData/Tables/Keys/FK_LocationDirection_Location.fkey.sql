ALTER TABLE [LocationData].[LocationDirection]
    ADD CONSTRAINT [FK_LocationDirection_Location] FOREIGN KEY ([SourceLocationID]) REFERENCES [LocationData].[Location] ([LocationID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

