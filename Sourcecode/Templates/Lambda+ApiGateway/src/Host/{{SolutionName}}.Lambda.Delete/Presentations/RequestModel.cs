using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Lambda.Delete.Presentations
{
    public class RequestModel: IRequestModel
    {
        public long {{Model.KeyField.Name}} { get; set; }

        public void Validate()
        {
            if ({{Model.KeyField.Name}} <= 0)
                throw new InvalidRequestException("Field {{Model.KeyField.Name}} invalid or not defined");
        }

    }
}
