using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersPuzzle.Models;

namespace NumbersPuzzle.Tests
{
    /// <summary>
    /// Точно (Precisely) - количество цифр (соответствует количеству полных смайликов),
    /// которые есть и в загаданном числе и в Вашем варианте ответа, 
    /// причем стоят они точно на своих позициях, 
    /// Рядом (Beside) - количество цифр(соответствует количеству половинок смайликов),
    /// которые есть и в загаданном числе и в Вашем варианте ответа, 
    /// но стоят они на разных позициях.
    /// </summary>
    [TestClass]
    public class EnteredNumberTest
    {
        /// <summary>
        /// Все цифры в числе на своих местах.
        /// </summary>
        [TestMethod]
        public void SetPrecisely_WhereAllNumbersAreRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber();

            UserNumber _userNumber = new UserNumber(_randomNumber.FirstNumber.Value,
                _randomNumber.SecondNumber.Value,
                _randomNumber.ThirdNumber.Value,
                _randomNumber.FourthNumber.Value);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Precisely == "****");

            #endregion
        }

        /// <summary>
        /// Три цифры в числе на своих местах.
        /// </summary>
        [TestMethod]
        public void SetPrecisely_WhereOneNumberIsntRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber();

            UserNumber _userNumber = new UserNumber
                ((_randomNumber.FirstNumber.Value) == 9 ? 
                _randomNumber.FirstNumber.Value - 1 : _randomNumber.FirstNumber.Value + 1,
                _randomNumber.SecondNumber.Value,
                _randomNumber.ThirdNumber.Value,
                _randomNumber.FourthNumber.Value);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Precisely == "***");

            #endregion
        }

        /// <summary>
        /// Две цифры в числе на своих местах.
        /// </summary>
        [TestMethod]
        public void SetPrecisely_WhereTwoNumberArentRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber();

            UserNumber _userNumber = new UserNumber
                ((_randomNumber.FirstNumber.Value) == 9 ?
                _randomNumber.FirstNumber.Value - 1 : _randomNumber.FirstNumber.Value + 1,
                (_randomNumber.SecondNumber.Value) == 9 ?
                _randomNumber.SecondNumber.Value - 1 : _randomNumber.SecondNumber.Value + 1,
                _randomNumber.ThirdNumber.Value,
                _randomNumber.FourthNumber.Value);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Precisely == "**");

            #endregion
        }

        /// <summary>
        /// Все цифры правильные, но на разных местах.
        /// </summary>
        [TestMethod]
        public void SetBeside_WhereAllNumbersAreRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber();

            UserNumber _userNumber = new UserNumber(_randomNumber.FourthNumber.Value,
                _randomNumber.ThirdNumber.Value,
                _randomNumber.SecondNumber.Value,
                _randomNumber.FirstNumber.Value);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Beside == "----");

            #endregion
        }

        /// <summary>
        /// Одна цифра правильная, но не на своём месте.
        /// </summary>
        [TestMethod]
        public void SetBeside_WhereOneNumberIsntRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber(1, 2, 3, 4);

            UserNumber _userNumber = new UserNumber(4, 7, 6, 5);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Beside == "-");

            #endregion
        }

        /// <summary>
        /// Три цифры правильные, но на разных местах.
        /// </summary>
        [TestMethod]
        public void SetBeside_WhereThreeNumberAreRight_test()
        {
            #region Arrange

            RandomNumber _randomNumber = new RandomNumber(1, 2, 3, 4);

            UserNumber _userNumber = new UserNumber(4, 3, 2, 5);

            EnteredNumber _enteredNumber = new EnteredNumber(_randomNumber, _userNumber);

            #endregion

            #region Assert

            Assert.IsTrue(_enteredNumber.Beside == "---");

            #endregion
        }
    }
}
