using System.Collections.Generic;

namespace Model.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}