using PagHiper.Requests;
using PagHiper.Responses;

namespace PagHiper.Interfaces.Services
{
    public interface IBankSlipService
    {
        BankSlipResponse CreateBankSlip(BankSlipRequest request);

        BankSlipResponse ConsultBankSlip(ConsultRequest request);

        BankSlipResponse CancelBankSlip(ConsultRequest request);
    }
}
