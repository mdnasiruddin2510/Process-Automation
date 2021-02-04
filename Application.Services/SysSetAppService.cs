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
    public class SysSetAppService : AppService<ERPConfigurationContext>, ISysSetAppService
    {
        private readonly ISysSetService _service;

        public SysSetAppService(ISysSetService SysSetService)
        {
            _service = SysSetService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public SysSet Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<SysSet> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<SysSet> Find(Expression<Func<SysSet, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<SysSet> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }



        public void Add(SysSet obj)
        {
            _service.Add(obj);
        }

        public void Update(SysSet obj)
        {
            _service.Update(obj);
        }

        public void Delete(SysSet obj)
        {
           _service.Delete(obj);
        }

        public void Save()
        {
          _service.Save();
        }
        public void Setvalues(SysSet entity, SysSet existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    
    }
}