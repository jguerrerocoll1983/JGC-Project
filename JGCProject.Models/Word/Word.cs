using System;
using JGCProject.Interfaces.Word.Models;

namespace JGCProject.Models
{
    public class Word : ValidWord, IWord
    {
        private string _value;

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public Word(string value)
        {
            if (IsValidWord(value))
            {
                _value = value;
            }
            else
            {
                throw new FormatException("The format is not valid for a word");
            }
        }
    }
}
