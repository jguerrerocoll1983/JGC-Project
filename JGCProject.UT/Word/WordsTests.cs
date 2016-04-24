using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JGCProject.DAL.Word;
using JGCProject.BLL.Word;
using JGCProject.Models;
using System.Collections.Generic;

namespace JGCProject.UT
{
    [TestClass]
    public class WordsTests
    {
        // Some test example for Word Combinator
        [TestMethod]
        public void WordCombinator_TestCase1()
        {
            List<string> testCase = new List<string>() { "abael", "ml", "123456" };

            Words words = new Words();
            words.AddWords(testCase);

            WordsCombinator wordCombinator = new WordsCombinator(words, 6);
            var results = wordCombinator.GetAllCombinatedWordsAsList();

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void WordCombinator_TestCase2()
        {
            List<string> testCase = new List<string>() { "abae", "ml", "123456" };

            Words words = new Words();
            words.AddWords(testCase);

            WordsCombinator wordCombinator = new WordsCombinator(words, 6);
            var results = wordCombinator.GetAllCombinatedWordsAsList();

            Assert.IsTrue(
                results.Contains("abaeml") && 
                results.Contains("mlabae"));
        }

        [TestMethod]
        public void WordCombinator_TestCase3()
        {
            List<string> testCase = new List<string>() { "alba", "abael", "ja", "m", "123456" };

            Words words = new Words();
            words.AddWords(testCase);

            WordsCombinator wordCombinator = new WordsCombinator(words, 6);
            var results = wordCombinator.GetAllCombinatedWordsAsList();


            Assert.IsTrue(
                results.Contains("albaja") &&
                results.Contains("jaalba") &&
                results.Contains("mabael") &&
                results.Contains("abaelm"));
        }

        // Test Exceptions
        [TestMethod]
        [ExpectedException(typeof(FormatException))]        
        public void Word_StringEmpty_ShouldThrowFormatException()
        {
            Word word1 = new Word("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Word_WhiteSpaces_ShouldThrowFormatException()
        {
            Word word1 = new Word("White space");
        }

        // File Access Test
        [TestMethod]
        public void DataAccessTest()
        {
            WordsFileAccess wordFileAccess = new WordsFileAccess();
            var data = wordFileAccess.GetData();

            Assert.IsTrue(data.Count > 0);
        }
    }
}
