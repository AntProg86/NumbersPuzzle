using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersPuzzle.Models;

namespace NumbersPuzzle.Tests
{
    [TestClass]
    public class SingleDigitTests
    {
        [TestMethod]
        public void GenerateRandomValue_From_0_to_9()
        {
            #region Arrange

            SingleDigit SingleDigit = new SingleDigit();

            int[] GeneratedNumbers = new int[49];

            #endregion

            #region Act
            
            for (int i = 0; i < 49; i++)
            {

                SingleDigit.GenerateRandomValue();
                GeneratedNumbers[i] = SingleDigit.Value;
                Thread.Sleep(500);

            }

            #endregion

            #region Assert
            
            foreach (var a in GeneratedNumbers)
            {
                Debug.Write(a.ToString() + " || ");
                Assert.IsFalse(CheckNumber(a));
            }

            #endregion
        }

        private bool CheckNumber(int x)
        {
            if (x < 0 & x > 9)
                return true;

            return false;
        }
    }
}
