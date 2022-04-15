

using System.Collections.Generic;

namespace VenturaHRPB.Model
{
    public class VagasModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public List<CandidatoModel> candidatos { get; set; }

        public string Descricao { get; set; }

        public List<CompetenciaModel> Competencias { get; set; }

        public string Empresa { get; set; }
    }
}
