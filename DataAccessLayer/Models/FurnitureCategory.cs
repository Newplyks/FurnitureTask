using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FurnitureCategory: BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Furniture> FurnitureCollection { get; set; }
    }
}
