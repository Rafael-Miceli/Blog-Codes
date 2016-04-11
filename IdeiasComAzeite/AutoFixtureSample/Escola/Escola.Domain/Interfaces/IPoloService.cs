using Escola.Domain.Model;

namespace Escola.Domain.Interfaces
{
    public interface IPoloService
    {
        Polo BuscarPoloSelecionado(int poloSelecionadoId);
    }
}
