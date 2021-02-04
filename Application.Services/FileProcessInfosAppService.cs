using App.Domain;
using App.Domain.Interface.Service;
using Application.Interfaces;
using Data.Context;
using System;
using App.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileProcessInfosAppService : AppService<ERPConfigurationContext>, IFileProcessInfosAppService
    {
        private readonly IFileProcessInfosService _service;
        public FileProcessInfosAppService(IFileProcessInfosService fileProcessInfoService)
        {
            _service = fileProcessInfoService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public FileProcessInfos Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<FileProcessInfos> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }
        public IEnumerable<FileProcessInfos> Find(Expression<Func<FileProcessInfos, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<FileProcessInfos> SqlQueary(string sql, params object[] parameters)
        {
            return _service.SqlQueary(sql, parameters);
        }

        public void Add(FileProcessInfos obj)
        {
            _service.Add(obj);
        }

        public void Update(FileProcessInfos obj)
        {
            _service.Update(obj);
        }

        public void Delete(FileProcessInfos obj)
        {
            _service.Delete(obj);
        }

        public void Save()
        {
            _service.Save();
        }
        public void Setvalues(FileProcessInfos entity, FileProcessInfos existingEntity)
        {
            _service.Setvalues(entity, existingEntity);
        }
    }
}
