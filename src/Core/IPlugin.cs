using System;

namespace Core
{
    public interface IPlugin
    {
        string Name { get; }
		string Explanation { get; }
		void Go(string parameters);
    }
}
