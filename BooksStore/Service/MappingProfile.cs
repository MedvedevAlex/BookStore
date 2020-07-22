using AutoMapper;
using Model.Entities;
using ViewModel.Models;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();

            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();
            
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            
            CreateMap<Painter, PainterModel>().ReverseMap();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
            CreateMap<PainterStyle, PainterStyleModel>().ReverseMap();
        }
    }
}
