using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Interfaces.IServices;
using Manage_lead.Models;
using Manage_lead.Services.SendGrid;

namespace Manage_lead.Services
{
    public class LeadService(ILeadRepository leadRepository, SendGridService sendGridService) : ILeadService
    {
        private readonly ILeadRepository _leadRepository = leadRepository;
        private readonly SendGridService _sendGridService = sendGridService;

        public async Task<LeadEntity> AcceptLeadService(Guid id, double price)
        {
            if (price > 500)
            {
                await _leadRepository.DescountLeadRepository(id, price);
            }
            LeadEntity lead = await _leadRepository.AcceptLeadRepository(id);
            await _sendGridService.SendEmailAsync("vendas@test.com", "Accept Lead");

            return lead;
        }

        public async Task<LeadEntity> DeclineLeadService(Guid id)
        {
            return await _leadRepository.DeclineLeadRepository(id);
        }

        public async Task<IEnumerable<LeadEntity>> GetLeadsService(StatusLead.StatusLeadEnum status)
        {
            return await _leadRepository.GetLeadsRepository(status);
        }
    }
}
