ALTER TABLE [LocationData].[LocationDirection]
    ADD CONSTRAINT [DF_LocationDirection_DirectionID] DEFAULT (newsequentialid()) FOR [DirectionID];

