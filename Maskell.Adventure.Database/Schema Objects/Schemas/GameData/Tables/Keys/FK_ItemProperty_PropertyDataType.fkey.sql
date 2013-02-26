ALTER TABLE [GameData].[ItemProperty]
    ADD CONSTRAINT [FK_ItemProperty_PropertyDataType] FOREIGN KEY ([PropertyDataTypeID]) REFERENCES [LookupData].[PropertyDataType] ([PropertyDataTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

