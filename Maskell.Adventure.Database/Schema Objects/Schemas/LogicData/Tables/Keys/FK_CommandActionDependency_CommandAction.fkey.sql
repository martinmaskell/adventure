ALTER TABLE [LogicData].[CommandActionDependency]
    ADD CONSTRAINT [FK_CommandActionDependency_CommandAction] FOREIGN KEY ([CommandActionID]) REFERENCES [LogicData].[CommandAction] ([CommandActionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

