using Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Shirt
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        public static readonly string TemplatePath = " C:\\Users\\chaka\\source\\repos\\Shirt\\Utils\\EmailTemplate";
        private IEmailService EmailService { get; set; }
        private IMessageService MessageService { get; set; }

        public RequestController([FromServices] IEmailService emailService, IMessageService messageService)
        {
            EmailService = emailService;
            MessageService = messageService;
        }

        [HttpPost("send-request")]
        public IActionResult SendRequest([FromBody] FormRequest request)
        {
            if (request == null)
                return Json(new { Success = false, Message = "Request cannot be null" });

            if (!Validator.TryValidateObject(request, new ValidationContext(request), null, true))
                return Json(new { Success = false, Message = "Required Property Not Found" });

            var message = new Message
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                ColorType = request.ColorType,
                CountType = request.CountType,
                SizeEnum = request.SizeEnum,
                FirstAddress = request.FirstAddress,
                SecondAddress = request.SecondAddress,
                Date = DateTime.UtcNow
            };
            message = MessageService.CreateEntity(message);

            string color = "";
            string size = "";

            if (request.ColorType == Domain.Enum.ColorType.Black)
                color = "Черный";

            else if (request.ColorType == Domain.Enum.ColorType.Grey)
            {
                color = "Серый";
            }

            else
                color = "Коричневый";

            if (request.SizeEnum == Domain.Enum.SizeEnum.XS)
                size = "XS";
            else if (request.SizeEnum == Domain.Enum.SizeEnum.S)
                size = "S";
            else if (request.SizeEnum == Domain.Enum.SizeEnum.M)
                size = "M";
            else if (request.SizeEnum == Domain.Enum.SizeEnum.L)
                size = "L";
            else if (request.SizeEnum == Domain.Enum.SizeEnum.XL)
                size = "XL";
            else if (request.SizeEnum == Domain.Enum.SizeEnum.XXL)
                size = "XXL";
            else 
                size = "XXXL";

            var htmlText = new WebClient().DownloadString($"{TemplatePath}\\Email.cshtml");

            var text = String.Format(htmlText,
                message.ID.ToString(), 
                request.Email, 
                request.PhoneNumber,
                request.FirstAddress +" "+ request.SecondAddress, 
                request.CountType.ToString() ,color , size);

            EmailService.SendRequest("vanyamelikov@yandex.ru", text);

            return Ok(true);
        }


    }
}
