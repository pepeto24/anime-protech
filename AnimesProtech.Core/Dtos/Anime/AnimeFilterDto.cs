using AnimesProtech.Core.Dtos.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Dtos
{
    public class AnimeFilterDto : PageFilterDto
    {
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Diretor { get; set; }
    }
}
