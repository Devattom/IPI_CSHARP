namespace ZooKeeper.Classe;

public class Monkey : Animal
{
    public Monkey(string name, string location)
    {
        Name = name;
        Location = location;
    }
    
    public override string MakeSound()
    {
        return "Squeak!";
    }
}