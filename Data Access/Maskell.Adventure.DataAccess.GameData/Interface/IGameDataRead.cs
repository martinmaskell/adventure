using System;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DataAccess.GameData.Interface
{
	public interface IGameDataRead
	{
		GameDto GetGame(Guid gameId);
	}
}
