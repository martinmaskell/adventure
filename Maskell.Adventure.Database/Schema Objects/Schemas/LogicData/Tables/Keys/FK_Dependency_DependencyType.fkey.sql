ALTER TABLE [LogicData].[Dependency]
    ADD CONSTRAINT [FK_Dependency_DependencyType] FOREIGN KEY ([DependencyTypeID]) REFERENCES [LookupData].[DependencyType] ([DependencyTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

