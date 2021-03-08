using System;
using {{SolutionName}}.Models;
using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Host.Lambda.Put.Presentations
{
    public class BodyRequestModel: IRequestModel
    {
        public string UniqueReference { get; set; }

        public {{ModelName}}Model ToModel()
        {
            return new {{ModelName}}Model {
                UniqueReference = UniqueReference
            };
        }

        public void Validate()
        {
            /*if (OrderId <= 0 && InvoiceId <= 0)
                throw new InvalidRequestException("At least one field (OrderId or InvoiceId) should be setted.");*/
        }
    }
}
