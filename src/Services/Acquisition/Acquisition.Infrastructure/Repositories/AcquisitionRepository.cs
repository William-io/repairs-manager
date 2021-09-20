using Acquisition.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Acquisition.Infrastructure.Repositories
{
    public class AcquisitionRepository : IAcquisitionRepository
    {
        private readonly IDistributedCache _redisCache;

        public AcquisitionRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<PaymentCheckout> GetAcquisitionCheckout(string userName)
        {
            var acquisitionCheckout = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(acquisitionCheckout))
            {
                return null;
            }

            //JSON converting
            return JsonConvert.DeserializeObject<PaymentCheckout>(acquisitionCheckout);
        }


        public async Task<PaymentCheckout> UpdateAcquisitionCheckout(PaymentCheckout acquisitionCheckout)
        {
            await _redisCache.SetStringAsync(acquisitionCheckout.UserName, JsonConvert.SerializeObject(acquisitionCheckout));
            return await GetAcquisitionCheckout(acquisitionCheckout.UserName);
        }


        public async Task DeleteAcquisitionCheckout(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

      
     
    }
}
