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

        public Materia BuscarMateriaPorNome(string nomeMateria)
        {
            return _materiaRepo.BuscarMateriaPorNome(nomeMateria);
        }

        public IEnumerable<Materia> BuscarMaterias()
        {
            return _materiaRepo.BuscarMaterias();
        }

        public IEnumerable<Materia> BuscarMateriasSelecionadas(IEnumerable<int> materiasSelecionadasId)
        {
            return _materiaRepo.BuscarMateriasSelecionadas(materiasSelecionadasId);
        }

        public void CriarNovaMateria(Materia materia)
        {
            if (BuscarMateriaPorNome(materia.Nome) != null)
                throw new Exception("Matéria com esse nome já existe");

            _materiaRepo.CadastrarMateria(materia);
        }
    }
}
