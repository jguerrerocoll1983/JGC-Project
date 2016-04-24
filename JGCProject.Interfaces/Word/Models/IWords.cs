using System;
using System.Collections.Generic;

namespace JGCProject.Interfaces.Word.Models
{
    public interface IWords : IValidWord
    {
        List<IWord> GetList();

        void AddWord(string value);

        void AddWords(List<string> values);

        void AddWords(IWords words);
    }
}
