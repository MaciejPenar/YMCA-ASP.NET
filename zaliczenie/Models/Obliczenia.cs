using System.ComponentModel;

namespace zaliczenie.Models
{
    public class Obliczenia : INotifyPropertyChanged
    {
        bool plec = true;
        double masa = 80;
        double pas = 100; //talia

        public bool Plec
        {
            get { return plec; }
            set
            {
                plec = value;
                OnPropertyChanged("Plec");
                OnPropertyChanged("opis");
            }
        }
        public double Masa
        {
            get
            {
                return masa;
            }

            set
            {
                masa = value;
                OnPropertyChanged("Masa");
                OnPropertyChanged("Opis");
            }
        }
        public double Pas
        {
            get
            {
                return pas;
            }

            set
            {
                pas = value;
                OnPropertyChanged("Pas");
                OnPropertyChanged("Opis");
            }
        }
        public string Opis
        {
            get
            {
                try
                {
                    string opis;  // opis wynikow zgodny ze strona internetowa: https://www.trener.pl/trener-odpowiada/jak-obliczyc-zawartosc-tkanki-tluszczowej-w-organizmie/
                                  // wyniki zgodne ze strona internetowa: https://dietetykpro.pl/kalkulatory/ymca
                    double Wynik; // Zawartość tkanki tłuszczowej (kobiety) = ((1.634 x obwód pasa [cm] – 0.1804 x masa ciała [kg] - 76.76 ) / 2,2 * masa ciała [kg]) x 100
                                  // Zawartość tkanki tłuszczowej(mężczyźni) = ((1.634 x obwód pasa[cm] – 0.1804 x masa ciała[kg] - 98.42 ) / 2,2 x masa ciała[kg]) x 100
                    if (plec == true)
                    {
                        Wynik = ((1.634 * pas) - (0.1804 * masa) - 98.42) / (2.2 * masa) * 100;

                        if (Wynik < 8)
                            opis = Math.Round(Wynik, 2) + "% niski";
                        else if (Wynik < 20)
                            opis = Math.Round(Wynik, 2) + "% norma";
                        else if (Wynik < 25)
                            opis = Math.Round(Wynik, 2) + "% wysoka";
                        else
                            opis = Math.Round(Wynik, 2) + "% bardzo wysoka";

                        return opis;
                    }
                    else
                    {
                        Wynik = ((1.634 * pas) - (0.1804 * masa) - 76.76) / (2.2 * masa) * 100;

                        if (Wynik < 21)
                            opis = Math.Round(Wynik, 2) + "% ponizej normy";
                        else if (Wynik < 33)
                            opis = Math.Round(Wynik, 2) + "% norma";
                        else if (Wynik < 39)
                            opis = Math.Round(Wynik, 2) + "% wysoka";
                        else
                            opis = Math.Round(Wynik, 2) + "% bardzo wysoka";

                        return opis;
                    }
                }
                catch (FormatException)
                {
                    return "Błędne dane !";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(property);
                handler(this, e);
            }
        }

    }
}