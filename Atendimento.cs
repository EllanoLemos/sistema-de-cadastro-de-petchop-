using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_PetChop_Versao5_EllanoLemos
{
    public class Atendimento
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public string Pet { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}
