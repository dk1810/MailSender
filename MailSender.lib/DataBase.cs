using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib
{
    public class DataBase
    {
        public List<Recipient> Recipients { get; set; }
        public DataBase()
        {
            Recipients = new List<Recipient>();
        }

        /// <summary>
        /// Заполняет DataBase тестовыми данными
        /// </summary>
        public void FillTestData()
        {
            Recipient recipient;

            for (int i = 0; i < 10; i++)
            {
                recipient = new Recipient
                {
                    Address = $"dk1810+{i}@gmail.com",
                    Name = $"Имя{i}"
                };
                this.Recipients.Add(recipient);
            }
        }

    }

}
