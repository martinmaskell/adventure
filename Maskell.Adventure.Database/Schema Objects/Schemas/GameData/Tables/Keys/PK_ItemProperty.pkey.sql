﻿ALTER TABLE [GameData].[ItemProperty]
    ADD CONSTRAINT [PK_ItemProperty] PRIMARY KEY CLUSTERED ([ItemPropertyID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
