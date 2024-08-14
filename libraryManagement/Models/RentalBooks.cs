using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagement.Models
{
    public class RentalBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public required Book Book { get; set; }
        public required int Quantity { get; set; }

        [ForeignKey("RentalID")]
        public int RentalID { get; set; }
        public required Rental Rental { get; set; }
    }
}
