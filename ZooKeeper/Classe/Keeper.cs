using ZooKeeper.Enum;

namespace ZooKeeper.Classe;

public class Keeper : Worker
{
    public WorksTypeList Job { get; set; }
    public int Id { get; set; }
    public bool IsWorking { get; set; }
    public Keeper(int id)
    {
        Job = WorksTypeList.Keeper;
        Id = id;
    }
   
    public DateTime StartWork()
    {
        IsWorking = true;
        return DateTime.Now;
    }
    
    public DateTime EndWork()
    {
        IsWorking = false;
        return DateTime.Now;
    }
}