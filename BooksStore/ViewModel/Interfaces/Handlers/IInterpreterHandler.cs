using System;
using System.Threading.Tasks;
using ViewModel.Models.Interpreters;

namespace ViewModel.Handlers
{
    public interface IInterpreterHandler
    {
        Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter);
        Task<InterpreterViewModel> UpdateAsync(InterpreterModifyModel interpreter);
        Task<InterpreterViewModel> GetAsync(Guid id);
    }
}