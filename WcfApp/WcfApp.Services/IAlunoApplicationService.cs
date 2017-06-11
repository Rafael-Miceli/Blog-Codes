using System.Collections.Generic;

namespace WcfApp.Services
{
    public interface IAlunoApplicationService
    {
        IEnumerable<string> BuscarNomesDosAlunos();
    }

    public class AlunoApplicationService : IAlunoApplicationService
    {
        public IEnumerable<string> BuscarNomesDosAlunos()
        {
            return new List<string> { "Aluno1", "Aluno2" };
        }
    }
}
