using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalBus.Core.Context;
using TerminalBus.Core.Contract;
using TerminalBus.Core.Model;

namespace TerminalBus.Core.Service
{
    public class BusService : IBusService
    {
        private readonly TerminalBusContext _terminalBusContext;
        public BusService(TerminalBusContext terminalBusContext)
        {
            _terminalBusContext = terminalBusContext;
        }

        public JsonResult GetById(int Id)
        {
            try
            {

                if (!CheckExistById(Id))
                    return new JsonResult("Oops! Bus no exite con el id proporcionado") { StatusCode = 400 };

                Bus bus = null;
                bus = _terminalBusContext.Buses.Find(Id);

                return new JsonResult(bus) { StatusCode = 200 };
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
                exist = _terminalBusContext.Buses.Where(q => q.IdBus == Id).Count() > 0 ? true : false;
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
                var buses = new List<Bus>();
                    buses = _terminalBusContext.Buses.ToList();
                return new JsonResult(buses) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(Bus bus)
        {
            await _terminalBusContext.Buses.AddAsync(bus);
            await _terminalBusContext.SaveChangesAsync();            
        }

        public void Update(Bus bus)
        {
            var _bus = _terminalBusContext.Buses.Find(bus.IdBus);
            if(_bus != null)
            {
                _terminalBusContext.Buses.Update(bus);
                _terminalBusContext.SaveChanges();
            }            
        }

        public void Remove(int Id)
        {
            var _bus = _terminalBusContext.Buses.Find(Id);
            if (_bus != null)
            {
                _terminalBusContext.Buses.Remove(_bus);
                _terminalBusContext.SaveChanges();
            }
        }
    }
}
