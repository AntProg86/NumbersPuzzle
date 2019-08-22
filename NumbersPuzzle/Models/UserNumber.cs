using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NumbersPuzzle.Models
{
    public class UserNumber : BaseNumber
    {
        #region Properties

        /// <summary>
        /// Помогает определить, является четырёхзначное число корректным или нет.
        /// Все цифры в числе должны быть разными.
        /// Первая цифра не должна равняться «0».
        /// </summary>
        override public bool IsNumberCorrect
        {
            get => _isNumberCorrect;
            protected set
            {
                _isNumberCorrect = value;
                ChangeNumberColor();
            }
        }

        #endregion

        #region Constructor
        
        public UserNumber(int FirstNumberValue, int SecondNumberValue, int ThirdNumberValue, int FourthNumberValue)
            : base(FirstNumberValue, SecondNumberValue, ThirdNumberValue, FourthNumberValue)
        {
            FirstNumber.ValueChanged += CheckNumberForCorrectness;
            SecondNumber.ValueChanged += CheckNumberForCorrectness;
            ThirdNumber.ValueChanged += CheckNumberForCorrectness;
            FourthNumber.ValueChanged += CheckNumberForCorrectness;
            
            CheckNumberForCorrectness();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Меняет цвет некорректным цифрам на красный, а корректным на чёрный.
        /// </summary>
        private void ChangeNumberColor()
        {
            // Если четырёхзначное число корректное, меняем цвет всех цифр на чёрный.
            if (IsNumberCorrect == true)
            {
                foreach (var Number in Numbers)
                {
                    Number.SetBlackColor();
                }

                return;
            }

            /* Если цифры одинаковые, то меняем их цвет с черного на красный.
               Если цифры разные, а их цвет красный, то меняем его на черный. */
            foreach (var Number in Numbers)
            {
                if (Numbers.Where(x => x.Value == Number.Value).Count() > 1)
                    Number.SetRedColor();
                else
                    Number.SetBlackColor();
            }

            // Первая цифра в четырёхзначном числе не должна быть равна «0»
            if (FirstNumber.Value == 0)
                FirstNumber.SetRedColor();
        }
        
        #endregion

    }
}

