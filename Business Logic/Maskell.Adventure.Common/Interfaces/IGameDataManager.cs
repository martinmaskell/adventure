using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Common.Interfaces
{
	public interface IGameDataManager
	{
		Guid? CurrentGameId { get; }
		LocationDto CurrentLocation { get; }
		List<ItemDto> Inventory { get; }
		List<DirectionDto> Directions { get; }

		IGame LoadNewGame(Guid gameId);
		IGame LoadSavedGame(Guid savedGameId);

		void ChangeLocation(LocationDto location);
		void ChangeDirection(DirectionDto direction);
		void AddInventoryItem(IItem item);
		void RemoveInventoryItem(IItem item);
	}
}