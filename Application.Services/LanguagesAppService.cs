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
    public class LanguagesAppService : AppService<ERPConfigurationContext>, ILanguagesAppService 
    {
        private readonly ILanguagesService _service;
        public LanguagesAppService(ILanguagesService languagesService)
        {
            _service = languagesService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Languages Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Languages> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<Languages> Find(Expression<Func<Languages, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Languages> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(Languages obj)
        {
            _service.Add(obj);
        }

        public void Update(Languages obj)
        {
            _service.Update(obj);
        }

        public void Delete(Languages obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(Languages entity, Languages existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
