using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class IsValidParameterMarkupTests
	{
		[Test]
		public void IsValidParameterMarkup_NullInput_ReturnFalse()
		{
			// Act
			var response = CommandParameterParser.IsValidParameterMarkup(null);

			// Assert
			Assert.IsFalse(response);
		}

		[Test]
		public void IsValidParameterMarkup_InputWithOutMarkup_ReturnFalse()
		{
			// Act
			var response = CommandParameterParser.IsValidParameterMarkup("test");

			// Assert
			Assert.IsFalse(response);
		}

		[Test]
		public void IsValidParameterMarkup_InputWithMarkup_ReturnTrue()
		{
			// Act
			var response = CommandParameterParser.IsValidParameterMarkup("{test}");

			// Assert
			Assert.IsTrue(response);
		}
	}
}
