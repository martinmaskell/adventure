ALTER TABLE [GameData].[Game]
    ADD CONSTRAINT [FK_Game_Location] FOREIGN KEY ([StartLocationID]) REFERENCES [LocationData].[Location] ([LocationID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

