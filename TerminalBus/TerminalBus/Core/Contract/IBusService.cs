using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TerminalBus.Core.Model;

namespace TerminalBus.Core.Contract
{
    public interface IBusService
    {
        bool CheckExistById(int Id);
        Task Create(Bus bus);
        JsonResult GetAll();
        JsonResult GetById(int Id);
        void Remove(int Id);
        void Update(Bus bus);
    }
}
