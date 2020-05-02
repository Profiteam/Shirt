using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shirt
{
    public class FormRequest
    {
        public ColorType ColorType { get; set; }
        public CountType CountType { get; set; }
        public SizeEnum SizeEnum { get; set; }
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
