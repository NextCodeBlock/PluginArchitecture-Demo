using System;
using PluginArchitecture.Core;

namespace PluginArchitecture.Plugins.StringPlugins
{
    public class Cos : IPlugin
	{
		
		public string Name => "Cos";

		public string Description => "Calculate the cosine of given angle.";

		public string Category => "Mathematical";

		public void Run(string parameter)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				Console.WriteLine("The parameter must have a value.");
				return;
			}

			var value = double.Parse(parameter);
			Console.WriteLine(Math.Cos(value));
		}
	}
}
