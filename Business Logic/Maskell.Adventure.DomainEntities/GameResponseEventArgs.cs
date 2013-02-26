using System;

namespace Maskell.Adventure.DomainEntities
{
	public class GameResponseEventArgs : EventArgs
	{
		public string LocationDescription { get; private set; }
		public string Response { get; private set; }

		public GameResponseEventArgs(string locationDescription, string response)
		{
			LocationDescription = locationDescription;
			Response = response;
		}

	}
}
