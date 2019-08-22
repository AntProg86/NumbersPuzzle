using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersPuzzle.Models;
using System.Collections.Generic;
using System.Linq;

namespace NumbersPuzzle.Tests
{
    [TestClass]
    public class UserNumberTest
    {
        #region Fields

        UserNumber UserNumber;

        #endregion

        /// <summary>
        /// Проверка четырёхзначного числа на корректность при условии, что 
        /// все цифры разные, а первая цифра не равняться «0»
        /// </summary>
        [TestMethod]
        public void CheckNumberForCorrectness_SetCorrectNumber_test()
        {
            #region Arrange

            //Устанавливаем правильные цифры в номере.
            UserNumber = new UserNumber(1, 2, 3, 4);

            #endregion

            #region Assert

            //Свойство IsNumberCorrect должно быть установлено в True
            Assert.IsTrue(UserNumber.IsNumberCorrect);

            //Свойство Color всех цифр должно быть установлено в black
            Assert.IsTrue(UserNumber.Numbers.Where(x => x.Color == "Black").Count() == 4);

            #endregion
        }

        /// <summary>
        /// Проверка четырёхзначного числа на корректность при условии, что 
        /// все цифры разные, а первая цифра равняться «0»
        /// </summary>
        [TestMethod]
        public void CheckNumberForCorrectness_WhereFirstNumberIsZero_test()
        {
            #region Arrange

            //Устанавливаем правильные цифры в номере.
            UserNumber = new UserNumber(1, 2, 3, 4);

            #endregion

            #region Act

            //Меняем первую цифру на «0»
            UserNumber.FirstNumber.MinusOne();

            #endregion

            #region Assert

            //Свойство IsNumberCorrect должно быть установлено в false
            Assert.IsTrue(UserNumber.IsNumberCorrect == false);

            //Свойство Color первой цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.FirstNumber.Color == "Red");

            #endregion
        }

        /// <summary>
        /// Проверка четырёхзначного числа на корректность при условии, что 
        /// имеются две одинаковые цифры.
        /// </summary>
        [TestMethod]
        public void CheckNumberForCorrectness_WhereAreTwoIdenticalNumbers_test()
        {
            #region Arrange

            //Устанавливаем правильные цифры в номере.
            UserNumber = new UserNumber(1, 2, 3, 4);

            #endregion

            #region Act

            //Меняем первую цифру на «2»
            UserNumber.FirstNumber.PlusOne();

            #endregion

            #region Assert

            //Свойство IsNumberCorrect должно быть установлено в false
            Assert.IsTrue(UserNumber.IsNumberCorrect == false);

            //Свойство Color первой цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.FirstNumber.Color == "Red");

            //Свойство Color второй цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.SecondNumber.Color == "Red");
            #endregion
        }

        /// <summary>
        /// Проверка четырёхзначного числа на корректность при условии, что 
        /// имеются три одинаковые цифры.
        /// </summary>
        [TestMethod]
        public void CheckNumberForCorrectness_WhereAreThreeIdenticalNumbers_test()
        {
            #region Arrange

            //Устанавливаем правильные цифры в номере.
            UserNumber = new UserNumber(1, 2, 3, 4);

            #endregion

            #region Act

            //Меняем первую цифру на «2»
            UserNumber.FirstNumber.PlusOne();
            //Меняем третью цифру на «2»
            UserNumber.ThirdNumber.MinusOne();

            #endregion

            #region Assert

            //Свойство IsNumberCorrect должно быть установлено в false
            Assert.IsTrue(UserNumber.IsNumberCorrect == false);

            //Свойство Color первой цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.FirstNumber.Color == "Red");

            //Свойство Color второй цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.SecondNumber.Color == "Red");

            //Свойство Color третьей  цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.ThirdNumber.Color == "Red");
            #endregion
        }

        /// <summary>
        /// Делаем из не верного номера верный.
        /// </summary>
        [TestMethod]
        public void SetCorrectNumber()
        {
            #region Arrange

            //Устанавливаем неправильные цифры в номере.
            UserNumber = new UserNumber(2, 2, 3, 4);

            #endregion

            #region Act

            //Меняем первую цифру на «1»
            UserNumber.FirstNumber.MinusOne();

            #endregion

            #region Assert

            //Свойство IsNumberCorrect должно быть установлено в true
            Assert.IsTrue(UserNumber.IsNumberCorrect == true);

            //Свойство Color первой цифры должно быть установлено в Black
            Assert.IsTrue(UserNumber.FirstNumber.Color == "Black");

            //Свойство Color второй цифры должно быть установлено в Red
            Assert.IsTrue(UserNumber.SecondNumber.Color == "Black");
            #endregion
        }

    }
}

