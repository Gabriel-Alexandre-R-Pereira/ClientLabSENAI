using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientLab.Interfaces;

namespace ClientLab.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Caminho { get; private set; } = "Database/PessoaFisica.csv";

        public override float CalcularImposto(float Rendimento)
        {
            float Imposto = 0;

            if (Rendimento <= 1500)
            {

                return Imposto;

            }
            else if ((Rendimento > 1500) && (Rendimento <= 3500))
            {

                Imposto = (Rendimento / 100) * 2;
                return Imposto;

            }
            else if ((Rendimento > 3500) && (Rendimento <= 6000))
            {

                Imposto = (Rendimento / 100) * 3.5f;
                return Imposto;

            }
            else
            {

                Imposto = (Rendimento / 100) * 5;
                return Imposto;

            }
        }

        public bool ValidarMaioridade(DateTime DataNascimento)
        {

            DateTime DataAtual = DateTime.Today;

            double Idade = (DataAtual - DataNascimento).TotalDays / 365;

            if (Idade >= 18)
            {

                return true;

            }

            return false;
        }

        public bool ValidarMaioridade(string DataNascimento)
        {
            if (DateTime.TryParse(DataNascimento, out DateTime DataConvertida))
            {

                DateTime DataAtual = DateTime.Today;

                double Idade = (DataAtual - DataConvertida).TotalDays / 365;

                // Console.WriteLine(Idade);

                if (Idade >= 18)
                {

                    return true;

                }

                return false;

            }

            return false;

        }

        public void Inserir(PessoaFisica PF)
        {

            Utilitarios.VerificarPastaArquivo(Caminho);

            string[] PFString = { $"{PF.Nome},{PF.CPF},{PF.DataNascimento},{PF.Endereco.Logradouro},{PF.Endereco.Numero},{PF.Endereco.Complemento},{PF.Endereco.EnderecoComercial},{PF.Rendimento}" };

            File.AppendAllLines(Caminho, PFString);

            string Caminhotxt = $"Database/{PF.Nome}.txt";

            Utilitarios.VerificarPastaArquivo(Caminhotxt);

            File.AppendAllLines(Caminhotxt, PFString);

        }

        public List<PessoaFisica> LerAquivo()
        {

            List<PessoaFisica> ListaPF = new List<PessoaFisica>();

            string [] Linhas = File.ReadAllLines(Caminho);

            foreach (string CadaLinha in Linhas)
            {

                string [] Atributos = CadaLinha.Split(",");

                PessoaFisica CadaPF = new PessoaFisica();
                Endereco EnderecoCadaPF = new Endereco();
                CadaPF.Endereco = EnderecoCadaPF;

                CadaPF.Nome = Atributos[0];
                CadaPF.CPF = Atributos[1];
                CadaPF.DataNascimento = DateTime.Parse(Atributos[2]);
                EnderecoCadaPF.Logradouro = Atributos[3];
                EnderecoCadaPF.Numero = Atributos[4];
                EnderecoCadaPF.Complemento = Atributos[5];
                EnderecoCadaPF.EnderecoComercial = bool.Parse(Atributos[6]);
                CadaPF.Rendimento = float.Parse(Atributos[7]);

                ListaPF.Add(CadaPF);

            }

            return ListaPF;

        }

    }

}