using BaseBackend.Contract.Dto;
using BaseBackend.Domain;
using BaseBackend.Domian;

namespace BaseBackend.Application;

public class FirstService : IFirstService
{
    private readonly IGenericRepository<FirstEntity> _firstEntityRepo;
    public FirstService(IGenericRepository<FirstEntity> firstEntityRepo)
    {
        _firstEntityRepo = firstEntityRepo;
    }
    public async Task<string> EchoAsync(string name, CancellationToken cancellationToken)
    {
        return $"hi {name}";
    }

    public async Task<FirstDto> ReadAsync(long id, CancellationToken cancellationToken)
    {
        var result = await _firstEntityRepo.FindAsync(id);
        ArgumentNullException.ThrowIfNull(result);
        return new FirstDto(result.Id, result.Name);
    }

    public async Task<long> SaveAsync(string name, CancellationToken cancellationToken)
    {
        var result = await _firstEntityRepo.AddAsync(new()
        {
            Name = name
        }, cancellationToken);
        await _firstEntityRepo.SaveChangesAsync(cancellationToken);
        return result.Id;
    }
}
