using System.Threading.Tasks;

namespace Imagine.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, bool ignoreExpiration = true);
        Task SetAsync<T>(string key, T value, int? cacheTime = null);
    }
}
