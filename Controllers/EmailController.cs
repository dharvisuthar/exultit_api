using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {


        [HttpGet]
        public String Get()
        {
            return "OK";
        }

       
        [Route("SendMail")]
        [HttpPost]
        public ActionResult SendMail(EmailModel data)
        {
            string msg = "Mail sent successfully.";
             try
            {
                Send(data.From, data.To, data.Subject, data.Username, data.Userphone, data.Usermessage, data.Useroptions);
                ActionResult response; 
                response = Ok(new { msg });
                return response;
            }
            catch (Exception exception)
            {
                return Ok(exception.Message);
            }
        }

        public void Send(string from, string to, string subject, string Username, string Userphone, string Usermessage, string Useroptions)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.CC.Add("info@exultitsolution.com");
            mail.CC.Add("sales@exultitsolution.com");
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            if (Useroptions!= "")
            {
                mail.Body = "<table style='background-color: #0085d3; color:#ffffff;' border='0' cellpadding='0' cellspacing='0'><tr><td><table width='100%' cellpadding='0' cellspacing='0' ><tr><td width='900px' height='69'><a href='http://exultitsolution.com/'><p style='font-family: Georgia, Helvetica, sans-serif; font-size: 22px; font-weight: bold; color: #ffffff; padding-left: 10px;'>EXULT IT SOLUTIONS</p></a></td></tr></table><table width='900px' cellpadding='0' cellspacing='0' style='border: 1px solid #0085d3; background-color: #ffffff; padding:20px'><tr><td style='text-align:left;'><p style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #fbd03b;'>Hi! " + Username + ",</p><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;'>Mobile No.: " + Userphone + ".</p><br/><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>" + Usermessage + " for "+ Usermessage +".</p></td></tr></table></td></tr><tr style='background-color:#94c3df; color:#3f3e3e;'></tr></table>";
            }
            if (Useroptions == "")
            {
                mail.Body = "<table style='background-color: #0085d3; color:#ffffff;' border='0' cellpadding='0' cellspacing='0'><tr><td><table width='100%' cellpadding='0' cellspacing='0' ><tr><td width='900px' height='69'><a href='http://exultitsolution.com/'><p style='font-family: Georgia, Helvetica, sans-serif; font-size: 22px; font-weight: bold; color: #ffffff; padding-left: 10px;'>EXULT IT SOLUTIONS</p></a></td></tr></table><table width='900px' cellpadding='0' cellspacing='0' style='border: 1px solid #0085d3; background-color: #ffffff; padding:20px'><tr><td style='text-align:left;'><p style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #fbd03b;'>Hi! " + Username+ ",</p><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;'>Mobile No.: " + Userphone + ".</p><br/><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>" + Usermessage+ ".</p></td></tr></table></td></tr><tr style='background-color:#94c3df; color:#3f3e3e;'></tr></table>";
            }
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("exultitsolution@gmail.com", "Excellent1");
            smtp.Send(mail);
        }
    }
}
