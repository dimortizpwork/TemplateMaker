using InviteToKill.Oracle.Adapter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using InviteToKill.Models;

namespace InviteToKill.Oracle.Adapter.Dto
{
    public class InviteToKillDto
    {
        public long InviteToKillId { get; set; }
        public long InviteToKillStateId { get; set; }
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
        public string AllowPaymentCost { get; set; }
        public string LeavePaymentMethod { get; set; }
        public string SendSMS { get; set; }
        public string SMSNumber { get; set; }

        public static InviteToKillDto FromModel(InviteToKillModel model)
        {
            return new InviteToKillDto {
                InviteToKillId = model.InviteToKillId,
                InviteToKillStateId = model.InviteToKillStateId,
                UniqueReference = model.UniqueReference,
                ShopId = model.ShopId,
                CurrencyId = model.CurrencyId,
                Amount = model.Amount,
                ExpiryDateTime = model.ExpiryDateTime,
                OrderId = model.OrderId,
                InvoiceId = model.InvoiceId,
                CustomerId = model.CustomerId,
                CustomerInformation = model.CustomerInformation,
                InvitationUserId = model.InvitationUserId,
                InvitationDateTime = model.InvitationDateTime,
                ConfirmationDateTime = model.ConfirmationDateTime,
                AllowPaymentCost = OracleHelper.GetOracleBoolean(model.AllowPaymentCost),
                LeavePaymentMethod = OracleHelper.GetOracleBoolean(model.LeavePaymentMethod),
                SendSMS = OracleHelper.GetOracleBoolean(model.SendSMS),
                SMSNumber = model.SMSNumber
            };
        }

        public InviteToKillModel ToModel()
        {
            return new InviteToKillModel {
                InviteToKillId = InviteToKillId,
                InviteToKillStateId = InviteToKillStateId,
                UniqueReference = UniqueReference,
                ShopId = ShopId,
                CurrencyId = CurrencyId,
                Amount = Amount,
                ExpiryDateTime = ExpiryDateTime,
                OrderId = OrderId,
                InvoiceId = InvoiceId,
                CustomerId = CustomerId,
                CustomerInformation = CustomerInformation,
                InvitationUserId = InvitationUserId,
                InvitationDateTime = InvitationDateTime,
                ConfirmationDateTime = ConfirmationDateTime,
                AllowPaymentCost = OracleHelper.GetBoolean(AllowPaymentCost),
                LeavePaymentMethod = OracleHelper.GetBoolean(LeavePaymentMethod),
                SendSMS = OracleHelper.GetBoolean(SendSMS),
                SMSNumber = SMSNumber
            };
        }
    }
}
