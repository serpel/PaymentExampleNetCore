namespace TestingPayment.Test
{
    public class AuthorizeResponse
    {
        public CreditCardTransactionResult CreditCardTransactionResults { get; set; }
    }

    public class CreditCardTransactionResult
    {
        public string ResponseCode { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonCodeDescription { get; set; }
        public string AuthCode { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
