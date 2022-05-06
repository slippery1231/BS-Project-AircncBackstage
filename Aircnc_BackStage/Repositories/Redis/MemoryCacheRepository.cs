using Aircnc_BackStage.Repositories.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Repositories.Redis
{
    public class MemoryCacheRepository: IMemoryCacheRepository
    {
        private readonly IDistributedCache _iDisributedCache;
        public MemoryCacheRepository(IDistributedCache iDisributedCache)
        {
            _iDisributedCache = iDisributedCache;
        }
        public T Get<T>(string key) where T : class
        {
            return ByteArrayToOBj<T>(_iDisributedCache.Get(key));
        }

        public void Remove(string key)
        {
            _iDisributedCache.Remove(key);
        }

        public void Set<T>(string key, T value) where T : class
        {
            _iDisributedCache.Set(key, ObjectToByteArray(value), new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            });
        }
        private byte[] ObjectToByteArray(object obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }
        private T ByteArrayToOBj<T>(byte[] bytes) where T : class
        {
            return bytes is null ? null : JsonSerializer.Deserialize<T>(bytes);
        }
    }
}
