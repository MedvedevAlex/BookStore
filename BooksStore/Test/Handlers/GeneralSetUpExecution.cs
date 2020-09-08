using Model;
using NUnit.Framework;

namespace Test.Handlers
{
    /// <summary>
    /// Класс отвечающий за настройку тестов перед и после выполнения
    /// </summary>
    public class GeneralSetUpExecution
    {
        /// <summary>
        /// Метод создающий базу данных перед началом выполнения
        /// всех тестов
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            using (var context = new BookContextFactory().CreateDbContext(new string[0]))
            {
                context.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Метод удаляющий базу данных после выполнения
        /// всех тестов
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            using (var context = new BookContextFactory().CreateDbContext(new string[0]))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
