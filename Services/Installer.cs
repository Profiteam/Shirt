using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class Installer
    {
        public static void AddBuisnessServices(this IServiceCollection container)
        {
            container
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IMessageService, MessageService>();
        }
    }
}
