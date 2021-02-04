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
    public class FileMainAppService : AppService<ERPConfigurationContext>, IFileMainAppService
    {
        private readonly IFileMainService _service;
        public FileMainAppService(IFileMainService FileMainService)
        {
            _service = FileMainService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FileMain Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<FileMain> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<FileMain> Find(Expression<Func<FileMain, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<FileMain> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(FileMain obj)
        {
            _service.Add(obj);
        }

        public void Update(FileMain obj)
        {
            _service.Update(obj);
        }

        public void Delete(FileMain obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(FileMain entity, FileMain existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
