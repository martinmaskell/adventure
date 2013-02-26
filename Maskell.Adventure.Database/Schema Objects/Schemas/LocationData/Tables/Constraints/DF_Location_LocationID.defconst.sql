ALTER TABLE [LocationData].[Location]
    ADD CONSTRAINT [DF_Location_LocationID] DEFAULT (newsequentialid()) FOR [LocationID];

