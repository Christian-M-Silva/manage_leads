using Manage_lead.Models;

namespace Manage_lead.Interfaces.IRepositories
{
    public interface ILeadRepository
    {
        Task<IEnumerable<LeadEntity>> GetLeadsRepository(StatusLead.StatusLeadEnum status);
        Task<LeadEntity> AcceptLeadRepository(Guid id);
        Task<LeadEntity> DescountLeadRepository(Guid id, double price);
        Task<LeadEntity> IsExistLead(Guid id);


    }
}
