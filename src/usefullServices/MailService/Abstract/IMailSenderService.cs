using MailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderService.Abstract
{
    public interface IMailSenderService
    {
        Task<IResponseModel> SendMessage(string body, string displayName, string subject);
        Task<IResponseModel> SendMessage(string body, string displayName, string subject, string templatePath, string oldReplaceText, string newReplaceText);
    }
}
