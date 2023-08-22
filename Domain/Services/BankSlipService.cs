﻿using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Requests;
using Domain.Responses;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Domain.Services
{
    public class BankSlipService : IBankSlipService
    {
        private readonly UrlModel _url;

        public BankSlipService(IOptions<UrlModel> url) => _url = url.Value;

        private void Validate(BankSlipRequest request)
        {
            if (request == null)
                throw new ArgumentException("O objeto para criação do boleto não pode ser nulo");

            if (string.IsNullOrEmpty(request.ApiKey) || request.ApiKey.Length < 4 || request.ApiKey.Substring(0, 4) != "apk_")
                throw new ArgumentException("A chave de API não pode ser nula ou vazia. Ou esta invalida.");

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

            foreach (var item in request.Items)
            {
                if (string.IsNullOrEmpty(item.ItemId))
                    throw new ArgumentException("O ID do item não pode ser nulo ou vazio.");

                if (string.IsNullOrEmpty(item.Description))
                    throw new ArgumentException("A descrição do item não pode ser nula ou vazia.");

                if (item.PriceCents < 1)
                    throw new ArgumentException("O preço do item não pode ser menor que 1.");

                if (item.Quantity < 1)
                    throw new ArgumentException("A quantidade do item não pode ser menor que 1.");
            }
        }

        private async Task<CreateBankSlipResponse> Create(BankSlipRequest request)
        {
            var r = new CreateRequestResponse();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_url.CreateBankSlip, content);

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    throw new ArgumentException("Ocorreu um erro ao criar o boleto dentro do Pag Hiper.");

                var result = await response.Content.ReadAsStringAsync();

                r = JsonSerializer.Deserialize<CreateRequestResponse>(result);
            }


            if (r == null)
                throw new ArgumentException("Não foi possível obter as informações do boleto. O retorno está vazio.");

            return r.CreateRequest;
        }

        public CreateBankSlipResponse CreateBankSlip(BankSlipRequest request)
        {
            Validate(request);

            return Create(request).Result;
        }
    }
}
