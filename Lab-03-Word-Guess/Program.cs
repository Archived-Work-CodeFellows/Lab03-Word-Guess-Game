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
        /// <summary>
        /// This will create a file in the specified path
        /// </summary>
        /// <param name="path">Location of the file</param>
        /// <returns>Bool to inform programmer if file was created or already existed</returns>
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
        /// <summary>
        /// This will read the contents of file by creating an array with each line
        /// being assigned in an index
        /// </summary>
        /// <param name="path">Location of the file</param>
        /// <returns>Bool to inform programmer of it's success</returns>
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
                    sw.WriteLine("");
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
