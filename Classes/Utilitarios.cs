using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLab.Classes
{
    public static class Utilitarios
    {

        public static void BarraDeCarregamento(string Mensagem)
        {

            Console.WriteLine($"{Mensagem}");

            Console.BackgroundColor = ConsoleColor.Blue;
            for (var contador = 0; contador < 10; contador++)
            {

                Console.Write("     ");
                Thread.Sleep(500);

            }
            Console.ResetColor();
            Console.Clear();

        }

        public static void VerificarPastaArquivo(string Caminho)
        {

            string pasta = Caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {

                Directory.CreateDirectory(pasta);

            }

            if (!File.Exists(Caminho))
            {

                using (File.Create(Caminho)) { }

            }

        }

    }

}