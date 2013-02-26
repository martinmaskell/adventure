using System;
using Maskell.Adventure.DataAccess.GameData;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.GameDataService.Interface;

namespace Maskell.Adventure.GameDataService
{
	public partial class GameData : IAdventureGameDataRead
	{
		public GameDto GetGame(Guid gameId)
		{
			var gameDataservice = new GameDataServiceRead();
			return gameDataservice.GetGame(gameId);
		}
	}
}
