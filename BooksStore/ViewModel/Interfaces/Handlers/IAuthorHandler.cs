﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Authors;

namespace ViewModel.Handlers
{
    public interface IAuthorHandler
    {
        Task<AuthorViewModel> AddAsync(AuthorModifyModel author);
        Task<AuthorViewModel> UpdateAsync(AuthorModifyModel author);
        Task<AuthorViewModel> GetAsync(Guid id);
        void DeleteAsync(Guid id);
        Task<List<AuthorPreviewModel>> GetAsync(int takeCount, int skipCount);
    }
}