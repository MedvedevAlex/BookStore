﻿using System;
using System.Threading.Tasks;
using ViewModel.Models.Painters;
using ViewModel.Responses;
using ViewModel.Responses.Painters;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        Task<PainterViewResponse> AddAsync(PainterModifyModel painter);
        Task<PainterViewResponse> UpdateAsync(PainterModifyModel painter);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PainterViewResponse> GetAsync(Guid id);
        Task<PainterPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<PainterPreviewResponse> SearchByNameAsync(string painterName, int takeCount, int skipCount);
        Task<PainterPreviewResponse> SearchByStyleAsync(string styleName, int takeCount, int skipCount);
    }
}