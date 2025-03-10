using Manage_lead.Models;

namespace Manage_lead.Interfaces.IRepositories
{
    public interface ILeadRepository
    {
        Task<IEnumerable<LeadEntity>> GetLeadsRepository(StatusLead.StatusLeadEnum status);
        Task<IEnumerable<LeadEntity>> AcceptLeadRepository(Guid id);

    }
}
