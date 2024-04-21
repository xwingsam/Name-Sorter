using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Name_Sorter
{
    /// <summary>
    /// Gets a text file containing names and sort the name into a list.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">This application accepts only one argument the Input file</param>
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please verify the input, this application only accepts one parameter [args]= input file name");
                return;
            }

            string inputFile = args[0];

            List<string> listNames = generateList(inputFile);

            if (listNames.Count == 0) { return; }

            var mySortedList = sortList(listNames);
            displaySortedList(mySortedList);
            saveSortedList(mySortedList);
        }

        #region Private Methods

        /// <summary>
        /// Generates the list.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <returns>
        /// Generates a list of names based on the data on the input file
        /// </returns>
        public static List<string> generateList(string inputFile)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    throw new FileNotFoundException();
                }

                return File.ReadAllLines(inputFile).ToList();
            }
            catch (Exception ex)
            {
                string myDisplayError = string.Format("Failed to generate list: {0}{1} Exception:{2}", inputFile, Environment.NewLine, ex.Message);
                Console.WriteLine(myDisplayError);
                return new List<string>();
            }
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <param name="Nameslist">List of the names</param>
        /// <returns>
        /// a sorted list of names
        /// </returns>
        public static List<string> sortList(List<string> Nameslist)
        {
            try
            {
                List<string> mylist = Nameslist;

                return mylist.OrderBy(n => n.Split(' ').Last())
                   .ThenBy(n => n.Split(' ').Take(n.Split(' ').Length - 1))
                   .ToList();
            }
            catch (Exception ex)
            {
                string myDisplayError = string.Format("Failed to sort the list{0} Exception:{1}", Environment.NewLine, ex.Message);
                Console.WriteLine(myDisplayError);
                return new List<string>();
            }
        }


        /// <summary>
        /// Displays the sorted list on the screen.
        /// </summary>
        /// <param name="SortedNameslist">list of sorted names.</param>
        private static void displaySortedList(List<string> SortedNameslist)
        {
            try
            {
                foreach (var name in SortedNameslist)
                {
                    Console.WriteLine(name);
                }
            }
            catch (Exception ex)
            {
                string myDisplayError = string.Format("Unable to display list: {0} Exception:{1}", Environment.NewLine, ex.Message);
                Console.WriteLine(myDisplayError);
            }
        }

        /// <summary>
        /// Saves the sorted list.
        /// </summary>
        /// <param name="SortedNameslist">List of sorted name.</param>
        private static void saveSortedList(List<string> SortedNameslist)
        {
            string myFileName = "sorted-names-list.txt";
            try
            {
                File.WriteAllLines(myFileName, SortedNameslist);
            }
            catch (Exception ex)
            {
                string myDisplayError = string.Format("Unable to save: {0}{1} Exception:{2}", myFileName, Environment.NewLine, ex.Message);
                Console.WriteLine(myDisplayError);
            }
        }

        #endregion Private Methods
    }
}