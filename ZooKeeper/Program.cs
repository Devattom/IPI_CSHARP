// See https://aka.ms/new-console-template for more information

using ZooKeeper.Classe;

var cage1 = new Cage("Cage 1", 1);
var cage2 = new Cage("Cage 2", 2);
var cage3 = new Cage("Cage 3", 3);
var zoo = new Zoo();
zoo.Cages.Add(cage1);
zoo.Cages.Add(cage2);
zoo.Cages.Add(cage3);

Console.WriteLine("Hello, ZooKeeper!");

Console.WriteLine("Ajoutons une giraffe, donnez lui un nom :");

var giraffeName = Console.ReadLine();

if (giraffeName == null) {return;}

Console.WriteLine($"Nom de la giraffe : {giraffeName}");

Console.WriteLine("Elle ira dans la cage 1");

zoo.AddAnimal(new Giraffe(giraffeName, cage1.Name));

Console.WriteLine("Ajoutons un éléphant, donnez lui un nom :");

var elephantName = Console.ReadLine();

if (elephantName == null) {return;}

Console.WriteLine($"Nom de l'éléphant : {elephantName}");

Console.WriteLine("il va dans la cage 2");

zoo.AddAnimal(new Elephant(elephantName, cage2.Name));

Console.WriteLine("Ajoutons un singe, donnez lui un nom :");

var monkeyName = Console.ReadLine();

if (monkeyName == null) {return;}

Console.WriteLine($"Nom du singe : {monkeyName}");

Console.WriteLine("il va dans la cage 3");

zoo.AddAnimal(new Monkey(monkeyName, cage3.Name));

Console.WriteLine("Voici la liste des animaux :");

zoo.PrintAnimals();

Console.WriteLine("Voulez-vous bouger un animal ?");

Console.WriteLine("1. oui");
Console.WriteLine("2. non");


var choice = Console.ReadLine();
if (choice == null || choice == "2")
{
    Console.WriteLine("On ferme ciao !");
    return;
}

Console.WriteLine("Quel animal voulez-vous bouger ?");




