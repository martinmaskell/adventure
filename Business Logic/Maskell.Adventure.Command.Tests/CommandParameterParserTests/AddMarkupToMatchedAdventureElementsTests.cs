using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class AddMarkupToMatchedAdventureElementsTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddMarkupToMatchedAdventureElements_NullInput_ThrowArgumentException()
		{
			// Act
			CommandParameterParser.AddMarkupToMatchedAdventureElements(null, null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "AdventureElements is null\r\nParameter name: adventureElements")]
		public void AddMarkupToMatchedAdventureElements_NullAdventureElements_ThrowArgumentNullException()
		{
			// Act
			CommandParameterParser.AddMarkupToMatchedAdventureElements("gold key", null);
		}

		[Test]
		public void AddMarkupToMatchedAdventureElements_InvalidInput_ReturnUnmodifiedInput()
		{
			// Arrange
			const string input = "gold key";

			// Act
			var response = CommandParameterParser.AddMarkupToMatchedAdventureElements(input, new List<IAdventureElement>());

			// Assert
			Assert.AreEqual(input, response);
		}

		[Test]
		public void AddMarkupToMatchedAdventureElements_ValidInput_ReturnMarkedUpString()
		{
			// Act
			var response = CommandParameterParser.AddMarkupToMatchedAdventureElements("gold key",
			                                                                          new List<IAdventureElement>
			                                                                          	{
			                                                                          		new ItemDto
			                                                                          			{
			                                                                          				CommonName = "gold key",
			                                                                          				Name = "A Gold Key",
			                                                                          				Description = "A small gold key",
			                                                                          				Identity = Guid.NewGuid()
			                                                                          			}
			                                                                          	});

			// Assert
			Assert.AreEqual("{gold key}", response);
		}

		[Test]
		public void AddMarkupToMatchedAdventureElements_ValidInputDuplicateCommonNameAdventureElements_ReturnMarkedUpString()
		{
			// Act
			var response = CommandParameterParser.AddMarkupToMatchedAdventureElements("key", new List<IAdventureElement>() { new ItemDto { CommonName = "key", Description = "A small gold key", Identity = Guid.NewGuid(), Name = "Gold Key" }, new ItemDto { CommonName = "key", Description = "A small brass key", Identity = Guid.NewGuid(), Name = "Brass Key" } });

			// Assert
			Assert.AreEqual("{key}", response);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MarkupInputByElementValue_NullInput_ThrowArgumentNullException()
		{
			CommandParameterParser.MarkupInputByElementValue(null, null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MarkupInputByElementValue_NullElementValue_ThrowArgumentNullException()
		{
			CommandParameterParser.MarkupInputByElementValue(string.Empty, null);
		}

		[Test]
		public void MarkupInputByElementValue_ValidInput_ValidMarkup()
		{
			const string input = "brass key";
			const string elementValue = "Brass Key";
			const string expected = "{Brass Key}";

			var actual = CommandParameterParser.MarkupInputByElementValue(input, elementValue);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void MarkupInputByElementValues_ValidInput_ValidMarkup()
		{
			var element = new ItemDto {CommonName = "brass key", Name = "Brass Key"};
			const string input = "brass key";
			const string expected = "{brass key}";

			var actual = CommandParameterParser.MarkupInputByElementValues(input, element);

			Assert.AreEqual(expected, actual);
		}



	}
}
