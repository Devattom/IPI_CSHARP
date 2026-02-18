namespace ZooKeeper.Classe;

public class Cage
{
    public string Name { get; set; }
    public int Id { get; set; }
    
    public Cage(string name, int id)
    {
        Name = name;
        Id = id;
    }
}