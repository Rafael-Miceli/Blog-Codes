using System.Collections.Generic;
using Escola.Domain.Model;

namespace Escola.Domain.Interfaces
{
    public interface IMateriaService
    {
        IEnumerable<Materia> BuscarMateriasSelecionadas(IEnumerable<int> materiasSelecionadasId);
        void CriarNovaMateria(Materia materia);
        Materia BuscarMateriaPorNome(string nomeMateria);
        IEnumerable<Materia> BuscarMaterias();
    }
}
