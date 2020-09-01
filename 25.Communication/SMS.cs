using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace _25.Communication
{
    public class SMS
    {
        
        const string accountSid = "AC13a3b7a5c36b4b137a521a5f807cf450";
        const string authToken = "8d36234f4a8fd9524082b967a79aec5e";

        public static void NotifyAdminAboutNewBooking(string body)
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber("+14438427299"),
                to: new Twilio.Types.PhoneNumber("+27638386747")
            );
        }
    }
}