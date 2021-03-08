using System;
using {{SolutionName}}.Models;
using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Host.Lambda.Put.Presentations
{
    public class PathRequestModel: IRequestModel
    {
        public long {{Model.KeyField}} { get; set; }
       
        public void Validate()
        {
            if ({{Model.KeyField}} <= 0)
                throw new InvalidRequestException("Field {{Model.KeyField}} invalid or not defined");
        }
    }
}
