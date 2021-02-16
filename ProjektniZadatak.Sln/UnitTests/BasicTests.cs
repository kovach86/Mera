using System;
using Core.Entities;
using MainProgram.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories.Interfaces;
using Services;
using Services.TextReaders;

namespace UnitTests
{
    [TestClass]
    public class BasicTests
    {
        private ISourceReader _sourceReaderFromFile;
        private ISourceReader _userInputReader;

        [TestInitialize]
        public void Initialize()
        {
            _sourceReaderFromFile = new FileContentReader();
            _userInputReader = new UserInputReader();
        }

        [TestMethod]
        public void TestFileNotExist()
        {
            string text = _sourceReaderFromFile.GetTextFromSource(null);
            Assert.AreEqual(null, text);
        }

        [TestMethod]
        public void TestUserInput()
        {
            string inputText = $"some text inputed today {DateTime.Now.ToShortDateString()} ";
            Assert.AreEqual(inputText, _userInputReader.GetTextFromSource(inputText));
        }

        [TestMethod]
        public void TestOurChecker()
        {
            bool isFaulty = TextChecker.CheckIfTextIsFormedCorrectly(" ");
            Assert.AreEqual(false, isFaulty);

            string withoutLetters = "123123@##!@#";
            Assert.AreEqual(false, TextChecker.CheckIfTextIsFormedCorrectly(withoutLetters));

            string correctFormedText = "some text description";
            Assert.AreEqual(true, TextChecker.CheckIfTextIsFormedCorrectly(correctFormedText));

        }
    }
}
