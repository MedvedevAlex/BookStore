using System.Collections.Generic;
using ViewModel.Models.References;

namespace ViewModel.Responses.References.CoverTypes
{
    /// <summary>
    /// Ответ коллекция типов переплета
    /// </summary>
    public class ListCoverTypesResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция типов переплета
        /// </summary>
        public List<CoverTypeModel> CoverTypes { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
