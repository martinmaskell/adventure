ALTER TABLE [LogicData].[Command]
    ADD CONSTRAINT [FK_Command_CommandType] FOREIGN KEY ([CommandTypeID]) REFERENCES [LookupData].[CommandType] ([CommandTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

