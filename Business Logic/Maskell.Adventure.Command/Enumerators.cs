namespace Maskell.Adventure.Command
{
	public enum CommandParameterParserResponseState
	{
		Success,
		Fail,
		FailDuplicate
	}

	public enum DependencyProcessorResponseState
	{
		NothingToProcess,
		Success,
		Fail
	}

	public enum DependencyProcessorTypeResponseState
	{
		Success,
		Fail
	}

	public enum CommandActionProcessorResponse
	{
		NothingToProcess,
		Success,
		Fail
	}


}