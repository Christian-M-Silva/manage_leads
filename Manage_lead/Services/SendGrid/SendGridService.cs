using SendGrid;
using SendGrid.Helpers.Mail;
using Manage_lead.Models;


namespace Manage_lead.Services.SendGrid
{
    public class SendGridService(IConfiguration configuration)
    {
        private readonly string _apiKey = configuration["SendGrid:ApiKey"] ?? throw new ArgumentNullException("SendGrid API Key is missing!");

        public async Task SendEmailAsync(string toEmail, LeadEntity lead)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("christian.silva@igma.do", "Christian Silva");
                var subject = $"Leed acepted - {lead.FirstName} {lead.Surname}";
                var to = new EmailAddress(toEmail, $"Vendas");
                var plainTextContent = "Leed acepted!";
                var htmlContent = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                line-height: 1.6;
            }}
            .container {{
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                border: 1px solid #ddd;
                border-radius: 10px;
                background-color: #f9f9f9;
            }}
            h2 {{
                color: #333;
            }}
            p {{
                margin: 5px 0;
            }}
            .highlight {{
                font-weight: bold;
                color: #007bff;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h2>Lead Information</h2>
            <p><strong>First Name:</strong> <span class='highlight'>{lead.FirstName}</span></p>
            <p><strong>Surname:</strong> <span class='highlight'>{lead.Surname}</span></p>
            <p><strong>Suburb:</strong> <span class='highlight'>{lead.Suburb}</span></p>
            <p><strong>Category:</strong> <span class='highlight'>{lead.Category}</span></p>
            <p><strong>Description:</strong> {lead.Description}</p>
            <p><strong>Price:</strong> ${lead.Price:N2}</p>
            <p><strong>Phone:</strong> {lead.Phone}</p>
            <p><strong>Email:</strong> {lead.Email}</p>
            <p><strong>Date:</strong> {lead.CreatedAt}</p>
            <p><strong>Price Discount:</strong> ${lead.PriceDiscount:N2}</p>
        </div>
    </body>
    </html>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Body.ReadAsStringAsync();
                    throw new Exception($"Failed to send email. Status Code: {response.StatusCode}, Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw new ApplicationException("Error sending email", ex);
            }
        }

    }
}
