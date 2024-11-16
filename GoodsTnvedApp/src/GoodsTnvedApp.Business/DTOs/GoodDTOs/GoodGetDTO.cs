namespace GoodsTnvedApp.Business.DTOs.GoodDTOs;

public class GoodGetDTO
{
    public int ID { get; set; }
    public string Code { get; set; }
    public string? Defis { get; set; }
    public string Name { get; set; }
    public int ParentId { get; set; }
    public IEnumerable<GoodGetDTO> Children { get; set; }
}