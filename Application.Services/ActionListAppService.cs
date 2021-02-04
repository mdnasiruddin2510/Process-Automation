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
    public class ActionListAppService : AppService<ERPConfigurationContext>, IActionListAppService
    {
        private readonly IActionListService _service;

        public ActionListAppService(IActionListService commonSearchService)
        {
            _service = commonSearchService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ActionList Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ActionList> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<ActionList> Find(Expression<Func<ActionList, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<ActionList> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }



        public void Add(ActionList obj)
        {
            _service.Add(obj);
        }

        public void Update(ActionList obj)
        {
            _service.Update(obj);
        }

        public void Delete(ActionList obj)
        {
           _service.Delete(obj);
        }

        public void Save()
        {
          _service.Save();
        }
        public void Setvalues(ActionList entity, ActionList existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    
    }
}