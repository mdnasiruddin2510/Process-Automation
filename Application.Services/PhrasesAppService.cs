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
    public class PhrasesAppService : AppService<ERPConfigurationContext>, IPhrasesAppServices
    {
        private readonly IPhrasesServices _service;
        public PhrasesAppService(IPhrasesServices _service)
        {
            this._service = _service;
        }
                        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Phrases Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Phrases> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<Phrases> Find(Expression<Func<Phrases, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Phrases> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(Phrases obj)
        {
            _service.Add(obj);
        }

        public void Update(Phrases obj)
        {
            _service.Update(obj);
        }

        public void Delete(Phrases obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(Phrases entity, Phrases existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
