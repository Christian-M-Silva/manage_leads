using Manage_lead.Models;

namespace Manage_lead.Interfaces.IRepositories
{
    public interface ILeadRepository
    {
        Task<IEnumerable<LeadEntity>> GetLeads(StatusLead.StatusLeadEnum status);
    }
}
