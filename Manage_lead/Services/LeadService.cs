using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Interfaces.IServices;
using Manage_lead.Models;

namespace Manage_lead.Services
{
    public class LeadService(ILeadRepository leadRepository) : ILeadService
    {
        private readonly ILeadRepository _leadRepository = leadRepository;

        public async Task<LeadEntity> AcceptLeadService(Guid id, double price)
        {
            if (price > 500)
            {
                await _leadRepository.DescountLeadRepository(id, price);
            }
            return await _leadRepository.AcceptLeadRepository(id);
        }

        public async Task<IEnumerable<LeadEntity>> GetLeadsService(StatusLead.StatusLeadEnum status)
        {
            return await _leadRepository.GetLeadsRepository(status);
        }
    }
}
