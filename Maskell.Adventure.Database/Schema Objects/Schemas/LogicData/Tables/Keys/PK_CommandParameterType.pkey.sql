﻿ALTER TABLE [LogicData].[CommandParameterType]
    ADD CONSTRAINT [PK_CommandParameterType] PRIMARY KEY CLUSTERED ([CommandID] ASC, [ParameterTypeID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

