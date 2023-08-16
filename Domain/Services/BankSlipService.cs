using Domain.Interfaces.Services;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Services
{
    public class BankSlipService : IBankSlip
    {
        private List<string> Validate(BankSlipRequest request)
        {
            var returns = new List<string>();

            if (request == null)
                returns.Add("O objeto para criação do boleto não pode ser nulo");

            //Implementar as validações necessarias aqui

            return returns;
        }

        public CreateBankSlipResponse CreateBankSlip(BankSlipRequest request)
        {
            var errors = Validate(request);
            var bankSlipResponse = new CreateBankSlipResponse();

            if (errors.Count() == 0)
            {
                //Chama a API para criação do boleto
                //Retorna os dados do boleto
            }

            return bankSlipResponse;
        }
    }
}
