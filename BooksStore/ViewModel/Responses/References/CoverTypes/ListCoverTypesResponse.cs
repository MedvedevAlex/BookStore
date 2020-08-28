using System.Collections.Generic;
using ViewModel.Models.References;

namespace ViewModel.Responses.References.CoverTypes
{
    /// <summary>
    /// Ответ тип переплета
    /// </summary>
    public class ListCoverTypesResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция типы переплета
        /// </summary>
        public List<CoverTypeModel> CoverTypes { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
