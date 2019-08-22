using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersPuzzle.Models
{
    public class EnteredNumber
    {
        /// <summary>Номер угадан?</summary>
        public bool IsNumberGuessed { get; private set; }

        #region Properties for binding

        /// <summary> Номер попытки.</summary>
        public int AttemptNumber { get; set; }

        /// <summary> Введённый номер.</summary>
        public int Number { get; private set; }

        /// <summary>
        ///   Точно - количество цифр (соответствует количеству полных звёздочек), 
        ///   которые есть и в загаданном числе и в Вашем варианте ответа, 
        ///   причем  стоят они точно на своих позициях.
        /// </summary>
        public string Precisely { get; private set; }

        /// <summary>
        /// Рядом - количество цифр (соответствует количеству чёрточек),
        /// которые есть и в загаданном числе и в Вашем варианте ответа, 
        /// но стоят они на разных позициях.
        /// </summary>
        public string Beside { get; private set; }

        #endregion

        #region Constructor

        public EnteredNumber(RandomNumber GeneratedRandomNumber, UserNumber EnteredUserNumber)
        {
            Number = EnteredUserNumber.Value;
            SetPrecisely(GeneratedRandomNumber, EnteredUserNumber);
            SetBeside(GeneratedRandomNumber, EnteredUserNumber);
        }

        #endregion

        #region Methods

        private void SetPrecisely(RandomNumber GeneratedRandomNumber, UserNumber EnteredUserNumber)
        {
            if(GeneratedRandomNumber.FirstNumber.Value == EnteredUserNumber.FirstNumber.Value)
            {
                Precisely += '*';
            }

            if (GeneratedRandomNumber.SecondNumber.Value == EnteredUserNumber.SecondNumber.Value)
            {
                Precisely += '*';
            }

            if (GeneratedRandomNumber.ThirdNumber.Value == EnteredUserNumber.ThirdNumber.Value)
            {
                Precisely += '*';
            }

            if (GeneratedRandomNumber.FourthNumber.Value == EnteredUserNumber.FourthNumber.Value)
            {
                Precisely += '*';
            }

        }

        private void SetBeside(RandomNumber GeneratedRandomNumber, UserNumber EnteredUserNumber)
        {
            RandomNumber GRN = GeneratedRandomNumber;
            UserNumber EUN = EnteredUserNumber;

            if (EUN.Numbers.Where(x => x.Value == GRN.FirstNumber.Value).Count() > 0 &&
                EUN.FirstNumber.Value != GRN.FirstNumber.Value)
            {
                Beside += '-';
            }

            if (EUN.Numbers.Where(x => x.Value == GRN.SecondNumber.Value).Count() > 0 &&
                EUN.SecondNumber.Value != GRN.SecondNumber.Value)
            {
                Beside += '-';
            }

            if (EUN.Numbers.Where(x => x.Value == GRN.ThirdNumber.Value).Count() > 0 &&
                EUN.ThirdNumber.Value != GRN.ThirdNumber.Value)
            {
                Beside += '-';
            }

            if (EUN.Numbers.Where(x => x.Value == GRN.FourthNumber.Value).Count() > 0 &&
                EUN.FourthNumber.Value != GRN.FourthNumber.Value)
            {
                Beside += '-';
            }
        }

        #endregion
    }
}
