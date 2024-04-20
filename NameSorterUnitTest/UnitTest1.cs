using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Name_Sorter;

namespace Name_Sorter.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_GenerateList_WithValidInputFile_ShouldReturnListWithNames()
        {
            // Arrange
            string inputFile = "unsorted-names-list.txt";

            // Act
            List<string> result = Program.generateList(inputFile);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Test_GenerateList_WithInvalidInputFile_ShouldReturnEmptyList()
        {
            // Arrange
            string inputFile = "invalid-input.txt"; // This file does not exist

            // Act
            List<string> result = Program.generateList(inputFile);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Test_SortList_ShouldReturnSortedNamesList()
        {
            // Arrange
            List<string> unsortedList = new List<string> { "Tom Jerry", "Stacey Brown", "John Smith", "Alice Tim" };
            List<string> expected = new List<string> { "Stacey Brown", "Tom Jerry" , "John Smith", "Alice Tim", };

            // Act
            List<string> result = Program.sortList(unsortedList);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        // Note: Additional tests for displaySortedList and saveSortedList methods can be added how ever personally I did not
        // see any need to add these tests since these are fairly simple functions and most of the process is handled by Windows itself.

    }
}