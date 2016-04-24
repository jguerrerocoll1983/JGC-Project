using System;
using System.Collections.Generic;
using JGCProject.Interfaces.Word.Models;

namespace JGCProject.Interfaces.Word.UIP
{
    public interface IWordUIP
    {
        List<string> GetWordCombinations();
        IWords GetWords();
    }
}
