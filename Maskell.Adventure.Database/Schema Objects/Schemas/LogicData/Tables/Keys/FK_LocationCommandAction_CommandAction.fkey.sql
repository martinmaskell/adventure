ALTER TABLE [LogicData].[LocationCommandAction]
    ADD CONSTRAINT [FK_LocationCommandAction_CommandAction] FOREIGN KEY ([CommandActionID]) REFERENCES [LogicData].[CommandAction] ([CommandActionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

