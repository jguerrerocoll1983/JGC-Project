using System;
using System.Collections.Generic;
using System.Linq;
using JGCProject.Interfaces.Word.Models;

namespace JGCProject.Models
{
    /// <summary>
    /// I have ended using a HashSet, because looking for repeated values on a List would be to expensive in performance.
    /// </summary>
    public class Words : ValidWord, IWords
    {
        private HashSet<string> _hashSet;

        public Words()
        {
            _hashSet = new HashSet<string>();
        }

        /// <summary>
        /// The hash table is converted into a List of Word if it´s necesary.
        /// </summary>
        /// <returns></returns>
        public List<IWord> GetList()
        {
            List<IWord> result = _hashSet.Select(w => new Word(w)).ToList<IWord>();
            return result;
        }

        public void AddWord(string value)
        {
            if(IsValidWord(value))
            {
                _hashSet.Add(value);
            }
        }

        public void AddWords(List<string> values)
        {
            foreach (string value in values)
            {
                AddWord(value);
            }
        }

        public void AddWords(IWords words)
        {
            foreach (Word word in words.GetList())
            {
                if (IsValidWord(word.Value))
                {
                    _hashSet.Add(word.Value);
                }
            }
        }
    }
}
