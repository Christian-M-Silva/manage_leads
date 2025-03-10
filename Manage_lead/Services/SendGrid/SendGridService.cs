using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace Manage_lead.Services.SendGrid
{
    public class SendGridService
    {
        private readonly string _apiKey;

        public SendGridService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"] ?? throw new ArgumentNullException("SendGrid API Key is missing!");
        }

        public async Task SendEmailAsync(string toEmail, string toName)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("christian.silva@igma.do", "Example User");
                var subject = "Sending with Twilio SendGrid is Fun";
                var to = new EmailAddress(toEmail, toName);
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
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
