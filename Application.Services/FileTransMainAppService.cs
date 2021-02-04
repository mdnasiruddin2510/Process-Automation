using App.Domain;
using App.Domain.Interface.Service;
using Application.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileTransMainAppService : AppService<ERPConfigurationContext>, IFileTransMainAppService
    {
        private readonly IFileTransMainService _service;
        public FileTransMainAppService(IFileTransMainService commonService)
        {
            _service = commonService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FileTransMain Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<FileTransMain> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<FileTransMain> Find(Expression<Func<FileTransMain, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<FileTransMain> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(FileTransMain obj)
        {
            _service.Add(obj);
        }

        public void Update(FileTransMain obj)
        {
            _service.Update(obj);
        }

        public void Delete(FileTransMain obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(FileTransMain entity, FileTransMain existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
