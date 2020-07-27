﻿using System;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface IPainterStyleHandler
    {
        Task<PainterStyleModel> GetAsync(Guid id);
    }
}