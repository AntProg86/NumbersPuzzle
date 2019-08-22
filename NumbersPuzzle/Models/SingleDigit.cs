using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersPuzzle.Models
{
    public class SingleDigit : OnPropertyChangedClass
    {
        #region Fields

        /// <summary>Для генерации случайного значения от 0 до 9.</summary>
        private Random rnd;

        #endregion

        #region Private fields for storing property values

        /// <summary>Определяет свойство Value.</summary>
        private int _value;

        /// <summary>Определяет свойство Color.</summary>
        private string _color;

        #endregion

        #region Properties

        /// <summary>Цвет цифры в интерфейсе пользователя.</summary>
        public string Color
        {
            get { return _color; }
            private set
            {
                if(_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>Значение от 0 до 9</summary>
        public int Value
        {
            get { return _value; }
            private set
            {
                if (_value != value)
                {
                    if (value < 0)
                        _value = 0;
                    if (value > 9)
                        _value = 9;

                    _value = value;
                    ValueChanged?.Invoke();
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructor

        public SingleDigit()
        {
            Color = "Black";

            rnd = new Random();
        }

        public SingleDigit(int Value)
        {
            Color = "Black";

            rnd = new Random();

            this.Value = Value;
        }

        #endregion

        #region Methods

        /// <summary>Увеличивает значение на 1.</summary>
        public void PlusOne()
        {
            if (Value == 9)
                return;

            Value++;
        }

        /// <summary>Уменьшает значение на 1.</summary>
        public void MinusOne()
        {
            if (Value == 0)
                return;

            Value--;
        }

        /// <summary>Сменить цвет цифры на красный.</summary>
        public void SetRedColor()
        {
            Color = "Red";
        }

        /// <summary>Сменить цвет цифры на чёрный.</summary>
        public void SetBlackColor()
        {
            Color = "Black";
        }

        /// <summary>Сгенерировать случайное число от 0 до 9.</summary>
        public void GenerateRandomValue()
        {
            Value = rnd.Next(0, 9);
        }

        #endregion

        #region Events

        /// <summary>Происходит при изменении значения.</summary>
        public event Action ValueChanged;

        #endregion
    }
}
