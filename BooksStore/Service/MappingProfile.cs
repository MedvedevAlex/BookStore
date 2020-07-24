using AutoMapper;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using System.Linq;
using ViewModel.Models;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.JoinTables;
using ViewModel.Models.Painters;
using ViewModel.Models.Publishers;
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
                .ForMember(g => g.Genre, g => g.MapFrom(gr => gr.Genre.Name))
                .ForMember(a => a.Authors, a => a.MapFrom(ar => ar.AuthorBooks.Select(s => s.Author)))
                .ForMember(a => a.Painters, a => a.MapFrom(ar => ar.PainterBooks.Select(s => s.Painter)));
            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeModel>().ReverseMap();

            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Author, AuthorShortModel>();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();

            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<Publisher, PublisherShortModel>().ReverseMap();

            CreateMap<Painter, PainterModel>().ReverseMap();
            CreateMap<Painter, PainterShortModel>();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
            CreateMap<PainterStyle, PainterStyleModel>().ReverseMap();

            CreateMap<Interpreter, InterpreterModel>().ReverseMap();
            CreateMap<InterpreterBook, InterpreterBookModel>().ReverseMap();

            CreateMap<Shop, ShopModel>().ReverseMap();
            CreateMap<WorkShedule, WorkSheduleModel>().ReverseMap();
        }
    }
}
