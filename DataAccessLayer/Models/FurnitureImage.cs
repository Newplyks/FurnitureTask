using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FurnitureImage :BaseEntity
    {
        public Guid FurnitureId { get; set; }
        public Furniture Furniture { get; set; }
        public string Path { get; set; }
    }
}
