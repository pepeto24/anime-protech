using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public DateTime? DataInativacao { get; set; }
        public bool Ativo { get; set; }
    }
}
