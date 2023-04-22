using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Repository.Sql.Main.DepartmentRepo;
using Application.Abstraction.Core.Service.Main;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.CrossCuttingConcerns.Aspects.Caching.Microsoft;
using Application.CrossCuttingConcerns.Aspects.Caching.Redis;
using Application.CrossCuttingConcerns.Aspects.Logging;
using Application.CrossCuttingConcerns.Aspects.SecurityAccess;
using Application.DTO;
using Application.Enum;
using Application.Exception.Main;
using Application.Static.Message;
using AutoMapper;
using Domain.Concrete.Main;
using Domain.Concrete.NoSql.Main;
using JWTService.Abstract;
using MailSenderService;
using MailService.Abstract;
using MailService.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IAppSetting AppSetting { get; set; }
        public IMapper Mapper { get; set; }
        public IJWTService JWT { get; set; }
        public DepartmentService(IUnitOfWork unitOfWork,IAppSetting appSetting,IMapper mapper,IJWTService jWT)
        {
            UnitOfWork = unitOfWork;
            AppSetting = appSetting;
            Mapper = mapper;
            JWT = jWT;
        }
        //[NotificationLogging(typeof(DepartmentService), Priority =2)]
        [RedisCaching("DepartmentService-GetAll-Demo",typeof(IEnumerable<DepartmentGetAllDTO>))]

        [AccessSecure("admin,client")]
        public IEnumerable<DepartmentGetAllDTO> GetAll()
        {
            //var b = Convert.ToInt16(AppSetting.SqlConnectionString);
            //var model=MailSender.SendMessage("Alma", "Alma", "Alma").Result;
            var a = JWT.GenerateToken("SimaApplicationWebSite123", new List<Claim>() { new Claim("Name", "Ali") },1);
            var b = JWT.VerifyToken(a);
            return Mapper.Map<IEnumerable<DepartmentGetAllDTO>>(UnitOfWork.DepartmentReadRepository.GetListAsync(null,true,x=>x.Employees).Result);
            //return UnitOfWork.DepartmentReadRepository.GetListAsync(null, true, x => x.Employees).Result;
        }

        public bool Check()
        {
            return UnitOfWork.DepartmentReadRepository.CheckExist();
        }

        public int Count()
        {
            return UnitOfWork.DepartmentReadRepository.Count();
        }

        [ExceptionLogging(typeof(DepartmentService),Priority =2)]
        public Department FirstOrDefault(object obj)
        {
                var a = AppSetting.SqlConnectionString;
                //var b = Convert.ToInt16(AppSetting.SqlConnectionString);
                var c= UnitOfWork.DepartmentReadRepository.FirstOrDefaultAsync(x => x.Name == "Hr", true, x => x.Employees).Result;
                return c;
        }

        public IQueryable<Department> Get()
        {
            return UnitOfWork.DepartmentReadRepository.Get(x => x.Name == "Hr", true, x => x.Employees);
        }

        public IQueryable<Department> GetId()
        {
            return UnitOfWork.DepartmentReadRepository.Get(1, true, x => x.Employees);
        }
        public IEnumerable<Department> GetAllEst()
        {
            return UnitOfWork.DepartmentReadRepository.GetAll(true);
        }
        public void Add(Department department)
        {
            UnitOfWork.DepartmentWriteRepository.Add(department);
            UnitOfWork.Commit();
        }
        public void AddRange(IEnumerable<Department> departments)
        {
            UnitOfWork.DepartmentWriteRepository.AddRange(departments);
        }

        public void AddOrUpdate(Department department,int id)
        {
            UnitOfWork.DepartmentWriteRepository.AddOrUpdate(department,id);
        }
        public void DeleteId(int id)
        {
            UnitOfWork.DepartmentWriteRepository.Delete(id);
        }
        public void Delete(Department department)
        {
            UnitOfWork.DepartmentWriteRepository.Delete(department);
        }
        public void DeleteRange()
        {
            UnitOfWork.DepartmentWriteRepository.DeleteRange(x=>x.Name.Contains("eqem"));
        }
    }
}
