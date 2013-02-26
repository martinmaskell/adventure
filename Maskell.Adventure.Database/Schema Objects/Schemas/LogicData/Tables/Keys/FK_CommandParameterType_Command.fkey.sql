ALTER TABLE [LogicData].[CommandParameterType]
    ADD CONSTRAINT [FK_CommandParameterType_Command] FOREIGN KEY ([CommandID]) REFERENCES [LogicData].[Command] ([CommandID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

