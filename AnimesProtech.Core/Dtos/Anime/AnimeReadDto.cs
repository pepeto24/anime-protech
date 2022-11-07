using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Dtos
{
    public class AnimeReadDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Diretor { get; set; }
        public bool Ativo { get; set; }
    }
}
