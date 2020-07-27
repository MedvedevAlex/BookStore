using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Interpreters;

namespace ViewModel.Interfaces.Services
{
    public interface IInterpreterService
    {
        Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter);
        Task<InterpreterViewModel> UpdateAsync(InterpreterModifyModel interpreter);
        void Delete(Guid id);
        Task<InterpreterViewModel> GetAsync(Guid id);
        Task<List<InterpreterPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<List<InterpreterPreviewModel>> SearchByNameAsync(string interpreterName, int takeCount, int skipCount);
    }
}