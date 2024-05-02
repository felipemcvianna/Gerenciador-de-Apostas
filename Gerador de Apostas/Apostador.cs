namespace Gerador_de_Apostas
{
    public class Apostador
    {
        public string Nome { get; set; }
        public int[][] Apostas { get; set; } = new int[0][];
        public int[][] JogosVencedores { get; set; } = new int[0][];
        public AdmApostas AdmApostas { get; set; }
        public Apostador(string nome, AdmApostas adm)
        {
            Nome = nome;
            adm.RegistrarApostador(this);
        }
        public void Apostar(int QtdNumeros, int QtdApostas)
        {            
            try
            {                
                //Quantidade mínima de apostas é de 6 numeros e máximo de 100
                //No mínimo um jogo e nó máximo 15 
                if ((QtdNumeros >= 6 && QtdNumeros <= 100) && (QtdApostas <= 15 && QtdApostas > 0))
                {
                    Apostas = new int[QtdApostas][];
                    for (int linha = 0; linha < QtdApostas; linha++)
                    {
                        Console.WriteLine($"\n{Nome}, digite os numeros do {linha + 1}° jogo\n");
                        Apostas[linha] = new int[QtdNumeros];                        
                        for (int Numero = 0; Numero < QtdNumeros; Numero++)
                        {
                            do
                            {
                                Console.Write($"Digite o {Numero + 1}° número: ");
                                Apostas[linha][Numero] = int.Parse(Console.ReadLine());
                            } while (NumeroJaExisteNaLinha(Apostas[linha], Numero));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Quantidade de números (7 - 100) ou apostas ( 0 - 15) fora dos limites permitidos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Verifica se o array já possui o numero atual
        private bool NumeroJaExisteNaLinha(int[] linha, int NumeroAtual)
        {
            int numeroAtualAvaliado = linha[NumeroAtual];            
            for (int i = 0; i < NumeroAtual; i++)
            {
                if (linha[i] == numeroAtualAvaliado)
                {
                    Console.WriteLine("Número já digitado anteriormente, digite outro número.");
                    return true;
                }
            }
            return false;
        }
    }
}
