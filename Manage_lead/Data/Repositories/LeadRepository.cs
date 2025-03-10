using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Models;

namespace Manage_lead.Data.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        public Task<IEnumerable<LeadEntity>> GetLeads(StatusLead status)
        {
            throw new NotImplementedException();
        }
    }
}
