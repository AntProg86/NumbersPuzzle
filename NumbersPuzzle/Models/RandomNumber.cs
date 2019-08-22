using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumbersPuzzle.Models
{
    /// <summary>Случайное число, загаданное компьютером.</summary>
    public class RandomNumber : BaseNumber
    {
        #region Constructor

        public RandomNumber()
        {
            GenerateRandomNumber();

            CheckNumberForCorrectness();
        }

        /// <summary> Для тестов. </summary>
        public RandomNumber(int FirstNumberValue, int SecondNumberValue, 
                            int ThirdNumberValue, int FourthNumberValue)
        : base(FirstNumberValue, SecondNumberValue, ThirdNumberValue, FourthNumberValue)
        {
            CheckNumberForCorrectness();
        }

        #endregion

        #region Methods

        /// <summary>Генерирует случайное число.</summary>
        private void GenerateRandomNumber()
        {
            FirstNumber.GenerateRandomValue();

            while(FirstNumber.Value == 0)
                FirstNumber.GenerateRandomValue();

            SecondNumber.GenerateRandomValue();

            while (SecondNumber.Value == FirstNumber.Value)
                SecondNumber.GenerateRandomValue();

            ThirdNumber.GenerateRandomValue();

            while(ThirdNumber.Value == FirstNumber.Value || ThirdNumber.Value == SecondNumber.Value )
                ThirdNumber.GenerateRandomValue();

            FourthNumber.GenerateRandomValue();

            while(FourthNumber.Value == FirstNumber.Value ||
                  FourthNumber.Value == SecondNumber.Value ||
                  FourthNumber.Value == ThirdNumber.Value)
                FourthNumber.GenerateRandomValue();
        }

        #endregion
    }
}
