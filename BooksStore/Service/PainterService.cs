﻿using System.Collections.Generic;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Painters;
using System.Threading.Tasks;
using System;

namespace Service.PainterRepos
{
    public class PainterService : IPainterService
    {
        private readonly IPainterHandler _painterHandler;

        public PainterService(IPainterHandler painterHandler)
        {
            _painterHandler = painterHandler;
        }

        public async Task<PainterModel> GetAsync(Guid id)
        {
            return await _painterHandler.GetAsync(id);
        }

        public async Task<List<PainterModel>> GetAsync(int takeCount, int skipCount)
        {
            return await _painterHandler.GetAsync(takeCount, skipCount);
        }

        public async Task<List<PainterModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            return await _painterHandler.SearchByNameAsync(painterName, takeCount, skipCount);
        }
    }
}
