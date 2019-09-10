using System.ComponentModel.DataAnnotations;

namespace InterfaceDB.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DataType Data { get; set; }
        [MaxLength(20)]
        public string Publisher { get; set; }
        [MaxLength(10)]
        public string Cover { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string Language { get; set; }
        [Range(0, 10)]
        public long ISBN_10 { get; set; }
        [Range(0, 13)]
        public long ISBN_13 { get; set; }
        [MaxLength(10)]
        public string Dimensions { get; set; }
        public float AvgReview { get; set; }
        public int CountCustomers { get; set; }
    }
}
