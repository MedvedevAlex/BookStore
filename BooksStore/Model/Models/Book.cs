using System;
using System.Collections.Generic;
using InterfaceDB.Enums;
using InterfaceDB.JoinTables;

namespace InterfaceDB.Models
{
    //todo: модель только для базы, распарсить на составляющие MappingExtencion
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public Cover Cover { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }
        public string Dimensions { get; set; }
        public int NumbersPages { get; set; }
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
        public int Edition { get; set; }
        public byte AgeLimit { get; set; }
        public decimal Weight { get; set; }
        public int CountCustomers { get; set; }
        public decimal AvgReview { get; set; }//ignore

        public ICollection<AuthorBook> AuthorBooks { get; } = new List<AuthorBook>();

        public Publisher Publisher { get; set; }

        public ICollection<PainterBook> PainterBooks { get; } = new List<PainterBook>();
    }
}
