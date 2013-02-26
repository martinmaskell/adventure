namespace Maskell.Adventure.DomainEntities
{
	public enum AdventureCommandType
	{
		Unknown = 0,
		Close = 1,
		Drink = 2,
		Drop = 3,
		Eat = 4,
		Examine = 5,
		Give = 6,
		Go = 7,
		Lock = 8,
		Look = 9,
		Open = 10,
		Pickup = 11,
		Put = 12,
		Take = 13,
		Talk = 14,
		Unlock = 15,
		Use = 16
	}

	public enum CommandResponseState
	{
		Success,
		Fail
	}

	public enum CommandResponseReason
	{
		None = 0,
		InvalidCommand = 1,
		InvalidParameters = 2,
		DuplicateParameters = 3
	}

	public enum CommandParameterType
	{
		Item = 1,
		Location = 2,
		Direction = 3,
		NonPlayerCharacter = 4
	}

	public enum CommandAction
	{
		ChangeCurrentLocationByDirection = 1,
		ChangeCurrentLocationByLocation = 2,
		AddItemToInventory = 3,
		RemoveItemFromInventory = 4,
		ChangeItemProperty = 5,
		AddLocationRelationshipToLocation = 6,
		RemoveLocationRelationshipFromLocation = 7
	}

	public enum DependencyType
	{
		LocationIsAvailable = 1,
		LocationIsNotAvailable = 2,
		ItemIsInInventory = 3,
		ItemIsNotinInventory = 4,
		ItemIsAtLocation = 5,
		ItemIsNotAtLocation = 6,
		ItemPropertyValueIsEqualTo = 7,
		ItemPropertyValueIsNotEqualTo = 8,
		ItemPropertyValueIsTrue = 9,
		ItemPropertyValueIsFalse = 10,
		ItemPropertyValueIsGreaterThan = 11,
		ItemPropertyValueIsLessThan = 12,
		DirectionIsAvailable = 13,
		DirectionIsNotAvailable = 14
	}
}
