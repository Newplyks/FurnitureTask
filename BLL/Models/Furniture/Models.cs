using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Furniture
{
    public class InputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class OutputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedTime { get; set; }

    }

    public class CollectionOutputModel
    {
        public IEnumerable<OutputModel> Furniture { get; set; }
        public int Total { get; set; }
        public int Size { get; set; }
        public int Skip { get; set; }
    }



}
