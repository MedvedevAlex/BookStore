using System.Threading.Tasks;
using ViewModel.Models.Interpreters;

namespace ViewModel.Handlers
{
    public interface IInterpreterHandler
    {
        Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter);
    }
}