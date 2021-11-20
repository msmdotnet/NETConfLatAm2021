using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Mail
{
    public class MailService : IMailService
    {
        readonly IApplicationStatusLogger Logger;

        public MailService(IApplicationStatusLogger logger)
        {           
            Logger = logger;
        }

        public ValueTask Send(string message)
        {
           Logger.Log($"*** MailService; {message}");
            Logger.Log("*** MailService: Servidor de correo no configurado. ***");
            return ValueTask.CompletedTask;

        }
    }
}
