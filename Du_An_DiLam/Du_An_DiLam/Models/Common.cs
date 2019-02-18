using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace Du_An_DiLam.Models
{
    public  class Common
    {
        public static void Sendmail(string toEmail, string formEmail, string passEmail, string titleEmail, string ContenEmail)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);// gửi đến maill người mua
            mail.From = new MailAddress(formEmail);
            mail.Subject = titleEmail; // Tiêu đề mail mail
            mail.Body = ContenEmail;// nội dung 
            mail.IsBodyHtml = true;// cho phép viết mã Html
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(formEmail, passEmail);// tài khoản gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail); //gửi
        }

        public static string EncryptMD5(string data)
        {
            // khởi tạo
            MD5CryptoServiceProvider myMd5 = new MD5CryptoServiceProvider();
            // mã hóa 
            byte[] b = System.Text.Encoding.UTF8.GetBytes(data);
            b = myMd5.ComputeHash(b);
            StringBuilder s = new StringBuilder();
            foreach (byte p in b)
            {
                s.Append(p.ToString("x").ToLower());
            }
            return s.ToString();
        }
    }
}