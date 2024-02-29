using PagHiper.Constants;
using PagHiper.Entities;

namespace PagHiper.Services;

public static class BankSlipService
{
    private static void ValidateApiKey(string? apiKey)
    {
        if (string.IsNullOrEmpty(apiKey) || apiKey.Length < 4 || apiKey.Substring(0, 4) != "apk_")
            throw new ArgumentException("A chave de API não pode ser nula ou vazia. Ou esta invalida.");
    }

    private static void Validate(BankSlipRequest request)
    {
        if (request == null)
            throw new ArgumentException("O objeto para criação do boleto não pode ser nulo");

        ValidateApiKey(request.ApiKey);

        if (string.IsNullOrEmpty(request.OrderId))
            throw new ArgumentException("O ID do pedido não pode ser nulo ou vazio.");

        if (string.IsNullOrEmpty(request.PayerEmail))
            throw new ArgumentException("O e-mail do pagador não pode ser nulo ou vazio.");

        if (string.IsNullOrEmpty(request.PayerName))
            throw new ArgumentException("O nome do pagador não pode ser nulo ou vazio.");

        if (string.IsNullOrEmpty(request.PayerCpfCnpj))
            throw new ArgumentException("O CPF/CNPJ do pagador não pode ser nulo ou vazio.");

        if (request.DaysDueDate < 1 || request.DaysDueDate > 400)
            throw new ArgumentException("A quantidade de dias para vencimento deve ser entre 1 e 400 dias.");

        if (request.Items == null || request.Items.Count == 0)
            throw new ArgumentException("A lista de itens não pode ser nula ou vazia.");

        var total = 0;

        foreach (var item in request.Items)
        {
            total += item.PriceCents * item.Quantity;

            if (string.IsNullOrEmpty(item.ItemId))
                throw new ArgumentException("O ID do item não pode ser nulo ou vazio.");

            if (string.IsNullOrEmpty(item.Description))
                throw new ArgumentException("A descrição do item não pode ser nula ou vazia.");

            if (item.PriceCents < 1)
                throw new ArgumentException("O preço do item não pode ser menor que 1.");

            if (item.Quantity < 1)
                throw new ArgumentException("A quantidade do item não pode ser menor que 1.");
        }

        if (total < 300)
            throw new ArgumentException("O valor total do boleto não pode ser menor que R$ 3,00.");
    }

    private static void ValidateQuery(Consult request)
    {
        if (request == null)
            throw new ArgumentException("O objeto para consultar o boleto não pode ser nulo");

        ValidateApiKey(request.ApiKey);

        if (string.IsNullOrEmpty(request.Token))
            throw new ArgumentException("O token do boleto não pode ser nulo ou vazio.");

        if (string.IsNullOrEmpty(request.TransactionId))
            throw new ArgumentException("O ID da transação não pode ser nulo ou vazio.");
    }

    public static BankSlipResponse CreateBankSlip(BankSlipRequest request)
    {
        Validate(request);

        var r = new HttpClientService<Create, BankSlipRequest>().PostAsync(UrlConstant.CreateBankSlip, request).Result;

        if (r == null)
            throw new ArgumentException("Não foi possível obter os dados do boleto.");

        return r.BankSlipResponse ?? new BankSlipResponse();
    }

    public static BankSlipResponse ConsultBankSlip(Consult request)
    {
        ValidateQuery(request);

        var r = new HttpClientService<Status, Consult>().PostAsync(UrlConstant.ConsultBankSlip, request).Result;

        if (r == null)
            throw new ArgumentException("Não foi possível consultar os dados do boleto.");

        return r.BankSlipResponse ?? new BankSlipResponse();
    }

    public static BankSlipResponse CancelBankSlip(Consult request)
    {
        ValidateQuery(request);

        request.Status = TransactionStatusConstant.Canceled;

        var r = new HttpClientService<Cancellation, Consult>().PostAsync(UrlConstant.CancelBankSlip, request).Result;

        if (r == null)
            throw new ArgumentException("Não foi possível obter o retorno do cancelamento do boleto.");

        return r.BankSlipResponse ?? new BankSlipResponse();
    }
}
