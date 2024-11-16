using System.Text.Json.Serialization;

namespace GoodsTnvedApp.Core.Entities;

public class Good : BaseEntity
{
    public string Code { get; set; }
    public string? Defis { get; set; }
    public string Name { get; set; }
    public int ParentId { get; set; }
    public IEnumerable<Good> Children { get; set; }
    
    public override bool Equals(object obj)
    {
        return obj is Good other && ID == other.ID;
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}