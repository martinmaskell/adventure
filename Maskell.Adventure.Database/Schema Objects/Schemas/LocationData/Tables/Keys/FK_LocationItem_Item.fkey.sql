ALTER TABLE [LocationData].[LocationItem]
    ADD CONSTRAINT [FK_LocationItem_Item] FOREIGN KEY ([ItemID]) REFERENCES [GameData].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

