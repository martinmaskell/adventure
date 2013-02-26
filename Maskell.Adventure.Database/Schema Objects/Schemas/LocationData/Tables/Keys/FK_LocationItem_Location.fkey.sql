ALTER TABLE [LocationData].[LocationItem]
    ADD CONSTRAINT [FK_LocationItem_Location] FOREIGN KEY ([LocationID]) REFERENCES [LocationData].[Location] ([LocationID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

