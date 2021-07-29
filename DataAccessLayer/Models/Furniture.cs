using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Furniture :BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        [Required]
        public FurnitureCategory Category { get; set; }
        public ICollection<FurnitureImage> Images { get; set; }


    }
}
