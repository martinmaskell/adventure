﻿ALTER TABLE [LocationData].[LocationDirection]
    ADD CONSTRAINT [PK_LocationDirection_1] PRIMARY KEY CLUSTERED ([SourceLocationID] ASC, [TargetLocationID] ASC, [DirectionID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

