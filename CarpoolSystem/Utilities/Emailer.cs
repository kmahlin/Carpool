using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CarpoolSystem.Utilities
{
    public class Emailer
    {
        private MailMessage email;
        private SmtpClient smtp;

        public Emailer()
        {
            email = new MailMessage();
            smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials = new System.Net.NetworkCredential("361carpoolsystem@gmail.com", "361group5");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
        }

        public void RegistrationEmail(string userName, string email)
        {
            string subject = "Welcome to CarpoolSystem!";
            StringBuilder builder = new StringBuilder();
            builder.Append("Thank you for registering to Carpool System \n");
            builder.AppendFormat("Your user name is: " + userName);

            sendEmail(email,subject,builder.ToString());
 
        }

        public void ChangePasswordEmail(string userName, string email, string password)
        {
            string subject = "CarpoolSystem: YourPassword Has Changed!";
            StringBuilder builder = new StringBuilder();
            builder.Append("A password change has been initiated for your account: " + userName);
            builder.AppendFormat("\n");
            builder.Append("Your new Password is: " + password);
            builder.AppendFormat("\n");
            string link = "To log in, please got to : <a href='http://localhost:2825/'>CarpoolSystem.com</a> and proceed to" 
                            +" <a href='http://localhost:2825/account/ChangePassword'>this link</a> to change your password.";
            builder.Append(link);
            sendEmail(email, subject, builder.ToString());

        }

        public void sendEmail(string to, string subject ,string message)
        {
            email.From = new MailAddress("361CarpoolSystem@gmail.com", "CarpoolSystem");
            email.To.Add(new MailAddress(to));
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Body = String.Format(message);
            smtp.Send(email);
        }

    }
}