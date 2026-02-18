namespace ZooKeeper.Classe;

public class Zoo
{
    public List<Animal> Animals { get; set; }
    public List<Cage> Cages { get; set; }
    
    public Zoo()
    {
        Animals = new List<Animal>();
        Cages = new List<Cage>();
    }
    
    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }
    
    public void AddCage(Cage cage)
    {
        Cages.Add(cage);
    }
    
    public void RemoveAnimal(Animal animal)
    {
        Animals.Remove(animal);
    }
    public void RemoveCage(Cage cage)
    {
        Cages.Remove(cage);
    }
    public void PrintAnimals()
    {
        foreach (var animal in Animals)
        {
            Console.WriteLine(animal.Name);
        }
    }
    public void PrintCages()
    {
        foreach (var cage in Cages)
        {
            Console.WriteLine(cage.Name);
        }
    }
}