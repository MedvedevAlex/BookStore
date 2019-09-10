namespace InterfaceDB.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public long ISBN_10 { get; set; }
        public long ISBN_13 { get; set; }
        public string Dimensions { get; set; }
        public float AvgReview { get; set; }
        public int CountCustomers { get; set; }
    }
}
