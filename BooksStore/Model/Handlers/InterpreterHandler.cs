using System.Linq;
using AutoMapper;
using Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using ViewModel.Models.Interpreters;
using Model.Entities.JoinTables;
using ViewModel.Handlers;

namespace Service.PublisherRepos
{
    /// <summary>
    /// Хэндлер Переводчик
    /// </summary>
    public class InterpreterHandler : IInterpreterHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public InterpreterHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory(); ;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить Переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Модель переводчик</returns>
        public async Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter)
        {
            var interpreterEntity = _mapper.Map<Interpreter>(interpreter);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var newBooksEntitites = await context.Books
                    .Where(b => interpreter.BooksIds.Contains(b.Id))
                    .Select(b => new InterpreterBook() { Book = b, Interpreter = interpreterEntity })
                    .ToListAsync();
                interpreterEntity.InterpreterBooks = newBooksEntitites;

                await context.Interpreters.AddAsync(interpreterEntity);
                await context.SaveChangesAsync();
            }
            return new InterpreterViewModel();
        }
    }
}
