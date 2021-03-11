using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Seasons.MT5Ctas
{
    public class Correo
    {
        Logger.LogHandler lh = new Logger.LogHandler();

        public String enviaCorreoMt5(string login, string pass, string servidor, string correo)
        {
            lh = new Logger.LogHandler();
            lh.LogMessageToFile("enviaCorreoMt5 : entre");
            lh.LogMessageToFile("login : " + login);
            lh.LogMessageToFile("pass : " + pass);
            lh.LogMessageToFile("servidor : " + servidor);
            lh.LogMessageToFile("correo : " + correo);
            String mensaje = null;
            string cuerpo = emailresponseMt5(login, pass, servidor);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("accounts@gntcapital.com");
                mail.To.Add(correo.Trim());
                mail.Subject = "Acceso a Metatrader";
                mail.IsBodyHtml = true;
                mail.Body = cuerpo;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("accounts@gntcapital.com", "Notelasabes.1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mensaje = "Enviado";
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
                lh.LogMessageToFile("enviaCorreoMt5 mensaje :" + mensaje);
                return mensaje;
            }
        }

        public String enviaCorreoMt5Pass(string login, string pass, string servidor, string correo)
        {
            lh = new Logger.LogHandler();
            lh.LogMessageToFile("enviaCorreoMt5 : entre");
            lh.LogMessageToFile("login : " + login);
            lh.LogMessageToFile("pass : " + pass);
            lh.LogMessageToFile("servidor : " + servidor);
            lh.LogMessageToFile("correo : " + correo);
            String mensaje = null;
            string cuerpo = changePass(login, pass, servidor);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("accounts@gntcapital.com");
                mail.To.Add(correo.Trim());
                mail.Subject = "Acceso a Metatrader., su contraseña fue actualizada";
                mail.IsBodyHtml = true;
                mail.Body = cuerpo;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("accounts@gntcapital.com", "Notelasabes.1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mensaje = "Enviado";
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
                lh.LogMessageToFile("enviaCorreoMt5 mensaje :" + mensaje);
                return mensaje;
            }
        }

        private string emailresponseMt5(string login, string pass, string servidor)

        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/cuentaLive.html")))

            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{servidor}", servidor);
            body = body.Replace("{idLogin}", login);
            body = body.Replace("{Contrasena}", pass);

            return body;

        }

        private string changePass(string login, string pass, string servidor)

        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/cambioContrasena.html")))

            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{servidor}", servidor);
            body = body.Replace("{idLogin}", login);
            body = body.Replace("{pass}", pass);

            return body;

        }
    }
}
