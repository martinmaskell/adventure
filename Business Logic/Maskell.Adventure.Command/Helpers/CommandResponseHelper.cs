using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Helpers
{
	public class CommandResponseHelper : ICommandResponseHelper
	{
		private IGameDataManager GameDataManager { get; set; }
		public CommandResponseHelper(IGameDataManager gameDataManager)
		{
			GameDataManager = gameDataManager;
		}

		public string GetFailedResponseInvalidCommand(CommandResponse commandResponse)
		{
			//var isDirection = commandResponse.ValidCommandParameters[0] is IDirection;
			//var isItem = commandResponse.ValidCommandParameters[0] is IItem;
			const string genericUnknownResponse = "Sorry, I understand what you mean.";
			const string genericNegativeResponse = "You can't do that.";

			if (commandResponse.ValidCommandParameters.Count == 0)
				return genericUnknownResponse;

			switch (commandResponse.AdventureCommandType)
			{
				case AdventureCommandType.Go:
					return string.Format("You can't go that way.  Available exits are {0}", string.Join(", ",
					                     GameDataManager.CurrentLocation.Directions.Select(d => d.Name).ToArray()));
				case AdventureCommandType.Drink:
				case AdventureCommandType.Drop:
				case AdventureCommandType.Eat:
				case AdventureCommandType.Examine:
				case AdventureCommandType.Give:
				case AdventureCommandType.Lock:
				case AdventureCommandType.Look:
				case AdventureCommandType.Take:
				case AdventureCommandType.Unlock:
				case AdventureCommandType.Open:
				case AdventureCommandType.Pickup:
				case AdventureCommandType.Use:
					return genericNegativeResponse;
				default:
					return genericUnknownResponse;
			}
		}

		public string GetFailedResponseInvalidParameters(AdventureCommandType adventureCommandType, List<string> parameters)
		{
			// TODO: Calculate this string based on the parameters and return from a resource.
			return "Sorry, I do not know what " + string.Join(", ", parameters.Select(p => "'" + p + "'").ToArray()) + " means.";
		}

		public string GetFailedDuplicateResponseDuplicateParameters(AdventureCommandType adventureCommandType, Dictionary<string, List<IAdventureElement>> duplicateParameters)
		{
			// TODO: Implement Method
			throw new NotImplementedException();
		}

		public string GetSuccessResponse(AdventureCommandType adventureCommandType, List<IAdventureElement> parameters)
		{
			switch (adventureCommandType)
			{
				case AdventureCommandType.Close:
					return string.Format("You close the {0}", parameters[0].CommonName);
				case AdventureCommandType.Drink:
					return string.Format("You drink the {0}", parameters[0].CommonName);
				case AdventureCommandType.Drop:
					return string.Format("You drop the {0}", parameters[0].CommonName);
				case AdventureCommandType.Eat:
					return string.Format("You eat the {0}", parameters[0].CommonName);
				case AdventureCommandType.Examine:
					return string.Format("You examine the {0}", parameters[0].CommonName);
				case AdventureCommandType.Give:
					return string.Format("You give the {0} to {1}", parameters[0].CommonName, parameters[1].CommonName);
				case AdventureCommandType.Go:
					return string.Empty;
				case AdventureCommandType.Lock:
					return string.Format("You lock the {0}", parameters[0].CommonName);
				case AdventureCommandType.Look:
					return string.Format("You look {0}", parameters[0].CommonName);
				case AdventureCommandType.Open:
					return string.Format("You open the {0}", parameters[0].CommonName);
				case AdventureCommandType.Pickup:
					return string.Format("You pick up {0}", parameters[0].CommonName);
				case AdventureCommandType.Take:
					return string.Format("You take the {0}", parameters[0].CommonName);
				case AdventureCommandType.Unlock:
					return string.Format("You unlock the {0}", parameters[0].CommonName);
				case AdventureCommandType.Use:
					return string.Format("You use the {0} with the {1}", parameters[0].CommonName, parameters[1].CommonName);
				default:
					// TODO: Implement method
					throw new NotImplementedException();
			}
			
			
		}
	}
}
