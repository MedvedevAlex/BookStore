using System;
using System.Threading.Tasks;
using ViewModel.Models.Interpreters;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Interpreters;

namespace ViewModel.Handlers
{
    public interface IInterpreterHandler
    {
        Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter);
        Task<InterpreterViewModel> UpdateAsync(InterpreterModifyModel interpreter);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<InterpreterViewModel> GetAsync(Guid id);
        Task<InterpreterPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<InterpreterPreviewResponse> SearchByNameAsync(string interpreterName, int takeCount, int skipCount);
    }
}