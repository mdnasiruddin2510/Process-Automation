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
    public class FileDetailAppService : AppService<ERPConfigurationContext>, IFileDetailAppService
    {
        private readonly IFileDetailService _service;
        public FileDetailAppService(IFileDetailService fileDetailService)
        {
            _service = fileDetailService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FileDetail Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<FileDetail> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<FileDetail> Find(Expression<Func<FileDetail, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<FileDetail> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(FileDetail obj)
        {
            _service.Add(obj);
        }

        public void Update(FileDetail obj)
        {
            _service.Update(obj);
        }

        public void Delete(FileDetail obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(FileDetail entity, FileDetail existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
