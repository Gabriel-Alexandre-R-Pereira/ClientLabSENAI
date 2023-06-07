using ClientLab.Classes;



// =============== Variáveis e Listas de Objetos utilizadas no sistema ===============

string? Opcao;
string? OpcaoPF;
string? OpcaoPJ;

// ========== Instanciamento da NovaPF e EnderecoNovaPF. Atribuiçãp de EnderecoNovaPF ao Endereco de NovaPF ==========

PessoaFisica NovaPF = new PessoaFisica();
Endereco EnderecoNovaPF = new Endereco();
NovaPF.Endereco = EnderecoNovaPF;

// ========== Instanciamento da NovaPJ e EnderecoNovaPJ. Atribuiçãp de EnderecoNovaPJ ao Endereco de NovaPJ ==========

PessoaJuridica NovaPJ = new PessoaJuridica();
Endereco EnderecoNovaPJ = new Endereco();
NovaPJ.Endereco = EnderecoNovaPJ;


List<PessoaFisica> ListaPessoaFisica = NovaPF.LerAquivo();
List<PessoaJuridica> ListaPessoaJuridica = NovaPJ.LerAquivo();



// =============== Uso do Console ===============

Utilitarios.BarraDeCarregamento("Inicializando Sistema");

Console.WriteLine(@$"
                    =============================================
                    |           Bem Vindo à ClientLab           |
                    |                                           |
                    |        Sistema de de Cadastro para        |
                    |        Pessoas Físicas e Jurídicas        |
                    =============================================");

Thread.Sleep(3000);
Console.Clear();

do
{
    Console.WriteLine(@$"
                        =============================================
                        |       Esculha uma das opções abaixo       |
                        |          de acordo com o número e         |
                        |        pressione Enter para continuar     |
                        =============================================
                        |                                           |
                        |           [1] Pessoa Física               |
                        |           [2] Pessoa Jurídica             |
                        |                                           |
                        |           [0] Sair                        |
                        |                                           |
                        =============================================");

    Opcao = Console.ReadLine();

    switch (Opcao)
    {
        case "1":

            do
            {

                Console.Clear();

                Console.WriteLine(@$"
                    =============================================
                    |       Esculha uma das opções abaixo       |
                    |          de acordo com o número e         |
                    |        pressione Enter para continuar     |
                    =============================================
                    |                                           |
                    |        [1] Cadastrar Pessoa Física        |
                    |        [2] Listar Pessoas Física          |
                    |                                           |
                    |        [0] Voltar                         |
                    |                                           |
                    =============================================");

                OpcaoPF = Console.ReadLine();

                switch (OpcaoPF)
                {
                    case "1":

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Nome da Pessoa Física, depois pressione Enter ==========");
                        NovaPF.Nome = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o CPF da Pessoa Física, depois pressione Enter ==========");
                        NovaPF.CPF = Console.ReadLine();

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Logradouro do Endereço da Pessoa Física, depois pressione Enter ==========");
                        EnderecoNovaPF.Logradouro = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o Número do Endereço da Pessoa Física, depois pressione Enter ==========");
                        EnderecoNovaPF.Numero = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o Complemento do Endereço da Pessoa Física, depois pressione Enter ==========");
                        EnderecoNovaPF.Complemento = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Endereço Comercial? (Digite [true] para sim - Digite [false] para não), depois pressione Enter ==========");
                        string? EntradaEnderecoComercial = Console.ReadLine();
                        bool.TryParse(EntradaEnderecoComercial, out bool EnderecoComercialConvertido);
                        EnderecoNovaPF.EnderecoComercial = EnderecoComercialConvertido;

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Data de Nascimento da Pessoa Física, depois pressione Enter ==========");
                        string? EntradaDataNascimento = Console.ReadLine();
                        DateTime.TryParse(EntradaDataNascimento, out DateTime DataNascimentoConvertida);
                        NovaPF.DataNascimento = DataNascimentoConvertida;

                        Console.Clear();
                        Console.WriteLine("========== Digite o Rendimento da Pessoa Física, depois pressione Enter ==========");
                        string? EntradaRendimento = Console.ReadLine();
                        float.TryParse(EntradaRendimento, out float RendimentoConvertido);
                        NovaPF.Rendimento = RendimentoConvertido;

                        // ============================================================

                        ListaPessoaFisica.Add(NovaPF);
                        NovaPF.Inserir(NovaPF);

                        // ============================================================

                        Console.WriteLine("Pessoa Física cadastrada com Sucesso, Pressione Enter para continuar");
                        Console.ReadLine();
                        break;

                    case "2":

                        Console.Clear();



                        if (ListaPessoaFisica.Count > 0)
                        {

                            foreach (PessoaFisica CadaPessoaFisica in ListaPessoaFisica)
                            {

                                Console.WriteLine(@$"
                                ============================================================

                                Nome: {CadaPessoaFisica.Nome}
                                CPF: {CadaPessoaFisica.CPF}

                                ===== Endereço =====

                                Logradouro: {CadaPessoaFisica.Endereco.Logradouro}
                                Número: {CadaPessoaFisica.Endereco.Numero}
                                Complemento: {CadaPessoaFisica.Endereco.Complemento}
                                Endereço Comercial: {(CadaPessoaFisica.Endereco.EnderecoComercial ? "Sim" : "Não")}

                                Data de Nascimento: {CadaPessoaFisica.DataNascimento}
                                Validação de Maioridade: {(CadaPessoaFisica.ValidarMaioridade(CadaPessoaFisica.DataNascimento) ? "Maioridade" : "Menoridade")}

                                Rendimento: {CadaPessoaFisica.Rendimento.ToString("C")}
                                Imposto a pagar: {CadaPessoaFisica.CalcularImposto(CadaPessoaFisica.Rendimento).ToString("C")}

                                ============================================================

                                Pressione Enter para continuar");

                                Console.ReadLine();

                            }

                            Console.Clear();
                            Console.WriteLine("Listagen Finalizada Pressione Enter para continuar");
                            Console.ReadLine();

                        }
                        else
                        {

                            Console.WriteLine("Não há Pessoas Físicas cadastradas.");

                        }
                        break;

                    case "0":

                        Console.WriteLine("Voltar ao menú anterior (Pressione Enter)");
                        Console.ReadLine();
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção Inválida! Por favpr, digite uma das opções disponíveis");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }

            } while (OpcaoPF != "0");

            Console.Clear();
            break;

        case "2":

            do
            {

                Console.Clear();

                Console.WriteLine(@$"
                    =============================================
                    |       Esculha uma das opções abaixo       |
                    |          de acordo com o número e         |
                    |        pressione Enter para continuar     |
                    =============================================
                    |                                           |
                    |        [1] Cadastrar Pessoa Jurídica      |
                    |        [2] Listar Pessoa Jurídica         |
                    |                                           |
                    |        [0] Voltar                         |
                    |                                           |
                    =============================================");

                OpcaoPJ = Console.ReadLine();

                switch (OpcaoPJ)
                {
                    case "1":

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Nome da Pessoa Jurídica, depois pressione Enter ==========");
                        NovaPJ.Nome = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite a Razão Social da Empresa, depois pressione Enter ==========");
                        NovaPJ.RazaoSocial = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o CNPJ da Empresa, depois pressione Enter ==========");
                        NovaPJ.CNPJ = Console.ReadLine();

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Logradouro do Endereço da Pessoa Jurídica, depois pressione Enter ==========");
                        EnderecoNovaPJ.Logradouro = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o Número do Endereço da Pessoa Jurídica, depois pressione Enter ==========");
                        EnderecoNovaPJ.Numero = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Digite o Complemento do Endereço da Pessoa Jurídica, depois pressione Enter ==========");
                        EnderecoNovaPJ.Complemento = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("========== Endereço Comercial? (Digite [true] para sim - Digite [false] para não), depois pressione Enter ==========");
                        string? EntradaEnderecoComercial = Console.ReadLine();
                        bool.TryParse(EntradaEnderecoComercial, out bool EnderecoComercialConvertido);
                        EnderecoNovaPJ.EnderecoComercial = EnderecoComercialConvertido;

                        // ============================================================

                        Console.Clear();
                        Console.WriteLine("========== Digite o Rendimento da Pessoa Jurídica, depois pressione Enter ==========");
                        string? EntradaRendimento = Console.ReadLine();
                        float.TryParse(EntradaRendimento, out float RendimentoConvertido);
                        NovaPJ.Rendimento = RendimentoConvertido;

                        // ============================================================

                        NovaPJ.Inserir(NovaPJ);

                        // ============================================================

                        Console.WriteLine("Pessoa Jurídica cadastrada com Sucesso, Pressione Enter para continuar");
                        Console.ReadLine();
                        break;

                    case "2":

                        Console.Clear();

                        if (ListaPessoaJuridica.Count > 0)
                        {

                            foreach (PessoaJuridica CadaPessoaJuridica in ListaPessoaJuridica)
                            {
                                Console.WriteLine(@$"
                                ============================================================

                                Nome: {CadaPessoaJuridica.Nome}
                                Razão Social: {CadaPessoaJuridica.RazaoSocial}
                                CNPJ: {CadaPessoaJuridica.CNPJ}
                                Validação de CNPJ: {(CadaPessoaJuridica.ValidarCNPJ(CadaPessoaJuridica.CNPJ) ? "CNPJ Válido" : "CNPJ Inválido")}

                                ===== Endereço =====

                                Logradouro: {CadaPessoaJuridica.Endereco.Logradouro}
                                Número: {CadaPessoaJuridica.Endereco.Numero}
                                Complemento: {CadaPessoaJuridica.Endereco.Complemento}
                                Endereço Comercial: {(CadaPessoaJuridica.Endereco.EnderecoComercial ? "Sim" : "Não")}

                                Rendimento: {CadaPessoaJuridica.Rendimento.ToString("C")}
                                Imposto a pagar: {CadaPessoaJuridica.CalcularImposto(CadaPessoaJuridica.Rendimento).ToString("C")}

                                ============================================================

                                Pressione Enter para continuar");

                                Console.ReadLine();

                            }

                            Console.Clear();
                            Console.WriteLine("Listagen Finalizada Pressione Enter para continuar");
                            Console.ReadLine();

                        }
                        else
                        {

                            Console.WriteLine("Não há Pessoas Físicas cadastradas.");

                        }
                        break;

                    case "0":

                        Console.WriteLine("Voltar ao menú anterior (Pressione Enter)");
                        Console.ReadLine();
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção Inválida! Por favpr, digite uma das opções disponíveis");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }

            } while (OpcaoPJ != "0");

            Console.Clear();
            break;

        case "0":

            Utilitarios.BarraDeCarregamento("Encerrando Sistema");
            break;

        default:

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção Inválida! Por favpr, digite uma das opções disponíveis");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
            break;
    }

} while (Opcao != "0");



// =============== Método para gravar em arquivos as informações escritas no console ===============

// using (StreamWriter sw = new StreamWriter($"{NovaPF.Nome}.txt"))
// {

//     sw.WriteLine(NovaPF.Nome);

// }




// // =============== Criação de Objetos GabrielPF da classe PessoaFisica e EnderecoGabrielPF da classe Endereco ===============

// PessoaFisica GabrielPF = new PessoaFisica();
// Endereco EnderecoGabrielPF = new Endereco();

// // ===== Atributos =====

// GabrielPF.Nome = "Gabriel";
// GabrielPF.Rendimento = 3700.56f;

// EnderecoGabrielPF.Logradouro = "Rua Ser ou Não Ser";
// EnderecoGabrielPF.Numero = "9999999";
// EnderecoGabrielPF.Complemento = "Apartamento 1111111";
// EnderecoGabrielPF.EnderecoComercial = false;

// GabrielPF.Endereco = EnderecoGabrielPF;

// GabrielPF.CPF = "12345678910";
// GabrielPF.DataNascimento = new DateTime (1996, 9, 13);

// // ===== Métodos =====

// float ImpostoGabrielPF = GabrielPF.CalcularImposto(GabrielPF.Rendimento);
// bool ValidacaoMairidadeGabrielPF = GabrielPF.ValidarMaioridade(GabrielPF.DataNascimento);



// // =============== Uso do Console com Tratamento para GabrielPF ===============

// Console.WriteLine(@$"
// ============================================================

// Nome: {GabrielPF.Nome}
// CPF: {GabrielPF.CPF}

// ===== Endereço =====

// Logradouro: {EnderecoGabrielPF.Logradouro}
// Número: {EnderecoGabrielPF.Numero}
// Complemento: {EnderecoGabrielPF.Complemento}
// Endereço Comercial: {(EnderecoGabrielPF.EnderecoComercial ? "Sim" : "Não")}

// Data de Nascimento: {GabrielPF.DataNascimento}
// Validação de Maioridade: {(ValidacaoMairidadeGabrielPF ? "Maioridade" : "Menoridade")}

// Rendimento: {GabrielPF.Rendimento.ToString("C")}
// Imposto a pagar: {ImpostoGabrielPF.ToString("C")}

// ============================================================

// Pressione qualquer tecla para continuar");

// Console.ReadLine();




// // =============== Criação de Objeto AlexandrePJ da classe PessoaJuridica e EnderecoAlexandrePJ da classe Endereco ===============

// PessoaJuridica AlexandrePJ = new PessoaJuridica();
// Endereco EnderecoAlexandrePJ = new Endereco();

// // ===== Atributos =====

// AlexandrePJ.Nome = "Alexandre";
// AlexandrePJ.Rendimento = 7300.76f;

// EnderecoAlexandrePJ.Logradouro = "Rua Eis a Questão";
// EnderecoAlexandrePJ.Numero = "8888888";
// EnderecoAlexandrePJ.Complemento = "Apartamento 2222222";
// EnderecoAlexandrePJ.EnderecoComercial = true;

// AlexandrePJ.Endereco = EnderecoAlexandrePJ;

// AlexandrePJ.CNPJ = "12345678000191";
// AlexandrePJ.RazaoSocial = "Só Sei que Nada Sei Indústrias Ltda.";



// // =============== Uso do Console com Tratamento para AlexandrePJ ===============

// Console.WriteLine(@$"
// ============================================================

// Nome: {AlexandrePJ.Nome}
// Razão Social: {AlexandrePJ.RazaoSocial}
// CNPJ: {AlexandrePJ.CNPJ}
// Validação de CNPJ: {(AlexandrePJ.ValidarCNPJ(AlexandrePJ.CNPJ) ? "CNPJ Válido" : "CNPJ Inválido")}

// ===== Endereço =====

// Logradouro: {EnderecoAlexandrePJ.Logradouro}
// Número: {EnderecoAlexandrePJ.Numero}
// Complemento: {EnderecoAlexandrePJ.Complemento}
// Endereço Comercial: {(EnderecoAlexandrePJ.EnderecoComercial ? "Sim" : "Não")}

// Rendimento: {AlexandrePJ.Rendimento.ToString("C")}
// Imposto a pagar: {AlexandrePJ.CalcularImposto(AlexandrePJ.Rendimento).ToString("C")}

// ============================================================

// Pressione qualquer tecla para continuar");

// Console.ReadLine();



// // =============== Uso do Console para GabrielPF ===============

// // ===== Atributos =====

// Console.WriteLine("Nome: " + GabrielPF.Nome);
// Console.WriteLine($"Rendimento: {GabrielPF.Rendimento}");
// Console.WriteLine($"Endereço: {GabrielPF.Endereco}");
// Console.WriteLine($"CPF: {GabrielPF.CPF}");
// Console.WriteLine($"Data de Nascimento: {GabrielPF.DataNascimento}");

// // ===== Métodos =====

// Console.WriteLine($"Validação de Maioridade: {ValidacaoMairidadeGabrielPF}");
// Console.WriteLine($"Imposto a pagar: {ImpostoGabrielPF.ToString("C")}");



// // =============== Uso do Console para AlexandrePJ ===============

// // ===== Atributos =====

// Console.WriteLine ($"Nome: {AlexandrePJ.Nome}");
// Console.WriteLine($"Rendimento: {AlexandrePJ.Rendimento}");
// Console.WriteLine($"Endereço: {AlexandrePJ.Endereco}");
// Console.WriteLine($"CNPJ: {AlexandrePJ.CNPJ}");
// Console.WriteLine($"Razão Social: {AlexandrePJ.RazaoSocial}");

// // ===== Métodos =====

// Console.WriteLine($"Validação de CNPJ: {AlexandrePJ.ValidarCNPJ(AlexandrePJ.CNPJ)}");
// Console.WriteLine($"Imposto a pagar: {AlexandrePJ.CalcularImposto(AlexandrePJ.Rendimento).ToString("C")}");



// =============== Testes Extras ===============

// PessoaFisica TestePF = new PessoaFisica();
// PessoaJuridica TestePJ = new PessoaJuridica();

// ===== Testes de outras formas de usar e formatar o valor apresentado do método CalcularImposto(): =====

// Console.WriteLine($"Imposto a pagar: R${ImpostoGabrielPF}");
// Console.WriteLine($"Imposto a pagar: R${ImpostoGabrielPF:0.00}");

// Console.WriteLine($"Imposto a pagar: R${AlexandrePJ.CalcularImposto(AlexandrePJ.Rendimento)}");
// Console.WriteLine($"Imposto a pagar: R${AlexandrePJ.CalcularImposto(AlexandrePJ.Rendimento):0.00}");

// ===== Testes do método ValidarMaioridade() com valores irregulares: =====

// Console.WriteLine($" Maioridade Separado por /: {TestePF.ValidarMaioridade("09/09/1999")}");
// Console.WriteLine($" Maioridade Separado por -: {TestePF.ValidarMaioridade("09-09-1999")}");
// Console.WriteLine($" Maioridade Separado por ,: {TestePF.ValidarMaioridade("09,09,1999")}");
// Console.WriteLine($" Maioridade Separado por espaço: {TestePF.ValidarMaioridade("09 09 1999")}");
// Console.WriteLine($" Maioridade Separado por |: {TestePF.ValidarMaioridade("09|09|1999")}");
// Console.WriteLine($" Maioridade Separado por | e /: {TestePF.ValidarMaioridade("09|09/1999")}");
// Console.WriteLine($" Maioridade Separado por , e espaço: {TestePF.ValidarMaioridade("09,09 1999")}");
// Console.WriteLine($" Maioridade Separado por - e /: {TestePF.ValidarMaioridade("09-09/1999")}");
// Console.WriteLine($" Maioridade Não Separado: {TestePF.ValidarMaioridade("09-09-1999")}");

// Console.WriteLine($" Menoridade Separado por /: {TestePF.ValidarMaioridade("09/09/2009")}");
// Console.WriteLine($" Menoridade Separado por -: {TestePF.ValidarMaioridade("09-09-2009")}");
// Console.WriteLine($" Menoridade Separado por ,: {TestePF.ValidarMaioridade("09,09,2009")}");
// Console.WriteLine($" Menoridade Separado por espaço: {TestePF.ValidarMaioridade("09 09 2009")}");
// Console.WriteLine($" Menoridade Separado por |: {TestePF.ValidarMaioridade("09|09|2009")}");
// Console.WriteLine($" Menoridade Separado por | e /: {TestePF.ValidarMaioridade("09|09/2009")}");
// Console.WriteLine($" Menoridade Separado por , e espaço: {TestePF.ValidarMaioridade("09,09 2009")}");
// Console.WriteLine($" Menoridade Separado por - e /: {TestePF.ValidarMaioridade("09-09/2009")}");
// Console.WriteLine($" Menoridade Não Separado: {TestePF.ValidarMaioridade("09-09-2009")}");