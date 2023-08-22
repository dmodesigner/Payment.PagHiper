using Domain.Requests;
using Domain.Responses;

namespace Domain.Interfaces.Services
{
    public interface IBankSlipService
    {
        CreateBankSlipResponse CreateBankSlip(BankSlipRequest request);
    }
}
