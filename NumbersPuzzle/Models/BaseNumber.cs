using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NumbersPuzzle.Models
{
    abstract public class BaseNumber
    {
        #region Properties

        public SingleDigit FirstNumber { get; set; }
        public SingleDigit SecondNumber { get; set; }
        public SingleDigit ThirdNumber { get; set; }
        public SingleDigit FourthNumber { get; set; }

        /// <summary>Для удобства поиска одинаковых цифр.</summary>
        public readonly IList<SingleDigit> Numbers;

        /// <summary>Определяет свойство «IsNumberCorrect».</summary>
        protected bool _isNumberCorrect;

        /// <summary>
        /// Помогает определить, является четырёхзначное число корректным или нет.
        /// Все цифры в числе должны быть разными.
        /// Первая цифра не должна равняться «0».
        /// </summary>
        virtual public bool IsNumberCorrect
        {
            get => _isNumberCorrect;

            protected set
            {
                _isNumberCorrect = value;
            }
        }

        /// <summary> Значение числа целиком.</summary>
        public int Value
        {
            get
            {
                try
                {
                    return Int32.Parse(FirstNumber.Value.ToString() + SecondNumber.Value.ToString() +
                        ThirdNumber.Value.ToString() + FourthNumber.Value.ToString());
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }
            }
        }

        #endregion

        #region Constructor

        public BaseNumber()
        {
            FirstNumber = new SingleDigit();
            SecondNumber = new SingleDigit();
            ThirdNumber = new SingleDigit();
            FourthNumber = new SingleDigit();

            Numbers = new List<SingleDigit>()
            {
                FirstNumber,
                SecondNumber,
                ThirdNumber,
                FourthNumber
            };
        }

        public BaseNumber(int FirstNumberValue, int SecondNumberValue,
            int ThirdNumberValue, int FourthNumberValue)
        {
            FirstNumber = new SingleDigit(FirstNumberValue);
            SecondNumber = new SingleDigit(SecondNumberValue);
            ThirdNumber = new SingleDigit(ThirdNumberValue);
            FourthNumber = new SingleDigit(FourthNumberValue);

            Numbers = new List<SingleDigit>()
            {
                FirstNumber,
                SecondNumber,
                ThirdNumber,
                FourthNumber
            };

            CheckNumberForCorrectness();
        }

        #endregion

        /// <summary>Определяет, является четырёхзначное число корректным или нет.</summary>
        protected void CheckNumberForCorrectness()
        {
            // Если первая цифра равна «0», то число некорректное.
            if (FirstNumber.Value == 0)
            {
                IsNumberCorrect = false;
                return;
            }

            // Если в четырёхзначном числе есть одинаковые цифры, то число некорректное.
            if (Numbers.Select(x => x.Value).Distinct().Count() < 4)
            {
                IsNumberCorrect = false;
                return;
            }

            //Если предыдущие проверки прошли успешно, то число признаётся корректным.
            if (IsNumberCorrect == false)
                IsNumberCorrect = true;
        }

    }
}
