using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Host.Lambda.Delete.Presentations
{
    public class RequestModel: IRequestModel
    {
        public long {{Model.KeyField}} { get; set; }

        public void Validate()
        {
            if ({{Model.KeyField}} <= 0)
                throw new InvalidRequestException("Field {{Model.KeyField}} invalid or not defined");
        }

    }
}
