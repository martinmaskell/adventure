ALTER TABLE [GameData].[Game]
    ADD CONSTRAINT [DF_Game_DateCreated] DEFAULT (getdate()) FOR [DateAdded];

