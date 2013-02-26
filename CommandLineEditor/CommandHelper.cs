using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineEditor
{
	public class CommandHelper
	{
		public List<EditorCommand> EditorCommands { get; set; }

		public CommandHelper()
		{
			LoadCommands();
		}

		private void LoadCommands()
		{
			EditorCommands = new List<EditorCommand>
				{
					new EditorCommand {Name = "lg", Description = "List Games"},
					new EditorCommand {Name = "sg", Description = "Set Game"},
					new EditorCommand {Name = "cg", Description = "Displays the Current Game"},
					new EditorCommand {Name = "lc", Description = "List Commands"},
					new EditorCommand {Name = "help", Description = "Displays the Help", Alternatives = new[]{ "h" }},
					new EditorCommand { Name = "quit", Description = "Quits the Editor", IsExitCommand = true, Alternatives = new [] { "q", "bye" } }
				};
		}

		public bool IsExitCommand(string input)
		{
			return EditorCommands.Any(c => (c.Name == input || c.Alternatives != null && c.Alternatives.Contains(input)) && c.IsExitCommand);
		}

		public void ProcessCommand(string input)
		{
			EditorCommand command;

			if (!ParseCommand(input, out command))
			{
				Console.WriteLine("Invalid Command");
				return;
			}

			switch (command.Name)
			{
				case "help":
					DisplayHelp();
					break;
				case "lg":
					ListGames(input);
					break;
			}

		}

		private bool ParseCommand(string input, out EditorCommand command)
		{
			var text = input.ToLower().Split(' ')[0];
			command = null;
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}

			command = EditorCommands.FirstOrDefault(c => c.Name == text || c.Alternatives != null && c.Alternatives.Contains(text));
			return command != null;
		}

		private void ListGames(string input)
		{
			var parts = input.Split(' ');

			int id = 0;
			if (parts.Length > 1)
			{
				int.TryParse(parts[1], out id);
			}

			using (var dc = new AdventureEntities())
			{
				var games = from g in dc.Games
							orderby g.Title
							select g;

				List<Game> gameList = id > 0 ? new List<Game> {games.Skip(id).First()} : games.ToList();


				var i = 0;

				Console.WriteLine("\tID\t\tTITLE");
				Console.WriteLine("\t0\t\t[internal]");

				foreach (var game in gameList)
				{
					i++;
					Console.WriteLine(string.Format("\t{0}\t\t{1}", i, game.Title));
				}
			}

		}

		private void DisplayHelp()
		{
			Console.WriteLine();

			foreach (var command in EditorCommands)
			{
				Console.WriteLine("\t" + command.Name + "\t\t\t" + command.Description);
			}

			Console.WriteLine();
		}




	}
}
