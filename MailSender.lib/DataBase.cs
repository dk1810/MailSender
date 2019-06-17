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
    }
}
