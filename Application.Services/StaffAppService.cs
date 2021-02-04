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
    public class StaffAppService : AppService<ERPConfigurationContext>, IStaffAppService
    {
        private readonly IStaffService _service;
        public StaffAppService(IStaffService acbrService)
        {
            _service = acbrService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public StaffInfo Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<StaffInfo> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<StaffInfo> Find(Expression<Func<StaffInfo, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<StaffInfo> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(StaffInfo obj)
        {
            _service.Add(obj);
        }

        public void Update(StaffInfo obj)
        {
            _service.Update(obj);
        }

        public void Delete(StaffInfo obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(StaffInfo entity, StaffInfo existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
