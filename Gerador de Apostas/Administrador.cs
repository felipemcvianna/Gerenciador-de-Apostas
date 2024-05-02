using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Apostas
{
    public interface Administrador
    {
        public Sorteio Sorteios { get; set; }
        public HashSet<Apostador> Apostadores { get; set; }        
        public void RegistrarApostador(Apostador Apostador);
        public void RegistrarSorteio(Sorteio Sorteio);
        public void Vencedores();
    }
}
