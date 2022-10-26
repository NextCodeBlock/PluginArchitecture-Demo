using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginArchitecture.Core
{
    public class PluginLoader
	{
		public static List<IPlugin> Plugins { get; set; }

		public void LoadPlugins(string path)
		{
			Plugins = new List<IPlugin>();

			//Load the DLLs from the Plugins directory
			if (Directory.Exists(path))
			{
				string[] files = Directory.GetFiles(path);
				foreach (string file in files)
				{
					if (file.EndsWith(".dll"))
					{
						Assembly.LoadFile(Path.GetFullPath(file));
					}
				}
			}

			Type interfaceType = typeof(IPlugin);
			//Fetch all types that implement the interface IPlugin and are a class
			Type[] types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
				.ToArray();
			foreach (Type type in types)
			{
				//Create a new instance of all found types
				Plugins.Add((IPlugin)Activator.CreateInstance(type));
			}
		}
	}
}
