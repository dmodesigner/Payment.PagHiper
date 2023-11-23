using PagHiper.Entities;

namespace PagHiper.Interfaces.Services
{
    public interface IBankSlipService
    {
        BankSlipResponse CreateBankSlip(BankSlipRequest request);

        BankSlipResponse ConsultBankSlip(Consult request);

        BankSlipResponse CancelBankSlip(Consult request);
    }
}
