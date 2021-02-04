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
    public class ReportingAppService : AppService<ERPConfigurationContext>, IReportingAppService
    {
        private readonly IReportingService _service;
        public ReportingAppService(IReportingService acbrService)
        {
            _service = acbrService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ReportingTo Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ReportingTo> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<ReportingTo> Find(Expression<Func<ReportingTo, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<ReportingTo> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(ReportingTo obj)
        {
            _service.Add(obj);
        }

        public void Update(ReportingTo obj)
        {
            _service.Update(obj);
        }

        public void Delete(ReportingTo obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(ReportingTo entity, ReportingTo existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
