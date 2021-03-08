using InviteToKill.Models;
using InviteToKill.Repositories;
using InviteToKill.UseCases.Interfaces;

namespace InviteToKill.UseCases
{
    public class CreateInviteToKill : ICreateInviteToKill
    {
        private readonly IInviteToKillRepository _InviteToKillRepository;
        public CreateInviteToKill(IInviteToKillRepository InviteToKillRepository)
        {
            _InviteToKillRepository = InviteToKillRepository;
        }

        public void Send(InviteToKillModel model)
        {
            _InviteToKillRepository.Put(model);
        }
    }
}
