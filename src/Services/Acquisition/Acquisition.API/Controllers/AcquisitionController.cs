using Acquisition.API.GrpcService;
using Acquisition.Domain.Entities;
using Acquisition.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Acquisition.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AcquisitionController : ControllerBase
    {
        private readonly IAcquisitionRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public AcquisitionController(IAcquisitionRepository repository, DiscountGrpcService discounGrpcService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._discountGrpcService = discounGrpcService ?? throw new ArgumentNullException(nameof(discounGrpcService));
        }

        [HttpGet("{userName}", Name = "GetAcquisitionCheckout")]
        [ProducesResponseType(typeof(PaymentCheckout), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentCheckout>> GetAcquisitionCheckout(string userName)
        {
            var acquisitionCheckout = await _repository.GetAcquisitionCheckout(userName);
            //if the first time add item, we should create a new empty
            return Ok(acquisitionCheckout ?? new PaymentCheckout(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentCheckout), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentCheckout>> UpdateAcquisitionCheckout([FromBody] PaymentCheckout paymentCheckout)
        {

            //Communicate with Discount.Grpc
            foreach (var item in paymentCheckout.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                item.Price -= coupon.Amount;
            }

            return Ok(await _repository.UpdateAcquisitionCheckout(paymentCheckout));
        }

        [HttpDelete("{userName}", Name = "DeleteAcquisitionCheckout")]
        [ProducesResponseType(typeof(PaymentCheckout), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAcquisitionCheckout(string userName)
        {
            await _repository.DeleteAcquisitionCheckout(userName);
            return Ok();
        }

    }
}
