﻿namespace Gerador_de_Apostas
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
        //Sorteia 6 numeros entre 0 e 100
        public void Sortear()
        {
            var random = new Random();
            for (int i = 0; i < QtdSorteio; i++)
            {
                int numero;
                do
                {
                    numero = random.Next(0, 101);
                } while (NumerosSorteados.Contains(numero));
                NumerosSorteados[i] = numero;
            }
        }
    }
}
