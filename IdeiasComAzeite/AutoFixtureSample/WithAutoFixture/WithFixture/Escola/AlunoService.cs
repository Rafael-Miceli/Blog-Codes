using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class AlunoService
    {
        private IAlunoRepo _alunoRepo;
        private IMateriaService _materiaService;

        public AlunoService(IAlunoRepo alunoRepo, IMateriaService materiaService)
        {
            _alunoRepo = alunoRepo;
            _materiaService = materiaService;
        }

        public void AdcionarAluno(Aluno aluno, List<int> materiasIds)
        {
            if (MatriculaDoAlunoJaExiste(aluno.Matricula))
                throw new Exception("Matricula do aluno já existe");
            if (materiasIds == null || materiasIds.Count == 0)
                throw new Exception("Aluno não selecionou matéria");

            aluno.Materias = _materiaService.BuscarMateriaisSelecionados(materiasIds);

            //Adicionado no banco
            _alunoRepo.CriarAluno(aluno);
        }

        private bool MatriculaDoAlunoJaExiste(string matricula)
        {
            //verifica se matricula existe no banco
            return _alunoRepo.ExisteMatricula(matricula);
        }
    }
}
