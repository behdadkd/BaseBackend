using BaseBackend.Contract.Dto;

namespace BaseBackend.Application
{
    public interface IFirstService
    {
        Task<string> EchoAsync(string name, CancellationToken cancellationToken);
        Task<long> SaveAsync(string name, CancellationToken cancellationToken);
        Task<FirstDto> ReadAsync(long id, CancellationToken cancellationToken);
    }
}
