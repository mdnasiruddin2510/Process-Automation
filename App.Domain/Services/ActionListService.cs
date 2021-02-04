using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Domain.Interface.Repository;
using App.Domain.Interface.Service;
using App.Domain.Services.Common;

namespace App.Domain.Services
{
    public class ActionListService : Service<ActionList>, IActionListService
    {
        public ActionListService(IActionListRepository repository)
            : base(repository)
        {

        }
    }
}