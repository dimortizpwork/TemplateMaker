using System;
using InviteToKill.Models;
using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace InviteToKill.Host.Lambda.Put.Presentations
{
    public class PathRequestModel: IRequestModel
    {
        public long InviteToKillId { get; set; }
       
        public void Validate()
        {
            if (InviteToKillId <= 0)
                throw new InvalidRequestException("Field InviteToKillId invalid or not defined");
        }
    }
}
