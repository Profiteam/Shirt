using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmailService
    {
        Task<bool> SendActivationMessage(string receiver, string activationKey);
        Task<bool> SendRecoveMessage(string receiver, string activationCode);
        Task<bool> SendRequest(string receiver, string text);
    }
}
