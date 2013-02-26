using System;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Managers;
using Maskell.Adventure.Common.Game;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Game
{
	public class GameEngine : IGameEngine
	{
		public event EventHandler<GameResponseEventArgs> GameStarted;

		private IGameDataManager GameDataManager { get; set; }
		private ICommandManager CommandManager { get; set; }

		public string GameTitle { get; private set; }
		public string GameDescription { get; private set; }
		public string CommandResponse { get; private set; }

		public GameEngine()
		{
			GameDataManager = new GameDataManager();
			CommandManager = new CommandManager(GameDataManager);
			CommandManager.RequestProcessed += CommandManager_RequestProcessed;
		}

		internal GameEngine(IGameDataManager gameDataManager, ICommandManager commandManager)
		{
			GameDataManager = gameDataManager;
			CommandManager = commandManager;

			if (CommandManager != null)
			{
				CommandManager.RequestProcessed += CommandManager_RequestProcessed;
			}
		}

		public bool New(Guid gameId)
		{
			var game = GameDataManager.LoadNewGame(gameId);
			GameTitle = game.Title;
			GameDescription = game.Description;
			
			return true;
		}

		public bool Load(Guid gameDataId)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			throw new NotImplementedException();
		}

		public void StartNewGame()
		{
			if (GameStarted != null)
				GameStarted(this, new GameResponseEventArgs(GameDataManager.CurrentLocation.Description, null));
		}

		public void ProcessCommand(string commandText)
		{
			if (GameDataManager == null)
				throw new NullReferenceException("GameDataManager is null");

			if (CommandManager == null)
				throw new NullReferenceException("CommandManager is null");

			if (string.IsNullOrEmpty(commandText))
				throw new ArgumentException("CommandText is null or empty");

			CommandManager.ProcessCommand(commandText);
		}

		private void CommandManager_RequestProcessed(object sender, Command.CommandResponseEventArgs e)
		{
			CommandResponse = e.ResponseText;
			GameDescription = GameDataManager.CurrentLocation.Description;
		}


	}
}
