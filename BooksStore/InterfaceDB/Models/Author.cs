using System.Collections.Generic;

namespace InterfaceDB.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }

        public ICollection<Book> Books { get; set; }//вторичный ключ
    }
}