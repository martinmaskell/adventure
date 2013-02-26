using System;
using Maskell.Adventure.DomainEntities;
using NUnit.Framework;

namespace Maskell.Adventure.DataAccess.CommandData.Tests
{
	[TestFixture]
	public class CommandDataServiceReadTests
	{

		[Test]
		public void GetCommandAction_GoNorth_ReturnNotNull()
		{
			var serviceRead = new CommandDataServiceRead();

			var actual = serviceRead.GetCommandAction(AdventureCommandType.Go,
			                                          new[] {new Guid("027377FE-46E8-E011-B36B-005056C00008")}, null);

			Assert.IsNotNull(actual);
		}


	}
}
