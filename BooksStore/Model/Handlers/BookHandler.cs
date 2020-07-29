using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Models;
using ViewModel.Models.Books;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Books;

namespace Model.Handlers
{
    /// <summary>
    /// Хэндлер Книги
    /// </summary>
    public class BookHandler : IBookHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;
        private readonly GoogleDriveApi _googleDriveApi;
        private readonly string _googleFolderId = "1iam-yQGd3k3Vo9hQ2E8_PtucM6Lt9Qal";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public BookHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _googleDriveApi = new GoogleDriveApi();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> AddAsync(BookModifyModel book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var coverType = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == book.CoverTypeId);
                var genre = await context.Genres
                    .FirstOrDefaultAsync(g => g.Id == book.GenreId);
                var language = await context.Languages
                    .FirstOrDefaultAsync(l => l.Id == book.LanguageId);
                var publisher = await context.Publishers
                    .FirstOrDefaultAsync(p => p.Id == book.PublisherId);
                bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: не удалось найти тип переплета");
                bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: не удалось найти жанр");
                bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: не удалось найти язык");
                bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: не удалось найти издателя");

                var newAuthorsEntities = await context.Authors
                    .Where(a => book.AuthorsIds.Contains(a.Id))
                    .Select(a => new AuthorBook() { Book = bookEntity, Author = a })
                    .ToListAsync();
                var newPaintersEntities = await context.Painters
                    .Where(p => book.PaintersIds.Contains(p.Id))
                    .Select(p => new PainterBook() { Book = bookEntity, Painter = p })
                    .ToListAsync();
                var newInterpretersEntities = await context.Interpreters
                    .Where(i => book.InterpretersIds.Contains(i.Id))
                    .Select(i => new InterpreterBook() { Book = bookEntity, Interpreter = i })
                    .ToListAsync();
                bookEntity.AuthorBooks = newAuthorsEntities;
                bookEntity.PainterBooks = newPaintersEntities;
                bookEntity.InterpreterBooks = newInterpretersEntities;
                await InsertOrUpdateImagesAsync(book, context);

