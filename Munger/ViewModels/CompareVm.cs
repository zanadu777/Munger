using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Munger.Extensions;
using Munger.Properties;
using Prism.Commands;
using TextProcessing;
using TextProcessing.Extensions;
using TextProcessing.Transforms;

namespace Munger.ViewModels
{
    public class CompareVm : INotifyPropertyChanged
    {
        private string setASource;
        private string setBSource;
        private string onlySetA;
        private string onlySetB;
        private string bothAandB;
        private string onlyAorB;
        private int? setACount;
        private int? setBCount;
        private int? onlySetACount;
        private int? onlySetBCount;
        private int? bothAandBCount;
        private int? onlyAorBCount;
        private bool setACountAvailable;
        private bool setBCountAvailable;
        private bool onlySetACountAvailable;
        private bool onlySetBCountAvailable;
        private bool bothAandBCountAvaialble;
        private bool onlyAorBCountAvailable;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CompareAndBCommand { get; set; }

        public CompareVm()
        {
            CompareAndBCommand = new DelegateCommand(CompareAndB);
        }

        private void CompareAndB()
        {

            var transA = new List<StringTransform>();
            transA.Add(new LineExtractor());
            transA.Add(new RemoveEmpty());
            var lstA = transA.Transform(setASource);

            var transB = new List<StringTransform>();
            transB.Add(new LineExtractor());
            transB.Add(new RemoveEmpty());
            transB.Add(new Split { Seperator = ';' });
            var lstB = transB.Transform(setBSource);

            var comparer = new Comparer(lstA, lstB);

            OnlySetA = comparer.OnlyA.ToStringCombined();
            OnlySetB = comparer.OnlyB.ToStringCombined();
            BothAandB = comparer.BothAandB.ToStringCombined();
            OnlyAorB = comparer.OnlyAorB.ToStringCombined();

            SetACount = lstA.Count;
            SetBCount = lstB.Count;

            OnlySetACount = comparer.OnlyA.Count;
            OnlySetBCount = comparer.OnlyB.Count;
            BothAandBCount = comparer.BothAandB.Count;
            OnlyAorBCount = comparer.OnlyAorB.Count;
        }

        public string SetASource
        {
            get { return setASource; }
            set
            {
                if (value == setASource) return;
                setASource = value;
                OnPropertyChanged();
            }
        }

        public string SetBSource
        {
            get { return setBSource; }
            set
            {
                if (value == setBSource) return;
                setBSource = value;
                OnPropertyChanged();
            }
        }

        public string OnlySetA
        {
            get { return onlySetA; }
            set
            {
                if (value == onlySetA) return;
                onlySetA = value;
                OnPropertyChanged();
            }
        }

        public string OnlySetB
        {
            get { return onlySetB; }
            set
            {
                if (value == onlySetB) return;
                onlySetB = value;
                OnPropertyChanged();
            }
        }

        public string BothAandB
        {
            get { return bothAandB; }
            set
            {
                if (value == bothAandB) return;
                bothAandB = value;
                OnPropertyChanged();
            }
        }

        public string OnlyAorB
        {
            get { return onlyAorB; }
            set
            {
                if (value == onlyAorB) return;
                onlyAorB = value;
                OnPropertyChanged();
            }
        }

        public int? SetACount
        {
            get { return setACount; }
            set
            {
                if (value == setACount) return;
                setACount = value;
                SetACountAvailable = SetACount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool SetACountAvailable
        {
            get { return setACountAvailable; }
            set
            {
                setACountAvailable = value;
                OnPropertyChanged();
            }
        }

        public int? SetBCount
        {
            get { return setBCount; }
            set
            {
                if (value == setBCount) return;
                setBCount = value;
                SetBCountAvailable = SetBCount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool SetBCountAvailable
        {
            get { return setBCountAvailable; }
            set
            {
                if (value == setBCountAvailable) return;
                setBCountAvailable = value;
                OnPropertyChanged();
            }
        }

        public int? OnlySetACount
        {
            get { return onlySetACount; }
            set
            {
                if (value == onlySetACount) return;
                onlySetACount = value;
                OnlySetACountAvailable = onlySetACount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool OnlySetACountAvailable
        {
            get { return onlySetACountAvailable; }
            set
            {
                if (value == onlySetACountAvailable) return;
                onlySetACountAvailable = value;
                OnPropertyChanged();
            }
        }

        public int? OnlySetBCount
        {
            get { return onlySetBCount; }
            set
            {
                if (value == onlySetBCount) return;
                onlySetBCount = value;
                OnlySetBCountAvailable = onlySetBCount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool OnlySetBCountAvailable
        {
            get { return onlySetBCountAvailable; }
            set
            {
                if (value == onlySetBCountAvailable) return;
                onlySetBCountAvailable = value;
                OnPropertyChanged();
            }
        }

        public int? BothAandBCount
        {
            get { return bothAandBCount; }
            set
            {
                if (value == bothAandBCount) return;
                bothAandBCount = value;
                BothAandBCountAvaialble = bothAandBCount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool BothAandBCountAvaialble
        {
            get { return bothAandBCountAvaialble; }
            set
            {
                if (value == bothAandBCountAvaialble) return;
                bothAandBCountAvaialble = value;
                OnPropertyChanged();
            }
        }

        public int? OnlyAorBCount
        {
            get { return onlyAorBCount; }
            set
            {
                if (value == onlyAorBCount) return;
                onlyAorBCount = value;
                OnlyAorBCountAvailable = onlyAorBCount.HasValue;
                OnPropertyChanged();
            }
        }

        public bool OnlyAorBCountAvailable
        {
            get { return onlyAorBCountAvailable; }
            set
            {
                if (value == onlyAorBCountAvailable) return;
                onlyAorBCountAvailable = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
