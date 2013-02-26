ALTER TABLE [LogicData].[CommandActionParameter]
    ADD CONSTRAINT [FK_CommandActionParameter_CommandAction] FOREIGN KEY ([CommandActionID]) REFERENCES [LogicData].[CommandAction] ([CommandActionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

