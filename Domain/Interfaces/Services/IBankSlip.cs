using Domain.Requests;
using Domain.Responses;

namespace Domain.Interfaces.Services
{
    public interface IBankSlip
    {
        CreateBankSlipResponse CreateBankSlip(BankSlipRequest request);
    }
}
