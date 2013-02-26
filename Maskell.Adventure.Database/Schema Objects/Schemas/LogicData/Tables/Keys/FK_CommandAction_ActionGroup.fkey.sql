ALTER TABLE [LogicData].[CommandAction]
    ADD CONSTRAINT [FK_CommandAction_ActionGroup] FOREIGN KEY ([ActionGroupID]) REFERENCES [LogicData].[ActionGroup] ([ActionGroupID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

