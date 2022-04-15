using System;
using System.Collections.Generic;
using System.Text;

namespace VenturaHRPB.Model
{
    public class EmpresaModel
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Area { get; set; }

        public List<VagasModel> VagasListadas { get; set; }
    }
}
