using System;
using System.Net;
using System.Net.Mail;

class MainClass
{

    static string fromUser = "yatest2021@mail.ru";
    static string password = "Qwerty_1234//";

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Введите пользователя, которому хотите отправить письмо (example@mail.ru, example@gmail.com): ");
        string toUser = Console.ReadLine();

        Console.Write("Введите ваше сообщение: ");
        string newMsg = Console.ReadLine();

        try
        {

            MailAddress fromU = new MailAddress(fromUser);
            MailAddress toU = new MailAddress(toUser);
            MailMessage msg = new MailMessage(fromU, toU)
            {
                Subject = "My first new message",
                IsBodyHtml = false,
                Body = newMsg
            };
    
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25)
            {
                Credentials = new NetworkCredential(fromUser, password),
                EnableSsl = true
            };

            smtp.Send(msg);
            Console.WriteLine();
            Console.Write("Сообщение успешно отправлено!");
    
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода записи");
        }

    }
}
