ALTER TABLE [LocationData].[Direction]
    ADD CONSTRAINT [DF_Direction_GameID] DEFAULT (newsequentialid()) FOR [DirectionID];

