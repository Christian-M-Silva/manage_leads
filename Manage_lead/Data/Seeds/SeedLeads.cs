using Manage_lead.Models;

namespace Manage_lead.Data.Seeds
{
    public class SeedLeads
    {
        public static void Initialize(IServiceProvider serviceProvider, MyDbContext context)
        {
            if (context.Leads.Any())
            {
                return; 
            }

            context.Leads.AddRange(
                new LeadEntity
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Suburb = "New York",
                    Category = "Real Estate",
                    Description = "Buying a new house",
                    Price = 250000,
                    Status = StatusLead.StatusLeadEnum.New, 
                    Phone = "123-456-7890",
                    Email = "johndoe@example.com",
                    CreatedAt = DateTime.UtcNow,
                    PriceDiscount = 0,
                    UpdateAt = DateTime.UtcNow
                },
                new LeadEntity
                {
                    FirstName = "Bruce",
                    Surname = "Wayne",
                    Suburb = "Gotham",
                    Category = "Buy",
                    Description = "Buying a new cave",
                    Price = 450000,
                    Status = StatusLead.StatusLeadEnum.New,
                    Phone = "123-456-7890",
                    Email = "wayne@example.com",
                    CreatedAt = DateTime.UtcNow,
                    PriceDiscount = 0,
                    UpdateAt = DateTime.UtcNow
                },
                new LeadEntity
                {
                    FirstName = "Tony",
                    Surname = "Stark",
                    Suburb = "New York",
                    Category = "Buy",
                    Description = "Buying a new tower",
                    Price = 450000,
                    Status = StatusLead.StatusLeadEnum.New,
                    Phone = "123-456-7890",
                    Email = "stark@example.com",
                    CreatedAt = DateTime.UtcNow,
                    PriceDiscount = 0,
                    UpdateAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();  // Salva as mudanças no banco
        }
    }
}
