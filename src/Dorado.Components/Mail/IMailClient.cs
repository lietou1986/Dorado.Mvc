using System;
using System.Threading.Tasks;

namespace Dorado.Components.Mail
{
    public interface IMailClient
    {
        Task SendAsync(String email, String subject, String body);
    }
}