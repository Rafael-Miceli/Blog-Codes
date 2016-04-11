using Escola.Domain.Model;

namespace Escola.Domain.Interfaces
{
    public interface IPoloRepo
    {
        Polo BuscarPoloSelecionado(int poloSelecionadoId);
    }
}
