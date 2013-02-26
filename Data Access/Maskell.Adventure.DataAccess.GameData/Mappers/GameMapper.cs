using Maskell.Adventure.DataAccess.GameData.dbml;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataAccess.GameData.Mappers
{
	public class GameMapper
	{
		public static GameDto Map(Game gameDao, Location locationDao)
		{
			if (gameDao == null)
				return null;

			var ret = new GameDto
			       	{
			       		DateAdded = gameDao.DateAdded,
			       		Description = gameDao.Description,
			       		GameId = gameDao.GameID,
			       		OwnerId = gameDao.OwnerID,
			       		Title = gameDao.Title,
			       		StartLocation =
			       			locationDao == null
			       				? null
			       				: LocationMapper.Map(locationDao)
			       	};

			return ret;
		}
	}
}
