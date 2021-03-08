using Lambda.Base.Exceptions;
using Lambda.Base.Presentations;

namespace InviteToKill.Host.Lambda.Get.Presentations
{
    public class RequestModel: IRequestModel
    {
        public long InviteToKillId { get; set; }

        public void Validate()
        {
            if (InviteToKillId <= 0)
                throw new InvalidRequestException("Field InviteToKillId invalid or not defined");
        }
    }
}
