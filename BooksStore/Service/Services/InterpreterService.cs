using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Interpreters;
using ViewModel.Responses;
using ViewModel.Responses.Interpreters;

namespace Service.Services
{
    public class InterpreterService : IInterpreterService
    {
        private readonly IInterpreterHandler _interpreterHandler;

        public InterpreterService(IInterpreterHandler interpreterHandler)
        {
            _interpreterHandler = interpreterHandler;
        }

        public async Task<InterpreterViewResponse> AddAsync(InterpreterModifyModel interpreter)
        {
            try
            {
                return new InterpreterViewResponse()
                {
                    Interpreter = await _interpreterHandler.AddAsync(interpreter)
                };
            }
            catch (Exception e)
            {
                return new InterpreterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<InterpreterViewResponse> UpdateAsync(InterpreterModifyModel interpreter)
        {
            try
            {
                return new InterpreterViewResponse()
                {
                    Interpreter = await _interpreterHandler.UpdateAsync(interpreter)
                };
            }
            catch (Exception e)
            {
                return new InterpreterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _interpreterHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
        
        public async Task<InterpreterViewResponse> GetAsync(Guid id)
        {
            try
            {
                return new InterpreterViewResponse()
                {
                    Interpreter = await _interpreterHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new InterpreterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<InterpreterPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            try
            {
                return await _interpreterHandler.GetAsync(takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new InterpreterPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<InterpreterPreviewResponse> SearchByNameAsync(string interpreterName, int takeCount, int skipCount)
        {
            try
            {
                return await _interpreterHandler.SearchByNameAsync(interpreterName, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new InterpreterPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
