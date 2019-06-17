namespace MailSender.lib.Data
{
    public static class Server
    {
        public static string Address { get; set; } = "smtp.yandex.ru";
        public static int Port { get; set; } = 25;
        public static bool UseSSL { get; set; } = true;
        public static string UserMailAddress { get; set; } = "d.konontsev@yandex.ru";
        public static string Password { get; set; } = "konontsev111";
    }
}
