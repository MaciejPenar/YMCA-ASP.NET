namespace zaliczenie.Models
{
    public class Dane
    {
        public int Id { get; set; }
        public bool plec { get; set; }
        public double pas { get; set; }
        public double masa { get; set; }
        public DateTime data { get; set; }

        public Obliczenia zaliczenie { get { return new Obliczenia() { Plec = plec, Pas = pas, Masa = masa }; } }

    }
}
