using InterfaceDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDB.JoinTables
{
    public class AuthorBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
