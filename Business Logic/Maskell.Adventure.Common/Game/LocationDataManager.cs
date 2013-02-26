using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DataManager.LocationData;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Common.Game
{
	public class LocationDataManager : ILocationDataManager
	{
		public List<LocationDto> Locations { get; private set; }
		public List<LocationDirectionRelationship> LocationDirectionRelationships { get; private set; }
		private ILocationDataReader LocationDataReader { get; set; }

		public List<DirectionDto> Directions { get; private set; }

		public LocationDataManager() : this(new DataReader())
		{
		}

		public LocationDataManager(ILocationDataReader locationDataReader)
		{
			LocationDataReader = locationDataReader;
			Locations = new List<LocationDto>();
			LocationDirectionRelationships = new List<LocationDirectionRelationship>();
			Directions = LocationDataReader.GetAllDirections();
		}

		public LocationDto GetLocationByDirection(LocationDto startingLocation, DirectionDto direction)
		{
			return GetLocationFromRelationships(startingLocation, direction);
		}

		private LocationDto GetLocationFromRelationships(LocationDto sourceLocation, DirectionDto direction)
		{
			var relationship = LocationDirectionRelationships.FirstOrDefault(ldr => ldr.Source.Identity == sourceLocation.Identity && ldr.Direction.Identity == direction.Identity);

			if (relationship != null)
				return relationship.Target;

			var location = LocationDataReader.GetLocationByDirection(sourceLocation, direction);
			if (location == null)
				return null;

			AddLocationDirectionRelationship(sourceLocation, direction, location);

			return location;
		}


		private void AddLocationDirectionRelationship(LocationDto sourceLocation, DirectionDto direction, LocationDto location)
		{
			LocationDirectionRelationships.Add(new LocationDirectionRelationship(sourceLocation, direction, location));
		}

	}
}
