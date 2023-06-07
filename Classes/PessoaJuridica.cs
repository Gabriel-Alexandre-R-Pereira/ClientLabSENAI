using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClientLab.Interfaces;

namespace ClientLab.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? CNPJ { get; set; }

        public string? RazaoSocial { get; set; }

        public string Caminho { get; private set; } = "Database/PessoaJuridica.csv";

        public override float CalcularImposto(float Rendimento)
        {
            if (Rendimento <= 3000)
            {

                return Rendimento * 0.03f;

            }
            else if (Rendimento <= 6000)
            {

                return Rendimento * 0.05f;

            }
            else if (Rendimento <= 10000)
            {

                return Rendimento * 0.07f;

            }
            else
            {

                return Rendimento * 0.09f;
            }
        }

        public bool ValidarCNPJ(string CNPJ)
        {

            if (Regex.IsMatch(CNPJ, @"^\d{14}$"))
            {

                string SubstringCNPJ14Caracteres = CNPJ.Substring(8, 4);

                if (SubstringCNPJ14Caracteres == "0001")
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }
            else if (Regex.IsMatch(CNPJ, @"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$"))
            {

                string SubstringCNPJ18Caracteres = CNPJ.Substring(11, 4);

                if (SubstringCNPJ18Caracteres == "0001")
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }
            else
            {

                return false;

            }

        }

        public void Inserir(PessoaJuridica PJ)
        {

            Utilitarios.VerificarPastaArquivo(Caminho);

            string[] PJString = { $"{PJ.Nome},{PJ.CNPJ},{PJ.RazaoSocial},{PJ.Endereco.Logradouro},{PJ.Endereco.Numero},{PJ.Endereco.Complemento},{PJ.Endereco.EnderecoComercial},{PJ.Rendimento}" };

            File.AppendAllLines(Caminho, PJString);

            string Caminhotxt = $"Database/{PJ.Nome}.txt";

            Utilitarios.VerificarPastaArquivo(Caminhotxt);

            File.AppendAllLines(Caminhotxt, PJString);

        }

        public List<PessoaJuridica> LerAquivo()
        {

            List<PessoaJuridica> ListaPJ = new List<PessoaJuridica>();

            string[] Linhas = File.ReadAllLines(Caminho);

            foreach (string CadaLinha in Linhas)
            {

                string[] Atributos = CadaLinha.Split(",");

                PessoaJuridica CadaPJ = new PessoaJuridica();
                Endereco EnderecoCadaPJ = new Endereco();
                CadaPJ.Endereco = EnderecoCadaPJ;

                CadaPJ.Nome = Atributos[0];
                CadaPJ.CNPJ = Atributos[1];
                CadaPJ.RazaoSocial = Atributos[2];
                EnderecoCadaPJ.Logradouro = Atributos[3];
                EnderecoCadaPJ.Numero = Atributos[4];
                EnderecoCadaPJ.Complemento = Atributos[5];
                EnderecoCadaPJ.EnderecoComercial = bool.Parse(Atributos[6]);
                CadaPJ.Rendimento = float.Parse(Atributos[7]);

                ListaPJ.Add(CadaPJ);

            }

            return ListaPJ;

        }

    }

}