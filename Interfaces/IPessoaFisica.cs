using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLab.Interfaces
{

    public interface IPessoaFisica
    {

        bool ValidarMaioridade(DateTime DataNascimento);

    }

}