using System.Collections.Generic;

namespace InterfaceDB.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Corporation { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}