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
	public class FindAdventureElementsByParameterTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Parameter is null or empty")]
		public void FindAdventureElementsByParameter_NullParameter_ThrowArgumentException()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>();
			var commandParameterParser = new CommandParameterParser(adventureElements);
			
			// Act
			commandParameterParser.FindAdventureElementsByParameter(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "AdventureElements is null")]
		public void FindAdventureElementsByParameter_NullAdventureElements_ThrowNullReference()
		{
			// Arrange
			var commandParameterParser = new CommandParameterParser();

			// Act
			commandParameterParser.FindAdventureElementsByParameter("key");
		}

		[Test]
		[ExpectedException(typeof(Exception), ExpectedMessage = "MatchedElementList is empty")]
		public void FindAdventureElementsByParameter_InvalidParameter_ThrowException()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>();
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			commandParameterParser.FindAdventureElementsByParameter("key");
		}

		[Test]
		public void FindAdventureElementsByParameter_ValidParameter_ReturnAdventureElement()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>
			                        	{
			                        		new ItemDto
			                        			{
			                        				CommonName = "key",
			                        				Description = "A small gold key",
			                        				Name = "Gold Key",
			                        				Identity = Guid.NewGuid()
			                        			}
			                        	};
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var response = commandParameterParser.FindAdventureElementsByParameter("{key}");

			// Assert
			Assert.AreEqual(adventureElements, response);
		}


	}
}
