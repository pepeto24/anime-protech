using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Dtos.Page
{
    public class PageFilterDto
    {
        public string OrderBy { get; set; } = "";
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
    }
}
