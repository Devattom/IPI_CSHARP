

using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

// Combine proprement avec le dossier images
string imagesDirectoryInput = Path.Combine(baseDirectory, "images");
string imagesDirectoryOutput = Path.Combine(imagesDirectoryInput, "resized");
Directory.CreateDirectory(imagesDirectoryOutput);

var images = Directory.GetFiles(imagesDirectoryInput);

// ProcessImagesWithoutPerf(images);
ProcessImagesWithPerf(images);
void ProcessImagesWithoutPerf(string[] imagePath)
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

void ProcessImagesWithPerf(string[] imagePath)
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