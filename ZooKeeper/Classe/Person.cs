namespace ZooKeeper.Classe;

public abstract class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public string FullName() { return $"{FirstName} {LastName}";}
}