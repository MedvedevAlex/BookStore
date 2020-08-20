using AutoMapper;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using System.Linq;
using ViewModel.Models;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Interpreters;
using ViewModel.Models.JoinTables;
using ViewModel.Models.Orders;
using ViewModel.Models.Painters;
using ViewModel.Models.Publishers;
using ViewModel.Models.References;
using ViewModel.Models.Users;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Карты Книга
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, BookViewModel>()
                .ForMember(ct => ct.CoverType, ct => ct.MapFrom(cvt => cvt.CoverType.Name))
                .ForMember(l => l.Language, l => l.MapFrom(lg => lg.Language.Name))
                .ForMember(g => g.Genre, g => g.MapFrom(gr => gr.Genre.Name))
                .ForMember(a => a.Authors, a => a.MapFrom(ar => ar.AuthorBooks.Select(s => s.Author)))
                .ForMember(p => p.Painters, p => p.MapFrom(pr => pr.PainterBooks.Select(s => s.Painter)))
                .ForMember(i => i.Interpreters, i => i.MapFrom(ir => ir.InterpreterBooks.Select(s => s.Interpreter)));
            CreateMap<Book, BookPreviewModel>()
                .ForMember(a => a.Authors, a => a.MapFrom(ar => ar.AuthorBooks.Select(s => s.Author)));
            CreateMap<Book, BookModifyModel>().ReverseMap();
            #endregion
            #region Карты Справочники
            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeModel>().ReverseMap();
            CreateMap<PainterStyle, PainterStyleModel>().ReverseMap();
            CreateMap<WorkShedule, WorkSheduleModel>().ReverseMap();
            #endregion
            #region Карты Автор
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>()
                .ForMember(avm => avm.Books, mce => mce.MapFrom(a => a.AuthorBooks.Select(ab => ab.Book)));
            CreateMap<Author, AuthorPreviewModel>();
            CreateMap<Author, AuthorModifyModel>().ReverseMap();
            CreateMap<Author, AuthorShortModel>();
            CreateMap<AuthorBook, AuthorBookModel>().ReverseMap();
            #endregion
            #region Карты Издатель
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<Publisher, PublisherPreviewModel>();
            CreateMap<Publisher, PublisherModifyModel>().ReverseMap();
            CreateMap<Publisher, PublisherShortModel>();
            #endregion
            #region Карты Художник
            CreateMap<Painter, PainterModel>().ReverseMap();
            CreateMap<Painter, PainterViewModel>()
                .ForMember(pm => pm.Style, pm => pm.MapFrom(p => p.Style.Name))
                .ForMember(pm => pm.Books, pm => pm.MapFrom(p => p.PainterBooks.Select(s => s.Book)));
            CreateMap<Painter, PainterPreviewModel>()
                .ForMember(pm => pm.Style, pm => pm.MapFrom(p => p.Style.Name));
            CreateMap<Painter, PainterModifyModel>().ReverseMap();
            CreateMap<Painter, PainterShortModel>();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
            #endregion
            #region Карты Переводчик
            CreateMap<Interpreter, InterpreterModel>().ReverseMap();
            CreateMap<Interpreter, InterpreterViewModel>()
                .ForMember(im => im.Books, im => im.MapFrom(i => i.InterpreterBooks.Select(s => s.Book)));
            CreateMap<Interpreter, InterpreterPreviewModel>();
            CreateMap<Interpreter, InterpreterModifyModel>().ReverseMap();
            CreateMap<Interpreter, InterpreterShortModel>();
            CreateMap<InterpreterBook, InterpreterBookModel>().ReverseMap();
            #endregion
            #region Карты Магазин
            CreateMap<Shop, ShopModel>().ReverseMap();
            #region Карты Магазин
            CreateMap<Shop, ShopModel>().ReverseMap();
            #endregion
            #endregion
            #region Карты Пользователь
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserModifyModel>().ReverseMap();
            CreateMap<User, UserShortModel>().ReverseMap();
            CreateMap<UserShortModel, UserModifyModel>();
            #endregion
            #region Заказ
            CreateMap<Order, OrderModel>();
            #endregion
        }
    }
}
