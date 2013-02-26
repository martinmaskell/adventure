ALTER TABLE [GameData].[ItemProperty]
    ADD CONSTRAINT [FK_ItemProperty_Item] FOREIGN KEY ([ItemID]) REFERENCES [GameData].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

