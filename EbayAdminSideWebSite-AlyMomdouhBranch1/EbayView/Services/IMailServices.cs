using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Services
{
    public interface IMailServices
    {
        Task SendEmailAsync(string mailto, string subject, string body, IList<IFormFile> attachments = null);
    }
}
