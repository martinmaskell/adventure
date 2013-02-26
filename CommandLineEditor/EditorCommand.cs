namespace CommandLineEditor
{
	public class EditorCommand
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsExitCommand { get; set; }
		public string[] Alternatives { get; set; }
	}
}
