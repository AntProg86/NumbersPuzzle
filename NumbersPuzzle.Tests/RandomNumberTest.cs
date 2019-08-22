using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersPuzzle.Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace NumbersPuzzle.Tests
{
    [TestClass]
    public class RandomNumberTest
    {
        /// Все цифры разные в числе должны быть разными.
        /// Первая цифра не должна быть равна «0».
        /// </summary>
        [TestMethod]
        public void GenerateRandomNumberTest()
        {
            #region Arrange

            IList<RandomNumber> RandomNumbers = new List<RandomNumber>();

            for(int i = 1; i <= 10; i++)
            {
                RandomNumbers.Add(new RandomNumber());
                Thread.Sleep(500);
            }

            #endregion

            #region Assert

            foreach(var randomNumber in RandomNumbers)
            {

                Assert.IsTrue(randomNumber.IsNumberCorrect);
                Debug.Write(randomNumber.Value.ToString() + " || ");
            }

            #endregion

        }
    }
}
