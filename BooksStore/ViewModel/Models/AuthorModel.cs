using System.Collections.Generic;

namespace ViewModel.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }

        public ICollection<AuthorBookModel> AuthorBooks { get; set; };
    }
}