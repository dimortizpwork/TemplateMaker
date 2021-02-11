using System;

namespace Gimme.Core.Models
{
    public class PendingPayment
    {
        public long PendingPaymentId { get; set; }
        public long PaymentMethodId { get; set; }
        public DateTime PendingPaymentDatetime { get; set; }
        public long CurrencyId { get; set; }
        public double Amount { get; set; }
        public double Amountlocal { get; set; }
        public double RoundAmount { get; set; }
        public long UserId { get; set; }
        public long? PaymentId { get; set; }
        public long? InvoiceId { get; set; }
        public long? OrderId { get; set; }
        public long? CustomerId { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentsubReference { get; set; }
        public long? StockLocationId { get; set; }
        public long? InvitetopayId { get; set; }
        public long? PaymentTransactionId { get; set; }
        public DateTime LastModificationDatetime { get; set; }
    }

}
