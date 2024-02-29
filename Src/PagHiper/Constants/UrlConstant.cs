namespace PagHiper.Constants;

internal class UrlConstant
{
    public const string UrlBase = "https://api.paghiper.com/";

    public const string CreateBankSlip = UrlBase + "transaction/create/";
    public const string CancelBankSlip = UrlBase + "transaction/cancel/";
    public const string ConsultBankSlip = UrlBase + "transaction/status/";

    public const string Notification = UrlBase + "transaction/notification/";

    public const string BankAccountList = UrlBase + "bank_accounts/list/";
}
