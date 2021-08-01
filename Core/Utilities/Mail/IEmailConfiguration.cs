using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
    public interface IEmailConfiguration
    {
        string SmpServer { get; }
        int SmtPort { get; }
        string SmtpUserName { get; set; }
        string Password { get; set; }

    }
}
