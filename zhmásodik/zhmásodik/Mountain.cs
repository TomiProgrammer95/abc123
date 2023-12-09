
using System.Collections.ObjectModel;

namespace zhmásodik
{
    public class Mountain : BindableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int magassag;
        public int Magassag
        {
            get { return magassag; }
            set
            {
                if (magassag != value)
                {
                    magassag = value;
                    OnPropertyChanged(nameof(Magassag));
                }
          
            }
        }
        private bool megmaszta;
        public bool Megmaszta
        {
            get { return megmaszta; }
            set
            {
                if (megmaszta != value)
                {
                    megmaszta = value;
                    OnPropertyChanged(nameof(Megmaszta));
                }
            }
        }
    }
}
