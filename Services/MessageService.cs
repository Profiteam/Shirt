using Domain.Messages;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class MessageService : BaseCrudService<Message>, IMessageService
    {
        public MessageService(IRepository<Message> repository) : base(repository)
        {

        }
    }
}
