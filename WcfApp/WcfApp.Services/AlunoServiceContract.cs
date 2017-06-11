using System.Collections.Generic;
using System.ServiceModel;
using WcfApp.Contracts;

namespace WcfApp.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AlunoService : IAlunoServiceContract
    {
        IAlunoRepoToAnyDb _alunoRepoToAnyDb;

        public AlunoService(IAlunoRepoToAnyDb alunoRepoToAnyDb)
        {
            _alunoRepoToAnyDb = alunoRepoToAnyDb;
        }

        public IEnumerable<string> BuscarNomesDosAlunos()
        {
            return new List<string> { _alunoRepoToAnyDb.GetAlunos() };
        }
    }
}
