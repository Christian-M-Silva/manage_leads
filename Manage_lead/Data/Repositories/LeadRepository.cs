using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage_lead.Data.Repositories
{
    public class LeadRepository(MyDbContext context) : ILeadRepository
    {
        private readonly MyDbContext _context = context;

        public async Task<IEnumerable<LeadEntity>> GetLeadsRepository(StatusLead.StatusLeadEnum status)
        {
            try
            {
                IEnumerable<LeadEntity> leads = await _context.Leads
                    .Where(lead => lead.Status == status)
                    .ToListAsync();

                return leads;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                throw new ApplicationException("Error searching for leads.", ex);
            }
        }
    }
}
