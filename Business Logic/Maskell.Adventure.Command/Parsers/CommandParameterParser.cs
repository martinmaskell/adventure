using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Parsers
{
	public class CommandParameterParser : ICommandParser<CommandParameterParserResponse>
	{
		private const char _parameterPrefix = '{';
		private const char _parameterSuffix = '}';

		public List<IAdventureElement> AdventureElements { get; set; }

		internal CommandParameterParser()
		{
		}

		public CommandParameterParser(List<IAdventureElement> adventureElements)
		{
			AdventureElements = adventureElements;
		}

		public CommandParameterParserResponse Parse(string input)
		{
			if (input == null)
				throw new ArgumentNullException("input", "Input is null");

			if (AdventureElements == null)
				throw new NullReferenceException("AdventureElements is null");

			var matchedAdventureElementsByIdentity = AddMarkupToMatchedAdventureElements(input, AdventureElements);

			List<IAdventureElement> validParameters;
			Dictionary<string, List<IAdventureElement>> duplicateParameters;
			List<string> invalidParameters;

			ParseMatchedAdventureElements(matchedAdventureElementsByIdentity, out validParameters, out duplicateParameters,
			                              out invalidParameters);

			return BuildResponse(validParameters, duplicateParameters, invalidParameters);
		}

		internal static List<string> CreateParameterElementArray(string input)
		{
			if (input == null)
				throw new ArgumentNullException("input", "Input is null");
			
			var matches = Regex.Matches(input, @"\{.+?\}|\b[a-z]+\b", RegexOptions.IgnoreCase);

			return (from Match m in matches
			              select m.Value).ToList();
		}

		internal void ParseMatchedAdventureElements(string input, out List<IAdventureElement> validParameters, out Dictionary<string, List<IAdventureElement>> duplicateParameters, out List<string> invalidParameters)
		{
			validParameters = new List<IAdventureElement>();
			duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			invalidParameters = new List<string>();

			var elementArray = CreateParameterElementArray(input);
			foreach (var parameter in elementArray)
			{
				AssignParameterToParameterList(parameter, invalidParameters, validParameters, duplicateParameters);
			}
		}

		internal void AssignParameterToParameterList(string parameter, List<string> invalidParameters, List<IAdventureElement> validParameters, Dictionary<string, List<IAdventureElement>> duplicateParameters)
		{
			if (string.IsNullOrEmpty(parameter))
				throw new ArgumentException("Parameter is null or empty");

			if (invalidParameters == null)
				throw new NullReferenceException("InvalidParameters is null");

			if (validParameters == null)
				throw new NullReferenceException("ValidParameters is null");

			if (duplicateParameters == null)
				throw new NullReferenceException("DuplicateParameters is null");

			if (!IsValidParameterMarkup(parameter))
			{
				invalidParameters.Add(parameter);
				return;
			}

			var matches = FindAdventureElementsByParameter(parameter);
			if (matches.Count == 1)
			{
				validParameters.Add(matches[0]);
				return;
			}

			duplicateParameters.Add(RemoveParameterMarkup(parameter), matches);
		}

		internal static bool IsValidParameterMarkup(string input)
		{
			if (string.IsNullOrEmpty(input))
				return false;

			var inputString = input.Trim();
			return inputString.Length > 2 && inputString.StartsWith(_parameterPrefix.ToString()) && inputString.EndsWith(_parameterSuffix.ToString());
		}

		internal List<IAdventureElement> FindAdventureElementsByParameter(string parameter)
		{
			if (AdventureElements == null)
				throw new NullReferenceException("AdventureElements is null");

			if (string.IsNullOrEmpty(parameter))
				throw new ArgumentException("Parameter is null or empty");

			var matchedElementList = AdventureElements.Where(e => AddParameterMarkup(e.CommonName) == parameter).ToList();
			matchedElementList.AddRange(AdventureElements.Where(e => AddParameterMarkup(e.Name) == parameter).ToList());

			if (matchedElementList.Count == 0)
				throw new Exception("MatchedElementList is empty");

			return matchedElementList;
		}

		internal static CommandParameterParserResponse BuildResponse(List<IAdventureElement> validParameters, Dictionary<string, List<IAdventureElement>> duplicateParameters, List<string> invalidParameters)
		{
			if (invalidParameters == null)
				throw new NullReferenceException("InvalidParameters is null");

			if (duplicateParameters == null)
				throw new NullReferenceException("DuplicateParameters is null");

			if (validParameters == null)
				throw new NullReferenceException("ValidParameters is null");

			var responseState = CommandParameterParserResponseState.Success;

			if (invalidParameters.Count > 0)
				responseState = CommandParameterParserResponseState.Fail;

			if (duplicateParameters.Count > 0)
				responseState = CommandParameterParserResponseState.FailDuplicate;

			return new CommandParameterParserResponse
				{
					DuplicateParameters = duplicateParameters,
					InvalidParameters = invalidParameters,
					ValidParameters = validParameters,
					State = responseState
				};
		}

		internal static string AddMarkupToMatchedAdventureElements(string input, List<IAdventureElement> adventureElements)
		{
			if (input == null)
				throw new ArgumentNullException("input", "Input is null");

			if (adventureElements == null)
				throw new ArgumentNullException("adventureElements", "AdventureElements is null");

			return adventureElements.Aggregate(input, MarkupInputByElementValues);
		}

		internal static string MarkupInputByElementValues(string input, IAdventureElement adventureElement)
		{
			input = MarkupInputByElementCommonName(input, adventureElement);
			input = MarkupInputByElementName(input, adventureElement);

			return input;
		}

		internal static string MarkupInputByElementName(string input, IAdventureElement adventureElement)
		{
			return MarkupInputByElementValue(input, adventureElement.Name);
		}

		internal static string MarkupInputByElementCommonName(string input, IAdventureElement adventureElement)
		{
			return MarkupInputByElementValue(input, adventureElement.CommonName);
		}

		internal static string MarkupInputByElementValue(string input, string adventureElementValue)
		{
			if (input == null)
				throw new ArgumentNullException("input", "Input is null");

			if (adventureElementValue == null)
				throw new ArgumentNullException("adventureElementValue", "AdventureElementValue is null");

			var markedUpElementValue = AddParameterMarkup(adventureElementValue);

			//if (!input.Contains(markedUpElementValue))
			if (!Regex.IsMatch(input, markedUpElementValue, RegexOptions.IgnoreCase))
				input = Regex.Replace(input, "\\b" + adventureElementValue + "\\b",
											 AddParameterMarkup(adventureElementValue),
											 RegexOptions.IgnoreCase);
			return input;
		}

		internal static string AddParameterMarkup(string input)
		{
			if (string.IsNullOrEmpty(input))
				throw new ArgumentException("Input is null or empty");

			return string.Format("{0}{1}{2}", _parameterPrefix, input, _parameterSuffix);
		}

		internal static string RemoveParameterMarkup(string input)
		{
			if (string.IsNullOrEmpty(input))
				throw new ArgumentException("Input is null or empty");

			return input.Trim(new[] { _parameterPrefix, _parameterSuffix });
		}

	
	}
}
