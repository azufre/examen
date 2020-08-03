using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalBus.Core.Context;
using TerminalBus.Core.Model;
using TerminalBus.Core.Contract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TerminalBus.Core.ViewModel;

namespace TerminalBus.Core.Service
{
    public class BoletoService : IBoletoService
    {
        private readonly TerminalBusContext _terminalBusContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BoletoService(TerminalBusContext terminalBusContext, IHttpContextAccessor httpContextAccessor)
        {
            _terminalBusContext = terminalBusContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public JsonResult GetById(int Id)
        {
            try
            {

                if (!CheckExistById(Id))
                    return new JsonResult("Oops! Boleto no exite con el id proporcionado") { StatusCode = 400 };

                Boleto boleto = null;

                boleto = _terminalBusContext.Boletos.Find(Id);

                return new JsonResult(boleto) { StatusCode = 200};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckExistById(int Id)
        {
            try
            {
                bool exist;
                exist = _terminalBusContext.Boletos.Where(q => q.IdBoleto == Id).Count() > 0 ? true : false;

                return exist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetAll()
        {
            try
            {
                var boletos = new List<Boleto>();

                boletos = _terminalBusContext.Boletos.ToList();

                return new JsonResult(boletos) { StatusCode = 200};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetAllByIdViaje(int Id)
        {
            try
            {
                var boletos = new List<Boleto>();
                boletos = _terminalBusContext.Boletos.Where(q => q.Viaje.IdViaje == Id).ToList();

                return new JsonResult(boletos){StatusCode = 200};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(Boleto boleto)
        {
            var IdUser = ((ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            boleto.IdPasajero = IdUser;
            await _terminalBusContext.Boletos.AddAsync(boleto);
            await _terminalBusContext.SaveChangesAsync();
        }

        public void Update(BoletoUpdateViewModel boleto)
        {
            var _boleto = _terminalBusContext.Boletos.Find(boleto.IdBoleto);
            if(_boleto != null)
            {
                _boleto.IdViaje = boleto.IdViaje;
                _boleto.Asiento = boleto.Asiento;
                _boleto.FechaCompra = boleto.FechaCompra;                
                _terminalBusContext.Boletos.Update(_boleto);
                _terminalBusContext.SaveChanges();
            }                     
        }

        public void Remove(int Id)
        {
            var boleto = _terminalBusContext.Boletos.Find(Id);
            if(boleto != null)
            {
                _terminalBusContext.Boletos.Remove(boleto);
                _terminalBusContext.SaveChanges();
            }                     
        }

    }
}
