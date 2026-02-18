namespace ZooKeeper.Classe;

public class Elephant : Animal
{
    public Elephant(string name, string location)
    {
        Name = name;
        Location = location;
    }
    
    public override string MakeSound() { return "Trumpet!";}
}