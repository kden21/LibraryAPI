namespace Domain;

public record LibraryEntity : Entity
{
    public string Name { get; set; }
    public string Address { get; set; } 
    public List<BookEntity> Books{ get; set; }
    public List<HumanEntity> Humans { get; set; } = new List<HumanEntity>();
}