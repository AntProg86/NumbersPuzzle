using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using NumbersPuzzle.Models;
using NumbersPuzzle.View;

namespace NumbersPuzzle.ViewModel
{
    class MainWindowVM : OnPropertyChangedClass
    {
        #region Fields

        /// <summary> Случайное число, загаданное компьютером.</summary>
        private RandomNumber _randomNumber;

        /// <summary> Номер попытки.</summary>
        private int _attemptNumber;

        #endregion

        #region Properties for binding

        /// <summary> Выбираемое пользователем число.</summary>
        public UserNumber UserNumber { get; set; }

        /// <summary> Введённые пользователем четырёхзначные числа.</summary>
        public ObservableCollection<EnteredNumber> EnteredNumbers { get; set; }

        #endregion

        #region Commands

        /// <summary> Прибавить единицу к значению первого номера.</summary>
        public RelayCommand FirstNumberPlusOneCommand { get; }
        /// <summary> Отнять единицу от значения первого номера.</summary>
        public RelayCommand FirstNumberMinusOneCommand { get; }

        /// <summary> Прибавить единицу к значению второго номера.</summary>
        public RelayCommand SecondNumberPlusOneCommand { get; }
        /// <summary> Отнять единицу от значения второго номера.</summary>
        public RelayCommand SecondNumberMinusOneCommand { get; }

        /// <summary> Прибавить единицу к значению третьего номера.</summary>
        public RelayCommand ThirdNumberPlusOneCommand { get; }
        /// <summary> Отнять единицу от значения третьего номера.</summary>
        public RelayCommand ThirdNumberMinusOneCommand { get; }

        /// <summary> Прибавить единицу к значению четвёртого номера.</summary>
        public RelayCommand FourthNumberPlusOneCommand { get; }
        /// <summary> Отнять единицу от значения четвёртого номера.</summary>
        public RelayCommand FourthNumberMinusOneCommand { get; }

        /// <summary> Ввод номера.</summary>
        public RelayCommand EnterNumberCommand { get; }
        
        /// <summary> Перезапустить игру.</summary>
        public RelayCommand StartOverCommand { get; }

        /// <summary> Открыть справку.</summary>
        public RelayCommand OpenManualCommand { get; }

        public RelayCommand ClosedCommand { get; }

        #endregion

        #region Constructor

        public MainWindowVM()
        {
            _attemptNumber = 1;

            UserNumber = new UserNumber(1, 2, 3, 4);
            EnteredNumbers = new ObservableCollection<EnteredNumber>();
            _randomNumber = new RandomNumber();

            FirstNumberPlusOneCommand = new RelayCommand((x) => UserNumber.FirstNumber.PlusOne());
            FirstNumberMinusOneCommand = new RelayCommand((x) => UserNumber.FirstNumber.MinusOne());
            SecondNumberPlusOneCommand = new RelayCommand((x) => UserNumber.SecondNumber.PlusOne());
            SecondNumberMinusOneCommand = new RelayCommand((x) => UserNumber.SecondNumber.MinusOne());
            ThirdNumberPlusOneCommand = new RelayCommand((x) => UserNumber.ThirdNumber.PlusOne());
            ThirdNumberMinusOneCommand = new RelayCommand((x) => UserNumber.ThirdNumber.MinusOne());
            FourthNumberPlusOneCommand = new RelayCommand((x) => UserNumber.FourthNumber.PlusOne());
            FourthNumberMinusOneCommand = new RelayCommand((x) => UserNumber.FourthNumber.MinusOne());

            EnterNumberCommand = new RelayCommand((x) => EnterNumber(),
                (x) => UserNumber.IsNumberCorrect == false ? false : true);

            StartOverCommand = new RelayCommand((x) => StartOver());

            OpenManualCommand = new RelayCommand((x) => OpenManual());

            ClosedCommand = new RelayCommand((x) => Closed());
        }

        #endregion

        #region Methods for commands

        private void StartOver()
        {
            EnteredNumbers.Clear();
            _attemptNumber = 1;

            UserNumber = new UserNumber(1, 2, 3, 4);
            _randomNumber = new RandomNumber();
            OnAllPropertyChanged();
        }

        private void OpenManual()
        {
            Manual manual = new Manual();
            manual.Show();
        }

        private void EnterNumber()
        {
            EnteredNumbers.Add(new EnteredNumber(_randomNumber, UserNumber)
            {
                AttemptNumber = _attemptNumber
            });

            if(_randomNumber.Value == UserNumber.Value)
            {
                MessageBoxResult Result = MessageBox.Show("Вы выиграли. Загаданное число : " 
                    + _randomNumber.Value +
                    "\n Начать игру заново?", "Победа!", MessageBoxButton.YesNo);
                if (Result == MessageBoxResult.Yes)
                {
                    StartOver();
                }
                else if (Result == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }

            if (_attemptNumber == 7)
            {
                MessageBoxResult Result = MessageBox.Show("Вы проиграли. Загаданное число : "
                    + _randomNumber.Value +
                    "\n Начать игру заново?", "Проигрыш.", MessageBoxButton.YesNo);
                if (Result == MessageBoxResult.Yes)
                {
                    StartOver();
                }
                else if (Result == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }

            _attemptNumber++;
        }

        private void Closed()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
