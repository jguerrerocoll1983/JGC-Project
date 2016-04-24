using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using JGCProject.Interfaces.Word.DAL;

namespace JGCProject.DAL.Word
{
    public class WordsFileAccess : IWordsAccess
    {

        public List<string> GetData()
        {
            List<string> result = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "JGCProject.DAL.Word.wordlist.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
