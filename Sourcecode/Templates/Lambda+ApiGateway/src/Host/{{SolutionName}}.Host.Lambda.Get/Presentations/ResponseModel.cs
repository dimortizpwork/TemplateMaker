using System;

namespace {{SolutionName}}.Host.Lambda.Get.Presentations
{
    public class ResponseModel
    {
        public long {{ModelName}}Id { get; set; }
        public long {{ModelName}}StateId { get; set; }
        public string UniqueReference { get; set; }
        public long ShopId { get; set; }
        public long CurrencyId { get; set; }
        public double Amount { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public long OrderId { get; set; }
        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerInformation { get; set; }
        public long InvitationUserId { get; set; }
        public DateTime InvitationDateTime { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
        public bool AllowPaymentCost { get; set; }
        public bool LeavePaymentMethod { get; set; }
        public bool SendSMS { get; set; }
        public string SMSNumber { get; set; }
    }
}
