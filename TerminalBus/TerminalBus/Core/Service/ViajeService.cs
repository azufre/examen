using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalBus.Core.Context;
using TerminalBus.Core.Model;
using TerminalBus.Core.Contract;

namespace TerminalBus.Core.Service
{
    public class ViajeService : IViajeService
    {
        private readonly TerminalBusContext _terminalBusContext;
        public ViajeService(TerminalBusContext terminalBusContext)
        {
            _terminalBusContext = terminalBusContext;
        }

        public JsonResult GetById(int Id)
        {
            try
            {

                if (!CheckExistById(Id))
                    return new JsonResult("Oops! Viaje no exite con el id proporcionado") { StatusCode = 400 };

                Viaje viaje = null;
                viaje = _terminalBusContext.Viajes.Find(Id);

                return new JsonResult(viaje) { StatusCode = 200 };
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
                exist = _terminalBusContext.Viajes.Where(q => q.IdViaje == Id).Count() > 0 ? true : false;
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
                var viajes = new List<Viaje>();
                viajes = _terminalBusContext.Viajes.ToList();
                return new JsonResult(viajes) { StatusCode = 200};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(Viaje viaje)
        {
            await _terminalBusContext.Viajes.AddAsync(viaje);
            await _terminalBusContext.SaveChangesAsync();
        }

        public void Update(Viaje viaje)
        {
            var _viaje = _terminalBusContext.Viajes.Find(viaje.IdViaje);
            if (_viaje != null)
            {
                _terminalBusContext.Viajes.Update(viaje);
                _terminalBusContext.SaveChanges();
            }
        }

        public void Remove(int Id)
        {
            var viaje = _terminalBusContext.Viajes.Find(Id);
            if(viaje != null){
                _terminalBusContext.Viajes.Remove(viaje);
                _terminalBusContext.SaveChanges();
            }            
        }
    }
}
