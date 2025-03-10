using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage_lead.Data.Repositories
{
    public class LeadRepository(MyDbContext context) : ILeadRepository
    {
        private readonly MyDbContext _context = context;

        public async Task<LeadEntity> AcceptLeadRepository(Guid id)
        {
            try
            {
                LeadEntity lead = await IsExistLead(id);
                lead.Status = StatusLead.StatusLeadEnum.Accepted;

                await _context.SaveChangesAsync();

                return lead;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                throw new ApplicationException("Error accepting lead", ex);
            }
        }

        public async Task<LeadEntity> DeclineLeadRepository(Guid id)
        {
            try
            {
                LeadEntity lead = await IsExistLead(id);
                lead.Status = StatusLead.StatusLeadEnum.Rejected;

                await _context.SaveChangesAsync();

                return lead;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                throw new ApplicationException("Error Rejected lead", ex);
            }
        }

        public async Task<LeadEntity> DescountLeadRepository(Guid id, double price)
        {
            try
            {
                LeadEntity lead = await IsExistLead(id);

                double discount = price * 0.10;
                double priceWhitDiscount = price - discount;

                lead.PriceDiscount = priceWhitDiscount;

                await _context.SaveChangesAsync();

                return lead;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                throw new ApplicationException("Error performing lead discount", ex);
            }
        }

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

        public async Task<LeadEntity> IsExistLead(Guid id)
        {
            LeadEntity? lead = await _context.Leads
                  .FirstOrDefaultAsync(lead => lead.Id == id);

            return lead ??throw new ApplicationException("Lead not found");
        }
    }
}
