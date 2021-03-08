using InviteToKill.Models;

namespace InviteToKill.UseCases.Interfaces
{
    public interface ICreateInviteToKill
    {
        int Create(InviteToKillModel model);
    }
}
