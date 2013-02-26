using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class RemoveParameterMarkupTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Input is null or empty")]
		public void RemoveParameterMarkup_NullInput_ThrowArgumentException()
		{
			CommandParameterParser.RemoveParameterMarkup(null);

		}

		[Test]
		public void RemoveParameterMarkup_ValidInput_ReturnStringWithMarkUpRemoved()
		{
			var response = CommandParameterParser.RemoveParameterMarkup("{gold key}");

			Assert.AreEqual("gold key", response);
		}

	}
}
