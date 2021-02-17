using System;

namespace ExampleService.Core.Models
{
    public class Order
    {
            public int OrderId { get; set; }
            public string IPAddress { get; set; }
            public int CustomerId { get; set; }
            public int ShopOutletId { get; set; }
            public int PaymentMethodId { get; set; }
            public int CurrencyId { get; set; }
            public int Discount { get; set; }
            public int PaymentDiscount { get; set; }
            public int DiscountVatId { get; set; }
            public DateTime OrderDateTime { get; set; }
            public int UserId { get; set; }
            public int ShipmentAddressId { get; set; }
            public int InvoiceAddressId { get; set; }
            public int ShipmentMethodId { get; set; }
            public int PaymentCost { get; set; }
            public int PaymentCostVatId { get; set; }
            public int ShipmentCost { get; set; }
            public int ShipmentCostVatId { get; set; }
            public char VatFree { get; set; }
            public char Deleted { get; set; }
            public DateTime ShipDate { get; set; }
            public DateTime PickupDate { get; set; }
            public DateTime ExpireDate { get; set; }
            public char AllowPacking { get; set; }
            public int ShopOutletOrderId { get; set; }
            public string CustomerReference { get; set; }
            public int VatFreeReasonId { get; set; }
            public DateTime PickupReadyDateTime { get; set; }
            public int StockLocationIdx { get; set; }
            public DateTime PriorityPrepareDateTime { get; set; }
            public int OriginatingOrderId { get; set; }
            public DateTime CommunicatedDeliveryDate { get; set; }
            public int AssistUserId { get; set; }
            public int ShipmentCarrierIdx { get; set; }
            public int InvoiceDeliveryMethodId { get; set; }
            public DateTime StockClaimFromDate { get; set; }
            public string ReferrerId { get; set; }
            public int CartId { get; set; }
            public DateTime AllocationEndDateTime { get; set; }
            public string OrderLineHash { get; set; }
            public int ShoppingCartId { get; set; }
            public int CarrierDropOffLocationId { get; set; }
            public int ShipmentCarrierGroupId { get; set; }
            public int StockClusterId { get; set; }
            public int ForcedStockLocationId { get; set; }
            public int DeletedUserId { get; set; }
            public DateTime DeletedDateTime { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string IPV6Address { get; set; }
            public int ClosedCommunityDiscountId { get; set; }
            public string CustomerMessage { get; set; }
            public int ForcedShipmentCarrierGrpId { get; set; }
            public int LanguageId { get; set; }
            public int SalesChannelId { get; set; }
            public int VisitTimeslotId { get; set; }
            public DateTime LastModificationDateTime { get; set; }
            public string VatNumber { get; set; }
            public char VatNumberValid { get; set; }
            public int DeliveryPromiseId { get; set; }
    }
}
