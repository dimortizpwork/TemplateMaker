using InviteToKill.Models;
using InviteToKill.Repositories;
using InviteToKill.UseCases.Interfaces;

namespace InviteToKill.UseCases
{
    public class UpdateInviteToKill : IUpdateInviteToKill
    {
        private readonly IInviteToKillRepository _InviteToKillRepository;
        public UpdateInviteToKill(IInviteToKillRepository InviteToKillRepository)
        {
            _InviteToKillRepository = InviteToKillRepository;
        }

        public void Update(long InviteToKillId, InviteToKillModel model)
        {
            _InviteToKillRepository.Put(InviteToKillId, model);
        }
    }
}
