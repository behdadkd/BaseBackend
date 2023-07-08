using BaseBackend.Domain.Filght;

namespace BaseBackend.Domain.Financial;
public class Payment : FullEntity<Guid>
{
    public Payment() => Id = Guid.NewGuid();
    public long Code { get; set; }

    public double Amount { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}
