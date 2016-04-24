using System;
using System.Collections.Generic;
using System.Linq;
using JGCProject.Interfaces.Word.BLL;
using JGCProject.Interfaces.Word.Models;
using JGCProject.Models;

namespace JGCProject.BLL.Word
{
    public class WordsCombinator : IWordsCombinator
    {
        private IWords _words;
        private int _combinedWordSize;

        public WordsCombinator(IWords words, int combinedWordSize)
        {
            _words = words;
            _combinedWordSize = combinedWordSize;
        }

        public IWords GetAllCombinatedWords()
        {
            IWords result = new Words();

            List<string> processedValues = new List<string>();

            foreach (IWord word in _words.GetList())
            {
                int currentWordLength = word.Value.Length;

                // Words with an equal or a bigger lenght than "combinedSize" doesn´t need to be processed
                if (currentWordLength < _combinedWordSize)
                {
                    // Get all the processed words, which lenght summed to the lenght of the current word are equal to "combinedSize"
                    var availableValues = processedValues.Where(w => w.Length + currentWordLength == _combinedWordSize).ToList();

                    // Generate all the possible combinations between the available words and the currentword, in both sides
                    var newValues = availableValues.Select(w => w + word.Value).Union(availableValues.Select(w => word.Value + w));

                    foreach (var newValue in newValues)
                    {
                        // Repeated values are already avoided on this method
                        result.AddWord(newValue);
                    }

                    processedValues.Add(word.Value);
                }
            }

            return result;
        }

        public List<string> GetAllCombinatedWordsAsList()
        {
            return GetAllCombinatedWords().GetList().Select(w => w.Value).ToList();
        }

    }
}
