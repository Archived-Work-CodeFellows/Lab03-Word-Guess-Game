using System;
using System.IO;

namespace Lab_03_Word_Guess
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../testFile.txt";
            Console.WriteLine("Hello World!");
            CreateFile(path);
            ReadFile(path);
            UpdateFile(path, "doggo");
            ReadFile(path);
            DeleteFile(path);
        }

        public static bool CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("This is a line of text");
                }
                return true;
            }
            return false;
        }

        public static bool ReadFile(string path)
        {
            try
            {
                string[] myText = File.ReadAllLines(path);
                foreach(string element in myText)
                {
                    Console.WriteLine(element);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops...something went wrong!");
            }
            return false;
        }

        public static bool UpdateFile(string path, string word)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("");
                    sw.WriteLine(word);
                }
                return true;
            }
            return false;
        }

        public static bool DeleteFile(string path)
        {
            File.Delete(path);
            return true;
        }
    }
}
