ALTER TABLE [LogicData].[CommandActionDependency]
    ADD CONSTRAINT [FK_CommandTypeDirectionDependency_Dependency] FOREIGN KEY ([DependencyID]) REFERENCES [LogicData].[Dependency] ([DependencyID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

