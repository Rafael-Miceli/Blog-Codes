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

        public AlunoService(IAlunoRepo alunoRepo)
        {
            _alunoRepo = alunoRepo;
        }

        public void AdcionarAluno(Aluno aluno)
        {
            if (MatriculaDoAlunoJaExiste(aluno.Matricula))
                throw new Exception("Matricula do aluno já existe");

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
