using PagHiper.Constants;
using PagHiper.Entities;

namespace PagHiper.Services;

public static class BankAccountListService
{
    public static BankAccount BankAccountList(string token, string apiKey)
    {
        #region Validate

        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException("Você deve informar o token.", nameof(token));

        if (string.IsNullOrWhiteSpace(apiKey) || apiKey.Length < 3)
            throw new ArgumentNullException("Você deve informar a api key valida.", nameof(apiKey));

        #endregion

        var request = new
        {
            token,
            apiKey
        };

        var r = new HttpClientService<BankAccountListRequest, object>().PostAsync(UrlConstant.BankAccountList, request).Result;

        if (r == null)
            throw new ArgumentException("Não foi possível obter a lista de contas bancarias.");

        return r.BankAccount ?? new BankAccount();
    }
}
