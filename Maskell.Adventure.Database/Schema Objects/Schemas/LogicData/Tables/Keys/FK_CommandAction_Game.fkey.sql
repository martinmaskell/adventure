ALTER TABLE [LogicData].[CommandAction]
    ADD CONSTRAINT [FK_CommandAction_Game] FOREIGN KEY ([GameID]) REFERENCES [GameData].[Game] ([GameID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

