using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References.CoverTypes;

namespace Service.References
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ICoverTypeHandler _coverTypeHandler;

        public CoverTypeService(ICoverTypeHandler coverTypeHandler)
        {
            _coverTypeHandler = coverTypeHandler;
        }

        public async Task<CoverTypeResponse> AddAsync(CoverTypeModel coverType)
        {
            try
            {
                return new CoverTypeResponse
                {
                    CoverType = await _coverTypeHandler.AddAsync(coverType)
                };
            }
            catch (Exception e)
            {
                return new CoverTypeResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<CoverTypeResponse> UpdateAsync(CoverTypeModel coverType)
        {
            try
            {
                return new CoverTypeResponse
                {
                    CoverType = await _coverTypeHandler.UpdateAsync(coverType)
                };
            }
            catch (Exception e)
            {
                return new CoverTypeResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _coverTypeHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<CoverTypeResponse> GetAsync(Guid id)
        {
            try
            {
                return new CoverTypeResponse
                {
                    CoverType = await _coverTypeHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new CoverTypeResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<ListCoverTypesResponse> GetAsync()
        {
            try
            {
                return await _coverTypeHandler.GetAsync();
            }
            catch (Exception e)
            {
                return new ListCoverTypesResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<ListCoverTypesResponse> SearchByNameAsync(string coverTypeName)
        {
            try
            {
                return await _coverTypeHandler.SearchByNameAsync(coverTypeName);
            }
            catch (Exception e)
            {
                return new ListCoverTypesResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
