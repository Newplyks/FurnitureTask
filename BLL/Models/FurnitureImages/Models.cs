using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.FurnitureImages
{
    public class OutputModel
    {
        public Dictionary<Guid, byte[]> Images { get; set; }
    }
}
