using InviteToKill.Models;

namespace InviteToKill.Repositories
{
    public interface IInviteToKillRepository
    {
        InviteToKillModel Get(long InviteToKillId);
        int Post(InviteToKillModel model);
        void Put(long InviteToKillId, InviteToKillModel model);
        void Delete(long InviteToKillId);
        void Send(long InviteToKillId, long UserId, string Recipient);
    }
}
