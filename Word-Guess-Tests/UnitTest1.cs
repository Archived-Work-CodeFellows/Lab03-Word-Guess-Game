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
            Assert.True(Program.UpdateFile(path, word));
             
        }
        [Fact]
        public void DeleteFile()
        {
            string path = "../../../testFile.txt";
            Assert.True(Program.DeleteFile(path));
        }
    }
}
