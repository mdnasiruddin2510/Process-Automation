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
    public class BoundaryAppService : AppService<ERPConfigurationContext>, IBoundaryAppService
    {
        private readonly IBoundaryService _service;
        public BoundaryAppService(IBoundaryService acbrService)
        {
            _service = acbrService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Boundary Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Boundary> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<Boundary> Find(Expression<Func<Boundary, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Boundary> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(Boundary obj)
        {
            _service.Add(obj);
        }

        public void Update(Boundary obj)
        {
            _service.Update(obj);
        }

        public void Delete(Boundary obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(Boundary entity, Boundary existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
