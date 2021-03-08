using System;

namespace InviteToKill.Models
{
    public class InviteToKillModel
    {
        public long InviteToKillId { get; set; }
        public long InviteToKillStateId { get; set; }
        public string UniqueReference { get; set; }
        public long ShopId { get; set; }
        public long OrderId { get; set; }
        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerInformation { get; set; }
        public long InvitationUserId { get; set; }
        public DateTime InvitationDateTime { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
        public bool AllowPaymentCost { get; set; }
    }

}
