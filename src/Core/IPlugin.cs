using System;

namespace PluginArchitecture.Core
{
    public interface IPlugin
    {
        string Name { get; }
		string Description { get; }
        string Category { get; }
		void Run(string parameter);
    }
}
