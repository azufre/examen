using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TerminalBus.Core.Model;

namespace TerminalBus.Core.Contract
{
    public interface IViajeService
    {
        bool CheckExistById(int Id);
        Task Create(Viaje viaje);
        JsonResult GetAll();
        JsonResult GetById(int Id);
        void Remove(int Id);
        void Update(Viaje viaje);
    }
}
