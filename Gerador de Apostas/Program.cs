using System.Xml;

namespace Gerador_de_Apostas
{
    class Program
    {
        static void Main(string[] args)
        {
            AdmApostas admApostas = new AdmApostas();
            Sorteio s = new(admApostas);
            Apostador felipe = new("Felipe", admApostas);            
            admApostas.Vencedores();
        }
    }
}




















