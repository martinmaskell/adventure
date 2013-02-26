using System;

namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface IGameEngine
	{
		string GameTitle { get; }
		string GameDescription { get; }
		string CommandResponse { get; }

		bool New(Guid gameId);
		bool Load(Guid gameDataId);
		bool Save();
		void StartNewGame();
		void ProcessCommand(string commandText);

		//event EventHandler<GameResponseEventArgs> CommandProcessed;
		event EventHandler<GameResponseEventArgs> GameStarted;
	}
}
