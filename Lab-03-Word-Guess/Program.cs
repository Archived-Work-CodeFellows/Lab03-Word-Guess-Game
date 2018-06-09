using System;
using System.IO;

namespace Lab_03_Word_Guess
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../WordList.txt";
            string[] wordList = new string[] { "dog", "saxophone", "laptop", "apples", "code", "taco cat" };
            CreateFile(path, wordList);

            UserMainMenu(path);
        }
        /// <summary>
        /// Landing interface at application start, gives
        /// user navigation options
        /// </summary>
        /// <param name="path">Location of File</param>
        static void UserMainMenu(string path)
        {
            bool isRunning = true;
            while (isRunning)
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
                        string mysteryWord = WordGrabber(path);
                        bool replay = true;
                        while (replay)
                        {
                            Console.Clear();
                            GuessingGame(mysteryWord);
                            replay = ReplayGame(mysteryWord);
                            mysteryWord = WordGrabber(path);
                        }
                        break;
                    case "2":
                        Console.Clear();
                        WordListMenu(path);
                        break;
                    default:
                        isRunning = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }
        /// <summary>
        /// Menu interaction for interacting with the file. Users can view, add word,
        /// delete word, remove file to get a fresh start
        /// </summary>
        /// <param name="path">Location of file</param>
        static void WordListMenu(string path)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Please Select and option...");
                Console.WriteLine("");
                Console.WriteLine("1) View Words");
                Console.WriteLine("2) Add Word");
                Console.WriteLine("3) Remove Word");
                Console.WriteLine("4) Remove File");
                Console.Write("Press enter if you wish to return to main menu... ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        string[] wordList = ReadFile(path);
                        foreach (string element in wordList)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please type in the word you would like to add!");
                        string addedWord = Console.ReadLine();
                        AddWord(path, addedWord);
                        break;
                    case "3":
                        Console.Clear();
                        wordList = ReadFile(path);
                        foreach (string element in wordList)
                        {
                            Console.WriteLine(element);
                        }
                        RemoveWord(path);
                        Console.Clear();
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
                            Console.WriteLine("Alright all gone! Your word list will be reset when you run the app again!");
                            Console.WriteLine("Bye-bye!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("I'll assume no then...");
                            Console.WriteLine(" ");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
        }
        /// <summary>
        /// This method allows the user to decide to play again
        /// </summary>
        /// <param name="mysteryWord">The word that the user had guessed</param>
        /// <returns>Determines if the while statement stays active</returns>
        public static bool ReplayGame(string mysteryWord)
        {
            Console.Clear();
            Console.WriteLine($"Yay! You did it. You figured out that the word was {mysteryWord}");
            Console.WriteLine(" ");
            Console.WriteLine("I can only give you theoretical dollars so here is 100 theoretical dollars!");
            Console.WriteLine("Would you like to play again? yes/no");
            string input = Console.ReadLine().ToLower();

            if (input == "y" || input == "yes") return true;
            Console.Clear();
            Console.WriteLine("I'll return you back the the main menu!");
            Console.ReadLine();
            return false;
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
            return wordList;
        }
        /// <summary>
        /// This will allow a passing value be added to the file via user
        /// input
        /// </summary>
        /// <param name="path">Location of File</param>
        /// <param name="word">The string to be added to the File</param>
        /// <returns>Bool to inform programmer of it's success</returns>
        public static bool AddWord(string path, string word)
        {
            if (File.Exists(path))
            {
                if (word.Length > 0)
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(word);
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// This method allows users to remove a word based on what they type
        /// </summary>
        /// <param name="path">Location of File</param>
        public static void RemoveWord(string path)
        {
            string[] wordList = ReadFile(path);
            Console.WriteLine(" ");
            Console.WriteLine("Which word would you like to remove?");
            string wordRemove = Console.ReadLine().ToLower();
            try
            {
                for (int i = 0; i < wordList.Length; i++)
                {
                    wordList[i] = wordRemove == wordList[i].ToLower() ? " " : wordList[i];
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oops...something went wrong");
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < wordList.Length; i++)
                {
                    if (wordList[i] != " ") sw.WriteLine(wordList[i]);
                }
            }
        }
        /// <summary>
        /// This takes in the path of the file and reads the contents
        /// into an array and will randomly select a word based
        /// off of that
        /// </summary>
        /// <param name="path">Location of file</param>
        /// <returns>The randomly selected word</returns>
        public static string WordGrabber(string path)
        {
            string[] wordList = ReadFile(path);
            Random random = new Random();
            int randNum = random.Next(0, wordList.Length);
            return wordList[randNum];
        }
        /// <summary>
        /// This method is the main Guessing Game. It prepares the
        /// word to be passed and checked into the WordChecker method
        /// </summary>
        /// <param name="mysteryWord">Randomly grabbed word</param>
        static void GuessingGame(string mysteryWord)
        {
            string guesses = "";
            bool guessing = true;
            string[] reveal = new string[mysteryWord.Length];

            while (guessing)
            {
                int lettersLeft = 0;

                for (int i = 0; i < mysteryWord.Length; i++)
                {
                    if (reveal[i] == null) Console.Write(" _ ");
                    else Console.Write($" {reveal[i]} ");
                }
                Console.Write("\n\n");
                Console.WriteLine($"User Guesses: {guesses}");
                Console.WriteLine(" ");
                Console.WriteLine("Please guess a letter!");
                Console.WriteLine("psssst....spaces count too..cough cough...");
                string userGuess = Console.ReadLine();

                if (userGuess.Length < 2)
                {
                    bool goodGuess = WordChecker(mysteryWord, userGuess, guesses, reveal);
                    guesses = guesses + userGuess;
                    if (goodGuess) Console.WriteLine("Woohoo! Good Guess");
                    else Console.WriteLine("Try again!");
                    Console.ReadLine();
                }

                for (int i = 0; i < mysteryWord.Length; i++)
                {
                    if (reveal[i] == null) lettersLeft++;
                }
                guessing = lettersLeft > 0 ? true : false;
                Console.Clear();
            }
        }
        /// <summary>
        /// This method takes user input and compares to the mystery word and previous
        /// guesses.
        /// </summary>
        /// <param name="mysteryWord">The randomly selected word</param>
        /// <param name="userGuess">User input</param>
        /// <param name="guesses">Contains string of user current's guesses</param>
        /// <param name="reveal">The comparison array</param>
        /// <returns>True or false based on if the users guess is contained in the mystery word</returns>
        public static bool WordChecker(string mysteryWord, string userGuess,string guesses, string[] reveal)
        {
            try
            {
                char[] word = mysteryWord.ToCharArray();

                if (mysteryWord.Contains(userGuess))
                {
                    char[] check = userGuess.ToCharArray();
                    for (int i = 0; i < mysteryWord.Length; i++)
                    {
                        if (check[0] == word[i]) reveal[i] = userGuess;
                    }
                }
                if (guesses.Contains(userGuess))
                {
                    Console.WriteLine("You've already guessed that!");
                    return false;
                }
                return mysteryWord.Contains(userGuess);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("I see what you did there...sorry can't just press enter!");
                return false;
            }
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
