namespace Gerador_de_Apostas
{
    public class Sorteio
    {
        public DateTime DiaAposta { get; set; } = DateTime.Now;
        private AdmApostas privateadm;
        public AdmApostas Administrador
        {
            get { return privateadm; }
            set
            {
                if(privateadm == null)
                {
                    privateadm = value;                    
                }
                else
                {
                    throw new Exception("Administrador já registrado");
                }
            }
        }

        private const int QtdSorteio = 6;
        public int[] NumerosSorteados { get; set; } = new int[QtdSorteio];
        public Sorteio(AdmApostas adm)
        {
            adm.RegistrarSorteio(this);
            Sortear();
        }
        public void Sortear()
        {
            for (int i = 0; i < QtdSorteio; i++)
            {
                int numero;
                var random = new Random();
                do
                {
                    numero = random.Next(0, 100);
                } while (NumerosSorteados.Contains(numero));
                NumerosSorteados[i] = numero;
            }
        }
    }
}
