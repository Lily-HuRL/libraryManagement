using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace libraryManagement.Models
{
    [SQLite.Table("Rentals")]
    public class Rental
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StudentId { get; set; }

        [Ignore]
        public List<RentalBooks> RentalBooks { get; set; } = new List<RentalBooks>();
        [Ignore]
        public Student Student { get; set; }
    }
}

