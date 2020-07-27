using System.Threading.Tasks;
using ViewModel.Models.Interpreters;

namespace ViewModel.Interfaces.Services
{
    public interface IInterpreterService
    {
        Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter);
    }
}