using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcern.Comunication
{
    public class MailIslemleri
    {


        IConfiguration _configuration;
        public MailIslemleri(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Send(string to, string title, string message)
        {
            #region Eski
            var email = _configuration.GetSection("email").Value;

            MailMessage mailMessage = new MailMessage(email, to);
            mailMessage.Subject = title;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;


            client.Credentials = new NetworkCredential(_configuration.GetSection("email").Value, _configuration.GetSection("sifre").Value);



            client.Host = _configuration.GetSection("host").Value ?? "";
            //client.Port = 465;
            client.Port = int.Parse(_configuration.GetSection("port").Value ?? "");

            client.EnableSsl = false; // Şirket hesabından ma*/il gönderme işleminde hata almamak için false yapıyoruz.


            client.Send(mailMessage);





            #endregion

            //MailMessage mailMessage = new MailMessage("info@skardesign.de", to);
            //mailMessage.Subject = title;
            //mailMessage.Body = message;
            //mailMessage.IsBodyHtml = true;

            //// SMTP
            //// POP 

            //SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new NetworkCredential("info@skardesign.de", "Sinan25901478");

            //client.Host = "mail5013.site4now.net";
            ////client.Port = 465;
            //client.Port = 8889;

            //client.EnableSsl = false; // Şirket hesabından ma*/il gönderme işleminde hata almamak için false yapıyoruz.
            //client.Send(mailMessage);

            return true;


        }

        public bool Send(string to, string title, string message, params string[] Attachments)
        {
            // 

            var email = _configuration.GetSection("email").Value;

            MailMessage mailMessage = new MailMessage(email, to);
            mailMessage.Subject = title;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            foreach (var item in Attachments)
            {
                mailMessage.Attachments.Add(new Attachment(item));
            }


            SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;


            client.Credentials = new NetworkCredential(_configuration.GetSection("email").Value, _configuration.GetSection("sifre").Value);

            client.Host = _configuration.GetSection("host").Value ?? "";
            //client.Port = 465;
            client.Port = int.Parse(_configuration.GetSection("port").Value ?? "");

            client.EnableSsl = true; // Şirket hesabından ma*/il gönderme işleminde hata almamak için false yapıyoruz.

            client.Send(mailMessage);

            return true;

        }


    }
}
