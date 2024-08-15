using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace libraryManagement.Models
{
    [SQLite.Table("RentalBooks")]
    public class RentalBooks
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int BookId { get; set; }

        [Ignore]
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public int RentalID { get; set; }

        [Ignore]
        public Rental Rental { get; set; }
    }
}

