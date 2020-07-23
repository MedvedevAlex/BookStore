using AutoMapper;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using ViewModel.Models;
using ViewModel.Models.JoinTables;
using ViewModel.Models.References;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeModel>().ReverseMap();

            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();
            
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            
            CreateMap<Painter, PainterModel>().ReverseMap();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
            CreateMap<PainterStyle, PainterStyleModel>().ReverseMap();

            CreateMap<Interpreter, InterpreterModel>().ReverseMap();
            CreateMap<InterpreterBook, InterpreterBookModel>().ReverseMap();

            CreateMap<Shop, ShopModel>().ReverseMap();
            CreateMap<WorkShedule, WorkSheduleModel>().ReverseMap();
        }
    }
}
