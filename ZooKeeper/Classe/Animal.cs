namespace ZooKeeper.Classe;

public abstract class Animal : Keepable
{
    public string Name { get; set; }
    public string Location { get; set; }
    public Cage Cage { get; set; }
    
    public abstract string MakeSound();
    
    public string MoveCage(Animal animal, Cage cage)
    {
        this.Cage = cage;
        return "L'animal a été mis dans la cage " + cage.Name;
    }
}