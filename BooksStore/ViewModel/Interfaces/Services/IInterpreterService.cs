using System;
using System.Threading.Tasks;
using ViewModel.Models.Interpreters;
using ViewModel.Responses;
using ViewModel.Responses.Interpreters;

namespace ViewModel.Interfaces.Services
{
    public interface IInterpreterService
    {
        Task<InterpreterViewResponse> AddAsync(InterpreterModifyModel interpreter);
        Task<InterpreterViewResponse> UpdateAsync(InterpreterModifyModel interpreter);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<InterpreterViewResponse> GetAsync(Guid id);
        Task<InterpreterPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<InterpreterPreviewResponse> SearchByNameAsync(string interpreterName, int takeCount, int skipCount);
    }
}