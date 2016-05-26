using System.Collections.Generic;

namespace Escola
{
    public interface IMateriaService
    {
        List<Materia> BuscarMateriaisSelecionados(List<int> materiasIds);
    }
}