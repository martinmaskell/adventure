using System;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DataManager.GameData
{
	public class DataReader : IGameDataReader
	{
		private readonly GameDataService.GameData _gameData;

		public DataReader()
		{
			_gameData = new GameDataService.GameData();
		}

		public IGame GetGame(Guid gameId)
		{
			//using (var client = new AdventureGameDataReadClient())
			//{
			//    return client.GetGame(gameId);
			//}
			return _gameData.GetGame(gameId);
		}
	}
}
