using System;

namespace JGCProject.Models
{
    public class ValidWord
    {
        public bool IsValidWord(string value)
        {
            return
                value.Length > 0 &&
                !value.Contains(" ");
        }
    }
}
