using InviteToKill.Repositories;
using InviteToKill.UseCases.Interfaces;

namespace InviteToKill.UseCases
{
    public class DeleteInviteToKill : IDeleteInviteToKill
    {
        private readonly IInviteToKillRepository _InviteToKillRepository;
        public DeleteInviteToKill(IInviteToKillRepository InviteToKillRepository)
        {
            _InviteToKillRepository = InviteToKillRepository;
        }
        public void Delete(long InviteToKillId)
        {
            _InviteToKillRepository.Delete(InviteToKillId);
        }
    }
}
