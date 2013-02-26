ALTER TABLE [LogicData].[CommandAction]
    ADD CONSTRAINT [FK_CommandAction_Command] FOREIGN KEY ([CommandID]) REFERENCES [LogicData].[Command] ([CommandID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

