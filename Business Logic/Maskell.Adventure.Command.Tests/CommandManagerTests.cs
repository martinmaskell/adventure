using System;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Managers;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.Common.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandManagerTests
	{
		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "GameDataManager is null")]
		public void ProcessCommand_NullGameDataManager_ThrowNullReferenceException()
		{
			var commandManager = new CommandManager {GameDataManager = null, CommandParser = null};
			commandManager.ProcessCommand(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "CommandParser is null")]
		public void ProcessCommand_NullCommandParser_ThrowNullReferenceException()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();

			var commandManager = new CommandManager { GameDataManager = gameDataManager, CommandParser = null };
			commandManager.ProcessCommand(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "CommandText cannot be null or empty")]
		public void ProcessCommand_NullString_ThrowArgumentException()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var commandParser = mocks.Stub<ICommandParser<CommandResponse>>();
			var commandResponseManager = mocks.Stub<CommandResponseManager>();

			var commandManager = new CommandManager { GameDataManager = gameDataManager, CommandParser = commandParser, CommandResponseManager = commandResponseManager};
			commandManager.RequestProcessed += delegate { };
			commandManager.ProcessCommand(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "CommandText cannot be null or empty")]
		public void ProcessCommand_EmptyString_ThrowArgumentException()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var commandParser = mocks.Stub<ICommandParser<CommandResponse>>();
			var commandResponseManager = mocks.Stub<CommandResponseManager>();

			var commandManager = new CommandManager { GameDataManager = gameDataManager, CommandParser = commandParser, CommandResponseManager = commandResponseManager };
			commandManager.RequestProcessed += delegate { };
			commandManager.ProcessCommand(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "No subscribers to RequestProcessed event")]
		public void ProcessCommand_NoRequestProcessedSubscriber_ThrowNullReferenceException()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var commandParser = mocks.Stub<ICommandParser<CommandResponse>>();

			var commandManager = new CommandManager { GameDataManager = gameDataManager, CommandParser = commandParser };
			commandManager.ProcessCommand(string.Empty);
		}

	}
}
