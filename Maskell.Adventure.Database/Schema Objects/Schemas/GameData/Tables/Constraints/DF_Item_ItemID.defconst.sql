ALTER TABLE [GameData].[Item]
    ADD CONSTRAINT [DF_Item_ItemID] DEFAULT (newsequentialid()) FOR [ItemID];

