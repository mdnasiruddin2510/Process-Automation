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
    public class StaffDetailsAppService : AppService<ERPConfigurationContext>, IStaffDetailsAppService
    {
        private readonly IStaffDetailsService _service;

        public StaffDetailsAppService(IStaffDetailsService commonSearchService)
        {
            _service = commonSearchService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public StaffDetails Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<StaffDetails> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<StaffDetails> Find(Expression<Func<StaffDetails, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<StaffDetails> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }



        public void Add(StaffDetails obj)
        {
            _service.Add(obj);
        }

        public void Update(StaffDetails obj)
        {
            _service.Update(obj);
        }

        public void Delete(StaffDetails obj)
        {
           _service.Delete(obj);
        }

        public void Save()
        {
          _service.Save();
        }
        public void Setvalues(StaffDetails entity, StaffDetails existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    
    }
}