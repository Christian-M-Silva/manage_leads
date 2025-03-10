using Manage_lead.Models;

namespace Manage_lead.Interfaces.IServices
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadEntity>> GetLeadsService(StatusLead.StatusLeadEnum status);
        Task<LeadEntity> AcceptLeadService(Guid id, double price);
    }
}
