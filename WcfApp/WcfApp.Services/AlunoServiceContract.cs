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
        IAlunoApplicationService _alunoApplicationService;

        public AlunoService(IAlunoApplicationService alunoApplicationService)
        {
            _alunoApplicationService = alunoApplicationService;
        }

        public IEnumerable<string> BuscarNomesDosAlunos()
        {
            return _alunoApplicationService.BuscarNomesDosAlunos();
        }
    }
}
