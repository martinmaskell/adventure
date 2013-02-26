namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface ICommand
	{
		int CommandID { get; }
		AdventureCommandType CommandType { get; }
		CommandParameterType[] Parameters { get; }
	}
}
