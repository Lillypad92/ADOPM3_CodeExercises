using System.Text.Json;
using System.Xml.Linq;
using Helpers;
namespace _05_Wines_Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Wines with Interface and Text Streams!");

        var rnd = new csSeedGenerator();
        WineCellar wineCellar = new WineCellar("Martin's cellar");
        

        #region Add wines to the winecellar
        for (int i = 0; i < 50; i++)
        {
            wineCellar.Add(new csWine().Seed(rnd));
            wineCellar.Add(new stWine().Seed(rnd));
        }
        #endregion

        #region write cellar to console
        Console.WriteLine($"\nWinecellar: {wineCellar.Name}");
        Console.WriteLine($"Nr of bottles: {wineCellar.Count}");
        Console.WriteLine($"Value of winecellar: {wineCellar.Value:N2} Sek");

        var hilo = wineCellar.WineHiLoCost();
        Console.WriteLine($"\nMost expensive wine:\n{hilo.hicost}");
        Console.WriteLine($"Least expensive wine:\n{hilo.locost}");

        Console.WriteLine("\nMyCellar");
        Console.WriteLine(wineCellar);
        #endregion

        #region write cellar to disk
        //Your code

        using (Stream s = File.Create(fname("winecellar.json")))
        using (TextWriter writer = new StreamWriter(s)) 
        {
            var json = JsonSerializer.Serialize<WineCellar>(wineCellar, new JsonSerializerOptions() { WriteIndented = true });
            writer.Write(json);
        }

            string filename = fname("Martins winecellar");

        using (FileStream fs = File.Create(filename))
        using (TextWriter writer = new StreamWriter(fs)) 
        {
            writer.WriteLine(filename);
            writer.WriteLine(wineCellar);
        }

        using (FileStream fs = File.OpenRead(fname("Martins winecellar")))
        using (TextReader reader = new StreamReader(fs)) 
        {
            Console.WriteLine(reader.ReadLine());
        }
        #endregion

    }
    static string fname(string name)
    {
        var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        documentPath = Path.Combine(documentPath, "ADOP", "M3_Exercises");
        if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
        return Path.Combine(documentPath, name);
    }
}

/* Exercises
1. Write code to save your winecellar to disk, using TextWriter
2. Change to store you cellar in MyDocuments
3. Open you text file in Word
*/