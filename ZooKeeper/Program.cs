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

var giraffe = new Giraffe(giraffeName, cage1.Name);
giraffe.Cage = cage1;
zoo.AddAnimal(giraffe);

Console.WriteLine("Ajoutons un éléphant, donnez lui un nom :");

var elephantName = Console.ReadLine();

if (elephantName == null) {return;}

Console.WriteLine($"Nom de l'éléphant : {elephantName}");

Console.WriteLine("il va dans la cage 2");

var elephant = new Elephant(elephantName, cage2.Name);
elephant.Cage = cage2;
zoo.AddAnimal(elephant);

Console.WriteLine("Ajoutons un singe, donnez lui un nom :");

var monkeyName = Console.ReadLine();

if (monkeyName == null) {return;}

Console.WriteLine($"Nom du singe : {monkeyName}");

Console.WriteLine("il va dans la cage 3");

var monkey = new Monkey(monkeyName, cage3.Name);
monkey.Cage = cage3;
zoo.AddAnimal(monkey);

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

for (int i = 0; i < zoo.Animals.Count; i++)
{
    Console.WriteLine($"{i + 1}. {zoo.Animals[i].Name} (cage : {zoo.Animals[i].Cage.Name})");
}

var animalChoice = Console.ReadLine();
if (animalChoice == null) { return; }

if (!int.TryParse(animalChoice, out int animalIndex) || animalIndex < 1 || animalIndex > zoo.Animals.Count)
{
    Console.WriteLine("Choix invalide !");
    return;
}
animalIndex--;

var selectedAnimal = zoo.Animals[animalIndex];

Console.WriteLine($"Vous avez choisi : {selectedAnimal.Name}");
Console.WriteLine("Dans quelle cage voulez-vous le déplacer ?");

for (int i = 0; i < zoo.Cages.Count; i++)
{
    Console.WriteLine($"{i + 1}. {zoo.Cages[i].Name}");
}

var cageChoice = Console.ReadLine();
if (cageChoice == null) { return; }

if (!int.TryParse(cageChoice, out int cageIndex) || cageIndex < 1 || cageIndex > zoo.Cages.Count)
{
    Console.WriteLine("Choix invalide !");
    return;
}
cageIndex--;

var selectedCage = zoo.Cages[cageIndex];

var result = selectedAnimal.MoveCage(selectedCage);
Console.WriteLine(result);

Console.WriteLine("Voici la liste mise à jour :");
zoo.PrintAnimals();




