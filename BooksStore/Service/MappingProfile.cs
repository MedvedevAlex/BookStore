using AutoMapper;
using Model.Models;
using ViewModel.Models;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Painter, PainterModel>().ReverseMap();
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
        }
    }
}
