using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class TabBook
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? BookPublished { get; set; }
        public int? BookPages { get; set; }
        public int? BookRate { get; set; }
        public string BookBrief { get; set; }
        public int? BookGenre { get; set; }
        public DateTime? BookJoinDate { get; set; }
        public int UserId { get; set; }
        public string BookImg64 { get; set; }
    }
}
