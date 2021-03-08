using InviteToKill.Models;

namespace InviteToKill.UseCases.Interfaces
{
    public interface IGetInviteToKill
    {
        InviteToKillModel Get(long InviteToKillId);
    }
}
