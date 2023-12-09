using System.Collections.ObjectModel;
using System.Windows.Input;

namespace zhmásodik
{
    public partial class MainPage : ContentPage
    {
   
        public ObservableCollection<Mountain> Hegyek { get; set; }
        
        public string High {  get; set; }
        public string Nev { get; set; }
        public bool Pipa {  get; set; }

        public ICommand MyCommand { get; }

        public MainPage()
        {
          
            Hegyek = new ObservableCollection<Mountain>()
            {
                new Mountain { Name = "János-hegy", Magassag = 572, Megmaszta = true },
                new Mountain { Name = "Kis-Hárs-hegy", Magassag = 362, Megmaszta = true },
                new Mountain { Name = "Nagy-Hárs-hegy", Magassag = 454, Megmaszta = false },
                new Mountain { Name = "Hármashatár-hegy", Magassag = 495, Megmaszta = false }
            };

            MyCommand = new Command(MaszasokTorlese);

            InitializeComponent();
            BindingContext = this;
        }

        public void CheckBox(object sender, CheckedChangedEventArgs e)
        {
            if (Hegyek != null)
            {
                // Az aktuálisan kijelölt hegyet keresd meg
                var selectedMountain = Hegyek.FirstOrDefault(m => m.Name == Nev);

                if (selectedMountain != null)
                {
                    // Frissítsd a Megmaszta tulajdonságot a CheckBox állapotával
                    selectedMountain.Megmaszta = e.Value;

                }
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Mountain selectedMountain)
            {
                High = $"{selectedMountain.Magassag}";
                OnPropertyChanged(nameof(High));
                Nev = selectedMountain.Name ;
                OnPropertyChanged(nameof(Nev));
                Pipa = selectedMountain.Megmaszta;
                OnPropertyChanged(nameof(Pipa));
                ((ListView)sender).SelectedItem = null;
            }
        }

        public void MaszasokTorlese()
        {
            foreach(Mountain a in Hegyek)
            {
                a.Megmaszta = false;
                Pipa = false;
                OnPropertyChanged(nameof(Pipa));
            }
        }

    }
}