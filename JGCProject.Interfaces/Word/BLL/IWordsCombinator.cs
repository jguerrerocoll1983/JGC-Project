using System;
using System.Collections.Generic;
using JGCProject.Interfaces.Word.Models;

namespace JGCProject.Interfaces.Word.BLL
{
    public interface IWordsCombinator
    {
        IWords GetAllCombinatedWords();

        List<string> GetAllCombinatedWordsAsList();
    }
}
