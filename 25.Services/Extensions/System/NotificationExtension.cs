using System.Linq;
using _25.Communication;
using _25.Core.System;
using _25.Data.Context;
using _25.Data.Entities;

namespace _25.Services.Extensions.System
{
    public static class NotificationExtension
    {
        public static void AddPsychologistNotification(int newPsychologistId)
        {
            var context = new ApplicationDbContext();
            var toPsychologist = context.Psychologists.Find(newPsychologistId);


            var HTMLMessageToPsychologist = $"Hello! Your account has been created, Here are your login details: <br/><br/>"
                          + "Username: " + toPsychologist.EmailAddress + "<br/><br/"
                          + "Temporary Password: " + toPsychologist.GeneratedPassword +
                          " <br/><br/>You will have to generate a new password when you login<br/><br/> " +
                          "Thanks,<br/>" +
                          "The Caleni Practice Team";
            var planTextMessage = "Here are your login details, Username: "
                                  + toPsychologist.EmailAddress +
                                  ", Password: " + toPsychologist.GeneratedPassword;

            var SMSTextToSuperAdmin = "New Psychologist Added";


            Email.SendNewAccountEmail(toPsychologist.EmailAddress, toPsychologist.FullName, HTMLMessageToPsychologist, planTextMessage);
            SMS.NotifyAdminAboutNewBooking(SMSTextToSuperAdmin);



        }

        public static void ResentAddPsychologistNotification(int newPsychologistId)
        {
            var context = new ApplicationDbContext();
            var toPsychologist = context.Psychologists.Find(newPsychologistId);


            var htmlMessageToPsychologist = @"Hello! Your account has been created, Here are your login details: <br/><br/>"
                                            + "Username: " + toPsychologist.EmailAddress + "<br/><br/>" + "Temporary Password: " + toPsychologist.GeneratedPassword +
                                            " <br/><br/>You will have to generate a new password when you login<br/><br/> " +
                                            "Thanks,<br/>" +
                                            "The Caleni Practice Team";

            var planTextMessage = "Here are your login details, Username: "
                                  + toPsychologist.EmailAddress +
                                  ", Password: " + toPsychologist.GeneratedPassword;

            var SMSTextToSuperAdmin = "Psychologist Email Resent";

            AuditLogExtenstion.LogActivity("System", SupportedLogOperation.Create, "Resend psychologist email");
            Email.SendNewAccountEmail(toPsychologist.EmailAddress, toPsychologist.FullName, htmlMessageToPsychologist, planTextMessage);
            SMS.NotifyAdminAboutNewBooking(SMSTextToSuperAdmin);



        }

        public static void NewPatientAlert(ApplicationUser user)
        {

            var emailTo = "mankgwanyane@tlaka.xyz";
            var emailName = "Mankgwanyane";
            var htmlMessageToPsychologist = @"Hello! New Patient has started the account creation process, Here are their details: <br/><br/>"
                                            + "Email: " + user.Email + "<br/><br/>" + "Cellphone Number: " + user.PhoneNumber +
                                            " <br/><br/> " +
                                            "Thanks,<br/>" +
                                            "The Caleni Practice System";

            var planTextMessage = " New Patient has started the account creation process, Here are their details: "
                                  + "Email: " + user.Email +" Cellphone Number: " + user.PhoneNumber;

            var SMSTextToSuperAdmin = "New patient has started the account creation process.";

            AuditLogExtenstion.LogActivity("System", SupportedLogOperation.Create, "New patient has started the account creation process.");
            Email.SendNewAccountEmail(emailTo, emailName, htmlMessageToPsychologist, planTextMessage);
            SMS.NotifyAdminAboutNewBooking(SMSTextToSuperAdmin);
        }
    }
}