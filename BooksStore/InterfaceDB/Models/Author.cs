using InterfaceDB.Enums;
using System.Collections.Generic;

namespace InterfaceDB.Models
{
    public class Author
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public Style Style { get;set; }

        public IEnumerable<Book> Books { get; set; }//вторичный ключ
    }
}