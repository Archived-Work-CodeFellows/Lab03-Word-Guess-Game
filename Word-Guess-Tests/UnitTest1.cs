using System;
using Lab_03_Word_Guess;
using Xunit;

namespace Word_Guess_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateFile()
        {
            string path = "../../../testFile.txt";
            string[] wordList = new string[] { "dog", "saxophone", "laptop", "apples", "code", "taco cat" };
            Assert.True(Program.CreateFile(path, wordList));
        }
        [Fact]
        public void ReadFile()
        {
            string path = "../../../testFile.txt";
            string[] wordList = new string[] { "dog", "saxophone", "laptop", "apples", "code", "taco cat" };
            CollectionAttribute.Equals(wordList, Program.ReadFile(path));
           
        }
        [Fact]
        public void UpdateFile()
        {
            string path = "../../../testFile.txt";
            string word = "doggo";
            Assert.True(Program.AddWord(path, word));
             
        }
        [Fact]
        public void RandomWord()
        {
            string path = "../../../testFile.txt";
            string[] wordList = new string[] { "dog", "saxophone", "laptop", "apples", "code", "taco cat" };
            CollectionAttribute.Equals(wordList, Program.WordGrabber(path));
        }
        [Fact]
        public void DeleteFile()
        {
            string path = "../../../testFile.txt";
            Assert.True(Program.DeleteFile(path));
        }
        [Theory]
        [InlineData("dog", "c", "aepf", false)]
        [InlineData("dog", "g", "Uyuhnb", true)]
        [InlineData("dog", "o", "Ouy23cbn", true)]
        [InlineData("dog", "4", "Ouy23cbn", false)]
        public void CheckGuess(string mysteryWord, string userGuess, string guesses, bool expected)
        {
            string[] reveal = new string[] { "d", "o", "g" };
            Assert.Equal(expected, Program.WordChecker(mysteryWord, userGuess, guesses, reveal));
        }
    }
}
