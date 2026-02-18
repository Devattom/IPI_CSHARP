namespace ZooKeeper.Classe;

public class Giraffe : Animal
{
    public Giraffe(string name, string location)
    {
        Name = name;
        Location = location;
    }
    
    public override string MakeSound()
    {
        return "Neigh!";
    }
}