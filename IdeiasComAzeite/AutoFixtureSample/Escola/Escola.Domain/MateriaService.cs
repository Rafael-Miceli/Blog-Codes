
using System;
using System.Collections.Generic;
using Escola.Domain.Interfaces;
using Escola.Domain.Model;

namespace Escola.Domain
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepo _materiaRepo;

        public MateriaService(IMateriaRepo materiaRepo)
        {
            _materiaRepo = materiaRepo;
        }

        public IEnumerable<Materia> BuscarMateriasSelecionadas(IEnumerable<int> materiasSelecionadasId)
        {
            return _materiaRepo.BuscarMateriasSelecionadas(materiasSelecionadasId);
        }
    }
}
