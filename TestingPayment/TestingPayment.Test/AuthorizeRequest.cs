namespace TestingPayment.Test
{
    public class AuthorizeRequest
    {
        public GetCardDetails CardDetails { get; set; }
        public TransactionDetails TransactionDetails { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
        public RecurringDetails RecurringDetails { get; set; }
        public FraudDetails FraudDetails { get; set; }
        public ThreeDSecureDetails ThreeDSecureDetails { get; set; }
    }

    public class GetCardDetails
    {

    }

    public class TransactionDetails
    {
    }

    public class ShippingDetails
    {
    }

    public class BillingDetails
    {

    }
    public class RecurringDetails
    {

    }

    public class FraudDetails
    {

    }

    public class ThreeDSecureDetails
    {

    }
}
