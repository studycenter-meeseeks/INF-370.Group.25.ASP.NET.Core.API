using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace _25.Communication
{
    public static class Email
    {
        private const string ApiKey = "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";

        private static async Task ConfirmEmailTask(string toEmail, string toName, string confirmationLink)
        {
            var client = new SendGridClient(ApiKey);

            var from = new EmailAddress("support@celanipractice.co.za", "Celani Practice");
            var subject = "[Caleni Practice] Please confirm your email";

            var to = new EmailAddress(toEmail.ToString(), toName.ToString());
            var plainTextContent = "Email Confirmation Link: " + confirmationLink + " ";
            var htmlContent = "Hello! Once you've confirmed your email address you'll be able to access all to the system, click on the link below to confirm your email address. <br/><br/>" + confirmationLink + " <br/><br/>If you have any questions, simply reply to this email. We'd love to help. <br/><br/> Thanks,<br/>The Caleni Practice Team";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
        }
      
        public static void SendAccountConfirmationEmail(string toEmail, string toName, string confirmationLink)
        {
            ConfirmEmailTask(toEmail, toName, confirmationLink).Wait();
        }

        private static async Task NewAccount(string toEmail, string toName, string HTMLMessage, string plainTextMessage)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("support@celanipractice.co.za", "Celani Practice");
            var subject = "[Caleni Practice] Account Creation";

            var to = new EmailAddress(toEmail.ToString(), toName.ToString());
            var plainTextContent = plainTextMessage;
            var htmlContent = HTMLMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);


        }

        public static void SendNewAccountEmail(string toEmail, string toName, string HTMLMessage, string plainTextMessage)
        {
            NewAccount(toEmail, toName, HTMLMessage, plainTextMessage).Wait();
        }

    }
}