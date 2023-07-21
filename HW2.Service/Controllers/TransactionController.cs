using AutoMapper;
using HW2.Base.BaseResponse;
using HW2.Data.Repository.TransactionRepository;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Schema;

namespace HW2.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionRepository repository,IMapper mapper)
        {
            _repository= repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ApiResponse<List<TransactionResponse>> GetByParameter(int AccountNumber, decimal MinAmountCredit, decimal MaxAmountCredit, decimal MinAmountDebit, decimal MaxAmountDebit, DateTime BeginDate,DateTime EndDate, string ReferenceNumber)
        {
           var transactionList= _repository.GetByParameter(x => x.AccountNumber == AccountNumber &&
            x.CreditAmount >= MinAmountCredit && x.CreditAmount <= MaxAmountCredit &&
            x.DebitAmount >= MinAmountDebit && x.DebitAmount <= MaxAmountDebit &&
            x.TransactionDate >= BeginDate && x.TransactionDate <= EndDate &&
            x.ReferenceNumber == ReferenceNumber);

            var transactionResponse = _mapper.Map<List<TransactionResponse>>(transactionList);
            return new ApiResponse<List<TransactionResponse>>(transactionResponse);
        }
    }
}
