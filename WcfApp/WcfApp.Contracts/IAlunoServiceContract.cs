using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfApp.Contracts
{
    [ServiceContract]
    public interface IAlunoServiceContract
    {
        [OperationContract]
        IEnumerable<string> BuscarNomesDosAlunos();
    }
}
