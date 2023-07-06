namespace BaseBackend.Contract.Dto;

public class FirstDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<AEnum> Adads { get; set; }
    public string Resultttt { get; set; }
}

public enum AEnum
{
    one = 1,
    doo = 2,
    see = 3,
}
