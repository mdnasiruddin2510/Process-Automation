﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.Config
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<ERPConfigurationContext>
    {
        protected override void Seed(ERPConfigurationContext context)
        {
            base.Seed(context);
        }
    }
}
