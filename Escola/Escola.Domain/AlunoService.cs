using System;
using System.Collections.Generic;
using Escola.Domain.Interfaces;
using Escola.Domain.Model;

namespace Escola.Domain
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepo _alunoRepo;

        public AlunoService(IAlunoRepo alunoRepo)
        {
            _alunoRepo = alunoRepo;
        }

        public Aluno BuscarPorMatricula(string matricula)
        {
            return _alunoRepo.BuscarPorMatricula(matricula);
        }

        public void CriarAluno(Aluno aluno, Polo polo, IEnumerable<Materia> materias)
        {
            aluno.Polo = polo;
            aluno.MateriasCursando = materias;

            _alunoRepo.CadastrarAluno(aluno);
        }
    }
}
