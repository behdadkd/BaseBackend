namespace BaseBackend.Domain.Filght;

public class Reservation : FullEntity<Guid>
{
    public Reservation() => Id = Guid.NewGuid();
    public long Code { get; set; }

    public Guid UserId { get; set; }
    public User.User User { get; set; }
    public Guid FlightId { get; set; }
    public Flight Flight { get; set; }
}