                await context.Books.AddAsync(bookEntity);
                await context.SaveChangesAsync();

            }
            return await GetAsync(book.Id);
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task<BookViewModel> UpdateAsync(BookModifyModel book)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Include(ib => ib.InterpreterBooks)
                        .ThenInclude(ir => ir.Interpreter)
                    .Include(pb => pb.PainterBooks)
                        .ThenInclude(pr => pr.Painter)
                    .FirstOrDefaultAsync(b => b.Id == book.Id);
                if (bookEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти книгу");

                context.Entry(bookEntity).CurrentValues.SetValues(book);

                var coverType = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == book.CoverTypeId);
                var genre = await context.Genres
                    .FirstOrDefaultAsync(g => g.Id == book.GenreId);
                var language = await context.Languages
                    .FirstOrDefaultAsync(l => l.Id == book.LanguageId);
                var publisher = await context.Publishers
                    .FirstOrDefaultAsync(p => p.Id == book.PublisherId);
                bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: не удалось найти тип переплета");
                bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: не удалось найти жанр");
                bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: не удалось найти язык");
                bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: не удалось найти издателя");

                var newAuthorsEntities = context.Authors
                    .Where(a => book.AuthorsIds.Contains(a.Id));
                var newPaintersEntities = context.Painters
                    .Where(p => book.PaintersIds.Contains(p.Id));
                var newInterpretersEntities = context.Interpreters
                    .Where(i => book.InterpretersIds.Contains(i.Id));

                context.TryUpdateManyToMany(bookEntity.AuthorBooks, newAuthorsEntities
                    .Select(s => new AuthorBook
                    {
                        BookId = bookEntity.Id,
                        AuthorId = s.Id
                    }), s => s.AuthorId);

                context.TryUpdateManyToMany(bookEntity.PainterBooks, newPaintersEntities
                    .Select(p => new PainterBook
                    {
                        BookId = bookEntity.Id,
                        PainterId = p.Id
                    }), p => p.PainterId);

                context.TryUpdateManyToMany(bookEntity.InterpreterBooks, newInterpretersEntities
                    .Select(i => new InterpreterBook
                    {
                        BookId = bookEntity.Id,
                        InterpreterId = i.Id
                    }), i => i.InterpreterId);
                
                await InsertOrUpdateImagesAsync(book, context);

                context.Books.Update(bookEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(book.Id);
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (bookEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти книгу");

                await DeleteImagesAsync(id, context);

                context.Books.Remove(bookEntity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .Include(c => c.CoverType)
                    .Include(g => g.Genre)
                    .Include(l => l.Language)
                    .Include(p => p.Publisher)
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Include(ib => ib.InterpreterBooks)
                        .ThenInclude(ir => ir.Interpreter)
                    .Include(pb => pb.PainterBooks)
                        .ThenInclude(pr => pr.Painter)
                    .FirstOrDefaultAsync(b => b.Id == id);
                return _mapper.Map<BookViewModel>(bookEntity);
            }
        }

        /// <summary>
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция превью книг</returns>
        public async Task<BookPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Books;
                result.PreviewBooks = await query
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Колекция книг</returns>
        public async Task<BookPreviewResponse> SearchByAuthorAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = from author in context.Authors
                            join authorbook in context.AuthorBooks on author.Id equals authorbook.AuthorId
                            join book in context.Books on authorbook.BookId equals book.Id
                            where author.Name.Contains(searchString.Trim())
                            select book;

                result.PreviewBooks = await query
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(b => _mapper.Map<BookPreviewModel>(b))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns></returns>
        public async Task<BookPreviewResponse> SearchByNameAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Books
                    .Where(b => b.Name.Contains(searchString.Trim()));

                result.PreviewBooks = await query
                    .Include(ab => ab.AuthorBooks)
                            .ThenInclude(ar => ar.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по жанру
        /// </summary>
        /// <param name="searchString">Название жанра</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Колекция книг</returns>
        public async Task<BookPreviewResponse> SearchByGenreAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var genresEntities = context.Genres
                    .Where(g => g.Name.Contains(searchString.Trim()))
                    .Select(s => s.Name);
                var query = context.Books
                    .Where(b => genresEntities.Contains(b.Genre.Name));

                result.PreviewBooks = await query
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Вставить или обновить картинки
        /// </summary>
        /// <param name="book">Модель книга</param>
        /// <param name="context">Подключение к базе данных</param>
        /// <returns></returns>
        private async Task InsertOrUpdateImagesAsync(BookModifyModel book, BookContext context)
        {
            var resultImages = new List<Image>();
            var imagesEntities = await context.Images
                .Where(i => i.BookId == book.Id)
                .ToListAsync();
            if (imagesEntities.Count == 0)
                foreach (var image in book.Images)
                    resultImages.Add(UploadFileToGoogleDrive(book.Id, image));
            else
            {
                var imagesEntitiesTypes = imagesEntities.Select(i => i.ImageType);
                foreach (var image in book.Images)
                    if (imagesEntitiesTypes.Contains(image.ImageType))
                    {
                        var imageUpdate = imagesEntities.FirstOrDefault(i => i.ImageType == image.ImageType);
                        _googleDriveApi.UpdateFile(imageUpdate, image.File, _googleFolderId);
                    }
                    else
                        resultImages.Add(UploadFileToGoogleDrive(book.Id, image));
            }
            foreach (var item in resultImages)
            {
                item.Id = Guid.NewGuid();
                item.BookId = book.Id;
            }
            await context.Images.AddRangeAsync(resultImages);
        }

        /// <summary>
        /// Загрузить файл на гугл диск
        /// </summary>
        /// <param name="bookId">Идентификатор книги</param>
        /// <param name="image">Модель картинка</param>
        private Image UploadFileToGoogleDrive(Guid bookId, ImageModel image)
        {
            var fileName = string.Empty;
            switch (image.ImageType)
            {
                case ViewModel.Enums.ImageType.Preview:
                    fileName = $"{bookId}-preview.jpg";
                    break;
                case ViewModel.Enums.ImageType.View:
                    fileName = $"{bookId}-view.jpg";
                    break;
                default:
                    break;
            }
            var result = _googleDriveApi.UploadFile(image.File, _googleFolderId, fileName);
            result.ImageType = image.ImageType;
            return result;
        }

        /// <summary>
        /// Удалить картинки
        /// </summary>
        /// <param name="bookId">Идентификатор книги</param>
        /// <param name="context">Подключение к базе данных</param>
        /// <returns></returns>
        private async Task DeleteImagesAsync(Guid bookId, BookContext context)
        {
            var imagesEntities = await context.Images
                    .Where(i => i.BookId == bookId)
                    .ToListAsync();

            _googleDriveApi.DeleteFile(imagesEntities.Select(i => i.GoogleFileId).ToList());
            await context.Images.AddRangeAsync(imagesEntities);
        }
    }
}
