using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineEditor
{
	class Program
	{
		private static CommandHelper _commandHelper;
		
		static void Main(string[] args)
		{
			_commandHelper = new CommandHelper();

			Console.WriteLine("Adventure Command Line Editor");
			Console.WriteLine("-----------------------------");
			Console.WriteLine();

			while (true)
			{
				Console.Write("> ");
				
				var input = Console.ReadLine();

				if (_commandHelper.IsExitCommand(input))
					break;

				_commandHelper.ProcessCommand(input);
			}

			Console.WriteLine("Bye!");
		}

		
	}
}
