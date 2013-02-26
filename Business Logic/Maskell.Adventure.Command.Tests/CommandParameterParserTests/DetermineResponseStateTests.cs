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
	public class DetermineResponseStateTests
	{
		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "ValidParameters is null")]
		public void DetermineResponseState_NullValidParameters_ThrowNullReferenceException()
		{
			// Arrange
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			var invalidParameters = new List<string>();

			// Act
			CommandParameterParser.BuildResponse(null, duplicateParameters, invalidParameters);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "DuplicateParameters is null")]
		public void DetermineResponseState_NullDuplicateParameters_ThrowNullReferenceException()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var invalidParameters = new List<string>();

			// Act
			CommandParameterParser.BuildResponse(validParameters, null, invalidParameters);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "InvalidParameters is null")]
		public void DetermineResponseState_InvalidParameters_ThrowNullReferenceException()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();

			// Act
			CommandParameterParser.BuildResponse(validParameters, duplicateParameters, null);
		}

		[Test]
		public void DetermineResponseState_EmptyParameters_ReturnSuccessResponseState()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			var invalidParameters = new List<string>();

			// Act
			var response = CommandParameterParser.BuildResponse(validParameters, duplicateParameters, invalidParameters);

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.Success, response.State);
		}

		[Test]
		public void DetermineResponseState_ValidParameters_ReturnSuccessResponseState()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			var invalidParameters = new List<string>();
			validParameters.Add(new ItemDto());

			// Act
			var response = CommandParameterParser.BuildResponse(validParameters, duplicateParameters, invalidParameters);

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.Success, response.State);
		}

		[Test]
		public void DetermineResponseState_DuplicateParameters_ReturnFailDuplicateResponseState()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			var invalidParameters = new List<string>();
			duplicateParameters.Add("key", new List<IAdventureElement> { new ItemDto() });

			// Act
			var response = CommandParameterParser.BuildResponse(validParameters, duplicateParameters, invalidParameters);

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.FailDuplicate, response.State);
		}

		[Test]
		public void DetermineResponseState_InvalidParameters_ReturnFailDuplicateResponseState()
		{
			// Arrange
			var validParameters = new List<IAdventureElement>();
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();
			var invalidParameters = new List<string>();
			invalidParameters.Add("key");

			// Act
			var response = CommandParameterParser.BuildResponse(validParameters, duplicateParameters, invalidParameters);

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.Fail, response.State);
		}

	}
}
