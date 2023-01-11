using System;
using TourAgency.Services.Models;

namespace TourAgency.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}

