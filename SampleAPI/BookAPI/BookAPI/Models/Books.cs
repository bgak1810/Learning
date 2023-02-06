using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{

    public class GenGuid
    {
        [Key]
        public Guid bookid { get; set; }
    }
    public class Books:GenGuid
    {
        public string bookname { get; set; }

        public int price { get; set; }

        public string author { get; set; }
    }

    public class NewBook
    {
        public string bookname { get; set; }

        public int price { get; set; }

        public string author { get; set; }
    }
}
