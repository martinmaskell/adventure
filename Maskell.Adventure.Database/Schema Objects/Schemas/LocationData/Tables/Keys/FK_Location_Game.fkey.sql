ALTER TABLE [LocationData].[Location]
    ADD CONSTRAINT [FK_Location_Game] FOREIGN KEY ([GameID]) REFERENCES [GameData].[Game] ([GameID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

