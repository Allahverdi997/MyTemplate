using MailSenderService.Abstract;
using MailService.Abstract;
using MailService.DTO;
using MailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderService.Concrete
{
    public class MailSender: IMailSenderService
    {
        public IMailService MailService => new MailService.Concrete.MailService(new MailSetting { Host = "10.0.239.11", Password = "3hd1bCPR", Port = 25, SenderMail = "noreply@azintelecom.az" });
        public bool UseCertificate { get; set; } = true;
        public System.Net.Mail.MailPriority Priority { get; set; } = System.Net.Mail.MailPriority.High;
        public bool UseDefaultCredentials { get; set; } = true;
        public bool EnableSSL { get; set; } = false;
        public List<ToAndCCMailDTO> ToAndCCMailDTOs => new List<ToAndCCMailDTO>() { new ToAndCCMailDTO() { DisplayName = "Ali", MailAddress = "allahverdi.novruzov997@gmail.com" } };

        public async Task<IResponseModel> SendMessage(string body, string displayName, string subject)
        {
            return MailService.SendMessage(new ClientMailInfoDTO()
            {
                Body = body,
                DisplayName = displayName,
                EnableSSL = EnableSSL,
                Subject = subject,
                UseDefaultCredentials = UseDefaultCredentials,
                ToMails = ToAndCCMailDTOs,
                Priority = Priority,
                UseCertificate = UseCertificate
            });
        }

        public async Task<IResponseModel> SendMessage(string body, string displayName, string subject, string templatePath, string oldReplaceText, string newReplaceText)
        {
            return MailService.SendMessageWithHtml(
                 new ClientMailInfoWithHtmlDTO()
                 {
                     DisplayName = displayName,
                     EnableSSL = EnableSSL,
                     Subject = subject,
                     UseDefaultCredentials = UseDefaultCredentials,
                     ToMails = ToAndCCMailDTOs,
                     Priority = Priority,
                     UseCertificate = UseCertificate,
                     Path = templatePath,
                     ClientHtmlReplaceDTOs = new HashSet<ClientHtmlReplaceDTO> { new ClientHtmlReplaceDTO() { NewHtmlReplaceText = oldReplaceText, OldHtmlReplaceText = newReplaceText } }
                 });
        }
    }
}
