namespace BaseBackend.Domain.Filght;
public class Flight : FullEntity<Guid>
{
    public Flight() => Id = Guid.NewGuid();
    public long Code { get; set; }

    public string FlightNumber { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }


    public Guid DepartureAirportId { get; set; }
    public Airport DepartureAirport { get; set; } = default!;
    public Guid ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; } = default!;
    public Guid AircraftId { get; set; }
}
