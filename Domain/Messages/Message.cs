using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Messages
{
    public class Message : PersistentObject
    {
        public virtual ColorType ColorType { get; set; }
        public virtual CountType CountType { get; set; }
        public virtual SizeEnum SizeEnum  { get; set; }
        public virtual string FirstAddress { get; set; }
        public virtual string SecondAddress { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
