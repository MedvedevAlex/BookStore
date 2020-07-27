using System;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Interpreters;

namespace Service.Services
{
    public class InterpreterService : IInterpreterService
    {
        private readonly IInterpreterHandler _interpreterHandler;

        public InterpreterService(IInterpreterHandler interpreterHandler)
        {
            _interpreterHandler = interpreterHandler;
        }

        public async Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter)
        {
            return await _interpreterHandler.AddAsync(interpreter);
        }

        public async Task<InterpreterViewModel> UpdateAsync(InterpreterModifyModel interpreter)
        {
            return await _interpreterHandler.UpdateAsync(interpreter);
        }

        public async Task<InterpreterViewModel> GetAsync(Guid id)
        {
            return await _interpreterHandler.GetAsync(id);
        }
    }
}
