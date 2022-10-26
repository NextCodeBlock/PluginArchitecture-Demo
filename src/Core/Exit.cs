using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginArchitecture.Core
{
    public class Exit : IPlugin
	{
		public string Name => "Exit";

		public string Description => "Exit the application gracefully.";

		public string Category => "System";

		public void Run (string parameter)
		{
			Environment.Exit(0);
		}
	}
}
