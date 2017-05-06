using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfApp.Contracts;

namespace WcfApp.Services
{
    public class AlunoService : IAlunoServiceContract
    {
        public IEnumerable<string> BuscarNomesDosAlunos()
        {
            return new List<string> { "Aluno1", "Aluno2" };
        }
    }
}
