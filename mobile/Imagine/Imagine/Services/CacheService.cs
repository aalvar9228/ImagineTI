using Imagine.Interfaces;
using MonkeyCache.FileStore;
using System;
using System.Threading.Tasks;

namespace Imagine.Services
{
    public class CacheService : ICacheService
    {
        public CacheService()
        {
            Barrel.ApplicationId = "QxXVeOP4ww";
        }

        public Task<T> GetAsync<T>(string key, bool ignoreExpiration = true)
        {
            if (!ignoreExpiration && Barrel.Current.IsExpired(key))
                return Task.FromResult(default(T));

            return Task.FromResult(Barrel.Current.Get<T>(key));
        }

        public Task SetAsync<T>(string key, T value, int? cacheTime = null)
        {
            Barrel.Current.Add(key, value, TimeSpan.FromMinutes(cacheTime ?? 0));
            return Task.CompletedTask;
        }
    }
}
