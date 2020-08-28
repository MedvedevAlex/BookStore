using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References;

namespace Service.References
{
    public class PainterStyleService : IPainterStyleService
    {
        private readonly IPainterStyleHandler _painterStyleHandler;

        public PainterStyleService(IPainterStyleHandler painterStyleHandler)
        {
            _painterStyleHandler = painterStyleHandler;
        }

        public async Task<PainterStyleResponse> AddAsync(PainterStyleModel painterStyle)
        {
            try
            {
                return new PainterStyleResponse
                {
                    Style = await _painterStyleHandler.AddAsync(painterStyle)
                };
            }
            catch (Exception e)
            {
                return new PainterStyleResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterStyleResponse> UpdateAsync(PainterStyleModel painterStyle)
        {
            try
            {
                return new PainterStyleResponse
                {
                    Style = await _painterStyleHandler.UpdateAsync(painterStyle)
                };
            }
            catch (Exception e)
            {
                return new PainterStyleResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _painterStyleHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }

        }

        public async Task<PainterStyleResponse> GetAsync(Guid id)
        {
            try
            {
                return new PainterStyleResponse
                {
                    Style = await _painterStyleHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new PainterStyleResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<ListPainterStylesResponse> GetAsync()
        {
            try
            {
                return new ListPainterStylesResponse
                {
                    Style = await _painterStyleHandler.GetAsync()
                };
            }
            catch (Exception e)
            {
                return new ListPainterStylesResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<ListPainterStylesResponse> SearchByNameAsync(string painterStyleName)
        {
            try
            {
                return new ListPainterStylesResponse
                {
                    Style = await _painterStyleHandler.SearchByNameAsync(painterStyleName)
                };
            }
            catch (Exception e)
            {
                return new ListPainterStylesResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
