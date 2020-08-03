using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TerminalBus.Core.Model;
using TerminalBus.Core.ViewModel;

namespace TerminalBus.Core.Contract
{
    public interface IBoletoService
    {
        bool CheckExistById(int Id);
        Task Create(Boleto boleto);
        JsonResult GetAll();
        JsonResult GetById(int Id);
        void Remove(int Id);
        void Update(BoletoUpdateViewModel boleto);
        JsonResult GetAllByIdViaje(int Id);
    }
}
