using InviteToKill.Models;

namespace InviteToKill.UseCases.Interfaces
{
    public interface IUpdateInviteToKill
    {
        void Update(long InviteToKillId, InviteToKillModel model);
    }
}
