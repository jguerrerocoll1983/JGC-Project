using System;
using System.Collections.Generic;
using System.Configuration;
using JGCProject.UIP;

namespace JGCProject.UI
{
    class Program
    {     
        static void Main(string[] args)
        {
            try
            {
                AppSettingsReader appSettings = new AppSettingsReader();
                int numberOfElementsPerPage = (int)appSettings.GetValue("NumberOfElementsPerPage", typeof(int));

                WordUIP wordUIP = new WordUIP();
                List<string> results = wordUIP.GetWordCombinations();

                int currentElement = 1;
                foreach (string result in results)
                {
                    if (currentElement % numberOfElementsPerPage == 1)
                    {
                        Console.WriteLine(String.Format("Result from {0} to {1} of {2}", currentElement, currentElement + (numberOfElementsPerPage - 1), results.Count));
                    }

                    Console.WriteLine(result);

                    if (currentElement % numberOfElementsPerPage == 0)
                    {
                        Console.WriteLine("-- Please press a key to continue -- ");
                        Console.ReadKey();
                    }

                    currentElement++;
                }
            }
            catch(Exception e)
            {
                Console.Write("Unexpected Exception: " + e.Message);
                Console.WriteLine("-- Please press a key to continue -- ");
                Console.ReadKey();
            }
        }
    }
}
