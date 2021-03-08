using SuperNiceProject.Oracle.Adapter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using SuperNiceProject.Models;

namespace SuperNiceProject.Oracle.Adapter.Dto
{
    public class OrderDto
    {
        public long OrderId { get; set; }
        public string UniqueReference { get; set; }

        public static OrderDto FromModel(OrderModel model)
        {
            return new OrderDto {
                OrderId = model.OrderId,
                UniqueReference = model.UniqueReference
            };
        }

        public OrderModel ToModel()
        {
            return new OrderModel {
                OrderId = OrderId,
                UniqueReference = UniqueReference
            };
        }
    }
}
