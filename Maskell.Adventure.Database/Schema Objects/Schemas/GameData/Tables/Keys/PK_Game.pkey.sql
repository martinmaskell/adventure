﻿ALTER TABLE [GameData].[Game]
    ADD CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([GameID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
