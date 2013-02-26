using System;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DataManager.Interface
{
	public interface IGameDataReader
	{
		IGame GetGame(Guid gameId);
	}
}
