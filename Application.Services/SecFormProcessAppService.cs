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
    public class SecFormProcessAppService : AppService<ERPConfigurationContext>, ISecFormProcessAppService
    {
        private readonly ISecFormProcessService _service;

        public SecFormProcessAppService(ISecFormProcessService commonSearchService)
        {
            _service = commonSearchService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public SecFormProcess Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<SecFormProcess> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<SecFormProcess> Find(Expression<Func<SecFormProcess, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<SecFormProcess> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }



        public void Add(SecFormProcess obj)
        {
            _service.Add(obj);
        }

        public void Update(SecFormProcess obj)
        {
            _service.Update(obj);
        }

        public void Delete(SecFormProcess obj)
        {
           _service.Delete(obj);
        }

        public void Save()
        {
          _service.Save();
        }
        public void Setvalues(SecFormProcess entity, SecFormProcess existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    
    }
}