using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class CreateParameterElementArrayTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "Input is null\r\nParameter name: input")]
		public void CreateParameterElementArray_NullInput_ThrowArgumentNullException()
		{
			CommandParameterParser.CreateParameterElementArray(null);
		}

		[Test]
		public void CreateParameterElementArray_ParametersWithNoMarkup_ReturnListWithSameNumberOfWordsAsInput()
		{
			// Act
			var response = CommandParameterParser.CreateParameterElementArray("gold key brass key");

			// Assert
			Assert.AreEqual(4, response.Count);
		}

		[Test]
		public void CreateParameterElementArray_OneParameterWithMarkup_ReturnListWithSameNumberOfWordsAsInput()
		{
			// Act
			var response = CommandParameterParser.CreateParameterElementArray("gold key {brass key}");

			// Assert
			Assert.AreEqual(3, response.Count);
		}

		[Test]
		public void CreateParameterElementArray_AllParameterWithMarkup_ReturnListWithSameNumberOfWordsAsInput()
		{
			// Act
			var response = CommandParameterParser.CreateParameterElementArray("{gold key} {brass key}");

			// Assert
			Assert.AreEqual(2, response.Count);
		}


	}
}
