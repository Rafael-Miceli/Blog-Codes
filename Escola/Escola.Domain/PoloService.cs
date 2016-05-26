using System;
using Escola.Domain.Interfaces;
using Escola.Domain.Model;

namespace Escola.Domain
{
    public class PoloService : IPoloService
    {
        private IPoloRepo _poloRepo;

        public PoloService(IPoloRepo poloRepo)
        {
            _poloRepo = poloRepo;
        }

        public Polo BuscarPoloSelecionado(int poloSelecionadoId)
        {
            return _poloRepo.BuscarPoloSelecionado(poloSelecionadoId);
        }
    }
}
