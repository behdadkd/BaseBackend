namespace BaseBackend.Application
{
    public class FirstService : IFirstService
    {
        public async Task<string> FirstMethod(string name)
        {
            return $"hi {name}";
        }
    }
}
