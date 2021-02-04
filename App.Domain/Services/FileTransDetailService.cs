using App.Domain.Interface.Repository;
using App.Domain.Interface.Service;
using App.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class FileTransDetailService : Service<FileTransDetail>, IFileTransDetailService
    {
        public FileTransDetailService(IFileTransDetailRepository repository)
            : base(repository)
        {

        }
    }
}
