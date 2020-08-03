using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerminalBus.Core.Contract;
using TerminalBus.Core.Mapper;
using TerminalBus.Core.Model;
using TerminalBus.Core.ViewModel;

namespace TerminalBus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(BusViewModel bus)
        {
            try
            {
                await _busService.Create(HelperMapper.Mapper.Map<Bus>(bus));
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll() => _busService.GetAll();

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int Id) => _busService.GetById(Id);

        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int Id)
        {
            try
            {
                _busService.Remove(Id);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(Bus bus)
        {
            try
            {
                _busService.Update(bus);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

    }
}