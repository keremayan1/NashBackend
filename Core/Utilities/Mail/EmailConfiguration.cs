using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmpServer { get; set; }

        public int SmtPort { get; set; }

        public string SmtpUserName { get; set; }
        public string Password { get; set; }
    }
}
