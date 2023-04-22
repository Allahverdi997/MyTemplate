using Api.Attributes;
using Api.Filters;
using Application.Abstraction.Core.Service.Main;
using Application.CrossCuttingConcerns.Aspects.SecurityAccess;
using Application.DTO;
using Application.Model.Response.Main;
using Domain.Concrete.Main;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IDepartmentService DepartmentService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IDepartmentService departmentService)
        {
            DepartmentService = departmentService;
        }

        [HttpGet]
        [Anonym]
        public async Task<IActionResult> Get()
        {
            var model = DepartmentService.GetAll();
            //var model1 = await DepartmentService.GetAll();
            //var m2 = DepartmentService.Get().ToList();
            var m3 =  DepartmentService.FirstOrDefault(new { Name="Ali",Surname="Musayev"});
            var m4 = DepartmentService.GetId().FirstOrDefault();
            //var m5 = DepartmentService.Check();
            //var m6 = DepartmentService.Count();
            var m7 = DepartmentService.GetAllEst().ToList();
            return Ok(new SuccessReponseModel<IEnumerable<Department>>(model));
        }

        [HttpPost]
        [SwaggerSign]
        [Anonym]
        public IActionResult Add(Department department)
        {
            DepartmentService.Add(department);
            return Ok();
        }
        [HttpPost("post")]
        public IActionResult AddOrUpdate(Department department)
        {
            DepartmentService.AddOrUpdate(department,department.Id);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Department department)
        {
            DepartmentService.Delete(department);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult DeleteId(int id)
        {
            DepartmentService.DeleteId(id);
            return Ok();
        }
        [HttpGet("deleteRange")]
        public IActionResult DeleteRange()
        {
            DepartmentService.DeleteRange();
            return Ok();
        }
    }
}