ALTER TABLE [LocationData].[LocationDirection]
    ADD CONSTRAINT [FK_LocationDirection_Direction] FOREIGN KEY ([DirectionID]) REFERENCES [LocationData].[Direction] ([DirectionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

