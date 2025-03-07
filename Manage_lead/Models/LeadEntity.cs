using static Manage_lead.Models.StatusLead;



namespace Manage_lead.Models
{
    public class LeadEntity : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required string Suburb { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public required StatusLeadEnum Status { get; set; }
        public required string Phone { get; set; } 
        public required string Email { get; set; }
    }
}