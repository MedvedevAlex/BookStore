using AutoMapper;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using System.Linq;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Deliveries;
using ViewModel.Models.Interpreters;
using ViewModel.Models.JoinTables;
using ViewModel.Models.Orders;
using ViewModel.Models.Painters;
using ViewModel.Models.Payments;
using ViewModel.Models.Publishers;
using ViewModel.Models.References;
using ViewModel.Models.Shops;
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
                .ForMember(bvm => bvm.CoverType, e => e.MapFrom(b => b.CoverType.Name))
                .ForMember(bvm => bvm.Language, e => e.MapFrom(b => b.Language.Name))
                .ForMember(bvm => bvm.Genre, e => e.MapFrom(b => b.Genre.Name))
                .ForMember(bvm => bvm.Authors, e => e.MapFrom(b => b.AuthorBooks.Select(ab => ab.Author)))
                .ForMember(bvm => bvm.Painters, e => e.MapFrom(b => b.PainterBooks.Select(pb => pb.Painter)))
                .ForMember(bvm => bvm.Interpreters, e => e.MapFrom(b => b.InterpreterBooks.Select(ib => ib.Interpreter)));
            CreateMap<Book, BookPreviewModel>()
                .ForMember(bpm => bpm.Authors, e => e.MapFrom(b => b.AuthorBooks.Select(ab => ab.Author)));
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
                .ForMember(avm => avm.Books, e => e.MapFrom(a => a.AuthorBooks.Select(ab => ab.Book)));
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
                .ForMember(pvm => pvm.Style, e => e.MapFrom(p => p.Style.Name))
                .ForMember(pvm => pvm.Books, e => e.MapFrom(p => p.PainterBooks.Select(pb => pb.Book)));
            CreateMap<Painter, PainterPreviewModel>()
                .ForMember(pvm => pvm.Style, e => e.MapFrom(p => p.Style.Name));
            CreateMap<Painter, PainterModifyModel>().ReverseMap();
            CreateMap<Painter, PainterShortModel>();
            CreateMap<PainterBook, PainterBookModel>().ReverseMap();
            #endregion
            #region Карты Переводчик
            CreateMap<Interpreter, InterpreterModel>().ReverseMap();
            CreateMap<Interpreter, InterpreterViewModel>()
                .ForMember(ivm => ivm.Books, e => e.MapFrom(i => i.InterpreterBooks.Select(ib => ib.Book)));
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
            #region Карты Заказ
            CreateMap<Order, OrderModel>();
            #endregion
            #region Карты Доставка
            CreateMap<Delivery, DeliveryModifyModel>().ReverseMap();
            CreateMap<Delivery, DeliveryModel>();
            #endregion
            #region Карты Платеж
            CreateMap<Payment, PaymentModel>();
            CreateMap<PaymentCreateModel, Payment>();
            #endregion
        }
    }
}
