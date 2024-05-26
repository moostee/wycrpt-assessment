using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Domain;
using TransactionService.Application.UseCases.GetAddressTransactionHistory;

namespace TransactionService.Api.Controllers
{
    public class TransactionController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("v1/block/{blockNumber}/address/{address}/currency/{currency}")]
        public async Task<IActionResult> GetTransactionHistoryAsync(string blockNumber, string address, string currency)
        {
            if (string.IsNullOrWhiteSpace(blockNumber) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(currency))
                return BadRequest(ServiceResponse<string>.Failure("block number, address, currency is required"));
            return Ok(await _mediator.Send(new GetAddressTransactionHistoryQuery(blockNumber, address, currency)));
        }
    }
}