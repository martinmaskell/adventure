ALTER TABLE [LogicData].[CommandActionResponse]
    ADD CONSTRAINT [FK_CommandActionResponse_CommandAction] FOREIGN KEY ([CommandActionID]) REFERENCES [LogicData].[CommandAction] ([CommandActionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

