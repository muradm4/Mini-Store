﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string HtmlMessage);
    }
}
