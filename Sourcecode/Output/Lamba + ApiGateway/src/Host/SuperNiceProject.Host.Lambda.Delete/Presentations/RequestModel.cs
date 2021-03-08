using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace SuperNiceProject.Host.Lambda.Delete.Presentations
{
    public class RequestModel: IRequestModel
    {
        public long NiceProjectId { get; set; }

        public void Validate()
        {
            if (NiceProjectId <= 0)
                throw new InvalidRequestException("Field NiceProjectId invalid or not defined");
        }

    }
}
