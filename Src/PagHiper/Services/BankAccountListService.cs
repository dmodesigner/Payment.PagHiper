using PagHiper.Constants;
using PagHiper.Entities;
using PagHiper.Interfaces.Services;
using System.Text.Json;
using System.Text;

namespace PagHiper.Services
{
    public class BankAccountListService : IBankAccountListService
    {
        private async Task<BankAccount?> Consult(string token, string apiKey)
        {
            var r = new BankAccount();

            using (var httpClient = new HttpClient())
            {
                var request = new
                {
                    token,
                    apiKey
                };

                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(UrlConstant.BankAccountList, content);

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    throw new ArgumentException("Ocorreu um erro ao criar o boleto dentro do Pag Hiper.");

                var result = await response.Content.ReadAsStringAsync();

                dynamic? obj = JsonSerializer.Deserialize<BankAccount>(result);

                if (obj == null)
                    throw new ArgumentException("Não foi possível obter as informações do boleto. O retorno está vazio.");

                r = obj.BankAccount;
            }

            return r;
        }

        public BankAccount BankAccountList(string token, string apiKey)
        {
            #region Validate

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("Você deve informar o token.", nameof(token));

            if (string.IsNullOrEmpty(apiKey) || apiKey.Length < 3)
                throw new ArgumentNullException("Você deve informar a api key valida.", nameof(apiKey));

            #endregion

            var r = Consult(token, apiKey).Result;

            if (r == null)
                throw new ArgumentException("Não foi possível obter a lista de contas bancarias.");

            return r;
        }
    }
}
