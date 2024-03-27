using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Envio_Email
    {
        private MailMessage email;
        private SmtpClient server;

        public Envio_Email()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pato157programacion@gmail.com", "hjpk ghvm cpda czlu\r\n");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Registro</h1> <br> Hola! Tu registro fue exitoso!";
            email.Body = cuerpo;
        }

        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
