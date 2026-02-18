using ZooKeeper.Enum;

namespace ZooKeeper.Classe;

public interface Worker
{
    public WorksTypeList Job { get; set; }
    public int Id { get; set; }
    
    public DateTime StartWork();
    
    public DateTime EndWork();
}