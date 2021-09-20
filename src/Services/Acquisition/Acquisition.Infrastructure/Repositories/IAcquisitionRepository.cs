using Acquisition.Domain.Entities;

namespace Acquisition.Infrastructure.Repositories
{
    public interface IAcquisitionRepository
    {
        Task<PaymentCheckout> GetAcquisitionCheckout(string userName);
        Task<PaymentCheckout> UpdateAcquisitionCheckout(PaymentCheckout acquisitionCheckout);
        Task DeleteAcquisitionCheckout(string userName);

    }
}