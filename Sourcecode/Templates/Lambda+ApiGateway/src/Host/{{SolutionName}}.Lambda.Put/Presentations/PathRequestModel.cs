using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Lambda.Put.Presentations
{
    public class PathRequestModel: IRequestModel
    {
        public long {{Model.KeyField.Name}} { get; set; }
       
        public void Validate()
        {
            if ({{Model.KeyField.Name}} <= 0)
                throw new InvalidRequestException("Field {{Model.KeyField.Name}} invalid or not defined");
        }
    }
}
