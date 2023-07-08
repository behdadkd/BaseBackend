using BaseBackend.Domain.Basic;

namespace BaseBackend.Domain.Filght;

public class Airport : FullEntity<Guid>
{
    public Airport() => Id = Guid.NewGuid();
    public long Code { get; set; }

    public string Name { get; set; } = default!;
    public Guid CityId { get; set; }
    public City City { get; set; }
}
