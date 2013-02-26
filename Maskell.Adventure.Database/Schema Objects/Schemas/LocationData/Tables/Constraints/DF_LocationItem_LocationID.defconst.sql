ALTER TABLE [LocationData].[LocationItem]
    ADD CONSTRAINT [DF_LocationItem_LocationID] DEFAULT (newid()) FOR [LocationID];

