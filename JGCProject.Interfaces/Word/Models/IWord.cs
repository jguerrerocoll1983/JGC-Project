using System;

namespace JGCProject.Interfaces.Word.Models
{
    public interface IWord : IValidWord
    {
        string Value { get; }
    }
}
