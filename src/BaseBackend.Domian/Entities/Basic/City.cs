namespace BaseBackend.Domain.Basic;
public class City : FullEntity<int>
{
    public string Name { get; set; } = default!;
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
