using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_PetChop_Versao5_EllanoLemos
{
    public class Agendamentos
    {
        public string Cliente { get; set; } = string.Empty;

        public string Pet { get; set; } = string.Empty;

        public string Servico { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public string Horario { get; set; } = string.Empty;

        public string Observacoes { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
