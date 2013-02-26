ALTER TABLE [LogicData].[ActionGroup]
    ADD CONSTRAINT [FK_ActionGroup_Action] FOREIGN KEY ([ActionID]) REFERENCES [LookupData].[Action] ([ActionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

