using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginArchitecture.Core
{
    public class Help : IPlugin
	{
		public string Name => "Help";

		public string Description => "This plugin shows all loaded plugins and their explanations";

		public string Category => "System";

		public void Run (string parameter)
		{
			IEnumerable<IPlugin> plugins = PluginLoader.Plugins;

			if (!string.IsNullOrWhiteSpace(parameter))
				plugins = PluginLoader.Plugins.Where(x => x.Name.ToLower().Equals(parameter.ToLower()));

			foreach(IPlugin plugin in plugins)
				Console.WriteLine("Name: {0} | Category: {1} | Description: {2}", plugin.Name, plugin.Category, plugin.Description);
		}
	}
}
