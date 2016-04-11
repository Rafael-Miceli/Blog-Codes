using Escola.Domain.Model;
using System.Collections.Generic;

namespace Escola.Domain.Interfaces
{
    public interface IAlunoService
    {
        Aluno BuscarPorMatricula(string matricula);
        void CriarAluno(Aluno aluno, Polo polo, IEnumerable<Materia> materias);
    }
}
