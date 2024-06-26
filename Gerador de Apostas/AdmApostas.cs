﻿using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Apostas
{
    public class AdmApostas : Administrador
    {
        public string Nome { get; } = "MEGA SENA";
        public Sorteio Sorteios { get; set; }
        public HashSet<Apostador> Apostadores { get; set; } = new HashSet<Apostador>();
        public HashSet<Apostador> Quadra { get; set; } = new HashSet<Apostador>();
        public HashSet<Apostador> Quina { get; set; } = new HashSet<Apostador>();
        public HashSet<Apostador> Sena { get; set; } = new HashSet<Apostador>();

        private void Resultado()
        {
            //Limpar todos os ganhadores anteriores
            Quadra.Clear();
            Quina.Clear();
            Sena.Clear();

            if (Sorteios != null && Sorteios.NumerosSorteados != null && Apostadores.Any())
            {
                foreach (var apostador in Apostadores)
                {
                    //Verificando todas as apostas dos apostadores
                    apostador.JogosVencedores = new int[apostador.Apostas.Length][];
                    for (int linha = 0; linha < apostador.Apostas.Length; linha++)
                    {
                        int acertos = 0;
                        for (int coluna = 0; coluna < apostador.Apostas[linha].Length; coluna++)
                        {
                            //Verifica se o array de numeros sorteador possui o numero apostado na linha e coluna correspondente
                            if (Sorteios.NumerosSorteados.Contains(apostador.Apostas[linha][coluna]))
                            {
                                //intera a quantidade de acertos do apostador
                                acertos++;
                            }
                        }
                        //Verifica a quantidade de acertos de cada jogo
                        //O jogo vencedor é adicionado a matriz de jogos vencedores
                        if (acertos == 4)
                        {
                            apostador.JogosVencedores[linha] = apostador.Apostas[linha]; Quadra.Add(apostador);
                        }
                        else if (acertos == 5)
                        {
                            apostador.JogosVencedores[linha] = apostador.Apostas[linha]; Quina.Add(apostador);
                        }
                        else if (acertos == 6)
                        {
                            apostador.JogosVencedores[linha] = apostador.Apostas[linha]; Sena.Add(apostador);
                        }
                    }
                }
            }
        }
        //Metodo para mostrar os numeros sorteados e ganhadores
        public void Vencedores()
        {
            Resultado();
            MostrarNumerosSorteados();
            GanhadoresQuadra();
            GanhadoresQuina();
            GanhadoresSena();
            Console.WriteLine($"\n\n\nSorteio realizado no dia {Sorteios.DiaAposta.ToString("dd/MM/yyyy")} " +
                $"ás {Sorteios.DiaAposta.ToString("HH:mm")}");
        }
        private void MostrarNumerosSorteados()
        {
            if (Sorteios != null && Sorteios.NumerosSorteados != null)
            {
                Console.WriteLine($"NUMEROS SORTEADOS DA {Nome.ToUpper()}");
                Console.WriteLine(string.Join(" ", Sorteios.NumerosSorteados));
                Console.WriteLine();
            }
        }
        public void RegistrarApostador(Apostador apostador)
        {
            Apostadores.Add(apostador);
            apostador.AdmApostas = this;
        }
        public void RegistrarSorteio(Sorteio sorteio)
        {
            Sorteios = sorteio;
            sorteio.Administrador = this;
        }
        private void GanhadoresQuadra()
        {
            Console.WriteLine($"\nGANHADORES DA QUADRA!\n");
            foreach (var apostadores in Quadra)
            {
                int tamanho = apostadores.Nome.Length;
                string linha = new string('-', tamanho);
                Console.WriteLine(linha);
                Console.WriteLine(apostadores.Nome);
                Console.WriteLine(linha);
            }

        }
        private void GanhadoresQuina()
        {
            Console.WriteLine($"\nGANHADORES DA QUINA!\n");
            foreach (var apostadores in Quina)
            {
                int tamanho = apostadores.Nome.Length;
                string linha = new string('-', tamanho);
                Console.WriteLine(linha);
                Console.WriteLine(apostadores.Nome);
                Console.WriteLine(linha);
            }
        }
        private void GanhadoresSena()
        {

            Console.WriteLine($"\nGANHADORES DA SENA!\n");
            foreach (var apostadores in Sena)
            {
                int tamanho = apostadores.Nome.Length;
                string linha = new string('-', tamanho);
                Console.WriteLine(linha);
                Console.WriteLine(apostadores.Nome);
                Console.WriteLine(linha);
            }

        }
    }
}
