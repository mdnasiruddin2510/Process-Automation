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
    public class DictionaryAppService : AppService<ERPConfigurationContext>, IDictionaryAppService
    {
        private readonly IDictionaryService _service;
        public DictionaryAppService(IDictionaryService _service)
        {
            this._service = _service;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Dictionary Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Dictionary> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<Dictionary> Find(Expression<Func<Dictionary, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Dictionary> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(Dictionary obj)
        {
            _service.Add(obj);
        }

        public void Update(Dictionary obj)
        {
            _service.Update(obj);
        }

        public void Delete(Dictionary obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(Dictionary entity, Dictionary existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
