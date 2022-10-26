using System;
using System.Linq;
using PluginArchitecture.Core;

namespace PluginArchitecture.Demo
{
    class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Started plugin app..");
            LoadPlugins();
            ExecuteCommand();
        }

        private static void LoadPlugins()
        {
            try
            {
                var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appLocation = System.IO.Path.GetDirectoryName(path);
                var pluginsPath = System.IO.Path.Combine(appLocation, "Plugins");
                PluginLoader loader = new PluginLoader();
                loader.LoadPlugins(pluginsPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", e.Message));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void ExecuteCommand()
        {
            while (true)
            {
                try
                {
                    //Let the user fill in an plugin name
                    Console.Write(">> ");
                    string line = Console.ReadLine();
                    string[] values = line.Split(new char[] { ' ' });
                    string name = values.FirstOrDefault();

                    IPlugin plugin = PluginLoader.Plugins.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault();
                    if (plugin != null)
                    {
                        //If the plugin is found, execute it
                        string parameters = values.Length >1 ? values.LastOrDefault() : string.Empty;
                        plugin.Run(parameters);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(string.Format("No plugin found with name '{0}'", name));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine (string.Format ("Caught exception: {0}", e.Message));
                }
            }
        }
    }
}
