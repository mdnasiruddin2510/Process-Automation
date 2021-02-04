using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using App.Domain;
using App.Domain.Interface.Service;
using Application.Interfaces;
using Data.Context;

namespace Application.Services
{
    public class FileTransDetailAppService : AppService<ERPConfigurationContext>, IFileTransDetailAppService
    {
        private readonly IFileTransDetailService _service;

        public FileTransDetailAppService(IFileTransDetailService commonSearchService)
        {
            _service = commonSearchService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FileTransDetail Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<FileTransDetail> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<FileTransDetail> Find(Expression<Func<FileTransDetail, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<FileTransDetail> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }



        public void Add(FileTransDetail obj)
        {
            _service.Add(obj);
        }

        public void Update(FileTransDetail obj)
        {
            _service.Update(obj);
        }

        public void Delete(FileTransDetail obj)
        {
           _service.Delete(obj);
        }

        public void Save()
        {
          _service.Save();
        }
        public void Setvalues(FileTransDetail entity, FileTransDetail existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    
    }
}