﻿using App.Domain.Interface.Repository;
using App.Domain.Interface.Service;
using App.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class EmailConfigService : Service<EmailConfig>, IEmailConfigService
    {
        public EmailConfigService(IEmailConfigRepository repository): base(repository)
        {

        }
    }
}
