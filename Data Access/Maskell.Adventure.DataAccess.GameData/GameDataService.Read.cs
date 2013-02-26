using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.DataAccess.GameData.Interface;
using Maskell.Adventure.DataAccess.GameData.dbml;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.DataAccess.Common;

namespace Maskell.Adventure.DataAccess.GameData
{
	public class GameDataServiceRead : IGameDataRead
	{
		public GameDto GetGame(Guid gameId)
		{
			using (var ctx = DataContext<GameDataDataContext>.TrackedContext)
			{
				var gameDao = (from g in ctx.Games
							  where g.GameID == gameId
							  select g).FirstOrDefault();

				if (gameDao == null)
					return null;

				var locationDao = !gameDao.StartLocationID.HasValue ? null : (from location in ctx.Locations
					               where location.LocationID == gameDao.StartLocationID && location.GameID == gameDao.GameID
					               select location).FirstOrDefault();

				return Mappers.GameMapper.Map(gameDao, locationDao);
			}
		}

	}
}
