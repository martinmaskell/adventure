ALTER TABLE [GameData].[Game]
    ADD CONSTRAINT [DF_Game_GameID] DEFAULT (newsequentialid()) FOR [GameID];

