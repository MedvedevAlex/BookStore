using AutoMapper;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using ViewModel.Models;
using ViewModel.Models.Book;
using ViewModel.Models.JoinTables;
using ViewModel.Models.Publisher;
using ViewModel.Models.References;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, BookViewModel>()
                .ForMember(ct => ct.CoverType, ct => ct.MapFrom(cvt => cvt.CoverType.Name))
                .ForMember(l => l.Language, l => l.MapFrom(lg => lg.Language.Name))
                .ForMember(g => g.Genre, g => g.MapFrom(gr => gr.Genre.Name));
            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeModel>().ReverseMap();

            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();
            
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<Publisher, PublisherShortModel>().ReverseMap();
            
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
