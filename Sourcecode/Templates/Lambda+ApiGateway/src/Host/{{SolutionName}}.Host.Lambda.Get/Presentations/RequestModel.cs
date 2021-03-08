using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Host.Lambda.Get.Presentations
{
    public class RequestModel: IRequestModel
    {
        public long {{ModelName}}Id { get; set; }

        public void Validate()
        {
            if ({{ModelName}}Id <= 0)
                throw new InvalidRequestException("Field {{ModelName}}Id invalid or not defined");
        }
    }
}
