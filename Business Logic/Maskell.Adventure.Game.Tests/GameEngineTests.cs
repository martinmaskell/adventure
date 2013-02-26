using System;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Common.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Game.Tests
{
	[TestFixture]
	public class GameEngineTests
	{
		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "GameDataManager is null")]
		public void ProcessCommand_NullGameDataManager_ThrowNullReferenceException()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandManager = mocks.Stub<ICommandManager>();

			// Act
			var gameEngine = new GameEngine(null, commandManager);
			gameEngine.ProcessCommand(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "CommandManager is null")]
		public void ProcessCommand_NullCommandManager_ThrowNullReferenceException()
		{
			// Arrange
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			
			// Act
			var gameEngine = new GameEngine(gameDataManager, null);
			gameEngine.ProcessCommand(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "No subscribers to CommandProcessed event")]
		public void ProcessCommand_NullCommandProcessedHookup_ThrowNullReferenceException()
		{
			// Arrange
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var commandManager = mocks.Stub<ICommandManager>();

			// Act
			var gameEngine = new GameEngine(gameDataManager, commandManager);
			gameEngine.ProcessCommand("test");
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ProcessCommand_NullCommandText_ThrowArgumentException()
		{
			// Arrange
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var commandManager = mocks.Stub<ICommandManager>();
			var gameEngine = new GameEngine(gameDataManager, commandManager);

			// Act
			gameEngine.ProcessCommand(null);
		}

	}
}
