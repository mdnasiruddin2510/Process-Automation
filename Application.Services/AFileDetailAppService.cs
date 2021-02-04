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
    public class AFileDetailAppService : AppService<ERPConfigurationContext>, IAFileDetailAppService
    {
        private readonly IAFileDetailService _service;
        public AFileDetailAppService(IAFileDetailService afileDetailService)
        {
            _service = afileDetailService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AFileDetail Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<AFileDetail> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<AFileDetail> Find(Expression<Func<AFileDetail, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<AFileDetail> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(AFileDetail obj)
        {
            _service.Add(obj);
        }

        public void Update(AFileDetail obj)
        {
            _service.Update(obj);
        }

        public void Delete(AFileDetail obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(AFileDetail entity, AFileDetail existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
