using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.DomainEntities;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandNoiseWordParserTests
	{
		[Test]
		public void Parse_NullInput_ReturnSuccessResponse()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			var parser = new CommandNoiseWordParser(noiseWordHelper);
			// Act
			var response = parser.Parse(null);

			Assert.AreEqual(CommandResponseState.Success, response.State);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "NoiseWords is null")]
		public void Parse_NullNoiseWords_ThrowNullReferenceException()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(null);
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				parser.Parse("the fish");
			}
		}

		[Test]
		public void Parse_EmptyNoiseWords_ReturnValidResponseState()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(new List<string>());
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				var response = parser.Parse("the fish");

				// Assert
				Assert.AreEqual(response.State, CommandResponseState.Fail);
			}
		}

		[Test]
		public void Parse_EmptyNoiseWords_ReturnMatchingOriginalAndParsedText()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(new List<string>());
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				var response = parser.Parse("the fish");

				// Assert
				Assert.AreEqual(response.OriginalCommandText, response.ParsedCommandText);
			}
		}

		[Test]
		public void Parse_ValidNoiseWords_ReturnValidResponseState()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(new List<string>() { "the" });
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				var response = parser.Parse("the fish");

				// Assert
				Assert.AreEqual(response.State, CommandResponseState.Success);
			}
		}

		[Test]
		public void Parse_ValidNoiseWords_ReturnMatchingInputAndOriginalText()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();
			const string input = "the fish with the net.";

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(new List<string>() { "the", "with" });
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				var response = parser.Parse(input);

				// Assert
				Assert.AreEqual(input, response.OriginalCommandText);
			}
		}

		[Test]
		public void Parse_ValidNoiseWords_ReturnValidParsedText()
		{
			// Arrange
			var mocks = new MockRepository();
			var noiseWordHelper = mocks.Stub<ICommandNoiseWordHelper>();

			using (mocks.Record())
			{
				SetupResult.For(noiseWordHelper.GetNoiseWords()).Return(new List<string>() { "the", "with" });
			}

			var parser = new CommandNoiseWordParser(noiseWordHelper);

			using (mocks.Playback())
			{
				// Act
				var response = parser.Parse("the fish with the net.");

				// Assert
				Assert.AreEqual("fish net", response.ParsedCommandText);
			}
		}

	}
}
