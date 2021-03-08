using InviteToKill.Models;
using InviteToKill.Repositories;
using InviteToKill.UseCases.Interfaces;

namespace InviteToKill.UseCases
{
    public class GetInviteToKill : IGetInviteToKill
    {
        private readonly IInviteToKillRepository _InviteToKillRepository;
        public GetInviteToKill(IInviteToKillRepository InviteToKillRepository)
        {
            _InviteToKillRepository = InviteToKillRepository;
        }

        public InviteToKillModel Get(long InviteToKillId)
        {
            return _InviteToKillRepository.Get(InviteToKillId);
        }
    }
}
