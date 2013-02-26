using System;
using System.Collections.Generic;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DataManager.GameData;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Common.Game
{
	public class GameDataManager : IGameDataManager
	{
		public Guid? CurrentGameId
		{
			get { return GetCurrentGameId(); }
		}

		private IGame CurrentGame { get; set; }
		public LocationDto CurrentLocation { get; private set; }
		public List<ItemDto> Inventory { get; private set; }
		public List<DirectionDto> Directions { get; private set; }

		private IGameDataReader GameDataReader { get; set; }
		private ILocationDataManager LocationDataManager { get; set; }

		public GameDataManager(IGameDataReader gameDataReader, ILocationDataManager locationDataManager)
		{
			GameDataReader = gameDataReader;
			LocationDataManager = locationDataManager;
			Inventory = new List<ItemDto>();
			Directions = LocationDataManager.Directions;
		}

		public GameDataManager()
			: this(new DataReader(), new LocationDataManager())
		{
		}

		public void ChangeLocation(LocationDto location)
		{
			CurrentLocation = location;
		}

		public void ChangeDirection(DirectionDto direction)
		{
			var newLocation = LocationDataManager.GetLocationByDirection(CurrentLocation, direction);
			if (newLocation != null)
				ChangeLocation(newLocation);
		}

		public void AddInventoryItem(IItem item)
		{
			throw new NotImplementedException();
		}

		public void RemoveInventoryItem(IItem item)
		{
			throw new NotImplementedException();
		}


		public IGame LoadNewGame(Guid gameId)
		{
			CurrentGame = GameDataReader.GetGame(gameId);
			CurrentLocation = CurrentGame.StartLocation;
			return CurrentGame;
		}

		public IGame LoadSavedGame(Guid savedGameId)
		{
			throw new NotImplementedException();
		}

		private Guid? GetCurrentGameId()
		{
			if (CurrentGame == null)
				return null;

			return CurrentGame.GameId;
		}
	}
}