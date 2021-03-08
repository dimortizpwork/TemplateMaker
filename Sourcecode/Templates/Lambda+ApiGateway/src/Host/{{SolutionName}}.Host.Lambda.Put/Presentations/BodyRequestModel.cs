using System;
using {{SolutionName}}.Models;
using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Host.Lambda.Put.Presentations
{
    public class BodyRequestModel: IRequestModel
    {
        public long InviteToPayStateId { get; set; }
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

        public InviteToPayModel ToModel()
        {
            return new InviteToPayModel {
                InviteToPayStateId = InviteToPayStateId
            };
        }

        public void Validate()
        {
            if (OrderId <= 0 && InvoiceId <= 0)
                throw new InvalidRequestException("At least one field (OrderId or InvoiceId) should be setted.");
        }
    }
}
