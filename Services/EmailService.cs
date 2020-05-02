
using System.Threading.Tasks;
using static Utils.SMTPHelper;

namespace Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendActivationMessage(string receiver, string activationKey)
        {
            var message = new SendMailModel
            {
                MailTo = receiver,
                Subject = "[SIGMA] Activation",
                Message = $"Ваш активационный код {activationKey}"
            };

            return await SendMail(message);
        }

        public Task<bool> SendRecoveMessage(string receiver, string activationCode)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SendRecoveryCodeMessage(string receiver, string activationCode)
        {
            var message = new SendMailModel
            {
                MailTo = receiver,
                Subject = "[SIGMA] Recovery",
                Message = $"Ваш код воостановления пароля {activationCode}"
            };

            return await SendMail(message);
        }

        public async Task<bool> SendRequest(string receiver, string text)
        {
            var message = new SendMailModel
            {
                MailTo = receiver,
                Subject = "[Заявка на покупку]",
                Message = text
            };

            return await SendMail(message);
        }
    }
}
