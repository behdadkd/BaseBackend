using BaseBackend.Contract.Dto;
using BaseBackend.Domain;
using BaseBackend.Domian;
using System.Collections;
using System.Web;

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
        //var result = await _firstEntityRepo.FindAsync(id);
        var result = new FirstDto
        {
            Id = 12345,
            Name = "Behdad",
            Adads = new List<AEnum>() { AEnum.one, AEnum.doo }
        };
        result.Resultttt = GetQueryString(result);
        ArgumentNullException.ThrowIfNull(result);
        //return new FirstDto(result.Id, result.Name);
        return result;
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

    public string GetQueryString(object obj)
    {
        var result = new List<string>();
        var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
        foreach (var p in props)
        {
            var value = p.GetValue(obj, null);
            var enumerable = value as ICollection;
            if (enumerable != null)
            {
                result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
            }
            else
            {
                result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
            }
        }

        return string.Join("&", result.ToArray());
    }
}
