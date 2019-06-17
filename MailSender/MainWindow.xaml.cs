using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSender.lib;
using MailSender.lib.Data;
using System.Net;
using System.Net.Mail;

namespace MailSender
{    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase dataBase;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadMainWindow(object sender, RoutedEventArgs e)
        {
            dataBase = new DataBase();
            Recipient recipient;

            for (int i = 0; i < 10; i++)
            {
                recipient = new Recipient
                {
                    Address = $"dk1810+{i}@gmail.com",
                    Name = $"Имя{i}"
                };
                dataBase.Recipients.Add(recipient);
            }

            lstRecipients.ItemsSource = dataBase.Recipients;
            txtStatus.Text = $"Загружено {dataBase.Recipients.Count} адресов для отправки.";
            txtServer.Text = Server.Address;
            txtPort.Text = Server.Port.ToString();
            txtLogin.Text = Server.UserMailAddress;
            txtPassword.Password = Server.Password;
        }

        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            foreach (Recipient recipient in dataBase.Recipients)
            {
                using (MailMessage mm = new MailMessage(Server.UserMailAddress, recipient.Address))
                {
                    mm.Subject = "Привет из C#";
                    mm.Body = "Hello, world!";

                    using (SmtpClient sc = new SmtpClient(Server.Address, Server.Port))
                    {
                        sc.EnableSsl = Server.UseSSL;
                        sc.Credentials = new NetworkCredential(txtLogin.Text, txtPassword.Password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        finally
                        {

                        }
                    }
                }
            }
            MessageBox.Show("Рассылка завершена!");
        }
    }
}
