using Domain.Requests;
using Domain.Responses;

namespace Domain.Interfaces.Services
{
    public interface IBankSlipService
    {
        BankSlipResponse CreateBankSlip(BankSlipRequest request);

        BankSlipResponse ConsultBankSlip(ConsultRequest request);
    }
}
