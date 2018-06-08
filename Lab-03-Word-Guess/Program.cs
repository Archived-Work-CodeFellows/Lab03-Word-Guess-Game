using System;
using System.IO;

namespace Lab_03_Word_Guess
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../testFile.txt";
            string[] wordList = new string[] { "dog", "saxophone", "laptop", "apples", "code", "taco cat" };
            CreateFile(path, wordList);

            UserMainMenu(path);
            //UpdateFile(path, "doggo");
            //ReadFile(path);
            //DeleteFile(path);
        }
        /// <summary>
        /// Landing interface at application start, gives
        /// user navigation options
        /// </summary>
        /// <param name="path">Location of File</param>
        static void UserMainMenu(string path)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Josie Cat Guess A Word, Word Guess Game!");
            Console.Write("\n\n");
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1) Play Game");
            Console.WriteLine("2) Word List");
            Console.WriteLine("3) Exit");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    Console.WriteLine("Game Code");
                    break;
                case "2":
                    Console.Clear();
                    WordListMenu(path);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary>
        /// Menu interaction for interacting with the file. Users can view, add word,
        /// delete word, remove file to get a fresh start
        /// </summary>
        /// <param name="path">Location of file</param>
        static void WordListMenu(string path)
        {
            Console.WriteLine("Please Select and option...");
            Console.WriteLine("");
            Console.WriteLine("1) View Words");
            Console.WriteLine("2) Add Word");
            Console.WriteLine("3) Remove Word");
            Console.WriteLine("4) Remove File");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    WordListMenu(path);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please type in the word you would like to add!");
                    string addedWord = Console.ReadLine();
                    UpdateFile(path, addedWord);
                    WordListMenu(path);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Remove word");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("This will remove the file and give you a fresh start!");
                    Console.WriteLine("Are you sure? yes/no ");
                    string confirm = Console.ReadLine().ToLower();
                    if (confirm == "yes" || confirm == "y")
                    {
                        Console.Clear();
                        DeleteFile(path);
                        Console.WriteLine("Alright all gone! Your word list will be reset when the app restarts!");
                        Console.WriteLine("Bye-bye!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("I'll assume no then...");
                        Console.Clear();
                        WordListMenu(path);
                    }
                    break;
                default:
                    UserMainMenu(path);
                    break;
            }
        }
        /// <summary>
        /// This will create a file in the specified path
        /// </summary>
        /// <param name="path">Location of the file</param>
        /// <returns>Bool to inform programmer if file was created or already existed</returns>
        public static bool CreateFile(string path, string[] wordList)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string element in wordList)
                    {
                        sw.WriteLine(element);
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// This will read the contents of file by creating an array with each line
        /// being assigned in an index
        /// </summary>
        /// <param name="path">Location of the file</param>
        /// <returns>String array to house all words</returns>
        public static string[] ReadFile(string path)
        {
            string[] wordList = File.ReadAllLines(path);
            foreach (string element in wordList)
            {
                Console.WriteLine(element);
            }
            return wordList;
        }
        /// <summary>
        /// This will allow a passing value be added to the file via user
        /// input
        /// </summary>
        /// <param name="path">Location of File</param>
        /// <param name="word">The string to be added to the File</param>
        /// <returns>Bool to inform programmer of it's success</returns>
        public static bool UpdateFile(string path, string word)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(word);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// This will allow for the removal of the file
        /// </summary>
        /// <param name="path">Location of file</param>
        /// <returns>Bool to inform programmer of it's success</returns>
        public static bool DeleteFile(string path)
        {
            File.Delete(path);
            return true;
        }
    }
}
