
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
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _viajeService;

        public ViajeController(IViajeService viajeService)
        {
            _viajeService = viajeService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(ViajeViewModel viaje)
        {
            try
            {
                await _viajeService.Create(HelperMapper.Mapper.Map<Viaje>(viaje));
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll() => _viajeService.GetAll();

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int Id) => _viajeService.GetById(Id);

        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int Id)
        {
            try
            {
                _viajeService.Remove(Id);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(Viaje viaje)
        {
            try
            {
                _viajeService.Update(viaje);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

    }
}