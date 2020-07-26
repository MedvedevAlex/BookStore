﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;

namespace ViewModel.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<PublisherViewModel> AddAsync(PublisherModifyModel publisher);
        Task<PublisherViewModel> UpdateAsync(PublisherModifyModel publisher);
        void DeleteAsync(Guid id);
        Task<PublisherViewModel> GetAsync(Guid id);
        Task<List<PublisherPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<List<PublisherPreviewModel>> SearchByNameAsync(string publisherName, int takeCount, int skipCount);
    }
}