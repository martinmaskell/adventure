using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class AddParameterMarkupTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Input is null or empty")]
		public void AddParameterMarkup_NullInput_ThrowArgumentException()
		{
			CommandParameterParser.AddParameterMarkup(null);
		}

		[Test]
		public void AddParameterMarkup_ValidInput_ReturnMarkedUpString()
		{
			// Act
			var response = CommandParameterParser.AddParameterMarkup("gold key");

			// Assert
			Assert.AreEqual("{gold key}", response);
		}


	}
}
