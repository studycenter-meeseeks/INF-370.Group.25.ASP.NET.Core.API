using System.Linq;
using _25.Communication;
using _25.Data.Context;

namespace _25.Services.Extensions.System
{
    public static class NotificationExtension
    {
        public static void AddPsychologistNotification(int newPsychologistId)
        {
            var context = new ApplicationDbContext();
            var toPsychologist = context.Psychologists.Find(newPsychologistId);
            

            var HTMLMessageToPsychologist = $"Hello! Your account has been created, Here are your login details: <br/><br/>" 
                          +"Username: "+ toPsychologist.EmailAddress + "<br/><br/"
                          + "Temporary Password: "+ toPsychologist.GeneratedPassword + 
                          " <br/><br/>You will have to generate a new password when you login<br/><br/> " +
                          "Thanks,<br/>" +
                          "The Caleni Practice Team";
            var planTextMessage = "Here are your login details, Username: "
                                  + toPsychologist.EmailAddress +
                                  ", Password: " + toPsychologist.GeneratedPassword;

            var SMSTextToSuperAdmin = "New Psychologist Added";


            Email.SendNewAccountEmail(toPsychologist.EmailAddress,toPsychologist.FullName,HTMLMessageToPsychologist,planTextMessage);
            SMS.NotifyAdminAboutNewBooking(SMSTextToSuperAdmin);



        }
    }
}