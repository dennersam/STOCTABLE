using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Application.DTOs
{
    public class FornecedorDTO
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? RefBancarias { get; set; }
    }
}
