ALTER TABLE [LocationData].[LocationItem]
    ADD CONSTRAINT [DF_LocationItem_ItemID] DEFAULT (newid()) FOR [ItemID];

