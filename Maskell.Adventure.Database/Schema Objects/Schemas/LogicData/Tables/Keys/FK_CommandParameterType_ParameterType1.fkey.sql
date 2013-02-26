ALTER TABLE [LogicData].[CommandParameterType]
    ADD CONSTRAINT [FK_CommandParameterType_ParameterType1] FOREIGN KEY ([ParameterTypeID]) REFERENCES [LookupData].[ParameterType] ([ParameterTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

