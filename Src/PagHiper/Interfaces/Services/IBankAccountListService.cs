using PagHiper.Entities;

namespace PagHiper.Interfaces.Services;

public interface IBankAccountListService
{
    BankAccount BankAccountList(string token, string apiKey);
}
