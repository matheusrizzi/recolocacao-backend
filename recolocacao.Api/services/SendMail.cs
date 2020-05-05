using System.Net;
using System.Net.Mail;

namespace recolocacao.Api.services
{
    public class SendMail
    {
        public void Send(
                            string mailAddressDestiny,
                            string subjectDescription,
                            string bodyMail, 
                            bool isHtml)
        {
            SmtpClient client = new SmtpClient("smtp.kinghost.net");
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.Credentials = new NetworkCredential("account@recolocacao.com.br", "r3c0l0c4c40#34");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("account@recolocacao.com.br");
            mailMessage.To.Add(mailAddressDestiny);
            mailMessage.Body = bodyMail;
            mailMessage.IsBodyHtml = isHtml;
            mailMessage.Subject = subjectDescription;
            client.Send(mailMessage);
        }
    }
}