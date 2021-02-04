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
    public class AFileMainAppService : AppService<ERPConfigurationContext>, IAFileMainAppService
    {
        private readonly IAFileMainService _service;
        public AFileMainAppService(IAFileMainService AFileMainService)
        {
            _service = AFileMainService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AFileMain Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<AFileMain> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<AFileMain> Find(Expression<Func<AFileMain, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<AFileMain> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(AFileMain obj)
        {
            _service.Add(obj);
        }

        public void Update(AFileMain obj)
        {
            _service.Update(obj);
        }

        public void Delete(AFileMain obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(AFileMain entity, AFileMain existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
