using System;

namespace Maskell.Adventure.Module
{
	public class ModuleResponseEventArgs : EventArgs
	{
		public ModuleResponse ModuleResponse { get; private set; }

		public ModuleResponseEventArgs(ModuleResponse moduleResponse)
		{
			ModuleResponse = moduleResponse;
		}
	}
	
}
