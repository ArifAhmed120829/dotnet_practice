namespace Ex.Domain.Entities
{


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate {get; set;}

    public DateTime? UpdatedDate {get; set;}
}

}
