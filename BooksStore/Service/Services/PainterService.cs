﻿using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Painters;
using System.Threading.Tasks;
using System;
using ViewModel.Responses.Painters;
using ViewModel.Responses;

namespace Service.Services
{
    public class PainterService : IPainterService
    {
        private readonly IPainterHandler _painterHandler;

        public PainterService(IPainterHandler painterHandler)
        {
            _painterHandler = painterHandler;
        }

        public async Task<PainterViewResponse> AddAsync(PainterModifyModel painter)
        {
            try
            {
                return new PainterViewResponse()
                {
                    Painter = await _painterHandler.AddAsync(painter)
                };
            }
            catch (Exception e)
            {
                return new PainterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterViewResponse> UpdateAsync(PainterModifyModel painter)
        {
            try
            {
                return new PainterViewResponse()
                {
                    Painter = await _painterHandler.UpdateAsync(painter)
                };
            }
            catch (Exception e)
            {
                return new PainterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _painterHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterViewResponse> GetAsync(Guid id)
        {
            try
            {
                return new PainterViewResponse()
                {
                    Painter = await _painterHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new PainterViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            try
            {
                return await _painterHandler.GetAsync(takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new PainterPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterPreviewResponse> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            try
            {
                return await _painterHandler.SearchByNameAsync(painterName ,takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new PainterPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PainterPreviewResponse> SearchByStyleAsync(string styleName, int takeCount, int skipCount)
        {
            try
            {
                return await _painterHandler.SearchByStyleAsync(styleName, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new PainterPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
