using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace libraryManagement.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Author { get; set; }
        [MaxLength(255)]
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        [MaxLength(13)]
        public string ISBN { get; set; }
        public int Stock { get; set; }
    }
}

