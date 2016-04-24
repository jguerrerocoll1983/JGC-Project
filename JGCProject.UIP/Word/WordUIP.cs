using System;
using System.Collections.Generic;
using JGCProject.Interfaces.Word.Models;
using JGCProject.DAL.Word;
using JGCProject.BLL.Word;
using JGCProject.Models;

namespace JGCProject.UIP
{
    public class WordUIP
    {
        public List<string> GetWordCombinations()
        {
            IWords words = GetWords();

            WordsCombinator wordCombinator = new WordsCombinator(words, 6);

            return wordCombinator.GetAllCombinatedWordsAsList();
        }

        public IWords GetWords()
        {
            WordsFileAccess fileAccess = new WordsFileAccess();
            List<string> rawWords = fileAccess.GetData();

            IWords words = new Words();
            words.AddWords(rawWords);

            return words;
        }
    }
}
