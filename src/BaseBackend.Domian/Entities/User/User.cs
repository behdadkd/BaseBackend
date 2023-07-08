namespace BaseBackend.Domain.User;
public class User : FullEntity<Guid>
{
    public User() => Id = Guid.NewGuid();
    public long Code { get; set; }


    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string NormalizedUserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string NormalizedEmail { get; set; } = default!;
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();


    //[Projectable]
    public string FullName => FirstName + " " + LastName;
}
