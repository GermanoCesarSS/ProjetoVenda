using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_2023.model
{
    internal class Telefone
    {
        //TELEFONE = {COD, NUMERO, CODOPERADORA_FK}
        public int Cod { get; set; }
        public String Numero { get; set; }
        public Operadora Operadora { get; set; }
        public Telefone() { } 
    }
}
