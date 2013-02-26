using System;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Managers;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandResponseManagerTests
	{
		[Test]
		[ExpectedException(typeof(NullReferenceException))]
		public void GetCommandResponseMessage_NullHelper_ThrowNullReferenceException()
		{
			// Arrange
			var commandResponseManager = new CommandResponseManager((IGameDataManager)null);

			// Act
			commandResponseManager.GetCommandResponseMessage(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetCommandResponseMessage_NullCommandResponseParameter_ThrowArgumentNullException()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);

			// Act
			commandResponseManager.GetCommandResponseMessage(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetCommandResponseMessage_FailedResponseUnknownCommandResponseReasonNone_ThrowArgumentOutOfRangeException()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);

			// Act
			commandResponseManager.GetCommandResponseMessage(new CommandResponse
			                                                 	{
			                                                 		AdventureCommandType = AdventureCommandType.Unknown,
			                                                 		ResponseReason = CommandResponseReason.None,
			                                                 		State = CommandResponseState.Fail
			                                                 	});

		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetCommandResponseMessage_FailedResponseUnknownCommandResponseReasonInvalidParameters_ThrowArgumentOutOfRangeException()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);

			// Act
			commandResponseManager.GetCommandResponseMessage(new CommandResponse
			{
				AdventureCommandType = AdventureCommandType.Unknown,
				ResponseReason = CommandResponseReason.InvalidParameters,
				State = CommandResponseState.Fail
			});

		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetCommandResponseMessage_SuccessResponseResponseReasonInvalidCommand_ThrowArgumentOutOfRangeException()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);

			// Act
			commandResponseManager.GetCommandResponseMessage(new CommandResponse
			{
				AdventureCommandType = AdventureCommandType.Open,
				ResponseReason = CommandResponseReason.InvalidParameters,
				State = CommandResponseState.Success
			});

		}

		[Test]
		public void GetCommandResponseMessage_InvalidCommand_ReturnCorrectResponse()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);
			const string expected = "Dummy Text";

			using (mocks.Record())
			{
				SetupResult.For(commandResponseHelper.GetFailedResponseInvalidCommand(null)).Return(expected);
			}

			using (mocks.Playback())
			{
				// Act
				var actual = commandResponseManager.GetCommandResponseMessage(new CommandResponse { AdventureCommandType = AdventureCommandType.Unknown, ResponseReason = CommandResponseReason.InvalidCommand, State = CommandResponseState.Fail });

				// Assert
				Assert.IsNotNullOrEmpty(actual);
			}
		}

		[Test]
		public void GetCommandResponseMessage_InvalidParameters_ReturnCorrectResponse()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);
			const string expected = "Dummy Text";

			using (mocks.Record())
			{
				SetupResult.For(commandResponseHelper.GetFailedResponseInvalidParameters(AdventureCommandType.Pickup, null)).IgnoreArguments().Return(expected);
			}

			using (mocks.Playback())
			{
				// Act
				var actual = commandResponseManager.GetCommandResponseMessage(new CommandResponse { AdventureCommandType = AdventureCommandType.Pickup, ResponseReason = CommandResponseReason.InvalidParameters, State = CommandResponseState.Fail });

				// Assert
				Assert.IsNotNullOrEmpty(actual);
			}
		}

		[Test]
		public void GetCommandResponseMessage_DuplicateParameters_ReturnCorrectResponse()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandResponseHelper = mocks.Stub<ICommandResponseHelper>();
			var commandResponseManager = new CommandResponseManager(commandResponseHelper);
			const string expected = "Dummy Text";

			using (mocks.Record())
			{
				SetupResult.For(commandResponseHelper.GetFailedDuplicateResponseDuplicateParameters(AdventureCommandType.Pickup, null)).IgnoreArguments().Return(expected);
			}

			using (mocks.Playback())
			{
				// Act
				var actual = commandResponseManager.GetCommandResponseMessage(new CommandResponse { AdventureCommandType = AdventureCommandType.Pickup, ResponseReason = CommandResponseReason.DuplicateParameters, State = CommandResponseState.Fail });

				// Assert
				Assert.IsNotNullOrEmpty(actual);
			}
		}

	}
}


