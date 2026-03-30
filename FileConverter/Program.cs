using System.Xml.Linq;
using FileConverter.Class;
using Newtonsoft.Json;

Console.WriteLine("JSON TO XML");

var choice = "";
List<Movie> dataToConvert = null;
var moviesJson = File.ReadAllText(@$"{Directory.GetCurrentDirectory()}/JSON/listFilm.json");
var movies = JsonConvert.DeserializeObject<List<Movie>>(moviesJson);

if (movies == null)
{
    Console.WriteLine("Erreur de lecture du fichier");
    return; 
}

while (choice != "1" && choice != "2" && choice != "oui" && choice != "non")
{
    Console.WriteLine("Voulez-vous rechercher et trier ?");
    Console.WriteLine("1. oui");
    Console.WriteLine("2. non");
    
    choice = Console.ReadLine();
}

if (choice == "oui" || choice == "1")
{
    Console.WriteLine("Indiquer votre rechercher : ");
    var searchParam = Console.ReadLine();
    
    while (searchParam == null) { searchParam = Console.ReadLine(); }
    
    dataToConvert = (from movie in movies
        where movie.Title.Contains(searchParam, StringComparison.OrdinalIgnoreCase)
        select movie).ToList();

    foreach (var movie in dataToConvert)
    {
        Console.WriteLine(movie.Title);
    }
    
    Console.WriteLine("Voulez vous trier le fichier ?");
    Console.WriteLine("1. oui");
    Console.WriteLine("2. non");
    
    var sortChoice = Console.ReadLine();
    if (sortChoice != null && (sortChoice == "oui" || sortChoice == "1"))
    {
        var sortOn = "";
        while (sortOn != "1" && sortOn != "2" && sortOn != "3")
        {
            Console.WriteLine("Trier part :");
            Console.WriteLine("1. titre du film");
            Console.WriteLine("2. date de sortie");
            Console.WriteLine("3. producteur");
            
            sortOn = Console.ReadLine();
        }
        Console.WriteLine("Option choisie :" + sortOn);
        
        switch (sortOn)
        {
            case "1":
                dataToConvert = dataToConvert.OrderBy(movie => movie.Title).ToList();
                break;
            case "2":
                dataToConvert = dataToConvert.OrderBy(movie => movie.ReleaseYear).ToList();
                break;
            case "3":
                dataToConvert = dataToConvert.OrderBy(movie => movie.Producer).ToList();
                break;
        }

        foreach (var movie in dataToConvert)
        {
            Console.WriteLine($"{movie.Title} - {movie.ReleaseYear} - {movie.Producer}");
        }
    }
}

Console.WriteLine("Quels champs voulez-vous exporter ?");
Console.WriteLine("1. Titre");
Console.WriteLine("2. Date de sortie");
Console.WriteLine("3. Producteur");
Console.WriteLine("4. Tout");
Console.WriteLine("Entrez les numéros séparés par une virgule (ex: 1,2) :");

var fieldsToExport = Console.ReadLine();

while (fieldsToExport == null) { fieldsToExport = Console.ReadLine(); }

var exportAllFields = fieldsToExport.Contains('4');

Console.WriteLine("On converti en XML");

dataToConvert = dataToConvert == null ? movies : dataToConvert;

var xml = new XElement("Root", 
    from movie in dataToConvert 
    select new XElement("Movie", 
        exportAllFields || fieldsToExport.Contains('1') ? new XAttribute("Title", movie.Title) : null, 
        exportAllFields || fieldsToExport.Contains('2') ? new XAttribute("ReleaseYear", movie.ReleaseYear) : null, 
        exportAllFields || fieldsToExport.Contains('3') ? new XAttribute("Producer", movie.Producer) : null
        )
    );

Console.WriteLine("Le fichier XML est :");
Console.WriteLine(xml);

var outputDir = Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}/XML");

// s'enregistre dans bin/Debug/net10.0/XML
xml.Save($@"{outputDir}/listFilm.xml");