using System.Collections.Generic;
using Escola.Domain.Model;

namespace Escola.Domain.Interfaces
{
    public interface IMateriaRepo
    {
        IEnumerable<Materia> BuscarMateriasSelecionadas(IEnumerable<int> materiasSelecionadasId);
    }
}