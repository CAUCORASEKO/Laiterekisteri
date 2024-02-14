using System;

// Yliluokka Device, joka sisältää yhteiset ominaisuudet kaikille laitteille
class Device
{
    public string Hankintapäivä { get; set; }
    public double Hankintahinta { get; set; }
    public int TakuuaikaKuukausina { get; set; }

    // Konstruktori, joka alustaa yhteiset ominaisuudet
    public Device(string hankintapäivä, double hankintahinta, int takuuaikaKuukausina)
    {
        Hankintapäivä = hankintapäivä;
        Hankintahinta = hankintahinta;
        TakuuaikaKuukausina = takuuaikaKuukausina;
    }

    // Metodi jäljellä olevan takuuajan selvittämiseksi
    public int JäljelläOlevaTakuuaikaKuukausina()
    {
        // Päivämäärän muuntaminen merkkijonosta DateTime-muotoon
        DateTime hankintapäivä = DateTime.Parse(Hankintapäivä);
        // Lisätään takuuaika hankintapäivään
        DateTime takuunPäättymispäivä = hankintapäivä.AddMonths(TakuuaikaKuukausina);
        // Etsitään ero nykyisen päivämäärän ja takuun päättymispäivän välillä kuukausina
        int jäljelläOlevaTakuuaika = (int)((takuunPäättymispäivä - DateTime.Now).TotalDays / 30);

        // Jos takuu on päättynyt, palauta 0
        if (jäljelläOlevaTakuuaika < 0)
            return 0;

        return jäljelläOlevaTakuuaika;
    }
}

// Luokka tietokoneille, periytetään Device-luokasta
class Computer : Device
{
    // Lisätään tietokoneille omia ominaisuuksia tarpeen mukaan
    public string Processor { get; set; }

    public Computer(string hankintapäivä, double hankintahinta, int takuuaikaKuukausina, string processor)
        : base(hankintapäivä, hankintahinta, takuuaikaKuukausina)
    {
        Processor = processor;
    }
}

// Luokka puhelimille, periytetään Device-luokasta
class Phone : Device
{
    // Lisätään puhelimille omia ominaisuuksia tarpeen mukaan
    public string OperatingSystem { get; set; }

    public Phone(string hankintapäivä, double hankintahinta, int takuuaikaKuukausina, string operatingSystem)
        : base(hankintapäivä, hankintahinta, takuuaikaKuukausina)
    {
        OperatingSystem = operatingSystem;
    }
}

// Luokka tableteille, periytetään Device-luokasta
class Tablet : Device
{
    // Lisätään tableteille omia ominaisuuksia tarpeen mukaan
    public string Model { get; set; }

    public Tablet(string hankintapäivä, double hankintahinta, int takuuaikaKuukausina, string model)
        : base(hankintapäivä, hankintahinta, takuuaikaKuukausina)
    {
        Model = model;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Luodaan esimerkki tietokoneesta
        Computer computer = new Computer("2022-01-01", 999.99, 24, "Intel i7");

        // Tulostetaan tietokoneen tiedot ja jäljellä oleva takuuaika
        Console.WriteLine("Tietokoneen tiedot:");
        Console.WriteLine("Hankintapäivä: " + computer.Hankintapäivä);
        Console.WriteLine("Hankintahinta: " + computer.Hankintahinta);
        Console.WriteLine("Takuuaika kuukausina: " + computer.TakuuaikaKuukausina);
        Console.WriteLine("Prosessori: " + computer.Processor);
        Console.WriteLine("Jäljellä oleva takuuaika kuukausina: " + computer.JäljelläOlevaTakuuaikaKuukausina());

        // Voit luoda vastaavasti puhelimille ja tableteille omat esimerkit ja tulostukset
    }
}
