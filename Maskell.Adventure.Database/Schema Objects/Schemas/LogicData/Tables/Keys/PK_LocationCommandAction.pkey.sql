﻿ALTER TABLE [LogicData].[LocationCommandAction]
    ADD CONSTRAINT [PK_LocationCommandAction] PRIMARY KEY CLUSTERED ([LocationID] ASC, [CommandActionID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
