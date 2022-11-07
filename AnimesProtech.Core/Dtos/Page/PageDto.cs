using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Dtos.Page
{
    public class PageDto<T>
    {
        public IEnumerable<T> Content { get; set; } = new T[0];
        public string OrderBy { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
