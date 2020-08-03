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
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(BoletoViewModel boleto)
        {
            try
            {
                await _boletoService.Create(HelperMapper.Mapper.Map<Boleto>(boleto));
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll() => _boletoService.GetAll();

        [HttpGet]
        [Route("GetAllByIdViaje")]
        public ActionResult GetAllByIdViaje(int Id) => _boletoService.GetAllByIdViaje(Id);

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int Id) => _boletoService.GetById(Id);

        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int Id)
        {
            try
            {
                _boletoService.Remove(Id);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(BoletoUpdateViewModel boleto)
        {
            try
            {
                _boletoService.Update(boleto);
            }
            catch (Exception)
            {
                return new JsonResult("Oops! algo salio mal.") { StatusCode = 400 };
            }
            return new JsonResult("OK") { StatusCode = 200 };
        }
    }
}