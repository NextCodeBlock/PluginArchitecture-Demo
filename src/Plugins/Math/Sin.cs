using System;
using PluginArchitecture.Core;

namespace PluginArchitecture.Plugins.StringPlugins
{
    public class Sin : IPlugin
	{
		public string Name => "Sin";

		public string Description => "Calculate the sine of given angle.";

		public string Category => "Mathematical";
		
		public void Run(string parameter)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				Console.WriteLine("The parameter must have a value.");
				return;
			}

			var value = double.Parse(parameter);
			Console.WriteLine(Math.Sin(value));
		}
	}
}
