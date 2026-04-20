using System.Diagnostics;
using Newtonsoft.Json;
using Optimiser.Class;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Net.Http;

using HttpClient client = new HttpClient();
string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

string dlDirectory = Path.Combine(baseDirectory, "dl");
Directory.CreateDirectory(dlDirectory);

string imagesDirectoryInput = Path.Combine(baseDirectory, "images");
string imagesDirectoryOutput = Path.Combine(imagesDirectoryInput, "resized");
Directory.CreateDirectory(imagesDirectoryOutput);


Console.WriteLine("Récupération des images depuis :");
Console.WriteLine("1 - Files");
Console.WriteLine("2 - JSON");

var types = Console.ReadLine();

if (types == null) {return;}


if (types == "1")
{
    var images = Directory.GetFiles(imagesDirectoryInput).ToList();
    ProcessImagesWithoutPerf(images);
    // ProcessImagesWithPerf(images);
}
else
{
    string jsonPath = Path.Combine(baseDirectory, "urls.json");
    
    if (File.Exists(jsonPath))
    {
        var jsonFile = File.ReadAllText(jsonPath);
        var images = JsonConvert.DeserializeObject<JsonImageUrls>(jsonFile);

        if (images != null)
        {
            
        }
        Console.WriteLine(images);
    }
    else
    {
        Console.WriteLine($"Erreur : Le fichier est introuvable à l'emplacement : {jsonPath}");
    }
}


void ProcessImagesWithoutPerf(List<string> imagePath)
{
    var sw = Stopwatch.StartNew();
    var i = 0;
    foreach (var file in imagePath)
    {
        var sw2 = Stopwatch.StartNew();
        using (var image = Image.Load(file))
        {
            var image1080 = image.Clone(ctx => ctx.Resize(1920, 1080));
            var image720 = image.Clone(ctx => ctx.Resize(1280, 720));
            var image480 = image.Clone(ctx => ctx.Resize(854, 480));
            
            
            image1080.SaveAsWebp(imagesDirectoryOutput + "/1080_" + Path.GetFileName(file));
            image720.SaveAsWebp(imagesDirectoryOutput + "/720_" + Path.GetFileName(file));
            image480.SaveAsWebp(imagesDirectoryOutput + "/480_" + Path.GetFileName(file));
            i++;
        }
        sw2.Stop();
        Console.WriteLine($"Temps de conversion image {i} : {sw2.ElapsedMilliseconds} ms");
        sw2.Restart();
    }
    sw.Stop();
    Console.WriteLine("Temps de convertion total :" + sw.ElapsedMilliseconds + " ms");
}

void ProcessImagesWithPerf(List<string> imagePath)
{
    var sw = Stopwatch.StartNew();

    Parallel.ForEach(imagePath, (file, state, i) =>
    {
        var sw2 = Stopwatch.StartNew();
        using (var image = Image.Load(file))
        {
            var image1080 = image.Clone(ctx => ctx.Resize(1920, 1080));
            var image720 = image.Clone(ctx => ctx.Resize(1280, 720));
            var image480 = image.Clone(ctx => ctx.Resize(854, 480));
            
            
            image1080.SaveAsWebp(imagesDirectoryOutput + "/1080_" + Path.GetFileName(file));
            image720.SaveAsWebp(imagesDirectoryOutput + "/720_" + Path.GetFileName(file));
            image480.SaveAsWebp(imagesDirectoryOutput + "/480_" + Path.GetFileName(file));
        }
        Console.WriteLine($"Temps de conversion image {i} : {sw2.ElapsedMilliseconds} ms");
    });
    sw.Stop();
    Console.WriteLine("Temps de convertion total :" + sw.ElapsedMilliseconds + " ms");
}

void dlImagesFromJsonWithoutPerf(JsonImageUrls imageUrls, string dlDirectory)
{
    if (imageUrls == null) { return; }
    List<string> downloadedPaths = new List<string>();
    
    var sw = Stopwatch.StartNew();
    var i = 0;
    foreach (var url in imageUrls.Images)
    {
        var sw2 = Stopwatch.StartNew();
        try
        {
            // On extrait le nom du fichier depuis l'URL (ex: photo.jpg)
            string fileName = Path.GetFileName(new Uri(url).LocalPath);
            string destinationPath = Path.Combine(dlDirectory, fileName);

            Console.WriteLine($"Téléchargement de : {url}...");
                
            // Téléchargement des octets de l'image
            byte[] imageBytes = await client.GetByteArrayAsync(url);
                
            // Écriture sur le disque
            await File.WriteAllBytesAsync(destinationPath, imageBytes);
                
            downloadedPaths.Add(destinationPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur sur l'URL {url} : {ex.Message}");
        }
        
        sw2.Stop();
        Console.WriteLine($"Temps de conversion image {i} : {sw2.ElapsedMilliseconds} ms");
        sw2.Restart();
    }
    sw.Stop();
    Console.WriteLine("Temps de convertion total :" + sw.ElapsedMilliseconds + " ms");
}

void ProcessImagesFromJsonWithPerf(List<string> imagePath)
{
    var sw = Stopwatch.StartNew();

    Parallel.ForEach(imagePath, (file, state, i) =>
    {
        var sw2 = Stopwatch.StartNew();
        using (var image = Image.Load(file))
        {
            var image1080 = image.Clone(ctx => ctx.Resize(1920, 1080));
            var image720 = image.Clone(ctx => ctx.Resize(1280, 720));
            var image480 = image.Clone(ctx => ctx.Resize(854, 480));
            
            
            image1080.SaveAsWebp(imagesDirectoryOutput + "/1080_" + Path.GetFileName(file));
            image720.SaveAsWebp(imagesDirectoryOutput + "/720_" + Path.GetFileName(file));
            image480.SaveAsWebp(imagesDirectoryOutput + "/480_" + Path.GetFileName(file));
        }
        Console.WriteLine($"Temps de conversion image {i} : {sw2.ElapsedMilliseconds} ms");
    });
    sw.Stop();
    Console.WriteLine("Temps de convertion total :" + sw.ElapsedMilliseconds + " ms");
}