using System.ComponentModel;
using System.Runtime.CompilerServices;
using TriangleLib;

namespace TriangleApp
{
    class Triangle : INotifyPropertyChanged
    {
        private readonly ITriangleType TriangleType;

        public Triangle()
        {
            TriangleType = new TriangleType();
        }

        private decimal sideA;
        public string SideA
        {
            get { return sideA.ToString(); }
            set
            {
                decimal.TryParse(value, out sideA);
                OnPropertyChanged("SideA");
            }
        }
        private decimal sideB;
        public string SideB
        {
            get { return sideB.ToString(); }
            set
            {
                decimal.TryParse(value, out sideB);
                OnPropertyChanged("SideB");
            }
        }
        private decimal sideC;
        public string SideC
        {
            get { return sideC.ToString(); }
            set
            {
                decimal.TryParse(value, out sideC);
                OnPropertyChanged("SideC");
            }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        private RunCommand runCmd;
        public RunCommand RunCmd
        {
            get 
            {
                return runCmd ?? (runCmd = new RunCommand(obj =>
                {
                    var res = TriangleType.GetTriangleType(sideA, sideB, sideC);
                    switch (res)
                    {
                        case TriangleTypes.Acute: Result = "Остроугольный"; break;
                        case TriangleTypes.Right: Result = "Прямоугольный"; break;
                        case TriangleTypes.Obtuse: Result = "Тупоугольный"; break;
                        case TriangleTypes.Error: Result = "Ошибка"; break;
                    }
                }
                    ));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
